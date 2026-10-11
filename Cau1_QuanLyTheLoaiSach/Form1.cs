using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Cau1_QuanLyTheLoaiSach.Models;

namespace Cau1_QuanLyTheLoaiSach
{
    public partial class Form1 : Form
    {
        private AppDbContext _context;

        public Form1()
        {
            InitializeComponent();
            _context = new AppDbContext();
            this.Load += Form1_Load;
        }

        private async void Form1_Load(object? sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync(string? searchKeyword = null)
        {
            try
            {
                var query = _context.TheLoaiSaches.AsNoTracking().AsQueryable();

                if (!string.IsNullOrWhiteSpace(searchKeyword))
                {
                    query = query.Where(tl => tl.TenTheLoai.Contains(searchKeyword));
                }

                var list = await query.OrderByDescending(x => x.MaTl).ToListAsync();

                dgvDanhSach.DataSource = list;

                // Cấu hình hiển thị tiêu đề và độ rộng cột DataGridView
                if (dgvDanhSach.Columns["MaTl"] != null)
                {
                    dgvDanhSach.Columns["MaTl"].HeaderText = "Mã";
                    dgvDanhSach.Columns["MaTl"].FillWeight = 50;
                }
                if (dgvDanhSach.Columns["TenTheLoai"] != null)
                {
                    dgvDanhSach.Columns["TenTheLoai"].HeaderText = "Tên thể loại";
                    dgvDanhSach.Columns["TenTheLoai"].FillWeight = 140;
                }
                if (dgvDanhSach.Columns["SoLuongSach"] != null)
                {
                    dgvDanhSach.Columns["SoLuongSach"].HeaderText = "Số lượng";
                    dgvDanhSach.Columns["SoLuongSach"].FillWeight = 70;
                }
                if (dgvDanhSach.Columns["NgayTao"] != null)
                {
                    dgvDanhSach.Columns["NgayTao"].HeaderText = "Ngày tạo";
                    dgvDanhSach.Columns["NgayTao"].FillWeight = 90;
                }
                if (dgvDanhSach.Columns["MoTa"] != null)
                {
                    dgvDanhSach.Columns["MoTa"].HeaderText = "Mô tả";
                    dgvDanhSach.Columns["MoTa"].FillWeight = 150;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSach_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvDanhSach.CurrentRow != null && dgvDanhSach.CurrentRow.DataBoundItem is TheLoaiSach selected)
            {
                txtMaTL.Text = selected.MaTl.ToString();
                txtTenTheLoai.Text = selected.TenTheLoai;
                numSoLuongSach.Value = selected.SoLuongSach ?? 0;
                lblNgayTaoValue.Text = selected.NgayTao.HasValue ? selected.NgayTao.Value.ToString("dd/MM/yyyy HH:mm") : "---";
                txtMoTa.Text = selected.MoTa ?? string.Empty;
            }
        }

        private void ClearInputs()
        {
            txtMaTL.Clear();
            txtTenTheLoai.Clear();
            numSoLuongSach.Value = 0;
            lblNgayTaoValue.Text = "---";
            txtMoTa.Clear();
            dgvDanhSach.ClearSelection();
        }

        private void btnLamMoi_Click(object? sender, EventArgs e)
        {
            ClearInputs();
        }

        private async void btnThem_Click(object? sender, EventArgs e)
        {
            string tenTL = txtTenTheLoai.Text.Trim();
            if (string.IsNullOrEmpty(tenTL))
            {
                MessageBox.Show("Vui lòng nhập tên thể loại sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTheLoai.Focus();
                return;
            }

            // Kiểm tra trùng tên
            bool isDuplicate = await _context.TheLoaiSaches.AnyAsync(x => x.TenTheLoai.ToLower() == tenTL.ToLower());
            if (isDuplicate)
            {
                MessageBox.Show("Tên thể loại sách này đã tồn tại trong hệ thống. Vui lòng chọn tên khác!", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTheLoai.Focus();
                return;
            }

            try
            {
                var newTL = new TheLoaiSach
                {
                    TenTheLoai = tenTL,
                    MoTa = string.IsNullOrWhiteSpace(txtMoTa.Text) ? null : txtMoTa.Text.Trim(),
                    SoLuongSach = (int)numSoLuongSach.Value,
                    NgayTao = DateTime.Now
                };

                _context.TheLoaiSaches.Add(newTL);
                await _context.SaveChangesAsync();

                MessageBox.Show("Thêm thể loại sách thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm mới: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSua_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtMaTL.Text, out int maTL))
            {
                MessageBox.Show("Vui lòng chọn thể loại cần cập nhật từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenTL = txtTenTheLoai.Text.Trim();
            if (string.IsNullOrEmpty(tenTL))
            {
                MessageBox.Show("Tên thể loại sách không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTheLoai.Focus();
                return;
            }

            // Kiểm tra trùng tên với bản ghi khác
            bool isDuplicate = await _context.TheLoaiSaches.AnyAsync(x => x.MaTl != maTL && x.TenTheLoai.ToLower() == tenTL.ToLower());
            if (isDuplicate)
            {
                MessageBox.Show("Tên thể loại sách này đã được sử dụng bởi mã khác!", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTheLoai.Focus();
                return;
            }

            try
            {
                var existing = await _context.TheLoaiSaches.FindAsync(maTL);
                if (existing == null)
                {
                    MessageBox.Show("Không tìm thấy thể loại sách này trong CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                existing.TenTheLoai = tenTL;
                existing.MoTa = string.IsNullOrWhiteSpace(txtMoTa.Text) ? null : txtMoTa.Text.Trim();
                existing.SoLuongSach = (int)numSoLuongSach.Value;

                await _context.SaveChangesAsync();
                MessageBox.Show("Cập nhật thông tin thể loại sách thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoa_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtMaTL.Text, out int maTL))
            {
                MessageBox.Show("Vui lòng chọn thể loại cần xóa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa thể loại '{txtTenTheLoai.Text}' (Mã: {maTL}) không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                var existing = await _context.TheLoaiSaches.FindAsync(maTL);
                if (existing != null)
                {
                    _context.TheLoaiSaches.Remove(existing);
                    await _context.SaveChangesAsync();
                    MessageBox.Show("Xóa thể loại thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    await LoadDataAsync();
                }
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("Không thể xóa thể loại này vì đang có các đầu sách hoặc bảng khác tham chiếu đến!", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnTimKiem_Click(object? sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            await LoadDataAsync(keyword);
        }

        private async void btnHienTatCa_Click(object? sender, EventArgs e)
        {
            txtTimKiem.Clear();
            await LoadDataAsync();
        }

        private void txtTimKiem_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
