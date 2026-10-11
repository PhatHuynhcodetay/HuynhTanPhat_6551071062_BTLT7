namespace Cau4_QuanLyLichKham
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
            this.Text = "Phòng Khám Đa Khoa An Khang - Quản Lý Lịch Khám Bệnh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            // GroupBox Thông tin lịch khám
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblMaLich = new System.Windows.Forms.Label();
            this.txtMaLich = new System.Windows.Forms.TextBox();
            this.lblTenBenhNhan = new System.Windows.Forms.Label();
            this.txtTenBenhNhan = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblNgayKham = new System.Windows.Forms.Label();
            this.dtpNgayKham = new System.Windows.Forms.DateTimePicker();
            this.lblGioKham = new System.Windows.Forms.Label();
            this.dtpGioKham = new System.Windows.Forms.DateTimePicker();
            this.lblBacSi = new System.Windows.Forms.Label();
            this.cboBacSi = new System.Windows.Forms.ComboBox();
            this.btnQuanLyBacSi = new System.Windows.Forms.Button();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();

            // Buttons CRUD
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();

            // Bộ lọc tìm kiếm
            this.grpTimKiem = new System.Windows.Forms.GroupBox();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.lblLocBacSi = new System.Windows.Forms.Label();
            this.cboLocBacSi = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnTatCa = new System.Windows.Forms.Button();

            // DataGridView
            this.dgvLichKham = new System.Windows.Forms.DataGridView();

            //
            // grpThongTin
            //
            this.grpThongTin.Text = "Thông Tin Đặt Lịch Khám";
            this.grpThongTin.Location = new System.Drawing.Point(15, 15);
            this.grpThongTin.Size = new System.Drawing.Size(430, 645);

            // txtMaLich
            this.lblMaLich.Text = "Mã lịch:";
            this.lblMaLich.Location = new System.Drawing.Point(15, 38);
            this.lblMaLich.Size = new System.Drawing.Size(120, 25);
            this.txtMaLich.Location = new System.Drawing.Point(140, 35);
            this.txtMaLich.Size = new System.Drawing.Size(270, 27);
            this.txtMaLich.ReadOnly = true;

            // txtTenBenhNhan
            this.lblTenBenhNhan.Text = "Tên bệnh nhân (*):";
            this.lblTenBenhNhan.Location = new System.Drawing.Point(15, 78);
            this.lblTenBenhNhan.Size = new System.Drawing.Size(120, 25);
            this.txtTenBenhNhan.Location = new System.Drawing.Point(140, 75);
            this.txtTenBenhNhan.Size = new System.Drawing.Size(270, 27);

            // txtSDT
            this.lblSDT.Text = "Số điện thoại (*):";
            this.lblSDT.Location = new System.Drawing.Point(15, 118);
            this.lblSDT.Size = new System.Drawing.Size(120, 25);
            this.txtSDT.Location = new System.Drawing.Point(140, 115);
            this.txtSDT.Size = new System.Drawing.Size(270, 27);

            // dtpNgayKham
            this.lblNgayKham.Text = "Ngày khám (*):";
            this.lblNgayKham.Location = new System.Drawing.Point(15, 158);
            this.lblNgayKham.Size = new System.Drawing.Size(120, 25);
            this.dtpNgayKham.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayKham.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayKham.Location = new System.Drawing.Point(140, 155);
            this.dtpNgayKham.Size = new System.Drawing.Size(270, 27);

            // dtpGioKham
            this.lblGioKham.Text = "Giờ khám (*):";
            this.lblGioKham.Location = new System.Drawing.Point(15, 198);
            this.lblGioKham.Size = new System.Drawing.Size(120, 25);
            this.dtpGioKham.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpGioKham.CustomFormat = "HH:mm";
            this.dtpGioKham.ShowUpDown = true;
            this.dtpGioKham.Location = new System.Drawing.Point(140, 195);
            this.dtpGioKham.Size = new System.Drawing.Size(270, 27);

            // cboBacSi & btnQuanLyBacSi
            this.lblBacSi.Text = "Bác sĩ (*):";
            this.lblBacSi.Location = new System.Drawing.Point(15, 238);
            this.lblBacSi.Size = new System.Drawing.Size(120, 25);
            this.cboBacSi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBacSi.Location = new System.Drawing.Point(140, 235);
            this.cboBacSi.Size = new System.Drawing.Size(175, 28);

            this.btnQuanLyBacSi.Text = "QL Bác sĩ";
            this.btnQuanLyBacSi.Location = new System.Drawing.Point(320, 234);
            this.btnQuanLyBacSi.Size = new System.Drawing.Size(90, 30);
            this.btnQuanLyBacSi.Click += new System.EventHandler(this.btnQuanLyBacSi_Click);

            // cboTrangThai
            this.lblTrangThai.Text = "Trạng thái:";
            this.lblTrangThai.Location = new System.Drawing.Point(15, 278);
            this.lblTrangThai.Size = new System.Drawing.Size(120, 25);
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.Items.AddRange(new object[] { "Chờ khám", "Đã khám", "Đã hủy" });
            this.cboTrangThai.SelectedIndex = 0;
            this.cboTrangThai.Location = new System.Drawing.Point(140, 275);
            this.cboTrangThai.Size = new System.Drawing.Size(270, 28);

            // Buttons
            this.btnThem.Text = "Thêm mới";
            this.btnThem.Location = new System.Drawing.Point(15, 335);
            this.btnThem.Size = new System.Drawing.Size(92, 36);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua.Text = "Cập nhật";
            this.btnSua.Location = new System.Drawing.Point(117, 335);
            this.btnSua.Size = new System.Drawing.Size(92, 36);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.Text = "Xóa";
            this.btnXoa.Location = new System.Drawing.Point(219, 335);
            this.btnXoa.Size = new System.Drawing.Size(92, 36);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Location = new System.Drawing.Point(321, 335);
            this.btnLamMoi.Size = new System.Drawing.Size(92, 36);
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            this.grpThongTin.Controls.Add(this.lblMaLich);
            this.grpThongTin.Controls.Add(this.txtMaLich);
            this.grpThongTin.Controls.Add(this.lblTenBenhNhan);
            this.grpThongTin.Controls.Add(this.txtTenBenhNhan);
            this.grpThongTin.Controls.Add(this.lblSDT);
            this.grpThongTin.Controls.Add(this.txtSDT);
            this.grpThongTin.Controls.Add(this.lblNgayKham);
            this.grpThongTin.Controls.Add(this.dtpNgayKham);
            this.grpThongTin.Controls.Add(this.lblGioKham);
            this.grpThongTin.Controls.Add(this.dtpGioKham);
            this.grpThongTin.Controls.Add(this.lblBacSi);
            this.grpThongTin.Controls.Add(this.cboBacSi);
            this.grpThongTin.Controls.Add(this.btnQuanLyBacSi);
            this.grpThongTin.Controls.Add(this.lblTrangThai);
            this.grpThongTin.Controls.Add(this.cboTrangThai);
            this.grpThongTin.Controls.Add(this.btnThem);
            this.grpThongTin.Controls.Add(this.btnSua);
            this.grpThongTin.Controls.Add(this.btnXoa);
            this.grpThongTin.Controls.Add(this.btnLamMoi);

            //
            // grpTimKiem
            //
            this.grpTimKiem.Text = "Tìm Kiếm Theo Khoảng Thời Gian & Bác Sĩ";
            this.grpTimKiem.Location = new System.Drawing.Point(460, 15);
            this.grpTimKiem.Size = new System.Drawing.Size(785, 80);

            this.lblTuNgay.Text = "Từ:";
            this.lblTuNgay.Location = new System.Drawing.Point(12, 34);
            this.lblTuNgay.Size = new System.Drawing.Size(28, 20);
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Location = new System.Drawing.Point(42, 30);
            this.dtpTuNgay.Size = new System.Drawing.Size(115, 27);

            this.lblDenNgay.Text = "Đến:";
            this.lblDenNgay.Location = new System.Drawing.Point(165, 34);
            this.lblDenNgay.Size = new System.Drawing.Size(35, 20);
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Location = new System.Drawing.Point(202, 30);
            this.dtpDenNgay.Size = new System.Drawing.Size(115, 27);

            this.lblLocBacSi.Text = "Bác sĩ:";
            this.lblLocBacSi.Location = new System.Drawing.Point(325, 34);
            this.lblLocBacSi.Size = new System.Drawing.Size(48, 20);
            this.cboLocBacSi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocBacSi.Location = new System.Drawing.Point(375, 30);
            this.cboLocBacSi.Size = new System.Drawing.Size(215, 28);

            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Location = new System.Drawing.Point(600, 27);
            this.btnTimKiem.Size = new System.Drawing.Size(85, 33);
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);

            this.btnTatCa.Text = "Tất cả";
            this.btnTatCa.Location = new System.Drawing.Point(692, 27);
            this.btnTatCa.Size = new System.Drawing.Size(78, 33);
            this.btnTatCa.Click += new System.EventHandler(this.btnTatCa_Click);

            this.grpTimKiem.Controls.Add(this.lblTuNgay);
            this.grpTimKiem.Controls.Add(this.dtpTuNgay);
            this.grpTimKiem.Controls.Add(this.lblDenNgay);
            this.grpTimKiem.Controls.Add(this.dtpDenNgay);
            this.grpTimKiem.Controls.Add(this.lblLocBacSi);
            this.grpTimKiem.Controls.Add(this.cboLocBacSi);
            this.grpTimKiem.Controls.Add(this.btnTimKiem);
            this.grpTimKiem.Controls.Add(this.btnTatCa);

            //
            // dgvLichKham
            //
            this.dgvLichKham.Location = new System.Drawing.Point(460, 105);
            this.dgvLichKham.Size = new System.Drawing.Size(785, 555);
            this.dgvLichKham.ReadOnly = true;
            this.dgvLichKham.MultiSelect = false;
            this.dgvLichKham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichKham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichKham.AllowUserToAddRows = false;
            this.dgvLichKham.RowHeadersWidth = 30;
            this.dgvLichKham.SelectionChanged += new System.EventHandler(this.dgvLichKham_SelectionChanged);

            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.grpTimKiem);
            this.Controls.Add(this.dgvLichKham);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblMaLich;
        private System.Windows.Forms.TextBox txtMaLich;
        private System.Windows.Forms.Label lblTenBenhNhan;
        private System.Windows.Forms.TextBox txtTenBenhNhan;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblNgayKham;
        private System.Windows.Forms.DateTimePicker dtpNgayKham;
        private System.Windows.Forms.Label lblGioKham;
        private System.Windows.Forms.DateTimePicker dtpGioKham;
        private System.Windows.Forms.Label lblBacSi;
        private System.Windows.Forms.ComboBox cboBacSi;
        private System.Windows.Forms.Button btnQuanLyBacSi;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;

        private System.Windows.Forms.GroupBox grpTimKiem;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label lblLocBacSi;
        private System.Windows.Forms.ComboBox cboLocBacSi;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnTatCa;

        private System.Windows.Forms.DataGridView dgvLichKham;
    }
}
