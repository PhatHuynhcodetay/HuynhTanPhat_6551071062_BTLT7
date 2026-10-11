namespace Cau1_QuanLyTheLoaiSach
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
            this.ClientSize = new System.Drawing.Size(1080, 600);
            this.Text = "Nhà Sách Tri Thức Books - Quản Lý Thể Loại Sách";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            // GroupBox Thông tin chi tiết
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblMaTL = new System.Windows.Forms.Label();
            this.txtMaTL = new System.Windows.Forms.TextBox();
            this.lblTenTheLoai = new System.Windows.Forms.Label();
            this.txtTenTheLoai = new System.Windows.Forms.TextBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.numSoLuongSach = new System.Windows.Forms.NumericUpDown();
            this.lblNgayTao = new System.Windows.Forms.Label();
            this.lblNgayTaoValue = new System.Windows.Forms.Label();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();

            // Các Buttons
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();

            // Tìm kiếm
            this.grpTimKiem = new System.Windows.Forms.GroupBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnHienTatCa = new System.Windows.Forms.Button();

            // DataGridView
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();

            //
            // grpThongTin
            //
            this.grpThongTin.Text = "Thông Tin Thể Loại Sách";
            this.grpThongTin.Location = new System.Drawing.Point(15, 15);
            this.grpThongTin.Size = new System.Drawing.Size(430, 565);

            // lblMaTL & txtMaTL
            this.lblMaTL.Text = "Mã thể loại:";
            this.lblMaTL.Location = new System.Drawing.Point(15, 38);
            this.lblMaTL.Size = new System.Drawing.Size(110, 25);
            this.txtMaTL.Location = new System.Drawing.Point(135, 35);
            this.txtMaTL.Size = new System.Drawing.Size(275, 27);
            this.txtMaTL.ReadOnly = true;

            // lblTenTheLoai & txtTenTheLoai
            this.lblTenTheLoai.Text = "Tên thể loại (*):";
            this.lblTenTheLoai.Location = new System.Drawing.Point(15, 83);
            this.lblTenTheLoai.Size = new System.Drawing.Size(110, 25);
            this.txtTenTheLoai.Location = new System.Drawing.Point(135, 80);
            this.txtTenTheLoai.Size = new System.Drawing.Size(275, 27);

            // lblSoLuong & numSoLuongSach
            this.lblSoLuong.Text = "Số lượng sách:";
            this.lblSoLuong.Location = new System.Drawing.Point(15, 128);
            this.lblSoLuong.Size = new System.Drawing.Size(110, 25);
            this.numSoLuongSach.Location = new System.Drawing.Point(135, 125);
            this.numSoLuongSach.Size = new System.Drawing.Size(275, 27);
            this.numSoLuongSach.Maximum = 100000;

            // lblNgayTao & lblNgayTaoValue
            this.lblNgayTao.Text = "Ngày tạo:";
            this.lblNgayTao.Location = new System.Drawing.Point(15, 173);
            this.lblNgayTao.Size = new System.Drawing.Size(110, 25);
            this.lblNgayTaoValue.Text = "---";
            this.lblNgayTaoValue.Location = new System.Drawing.Point(135, 173);
            this.lblNgayTaoValue.Size = new System.Drawing.Size(275, 25);
            this.lblNgayTaoValue.ForeColor = System.Drawing.Color.DarkSlateGray;

            // lblMoTa & txtMoTa
            this.lblMoTa.Text = "Mô tả:";
            this.lblMoTa.Location = new System.Drawing.Point(15, 218);
            this.lblMoTa.Size = new System.Drawing.Size(110, 25);
            this.txtMoTa.Location = new System.Drawing.Point(135, 215);
            this.txtMoTa.Size = new System.Drawing.Size(275, 160);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            // Buttons CRUD
            this.btnThem.Text = "Thêm mới";
            this.btnThem.Location = new System.Drawing.Point(15, 410);
            this.btnThem.Size = new System.Drawing.Size(92, 36);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua.Text = "Cập nhật";
            this.btnSua.Location = new System.Drawing.Point(117, 410);
            this.btnSua.Size = new System.Drawing.Size(92, 36);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.Text = "Xóa";
            this.btnXoa.Location = new System.Drawing.Point(219, 410);
            this.btnXoa.Size = new System.Drawing.Size(92, 36);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Location = new System.Drawing.Point(321, 410);
            this.btnLamMoi.Size = new System.Drawing.Size(92, 36);
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            this.grpThongTin.Controls.Add(this.lblMaTL);
            this.grpThongTin.Controls.Add(this.txtMaTL);
            this.grpThongTin.Controls.Add(this.lblTenTheLoai);
            this.grpThongTin.Controls.Add(this.txtTenTheLoai);
            this.grpThongTin.Controls.Add(this.lblSoLuong);
            this.grpThongTin.Controls.Add(this.numSoLuongSach);
            this.grpThongTin.Controls.Add(this.lblNgayTao);
            this.grpThongTin.Controls.Add(this.lblNgayTaoValue);
            this.grpThongTin.Controls.Add(this.lblMoTa);
            this.grpThongTin.Controls.Add(this.txtMoTa);
            this.grpThongTin.Controls.Add(this.btnThem);
            this.grpThongTin.Controls.Add(this.btnSua);
            this.grpThongTin.Controls.Add(this.btnXoa);
            this.grpThongTin.Controls.Add(this.btnLamMoi);

            //
            // grpTimKiem
            //
            this.grpTimKiem.Text = "Tìm kiếm Thể loại sách";
            this.grpTimKiem.Location = new System.Drawing.Point(460, 15);
            this.grpTimKiem.Size = new System.Drawing.Size(600, 75);

            this.txtTimKiem.Location = new System.Drawing.Point(15, 28);
            this.txtTimKiem.Size = new System.Drawing.Size(370, 27);
            this.txtTimKiem.PlaceholderText = "Nhập tên thể loại cần tìm...";
            this.txtTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyDown);

            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Location = new System.Drawing.Point(395, 25);
            this.btnTimKiem.Size = new System.Drawing.Size(95, 33);
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);

            this.btnHienTatCa.Text = "Tất cả";
            this.btnHienTatCa.Location = new System.Drawing.Point(498, 25);
            this.btnHienTatCa.Size = new System.Drawing.Size(85, 33);
            this.btnHienTatCa.Click += new System.EventHandler(this.btnHienTatCa_Click);

            this.grpTimKiem.Controls.Add(this.txtTimKiem);
            this.grpTimKiem.Controls.Add(this.btnTimKiem);
            this.grpTimKiem.Controls.Add(this.btnHienTatCa);

            //
            // dgvDanhSach
            //
            this.dgvDanhSach.Location = new System.Drawing.Point(460, 100);
            this.dgvDanhSach.Size = new System.Drawing.Size(600, 480);
            this.dgvDanhSach.ReadOnly = true;
            this.dgvDanhSach.MultiSelect = false;
            this.dgvDanhSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSach.AllowUserToAddRows = false;
            this.dgvDanhSach.RowHeadersWidth = 30;
            this.dgvDanhSach.SelectionChanged += new System.EventHandler(this.dgvDanhSach_SelectionChanged);

            // Add to Form
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.grpTimKiem);
            this.Controls.Add(this.dgvDanhSach);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblMaTL;
        private System.Windows.Forms.TextBox txtMaTL;
        private System.Windows.Forms.Label lblTenTheLoai;
        private System.Windows.Forms.TextBox txtTenTheLoai;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.NumericUpDown numSoLuongSach;
        private System.Windows.Forms.Label lblNgayTao;
        private System.Windows.Forms.Label lblNgayTaoValue;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;

        private System.Windows.Forms.GroupBox grpTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnHienTatCa;

        private System.Windows.Forms.DataGridView dgvDanhSach;
    }
}
