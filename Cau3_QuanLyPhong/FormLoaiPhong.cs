using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Cau3_QuanLyPhong.Models;

namespace Cau3_QuanLyPhong
{
    public partial class FormLoaiPhong : Form
    {
        private AppDbContext _context;

        public FormLoaiPhong()
        {
            InitializeComponent();
            _context = new AppDbContext();
            this.Load += FormLoaiPhong_Load;
        }

        private async void FormLoaiPhong_Load(object? sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var list = await _context.LoaiPhongs.AsNoTracking().ToListAsync();
                dgvLoaiPhong.DataSource = list;

                if (dgvLoaiPhong.Columns["Phongs"] != null)
                    dgvLoaiPhong.Columns["Phongs"].Visible = false;

                if (dgvLoaiPhong.Columns["MaLoai"] != null)
                    dgvLoaiPhong.Columns["MaLoai"].HeaderText = "Mã loại";
                if (dgvLoaiPhong.Columns["TenLoai"] != null)
                    dgvLoaiPhong.Columns["TenLoai"].HeaderText = "Tên loại";
                if (dgvLoaiPhong.Columns["GiaMoiDem"] != null)
                {
                    dgvLoaiPhong.Columns["GiaMoiDem"].HeaderText = "Giá/đêm (VNĐ)";
                    dgvLoaiPhong.Columns["GiaMoiDem"].DefaultCellStyle.Format = "N0";
                }
                if (dgvLoaiPhong.Columns["MoTa"] != null)
                    dgvLoaiPhong.Columns["MoTa"].HeaderText = "Mô tả";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh mục loại phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLoaiPhong_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvLoaiPhong.CurrentRow?.DataBoundItem is LoaiPhong selected)
            {
                txtMaLoai.Text = selected.MaLoai.ToString();
                txtTenLoai.Text = selected.TenLoai;
                numGiaMoiDem.Value = selected.GiaMoiDem;
                txtMoTa.Text = selected.MoTa ?? string.Empty;
            }
        }

        private void ClearInputs()
        {
            txtMaLoai.Clear();
            txtTenLoai.Clear();
            numGiaMoiDem.Value = 100000;
            txtMoTa.Clear();
            dgvLoaiPhong.ClearSelection();
        }

        private void btnLamMoi_Click(object? sender, EventArgs e)
        {
            ClearInputs();
        }

        private async void btnThem_Click(object? sender, EventArgs e)
        {
            string tenLoai = txtTenLoai.Text.Trim();
            if (string.IsNullOrEmpty(tenLoai))
            {
                MessageBox.Show("Vui lòng nhập tên loại phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoai.Focus();
                return;
            }

            try
            {
                var lp = new LoaiPhong
                {
                    TenLoai = tenLoai,
                    GiaMoiDem = numGiaMoiDem.Value,
                    MoTa = string.IsNullOrWhiteSpace(txtMoTa.Text) ? null : txtMoTa.Text.Trim()
                };

                _context.LoaiPhongs.Add(lp);
                await _context.SaveChangesAsync();

                MessageBox.Show("Thêm loại phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSua_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtMaLoai.Text, out int maLoai))
            {
                MessageBox.Show("Vui lòng chọn loại phòng cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenLoai = txtTenLoai.Text.Trim();
            if (string.IsNullOrEmpty(tenLoai))
            {
                MessageBox.Show("Tên loại phòng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var existing = await _context.LoaiPhongs.FindAsync(maLoai);
                if (existing != null)
                {
                    existing.TenLoai = tenLoai;
                    existing.GiaMoiDem = numGiaMoiDem.Value;
                    existing.MoTa = string.IsNullOrWhiteSpace(txtMoTa.Text) ? null : txtMoTa.Text.Trim();

                    await _context.SaveChangesAsync();
                    MessageBox.Show("Cập nhật loại phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoa_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtMaLoai.Text, out int maLoai))
            {
                MessageBox.Show("Vui lòng chọn loại phòng cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc muốn xóa loại phòng '{txtTenLoai.Text}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                var existing = await _context.LoaiPhongs.FindAsync(maLoai);
                if (existing != null)
                {
                    _context.LoaiPhongs.Remove(existing);
                    await _context.SaveChangesAsync();
                    MessageBox.Show("Xóa loại phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    await LoadDataAsync();
                }
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("Không thể xóa loại phòng này vì đang có các phòng thuộc loại này!", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
