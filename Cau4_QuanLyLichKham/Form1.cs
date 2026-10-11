using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Cau4_QuanLyLichKham.Models;

namespace Cau4_QuanLyLichKham
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
            // Thiết lập giá trị mặc định cho ngày lọc
            dtpTuNgay.Value = DateTime.Today.AddDays(-7);
            dtpDenNgay.Value = DateTime.Today.AddDays(14);
            dtpNgayKham.Value = DateTime.Today;

            await LoadBacSiComboBoxesAsync();
            await LoadLichKhamDataAsync();
        }

        private async Task LoadBacSiComboBoxesAsync()
        {
            try
            {
                var bsList = await _context.BacSis.AsNoTracking().ToListAsync();

                var displayList = bsList.Select(b => new
                {
                    b.MaBs,
                    DisplayName = $"BS. {b.HoTen} - {b.ChuyenKhoa}"
                }).ToList();

                // ComboBox chọn bác sĩ
                cboBacSi.DataSource = displayList;
                cboBacSi.DisplayMember = "DisplayName";
                cboBacSi.ValueMember = "MaBs";

                // ComboBox lọc
                var filterList = displayList.ToList();
                filterList.Insert(0, new { MaBs = 0, DisplayName = "Tất cả bác sĩ" });
                cboLocBacSi.DataSource = filterList;
                cboLocBacSi.DisplayMember = "DisplayName";
                cboLocBacSi.ValueMember = "MaBs";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách bác sĩ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadLichKhamDataAsync(DateTime? tuNgay = null, DateTime? denNgay = null, int maBsFilter = 0)
        {
            try
            {
                // LINQ Include (Eager Loading)
                var query = _context.LichKhams
                    .Include(l => l.MaBsNavigation)
                    .AsNoTracking()
                    .AsQueryable();

                if (tuNgay.HasValue)
                {
                    var dTu = DateOnly.FromDateTime(tuNgay.Value);
                    query = query.Where(l => l.NgayKham >= dTu);
                }

                if (denNgay.HasValue)
                {
                    var dDen = DateOnly.FromDateTime(denNgay.Value);
                    query = query.Where(l => l.NgayKham <= dDen);
                }

                if (maBsFilter > 0)
                {
                    query = query.Where(l => l.MaBs == maBsFilter);
                }

                var list = await query
                    .OrderBy(l => l.NgayKham)
                    .ThenBy(l => l.GioKham)
                    .ToListAsync();

                var displayList = list.Select(l => new
                {
                    l.MaLich,
                    l.TenBenhNhan,
                    l.Sdt,
                    NgayKham = l.NgayKham.ToString("dd/MM/yyyy"),
                    l.GioKham,
                    TenBacSi = l.MaBsNavigation != null ? l.MaBsNavigation.HoTen : "---",
                    ChuyenKhoa = l.MaBsNavigation != null ? l.MaBsNavigation.ChuyenKhoa : "---",
                    l.TrangThai,
                    l.MaBs,
                    RawNgayKham = l.NgayKham
                }).ToList();

                dgvLichKham.DataSource = displayList;

                // Ẩn cột bổ trợ
                if (dgvLichKham.Columns["MaBs"] != null)
                    dgvLichKham.Columns["MaBs"].Visible = false;
                if (dgvLichKham.Columns["RawNgayKham"] != null)
                    dgvLichKham.Columns["RawNgayKham"].Visible = false;

                // Cấu hình tiêu đề và độ rộng từng cột
                if (dgvLichKham.Columns["MaLich"] != null)
                {
                    dgvLichKham.Columns["MaLich"].HeaderText = "Mã";
                    dgvLichKham.Columns["MaLich"].FillWeight = 45;
                }
                if (dgvLichKham.Columns["TenBenhNhan"] != null)
                {
                    dgvLichKham.Columns["TenBenhNhan"].HeaderText = "Tên bệnh nhân";
                    dgvLichKham.Columns["TenBenhNhan"].FillWeight = 120;
                }
                if (dgvLichKham.Columns["Sdt"] != null)
                {
                    dgvLichKham.Columns["Sdt"].HeaderText = "Số ĐT";
                    dgvLichKham.Columns["Sdt"].FillWeight = 85;
                }
                if (dgvLichKham.Columns["NgayKham"] != null)
                {
                    dgvLichKham.Columns["NgayKham"].HeaderText = "Ngày khám";
                    dgvLichKham.Columns["NgayKham"].FillWeight = 85;
                }
                if (dgvLichKham.Columns["GioKham"] != null)
                {
                    dgvLichKham.Columns["GioKham"].HeaderText = "Giờ khám";
                    dgvLichKham.Columns["GioKham"].FillWeight = 70;
                }
                if (dgvLichKham.Columns["TenBacSi"] != null)
                {
                    dgvLichKham.Columns["TenBacSi"].HeaderText = "Bác sĩ";
                    dgvLichKham.Columns["TenBacSi"].FillWeight = 110;
                }
                if (dgvLichKham.Columns["ChuyenKhoa"] != null)
                {
                    dgvLichKham.Columns["ChuyenKhoa"].HeaderText = "Chuyên khoa";
                    dgvLichKham.Columns["ChuyenKhoa"].FillWeight = 105;
                }
                if (dgvLichKham.Columns["TrangThai"] != null)
                {
                    dgvLichKham.Columns["TrangThai"].HeaderText = "Trạng thái";
                    dgvLichKham.Columns["TrangThai"].FillWeight = 80;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải lịch khám: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLichKham_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvLichKham.CurrentRow != null)
            {
                var row = dgvLichKham.CurrentRow;
                txtMaLich.Text = row.Cells["MaLich"].Value?.ToString() ?? "";
                txtTenBenhNhan.Text = row.Cells["TenBenhNhan"].Value?.ToString() ?? "";
                txtSDT.Text = row.Cells["Sdt"].Value?.ToString() ?? "";

                if (row.Cells["RawNgayKham"].Value is DateOnly d)
                {
                    dtpNgayKham.Value = new DateTime(d.Year, d.Month, d.Day);
                }

                string gioKhamStr = row.Cells["GioKham"].Value?.ToString() ?? "08:00";
                if (TimeSpan.TryParse(gioKhamStr, out TimeSpan ts))
                {
                    dtpGioKham.Value = DateTime.Today.Add(ts);
                }

                if (row.Cells["MaBs"].Value is int maBs)
                {
                    cboBacSi.SelectedValue = maBs;
                }

                cboTrangThai.SelectedItem = row.Cells["TrangThai"].Value?.ToString() ?? "Chờ khám";
            }
        }

        private bool ValidateInputs()
        {
            // 1. Kiểm tra Tên bệnh nhân
            if (string.IsNullOrWhiteSpace(txtTenBenhNhan.Text))
            {
                MessageBox.Show("Tên bệnh nhân không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenBenhNhan.Focus();
                return false;
            }

            // 2. Kiểm tra SĐT
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }

            // 3. Chưa chọn bác sĩ
            if (cboBacSi.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn bác sĩ phụ trách!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboBacSi.Focus();
                return false;
            }

            // 4. Validate không cho đặt ngày trong quá khứ
            if (dtpNgayKham.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Không thể đặt lịch khám vào ngày trong quá khứ!", "Ngày không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayKham.Focus();
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            txtMaLich.Clear();
            txtTenBenhNhan.Clear();
            txtSDT.Clear();
            dtpNgayKham.Value = DateTime.Today;
            dtpGioKham.Value = DateTime.Today.AddHours(8);
            cboTrangThai.SelectedIndex = 0;
            dgvLichKham.ClearSelection();
        }

        private void btnLamMoi_Click(object? sender, EventArgs e)
        {
            ClearInputs();
        }

        private async void btnThem_Click(object? sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                var lk = new LichKham
                {
                    TenBenhNhan = txtTenBenhNhan.Text.Trim(),
                    Sdt = txtSDT.Text.Trim(),
                    NgayKham = DateOnly.FromDateTime(dtpNgayKham.Value),
                    GioKham = dtpGioKham.Value.ToString("HH:mm"),
                    MaBs = (int)cboBacSi.SelectedValue!,
                    TrangThai = cboTrangThai.SelectedItem?.ToString() ?? "Chờ khám"
                };

                _context.LichKhams.Add(lk);
                await _context.SaveChangesAsync();

                MessageBox.Show("Đặt lịch khám thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                await LoadLichKhamDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSua_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtMaLich.Text, out int maLich))
            {
                MessageBox.Show("Vui lòng chọn lịch khám cần cập nhật từ danh sách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInputs()) return;

            try
            {
                var existing = await _context.LichKhams.FindAsync(maLich);
                if (existing != null)
                {
                    existing.TenBenhNhan = txtTenBenhNhan.Text.Trim();
                    existing.Sdt = txtSDT.Text.Trim();
                    existing.NgayKham = DateOnly.FromDateTime(dtpNgayKham.Value);
                    existing.GioKham = dtpGioKham.Value.ToString("HH:mm");
                    existing.MaBs = (int)cboBacSi.SelectedValue!;
                    existing.TrangThai = cboTrangThai.SelectedItem?.ToString() ?? "Chờ khám";

                    await _context.SaveChangesAsync();
                    MessageBox.Show("Cập nhật thông tin lịch khám thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadLichKhamDataAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi sửa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoa_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtMaLich.Text, out int maLich))
            {
                MessageBox.Show("Vui lòng chọn lịch khám cần xóa từ danh sách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn hủy/xóa lịch hẹn của bệnh nhân '{txtTenBenhNhan.Text}'?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                var existing = await _context.LichKhams.FindAsync(maLich);
                if (existing != null)
                {
                    _context.LichKhams.Remove(existing);
                    await _context.SaveChangesAsync();
                    MessageBox.Show("Xóa lịch khám thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    await LoadLichKhamDataAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnTimKiem_Click(object? sender, EventArgs e)
        {
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show("Khoảng ngày lọc không hợp lệ (Từ ngày phải nhỏ hơn hoặc bằng Đến ngày)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maBs = (int)(cboLocBacSi.SelectedValue ?? 0);
            await LoadLichKhamDataAsync(dtpTuNgay.Value, dtpDenNgay.Value, maBs);
        }

        private async void btnTatCa_Click(object? sender, EventArgs e)
        {
            cboLocBacSi.SelectedIndex = 0;
            dtpTuNgay.Value = DateTime.Today.AddDays(-30);
            dtpDenNgay.Value = DateTime.Today.AddDays(30);
            await LoadLichKhamDataAsync();
        }

        private async void btnQuanLyBacSi_Click(object? sender, EventArgs e)
        {
            using (var frm = new FormBacSi())
            {
                frm.ShowDialog();
            }
            // Refresh lại danh sách bác sĩ trong ComboBox
            _context = new AppDbContext();
            await LoadBacSiComboBoxesAsync();
            await LoadLichKhamDataAsync();
        }
    }
}
