using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Cau3_QuanLyPhong.Models;

namespace Cau3_QuanLyPhong
{
    public partial class Form1 : Form
    {
        private AppDbContext _context;
        private string? _selectedImageFileName = null;
        private readonly string _imagesDirectory;

        public Form1()
        {
            InitializeComponent();
            _context = new AppDbContext();
            _imagesDirectory = Path.Combine(Application.StartupPath, "Images");
            if (!Directory.Exists(_imagesDirectory))
            {
                Directory.CreateDirectory(_imagesDirectory);
            }
            this.Load += Form1_Load;
        }

        private async void Form1_Load(object? sender, EventArgs e)
        {
            await LoadLoaiPhongComboBoxesAsync();
            await LoadPhongDataAsync();
        }

        private async Task LoadLoaiPhongComboBoxesAsync()
        {
            try
            {
                var loaiList = await _context.LoaiPhongs.AsNoTracking().OrderBy(l => l.TenLoai).ToListAsync();

                // ComboBox nhập liệu
                cboLoaiPhong.DataSource = loaiList;
                cboLoaiPhong.DisplayMember = "TenLoai";
                cboLoaiPhong.ValueMember = "MaLoai";

                // ComboBox bộ lọc
                var filterList = loaiList.ToList();
                filterList.Insert(0, new LoaiPhong { MaLoai = 0, TenLoai = "Tất cả loại phòng" });
                cboLocLoai.DataSource = filterList;
                cboLocLoai.DisplayMember = "TenLoai";
                cboLocLoai.ValueMember = "MaLoai";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh mục loại phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Image? LoadImageSafe(string? fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName)) return null;

            string fullPath = Path.Combine(_imagesDirectory, fileName);
            if (!File.Exists(fullPath)) return null;

            try
            {
                using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                {
                    return Image.FromStream(stream);
                }
            }
            catch
            {
                return null;
            }
        }

        private async Task LoadPhongDataAsync(int maLoaiFilter = 0, string? tinhTrangFilter = null)
        {
            try
            {
                // LINQ Include (Eager Loading)
                var query = _context.Phongs
                    .Include(p => p.MaLoaiNavigation)
                    .AsNoTracking()
                    .AsQueryable();

                if (maLoaiFilter > 0)
                {
                    query = query.Where(p => p.MaLoai == maLoaiFilter);
                }

                if (!string.IsNullOrWhiteSpace(tinhTrangFilter) && tinhTrangFilter != "Tất cả")
                {
                    query = query.Where(p => p.TinhTrang == tinhTrangFilter);
                }

                var list = await query.OrderByDescending(p => p.MaPhong).ToListAsync();

                var displayList = list.Select(p => new
                {
                    p.MaPhong,
                    p.SoPhong,
                    p.TangSo,
                    TenLoaiPhong = p.MaLoaiNavigation != null ? p.MaLoaiNavigation.TenLoai : "---",
                    p.TinhTrang,
                    HinhAnhThumbnail = LoadImageSafe(p.HinhAnh),
                    p.HinhAnh,
                    p.MaLoai
                }).ToList();

                dgvPhong.DataSource = displayList;

                // Ẩn các cột bổ trợ
                if (dgvPhong.Columns["MaLoai"] != null)
                    dgvPhong.Columns["MaLoai"].Visible = false;
                if (dgvPhong.Columns["HinhAnh"] != null)
                    dgvPhong.Columns["HinhAnh"].Visible = false;

                // Cấu hình tiêu đề và độ rộng từng cột
                if (dgvPhong.Columns["MaPhong"] != null)
                {
                    dgvPhong.Columns["MaPhong"].HeaderText = "Mã";
                    dgvPhong.Columns["MaPhong"].FillWeight = 45;
                }
                if (dgvPhong.Columns["SoPhong"] != null)
                {
                    dgvPhong.Columns["SoPhong"].HeaderText = "Số phòng";
                    dgvPhong.Columns["SoPhong"].FillWeight = 85;
                }
                if (dgvPhong.Columns["TangSo"] != null)
                {
                    dgvPhong.Columns["TangSo"].HeaderText = "Tầng";
                    dgvPhong.Columns["TangSo"].FillWeight = 55;
                }
                if (dgvPhong.Columns["TenLoaiPhong"] != null)
                {
                    dgvPhong.Columns["TenLoaiPhong"].HeaderText = "Loại phòng";
                    dgvPhong.Columns["TenLoaiPhong"].FillWeight = 140;
                }
                if (dgvPhong.Columns["TinhTrang"] != null)
                {
                    dgvPhong.Columns["TinhTrang"].HeaderText = "Tình trạng";
                    dgvPhong.Columns["TinhTrang"].FillWeight = 90;
                }

                // Cấu hình cột hình ảnh thumbnail
                if (dgvPhong.Columns["HinhAnhThumbnail"] is DataGridViewImageColumn imgCol)
                {
                    imgCol.HeaderText = "Hình ảnh";
                    imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    imgCol.FillWeight = 100;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi nạp dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPhong_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvPhong.CurrentRow != null)
            {
                var row = dgvPhong.CurrentRow;
                txtMaPhong.Text = row.Cells["MaPhong"].Value?.ToString() ?? "";
                txtSoPhong.Text = row.Cells["SoPhong"].Value?.ToString() ?? "";
                numTangSo.Value = Convert.ToDecimal(row.Cells["TangSo"].Value ?? 1);

                if (row.Cells["MaLoai"].Value is int maLoai)
                {
                    cboLoaiPhong.SelectedValue = maLoai;
                }

                cboTinhTrang.SelectedItem = row.Cells["TinhTrang"].Value?.ToString() ?? "Trống";

                string? imgFile = row.Cells["HinhAnh"].Value?.ToString();
                _selectedImageFileName = imgFile;
                lblTenFileAnh.Text = string.IsNullOrEmpty(imgFile) ? "Không có ảnh" : imgFile;

                if (picHinhAnh.Image != null)
                {
                    picHinhAnh.Image.Dispose();
                    picHinhAnh.Image = null;
                }
                picHinhAnh.Image = LoadImageSafe(imgFile);
            }
        }

        private void btnChonAnh_Click(object? sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Chọn hình ảnh phòng";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string ext = Path.GetExtension(ofd.FileName);
                        string newFileName = $"room_{DateTime.Now:yyyyMMdd_HHmmss}_{Guid.NewGuid().ToString().Substring(0, 5)}{ext}";
                        string destPath = Path.Combine(_imagesDirectory, newFileName);

                        // Copy ảnh vào thư mục Images của ứng dụng
                        File.Copy(ofd.FileName, destPath, true);

                        _selectedImageFileName = newFileName;
                        lblTenFileAnh.Text = newFileName;

                        if (picHinhAnh.Image != null)
                        {
                            picHinhAnh.Image.Dispose();
                            picHinhAnh.Image = null;
                        }
                        picHinhAnh.Image = LoadImageSafe(newFileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi upload ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ClearInputs()
        {
            txtMaPhong.Clear();
            txtSoPhong.Clear();
            numTangSo.Value = 1;
            cboTinhTrang.SelectedIndex = 0;
            _selectedImageFileName = null;
            lblTenFileAnh.Text = "Chưa chọn ảnh";
            if (picHinhAnh.Image != null)
            {
                picHinhAnh.Image.Dispose();
                picHinhAnh.Image = null;
            }
            dgvPhong.ClearSelection();
        }

        private void btnLamMoi_Click(object? sender, EventArgs e)
        {
            ClearInputs();
        }

        private async void btnThem_Click(object? sender, EventArgs e)
        {
            string soPhong = txtSoPhong.Text.Trim();
            if (string.IsNullOrEmpty(soPhong))
            {
                MessageBox.Show("Số phòng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoPhong.Focus();
                return;
            }

            if (cboLoaiPhong.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn loại phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra trùng số phòng
            bool isExists = await _context.Phongs.AnyAsync(p => p.SoPhong.ToLower() == soPhong.ToLower());
            if (isExists)
            {
                MessageBox.Show("Số phòng này đã tồn tại trên hệ thống!", "Trùng số phòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoPhong.Focus();
                return;
            }

            try
            {
                var p = new Phong
                {
                    SoPhong = soPhong,
                    TangSo = (int)numTangSo.Value,
                    MaLoai = (int)cboLoaiPhong.SelectedValue,
                    TinhTrang = cboTinhTrang.SelectedItem?.ToString() ?? "Trống",
                    HinhAnh = _selectedImageFileName
                };

                _context.Phongs.Add(p);
                await _context.SaveChangesAsync();

                MessageBox.Show("Thêm mới phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                await LoadPhongDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSua_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtMaPhong.Text, out int maPhong))
            {
                MessageBox.Show("Vui lòng chọn phòng cần sửa từ danh sách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string soPhong = txtSoPhong.Text.Trim();
            if (string.IsNullOrEmpty(soPhong))
            {
                MessageBox.Show("Số phòng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isExists = await _context.Phongs.AnyAsync(p => p.MaPhong != maPhong && p.SoPhong.ToLower() == soPhong.ToLower());
            if (isExists)
            {
                MessageBox.Show("Số phòng này bị trùng với phòng khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var existing = await _context.Phongs.FindAsync(maPhong);
                if (existing != null)
                {
                    existing.SoPhong = soPhong;
                    existing.TangSo = (int)numTangSo.Value;
                    existing.MaLoai = (int)cboLoaiPhong.SelectedValue!;
                    existing.TinhTrang = cboTinhTrang.SelectedItem?.ToString() ?? "Trống";
                    existing.HinhAnh = _selectedImageFileName;

                    await _context.SaveChangesAsync();
                    MessageBox.Show("Cập nhật thông tin phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadPhongDataAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoa_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtMaPhong.Text, out int maPhong))
            {
                MessageBox.Show("Vui lòng chọn phòng cần xóa từ danh sách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc muốn xóa phòng số '{txtSoPhong.Text}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                var existing = await _context.Phongs.FindAsync(maPhong);
                if (existing != null)
                {
                    _context.Phongs.Remove(existing);
                    await _context.SaveChangesAsync();
                    MessageBox.Show("Xóa phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    await LoadPhongDataAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnTimKiem_Click(object? sender, EventArgs e)
        {
            int maLoai = (int)(cboLocLoai.SelectedValue ?? 0);
            string tinhTrang = cboLocTinhTrang.SelectedItem?.ToString() ?? "Tất cả";
            await LoadPhongDataAsync(maLoai, tinhTrang);
        }

        private async void btnTatCa_Click(object? sender, EventArgs e)
        {
            cboLocLoai.SelectedIndex = 0;
            cboLocTinhTrang.SelectedIndex = 0;
            await LoadPhongDataAsync();
        }

        private async void btnQuanLyLoaiPhong_Click(object? sender, EventArgs e)
        {
            using (var frm = new FormLoaiPhong())
            {
                frm.ShowDialog();
            }
            // Sau khi đóng form Loại phòng thì refresh lại cboLoaiPhong
            _context = new AppDbContext();
            await LoadLoaiPhongComboBoxesAsync();
            await LoadPhongDataAsync();
        }
    }
}
