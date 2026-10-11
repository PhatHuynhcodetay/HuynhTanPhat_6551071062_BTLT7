using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Cau4_QuanLyLichKham.Models;

namespace Cau4_QuanLyLichKham
{
    public partial class FormBacSi : Form
    {
        private AppDbContext _context;

        public FormBacSi()
        {
            InitializeComponent();
            _context = new AppDbContext();
            this.Load += FormBacSi_Load;
        }

        private async void FormBacSi_Load(object? sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var list = await _context.BacSis.AsNoTracking().ToListAsync();
                dgvBacSi.DataSource = list;

                if (dgvBacSi.Columns["LichKhams"] != null)
                    dgvBacSi.Columns["LichKhams"].Visible = false;

                if (dgvBacSi.Columns["MaBs"] != null)
                    dgvBacSi.Columns["MaBs"].HeaderText = "Mã BS";
                if (dgvBacSi.Columns["HoTen"] != null)
                    dgvBacSi.Columns["HoTen"].HeaderText = "Họ và tên";
                if (dgvBacSi.Columns["ChuyenKhoa"] != null)
                    dgvBacSi.Columns["ChuyenKhoa"].HeaderText = "Chuyên khoa";
                if (dgvBacSi.Columns["Sdt"] != null)
                    dgvBacSi.Columns["Sdt"].HeaderText = "Số điện thoại";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh mục bác sĩ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBacSi_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvBacSi.CurrentRow?.DataBoundItem is BacSi selected)
            {
                txtMaBS.Text = selected.MaBs.ToString();
                txtHoTen.Text = selected.HoTen;
                txtChuyenKhoa.Text = selected.ChuyenKhoa;
                txtSDT.Text = selected.Sdt ?? string.Empty;
            }
        }

        private void ClearInputs()
        {
            txtMaBS.Clear();
            txtHoTen.Clear();
            txtChuyenKhoa.Clear();
            txtSDT.Clear();
            dgvBacSi.ClearSelection();
        }

        private void btnLamMoi_Click(object? sender, EventArgs e)
        {
            ClearInputs();
        }

        private async void btnThem_Click(object? sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim();
            string chuyenKhoa = txtChuyenKhoa.Text.Trim();

            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(chuyenKhoa))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ họ tên và chuyên khoa của bác sĩ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var bs = new BacSi
                {
                    HoTen = hoTen,
                    ChuyenKhoa = chuyenKhoa,
                    Sdt = string.IsNullOrWhiteSpace(txtSDT.Text) ? null : txtSDT.Text.Trim()
                };

                _context.BacSis.Add(bs);
                await _context.SaveChangesAsync();

                MessageBox.Show("Thêm bác sĩ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (!int.TryParse(txtMaBS.Text, out int maBS))
            {
                MessageBox.Show("Vui lòng chọn bác sĩ cần cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hoTen = txtHoTen.Text.Trim();
            string chuyenKhoa = txtChuyenKhoa.Text.Trim();

            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(chuyenKhoa))
            {
                MessageBox.Show("Họ tên và chuyên khoa không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var existing = await _context.BacSis.FindAsync(maBS);
                if (existing != null)
                {
                    existing.HoTen = hoTen;
                    existing.ChuyenKhoa = chuyenKhoa;
                    existing.Sdt = string.IsNullOrWhiteSpace(txtSDT.Text) ? null : txtSDT.Text.Trim();

                    await _context.SaveChangesAsync();
                    MessageBox.Show("Cập nhật thông tin bác sĩ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (!int.TryParse(txtMaBS.Text, out int maBS))
            {
                MessageBox.Show("Vui lòng chọn bác sĩ cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc muốn xóa bác sĩ '{txtHoTen.Text}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                var existing = await _context.BacSis.FindAsync(maBS);
                if (existing != null)
                {
                    _context.BacSis.Remove(existing);
                    await _context.SaveChangesAsync();
                    MessageBox.Show("Xóa bác sĩ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    await LoadDataAsync();
                }
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("Không thể xóa bác sĩ này do đang có các lịch hẹn khám bệnh liên kết!", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
