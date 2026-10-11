using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Cau2_QuanLyHoiVien.Models;

namespace Cau2_QuanLyHoiVien
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

        private async Task LoadDataAsync(string? hoTen = null, string? hangTV = null)
        {
            try
            {
                var query = _context.HoiViens.AsNoTracking().AsQueryable();

                if (!string.IsNullOrWhiteSpace(hoTen))
                {
                    query = query.Where(h => h.HoTen.Contains(hoTen));
                }

                if (!string.IsNullOrWhiteSpace(hangTV) && hangTV != "Tất cả")
                {
                    query = query.Where(h => h.HangThanhVien == hangTV);
                }

                var list = await query.OrderByDescending(h => h.MaHv).ToListAsync();

                // Dùng projection hiển thị thân thiện trên DataGridView
                var displayList = list.Select(h => new
                {
                    h.MaHv,
                    h.HoTen,
                    GioiTinh = h.GioiTinh ? "Nam" : "Nữ",
                    NgaySinh = h.NgaySinh.ToString("dd/MM/yyyy"),
                    h.Sdt,
                    h.Email,
                    h.HangThanhVien,
                    NgayDangKy = h.NgayDangKy.HasValue ? h.NgayDangKy.Value.ToString("dd/MM/yyyy HH:mm") : "",
                    TrangThai = (h.TrangThai ?? true) ? "Đang hoạt động" : "Tạm ngưng",
                    // Giữ entity gốc để lấy lại khi selection changed
                    RawEntity = h
                }).ToList();

                dgvDanhSach.DataSource = displayList;

                if (dgvDanhSach.Columns["RawEntity"] != null)
                    dgvDanhSach.Columns["RawEntity"].Visible = false;

                if (dgvDanhSach.Columns["MaHv"] != null)
                {
                    dgvDanhSach.Columns["MaHv"].HeaderText = "Mã";
                    dgvDanhSach.Columns["MaHv"].FillWeight = 45;
                }
                if (dgvDanhSach.Columns["HoTen"] != null)
                {
                    dgvDanhSach.Columns["HoTen"].HeaderText = "Họ và tên";
                    dgvDanhSach.Columns["HoTen"].FillWeight = 130;
                }
                if (dgvDanhSach.Columns["GioiTinh"] != null)
                {
                    dgvDanhSach.Columns["GioiTinh"].HeaderText = "Giới tính";
                    dgvDanhSach.Columns["GioiTinh"].FillWeight = 65;
                }
                if (dgvDanhSach.Columns["NgaySinh"] != null)
                {
                    dgvDanhSach.Columns["NgaySinh"].HeaderText = "Ngày sinh";
                    dgvDanhSach.Columns["NgaySinh"].FillWeight = 85;
                }
                if (dgvDanhSach.Columns["Sdt"] != null)
                {
                    dgvDanhSach.Columns["Sdt"].HeaderText = "Số ĐT";
                    dgvDanhSach.Columns["Sdt"].FillWeight = 85;
                }
                if (dgvDanhSach.Columns["Email"] != null)
                {
                    dgvDanhSach.Columns["Email"].HeaderText = "Email";
                    dgvDanhSach.Columns["Email"].FillWeight = 120;
                }
                if (dgvDanhSach.Columns["HangThanhVien"] != null)
                {
                    dgvDanhSach.Columns["HangThanhVien"].HeaderText = "Hạng";
                    dgvDanhSach.Columns["HangThanhVien"].FillWeight = 75;
                }
                if (dgvDanhSach.Columns["NgayDangKy"] != null)
                {
                    dgvDanhSach.Columns["NgayDangKy"].HeaderText = "Ngày ĐK";
                    dgvDanhSach.Columns["NgayDangKy"].FillWeight = 100;
                }
                if (dgvDanhSach.Columns["TrangThai"] != null)
                {
                    dgvDanhSach.Columns["TrangThai"].HeaderText = "Trạng thái";
                    dgvDanhSach.Columns["TrangThai"].FillWeight = 90;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSach_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvDanhSach.CurrentRow != null)
            {
                var rowItem = dgvDanhSach.CurrentRow.DataBoundItem;
                if (rowItem != null)
                {
                    var prop = rowItem.GetType().GetProperty("RawEntity");
                    if (prop?.GetValue(rowItem) is HoiVien selected)
                    {
                        txtMaHV.Text = selected.MaHv.ToString();
                        txtHoTen.Text = selected.HoTen;

                        if (selected.GioiTinh)
                            rdoNam.Checked = true;
                        else
                            rdoNu.Checked = true;

                        dtpNgaySinh.Value = new DateTime(selected.NgaySinh.Year, selected.NgaySinh.Month, selected.NgaySinh.Day);
                        txtSDT.Text = selected.Sdt ?? string.Empty;
                        txtEmail.Text = selected.Email ?? string.Empty;

                        cboHangThanhVien.SelectedItem = selected.HangThanhVien;
                        lblNgayDKValue.Text = selected.NgayDangKy.HasValue ? selected.NgayDangKy.Value.ToString("dd/MM/yyyy HH:mm") : "---";
                        chkTrangThai.Checked = selected.TrangThai ?? true;
                    }
                }
            }
        }

        private bool ValidateFormInputs()
        {
            // 1. Kiểm tra Họ tên
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ và tên hội viên không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            // 2. Validate SĐT (9-11 chữ số)
            string sdt = txtSDT.Text.Trim();
            if (string.IsNullOrWhiteSpace(sdt) || !Regex.IsMatch(sdt, @"^[0-9]{9,11}$"))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa các chữ số và phải có độ dài từ 9 đến 11 ký tự!", "Lỗi SĐT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }

            // 3. Validate Email
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Email không đúng định dạng (phải chứa ký tự '@' và tên miền)!", "Lỗi Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // 4. Validate Tuổi >= 15
            int tuoi = DateTime.Today.Year - dtpNgaySinh.Value.Year;
            if (dtpNgaySinh.Value.Date > DateTime.Today.AddYears(-tuoi)) tuoi--;

            if (tuoi < 15)
            {
                MessageBox.Show($"Hội viên phải từ 15 tuổi trở lên mới được đăng ký tập! (Tuổi hiện tại: {tuoi})", "Lỗi độ tuổi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySinh.Focus();
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            txtMaHV.Clear();
            txtHoTen.Clear();
            rdoNam.Checked = true;
            dtpNgaySinh.Value = DateTime.Today.AddYears(-20);
            txtSDT.Clear();
            txtEmail.Clear();
            cboHangThanhVien.SelectedIndex = 0;
            lblNgayDKValue.Text = "---";
            chkTrangThai.Checked = true;
            dgvDanhSach.ClearSelection();
        }

        private void btnLamMoi_Click(object? sender, EventArgs e)
        {
            ClearInputs();
        }

        private async void btnThem_Click(object? sender, EventArgs e)
        {
            if (!ValidateFormInputs()) return;

            try
            {
                var hv = new HoiVien
                {
                    HoTen = txtHoTen.Text.Trim(),
                    GioiTinh = rdoNam.Checked,
                    NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value),
                    Sdt = txtSDT.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    HangThanhVien = cboHangThanhVien.SelectedItem?.ToString() ?? "Basic",
                    NgayDangKy = DateTime.Now,
                    TrangThai = chkTrangThai.Checked
                };

                _context.HoiViens.Add(hv);
                await _context.SaveChangesAsync();

                MessageBox.Show("Đăng ký thông tin hội viên mới thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm hội viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSua_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtMaHV.Text, out int maHV))
            {
                MessageBox.Show("Vui lòng chọn hội viên cần cập nhật từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateFormInputs()) return;

            try
            {
                var existing = await _context.HoiViens.FindAsync(maHV);
                if (existing == null)
                {
                    MessageBox.Show("Không tìm thấy hội viên này trong CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                existing.HoTen = txtHoTen.Text.Trim();
                existing.GioiTinh = rdoNam.Checked;
                existing.NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value);
                existing.Sdt = txtSDT.Text.Trim();
                existing.Email = txtEmail.Text.Trim();
                existing.HangThanhVien = cboHangThanhVien.SelectedItem?.ToString() ?? "Basic";
                existing.TrangThai = chkTrangThai.Checked;

                await _context.SaveChangesAsync();
                MessageBox.Show("Cập nhật thông tin hội viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoa_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtMaHV.Text, out int maHV))
            {
                MessageBox.Show("Vui lòng chọn hội viên cần xóa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa hội viên '{txtHoTen.Text}' (Mã: {maHV}) không?",
                "Xác nhận xóa hội viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                var existing = await _context.HoiViens.FindAsync(maHV);
                if (existing != null)
                {
                    _context.HoiViens.Remove(existing);
                    await _context.SaveChangesAsync();
                    MessageBox.Show("Đã xóa hội viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    await LoadDataAsync();
                }
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("Không thể xóa hội viên này do có ràng buộc dữ liệu!", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnTimKiem_Click(object? sender, EventArgs e)
        {
            string hoTen = txtTimHoTen.Text.Trim();
            string hangTV = cboLocHang.SelectedItem?.ToString() ?? "Tất cả";
            await LoadDataAsync(hoTen, hangTV);
        }

        private async void btnTatCa_Click(object? sender, EventArgs e)
        {
            txtTimHoTen.Clear();
            cboLocHang.SelectedIndex = 0;
            await LoadDataAsync();
        }
    }
}
