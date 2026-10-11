namespace Cau2_QuanLyHoiVien
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1260, 680);
            this.Text = "Phòng Tập Gym FitZone - Quản Lý Hội Viên";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            // GroupBox Thông tin
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblMaHV = new System.Windows.Forms.Label();
            this.txtMaHV = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();

            // GroupBox Giới tính
            this.grpGioiTinh = new System.Windows.Forms.GroupBox();
            this.rdoNam = new System.Windows.Forms.RadioButton();
            this.rdoNu = new System.Windows.Forms.RadioButton();

            // Ngày sinh
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();

            // Hạng thành viên
            this.lblHangTV = new System.Windows.Forms.Label();
            this.cboHangThanhVien = new System.Windows.Forms.ComboBox();

            // Trạng thái & Ngày ĐK
            this.chkTrangThai = new System.Windows.Forms.CheckBox();
            this.lblNgayDK = new System.Windows.Forms.Label();
            this.lblNgayDKValue = new System.Windows.Forms.Label();

            // Buttons CRUD
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();

            // Tìm kiếm
            this.grpTimKiem = new System.Windows.Forms.GroupBox();
            this.lblTimTen = new System.Windows.Forms.Label();
            this.txtTimHoTen = new System.Windows.Forms.TextBox();
            this.lblLocHang = new System.Windows.Forms.Label();
            this.cboLocHang = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnTatCa = new System.Windows.Forms.Button();

            // DataGridView
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();

            // Setup Controls
            this.grpThongTin.Text = "Thông Tin Hội Viên";
            this.grpThongTin.Location = new System.Drawing.Point(15, 15);
            this.grpThongTin.Size = new System.Drawing.Size(430, 645);

            // txtMaHV
            this.lblMaHV.Text = "Mã hội viên:";
            this.lblMaHV.Location = new System.Drawing.Point(15, 38);
            this.lblMaHV.Size = new System.Drawing.Size(120, 25);
            this.txtMaHV.Location = new System.Drawing.Point(140, 35);
            this.txtMaHV.Size = new System.Drawing.Size(270, 27);
            this.txtMaHV.ReadOnly = true;

            // txtHoTen
            this.lblHoTen.Text = "Họ và tên (*):";
            this.lblHoTen.Location = new System.Drawing.Point(15, 78);
            this.lblHoTen.Size = new System.Drawing.Size(120, 25);
            this.txtHoTen.Location = new System.Drawing.Point(140, 75);
            this.txtHoTen.Size = new System.Drawing.Size(270, 27);

            // Giới tính
            this.grpGioiTinh.Text = "Giới tính";
            this.grpGioiTinh.Location = new System.Drawing.Point(15, 115);
            this.grpGioiTinh.Size = new System.Drawing.Size(395, 55);
            this.rdoNam.Text = "Nam";
            this.rdoNam.Location = new System.Drawing.Point(60, 22);
            this.rdoNam.Checked = true;
            this.rdoNam.AutoSize = true;
            this.rdoNu.Text = "Nữ";
            this.rdoNu.Location = new System.Drawing.Point(210, 22);
            this.rdoNu.AutoSize = true;
            this.grpGioiTinh.Controls.Add(this.rdoNam);
            this.grpGioiTinh.Controls.Add(this.rdoNu);

            // Ngày sinh
            this.lblNgaySinh.Text = "Ngày sinh (*):";
            this.lblNgaySinh.Location = new System.Drawing.Point(15, 185);
            this.lblNgaySinh.Size = new System.Drawing.Size(120, 25);
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.Location = new System.Drawing.Point(140, 182);
            this.dtpNgaySinh.Size = new System.Drawing.Size(270, 27);

            // SĐT
            this.lblSDT.Text = "Số điện thoại (*):";
            this.lblSDT.Location = new System.Drawing.Point(15, 225);
            this.lblSDT.Size = new System.Drawing.Size(120, 25);
            this.txtSDT.Location = new System.Drawing.Point(140, 222);
            this.txtSDT.Size = new System.Drawing.Size(270, 27);

            // Email
            this.lblEmail.Text = "Email (*):";
            this.lblEmail.Location = new System.Drawing.Point(15, 265);
            this.lblEmail.Size = new System.Drawing.Size(120, 25);
            this.txtEmail.Location = new System.Drawing.Point(140, 262);
            this.txtEmail.Size = new System.Drawing.Size(270, 27);

            // Hạng TV
            this.lblHangTV.Text = "Hạng thành viên:";
            this.lblHangTV.Location = new System.Drawing.Point(15, 305);
            this.lblHangTV.Size = new System.Drawing.Size(120, 25);
            this.cboHangThanhVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHangThanhVien.Items.AddRange(new object[] { "Basic", "VIP", "Premium" });
            this.cboHangThanhVien.SelectedIndex = 0;
            this.cboHangThanhVien.Location = new System.Drawing.Point(140, 302);
            this.cboHangThanhVien.Size = new System.Drawing.Size(270, 28);

            // Ngày ĐK
            this.lblNgayDK.Text = "Ngày đăng ký:";
            this.lblNgayDK.Location = new System.Drawing.Point(15, 345);
            this.lblNgayDK.Size = new System.Drawing.Size(120, 25);
            this.lblNgayDKValue.Text = "---";
            this.lblNgayDKValue.Location = new System.Drawing.Point(140, 345);
            this.lblNgayDKValue.Size = new System.Drawing.Size(270, 25);

            // CheckBox Trạng thái
            this.chkTrangThai.Text = "Đang hoạt động";
            this.chkTrangThai.Checked = true;
            this.chkTrangThai.Location = new System.Drawing.Point(140, 385);
            this.chkTrangThai.AutoSize = true;

            // Buttons
            this.btnThem.Text = "Thêm mới";
            this.btnThem.Location = new System.Drawing.Point(15, 440);
            this.btnThem.Size = new System.Drawing.Size(92, 36);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua.Text = "Cập nhật";
            this.btnSua.Location = new System.Drawing.Point(117, 440);
            this.btnSua.Size = new System.Drawing.Size(92, 36);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.Text = "Xóa";
            this.btnXoa.Location = new System.Drawing.Point(219, 440);
            this.btnXoa.Size = new System.Drawing.Size(92, 36);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Location = new System.Drawing.Point(321, 440);
            this.btnLamMoi.Size = new System.Drawing.Size(92, 36);
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            this.grpThongTin.Controls.Add(this.lblMaHV);
            this.grpThongTin.Controls.Add(this.txtMaHV);
            this.grpThongTin.Controls.Add(this.lblHoTen);
            this.grpThongTin.Controls.Add(this.txtHoTen);
            this.grpThongTin.Controls.Add(this.grpGioiTinh);
            this.grpThongTin.Controls.Add(this.lblNgaySinh);
            this.grpThongTin.Controls.Add(this.dtpNgaySinh);
            this.grpThongTin.Controls.Add(this.lblSDT);
            this.grpThongTin.Controls.Add(this.txtSDT);
            this.grpThongTin.Controls.Add(this.lblEmail);
            this.grpThongTin.Controls.Add(this.txtEmail);
            this.grpThongTin.Controls.Add(this.lblHangTV);
            this.grpThongTin.Controls.Add(this.cboHangThanhVien);
            this.grpThongTin.Controls.Add(this.lblNgayDK);
            this.grpThongTin.Controls.Add(this.lblNgayDKValue);
            this.grpThongTin.Controls.Add(this.chkTrangThai);
            this.grpThongTin.Controls.Add(this.btnThem);
            this.grpThongTin.Controls.Add(this.btnSua);
            this.grpThongTin.Controls.Add(this.btnXoa);
            this.grpThongTin.Controls.Add(this.btnLamMoi);

            // Tìm kiếm
            this.grpTimKiem.Text = "Tìm Kiếm Hội Viên (Đa Điều Kiện)";
            this.grpTimKiem.Location = new System.Drawing.Point(460, 15);
            this.grpTimKiem.Size = new System.Drawing.Size(785, 80);

            this.lblTimTen.Text = "Họ tên:";
            this.lblTimTen.Location = new System.Drawing.Point(15, 34);
            this.lblTimTen.Size = new System.Drawing.Size(50, 20);
            this.txtTimHoTen.Location = new System.Drawing.Point(70, 30);
            this.txtTimHoTen.Size = new System.Drawing.Size(220, 27);

            this.lblLocHang.Text = "Hạng:";
            this.lblLocHang.Location = new System.Drawing.Point(310, 34);
            this.lblLocHang.Size = new System.Drawing.Size(45, 20);
            this.cboLocHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocHang.Items.AddRange(new object[] { "Tất cả", "Basic", "VIP", "Premium" });
            this.cboLocHang.SelectedIndex = 0;
            this.cboLocHang.Location = new System.Drawing.Point(360, 30);
            this.cboLocHang.Size = new System.Drawing.Size(180, 28);

            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Location = new System.Drawing.Point(565, 27);
            this.btnTimKiem.Size = new System.Drawing.Size(95, 33);
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);

            this.btnTatCa.Text = "Tất cả";
            this.btnTatCa.Location = new System.Drawing.Point(670, 27);
            this.btnTatCa.Size = new System.Drawing.Size(90, 33);
            this.btnTatCa.Click += new System.EventHandler(this.btnTatCa_Click);

            this.grpTimKiem.Controls.Add(this.lblTimTen);
            this.grpTimKiem.Controls.Add(this.txtTimHoTen);
            this.grpTimKiem.Controls.Add(this.lblLocHang);
            this.grpTimKiem.Controls.Add(this.cboLocHang);
            this.grpTimKiem.Controls.Add(this.btnTimKiem);
            this.grpTimKiem.Controls.Add(this.btnTatCa);

            // DataGridView
            this.dgvDanhSach.Location = new System.Drawing.Point(460, 105);
            this.dgvDanhSach.Size = new System.Drawing.Size(785, 555);
            this.dgvDanhSach.ReadOnly = true;
            this.dgvDanhSach.MultiSelect = false;
            this.dgvDanhSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSach.AllowUserToAddRows = false;
            this.dgvDanhSach.RowHeadersWidth = 30;
            this.dgvDanhSach.SelectionChanged += new System.EventHandler(this.dgvDanhSach_SelectionChanged);

            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.grpTimKiem);
            this.Controls.Add(this.dgvDanhSach);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblMaHV;
        private System.Windows.Forms.TextBox txtMaHV;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.GroupBox grpGioiTinh;
        private System.Windows.Forms.RadioButton rdoNam;
        private System.Windows.Forms.RadioButton rdoNu;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblHangTV;
        private System.Windows.Forms.ComboBox cboHangThanhVien;
        private System.Windows.Forms.Label lblNgayDK;
        private System.Windows.Forms.Label lblNgayDKValue;
        private System.Windows.Forms.CheckBox chkTrangThai;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;

        private System.Windows.Forms.GroupBox grpTimKiem;
        private System.Windows.Forms.Label lblTimTen;
        private System.Windows.Forms.TextBox txtTimHoTen;
        private System.Windows.Forms.Label lblLocHang;
        private System.Windows.Forms.ComboBox cboLocHang;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnTatCa;

        private System.Windows.Forms.DataGridView dgvDanhSach;
    }
}
