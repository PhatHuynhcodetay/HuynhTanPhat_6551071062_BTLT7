namespace Cau3_QuanLyPhong
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
            this.Text = "Sunrise Homestay - Quản Lý Phòng Nghỉ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            // GroupBox Thông tin phòng
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblMaPhong = new System.Windows.Forms.Label();
            this.txtMaPhong = new System.Windows.Forms.TextBox();
            this.lblSoPhong = new System.Windows.Forms.Label();
            this.txtSoPhong = new System.Windows.Forms.TextBox();
            this.lblTangSo = new System.Windows.Forms.Label();
            this.numTangSo = new System.Windows.Forms.NumericUpDown();
            this.lblLoaiPhong = new System.Windows.Forms.Label();
            this.cboLoaiPhong = new System.Windows.Forms.ComboBox();
            this.btnQuanLyLoaiPhong = new System.Windows.Forms.Button();
            this.lblTinhTrang = new System.Windows.Forms.Label();
            this.cboTinhTrang = new System.Windows.Forms.ComboBox();

            // Ảnh phòng
            this.lblHinhAnh = new System.Windows.Forms.Label();
            this.picHinhAnh = new System.Windows.Forms.PictureBox();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.lblTenFileAnh = new System.Windows.Forms.Label();

            // Buttons CRUD
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();

            // Bộ lọc tìm kiếm
            this.grpTimKiem = new System.Windows.Forms.GroupBox();
            this.lblLocLoai = new System.Windows.Forms.Label();
            this.cboLocLoai = new System.Windows.Forms.ComboBox();
            this.lblLocTinhTrang = new System.Windows.Forms.Label();
            this.cboLocTinhTrang = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnTatCa = new System.Windows.Forms.Button();

            // DataGridView
            this.dgvPhong = new System.Windows.Forms.DataGridView();

            //
            // grpThongTin
            //
            this.grpThongTin.Text = "Thông Tin Phòng Nghỉ";
            this.grpThongTin.Location = new System.Drawing.Point(15, 15);
            this.grpThongTin.Size = new System.Drawing.Size(430, 645);

            // txtMaPhong
            this.lblMaPhong.Text = "Mã phòng:";
            this.lblMaPhong.Location = new System.Drawing.Point(15, 38);
            this.lblMaPhong.Size = new System.Drawing.Size(110, 25);
            this.txtMaPhong.Location = new System.Drawing.Point(130, 35);
            this.txtMaPhong.Size = new System.Drawing.Size(280, 27);
            this.txtMaPhong.ReadOnly = true;

            // txtSoPhong
            this.lblSoPhong.Text = "Số phòng (*):";
            this.lblSoPhong.Location = new System.Drawing.Point(15, 78);
            this.lblSoPhong.Size = new System.Drawing.Size(110, 25);
            this.txtSoPhong.Location = new System.Drawing.Point(130, 75);
            this.txtSoPhong.Size = new System.Drawing.Size(280, 27);

            // numTangSo
            this.lblTangSo.Text = "Tầng số:";
            this.lblTangSo.Location = new System.Drawing.Point(15, 118);
            this.lblTangSo.Size = new System.Drawing.Size(110, 25);
            this.numTangSo.Location = new System.Drawing.Point(130, 115);
            this.numTangSo.Size = new System.Drawing.Size(280, 27);
            this.numTangSo.Minimum = 1;
            this.numTangSo.Maximum = 50;

            // cboLoaiPhong
            this.lblLoaiPhong.Text = "Loại phòng (*):";
            this.lblLoaiPhong.Location = new System.Drawing.Point(15, 158);
            this.lblLoaiPhong.Size = new System.Drawing.Size(110, 25);
            this.cboLoaiPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiPhong.Location = new System.Drawing.Point(130, 155);
            this.cboLoaiPhong.Size = new System.Drawing.Size(185, 28);

            // btnQuanLyLoaiPhong
            this.btnQuanLyLoaiPhong.Text = "QL Loại...";
            this.btnQuanLyLoaiPhong.Location = new System.Drawing.Point(320, 154);
            this.btnQuanLyLoaiPhong.Size = new System.Drawing.Size(90, 30);
            this.btnQuanLyLoaiPhong.Click += new System.EventHandler(this.btnQuanLyLoaiPhong_Click);

            // cboTinhTrang
            this.lblTinhTrang.Text = "Tình trạng:";
            this.lblTinhTrang.Location = new System.Drawing.Point(15, 198);
            this.lblTinhTrang.Size = new System.Drawing.Size(110, 25);
            this.cboTinhTrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTinhTrang.Items.AddRange(new object[] { "Trống", "Đang ở", "Đang dọn" });
            this.cboTinhTrang.SelectedIndex = 0;
            this.cboTinhTrang.Location = new System.Drawing.Point(130, 195);
            this.cboTinhTrang.Size = new System.Drawing.Size(280, 28);

            // Hình ảnh
            this.lblHinhAnh.Text = "Hình ảnh:";
            this.lblHinhAnh.Location = new System.Drawing.Point(15, 238);
            this.lblHinhAnh.Size = new System.Drawing.Size(110, 25);

            this.picHinhAnh.Location = new System.Drawing.Point(130, 238);
            this.picHinhAnh.Size = new System.Drawing.Size(280, 180);
            this.picHinhAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picHinhAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.btnChonAnh.Text = "Chọn file ảnh...";
            this.btnChonAnh.Location = new System.Drawing.Point(130, 428);
            this.btnChonAnh.Size = new System.Drawing.Size(120, 32);
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);

            this.lblTenFileAnh.Text = "Chưa chọn ảnh";
            this.lblTenFileAnh.Location = new System.Drawing.Point(260, 434);
            this.lblTenFileAnh.Size = new System.Drawing.Size(150, 20);
            this.lblTenFileAnh.ForeColor = System.Drawing.Color.DimGray;

            // Buttons
            this.btnThem.Text = "Thêm mới";
            this.btnThem.Location = new System.Drawing.Point(15, 485);
            this.btnThem.Size = new System.Drawing.Size(92, 36);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua.Text = "Cập nhật";
            this.btnSua.Location = new System.Drawing.Point(117, 485);
            this.btnSua.Size = new System.Drawing.Size(92, 36);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.Text = "Xóa";
            this.btnXoa.Location = new System.Drawing.Point(219, 485);
            this.btnXoa.Size = new System.Drawing.Size(92, 36);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Location = new System.Drawing.Point(321, 485);
            this.btnLamMoi.Size = new System.Drawing.Size(92, 36);
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            this.grpThongTin.Controls.Add(this.lblMaPhong);
            this.grpThongTin.Controls.Add(this.txtMaPhong);
            this.grpThongTin.Controls.Add(this.lblSoPhong);
            this.grpThongTin.Controls.Add(this.txtSoPhong);
            this.grpThongTin.Controls.Add(this.lblTangSo);
            this.grpThongTin.Controls.Add(this.numTangSo);
            this.grpThongTin.Controls.Add(this.lblLoaiPhong);
            this.grpThongTin.Controls.Add(this.cboLoaiPhong);
            this.grpThongTin.Controls.Add(this.btnQuanLyLoaiPhong);
            this.grpThongTin.Controls.Add(this.lblTinhTrang);
            this.grpThongTin.Controls.Add(this.cboTinhTrang);
            this.grpThongTin.Controls.Add(this.lblHinhAnh);
            this.grpThongTin.Controls.Add(this.picHinhAnh);
            this.grpThongTin.Controls.Add(this.btnChonAnh);
            this.grpThongTin.Controls.Add(this.lblTenFileAnh);
            this.grpThongTin.Controls.Add(this.btnThem);
            this.grpThongTin.Controls.Add(this.btnSua);
            this.grpThongTin.Controls.Add(this.btnXoa);
            this.grpThongTin.Controls.Add(this.btnLamMoi);

            //
            // grpTimKiem
            //
            this.grpTimKiem.Text = "Tìm Kiếm Kết Hợp (Loại Phòng + Tình Trạng)";
            this.grpTimKiem.Location = new System.Drawing.Point(460, 15);
            this.grpTimKiem.Size = new System.Drawing.Size(785, 80);

            this.lblLocLoai.Text = "Loại phòng:";
            this.lblLocLoai.Location = new System.Drawing.Point(15, 34);
            this.lblLocLoai.Size = new System.Drawing.Size(75, 20);
            this.cboLocLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocLoai.Location = new System.Drawing.Point(95, 30);
            this.cboLocLoai.Size = new System.Drawing.Size(200, 28);

            this.lblLocTinhTrang.Text = "Tình trạng:";
            this.lblLocTinhTrang.Location = new System.Drawing.Point(310, 34);
            this.lblLocTinhTrang.Size = new System.Drawing.Size(70, 20);
            this.cboLocTinhTrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTinhTrang.Items.AddRange(new object[] { "Tất cả", "Trống", "Đang ở", "Đang dọn" });
            this.cboLocTinhTrang.SelectedIndex = 0;
            this.cboLocTinhTrang.Location = new System.Drawing.Point(385, 30);
            this.cboLocTinhTrang.Size = new System.Drawing.Size(160, 28);

            this.btnTimKiem.Text = "Lọc dữ liệu";
            this.btnTimKiem.Location = new System.Drawing.Point(565, 27);
            this.btnTimKiem.Size = new System.Drawing.Size(95, 33);
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);

            this.btnTatCa.Text = "Tất cả";
            this.btnTatCa.Location = new System.Drawing.Point(670, 27);
            this.btnTatCa.Size = new System.Drawing.Size(90, 33);
            this.btnTatCa.Click += new System.EventHandler(this.btnTatCa_Click);

            this.grpTimKiem.Controls.Add(this.lblLocLoai);
            this.grpTimKiem.Controls.Add(this.cboLocLoai);
            this.grpTimKiem.Controls.Add(this.lblLocTinhTrang);
            this.grpTimKiem.Controls.Add(this.cboLocTinhTrang);
            this.grpTimKiem.Controls.Add(this.btnTimKiem);
            this.grpTimKiem.Controls.Add(this.btnTatCa);

            //
            // dgvPhong
            //
            this.dgvPhong.Location = new System.Drawing.Point(460, 105);
            this.dgvPhong.Size = new System.Drawing.Size(785, 555);
            this.dgvPhong.ReadOnly = true;
            this.dgvPhong.MultiSelect = false;
            this.dgvPhong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhong.AllowUserToAddRows = false;
            this.dgvPhong.RowTemplate.Height = 65;
            this.dgvPhong.RowHeadersWidth = 30;
            this.dgvPhong.SelectionChanged += new System.EventHandler(this.dgvPhong_SelectionChanged);

            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.grpTimKiem);
            this.Controls.Add(this.dgvPhong);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblMaPhong;
        private System.Windows.Forms.TextBox txtMaPhong;
        private System.Windows.Forms.Label lblSoPhong;
        private System.Windows.Forms.TextBox txtSoPhong;
        private System.Windows.Forms.Label lblTangSo;
        private System.Windows.Forms.NumericUpDown numTangSo;
        private System.Windows.Forms.Label lblLoaiPhong;
        private System.Windows.Forms.ComboBox cboLoaiPhong;
        private System.Windows.Forms.Button btnQuanLyLoaiPhong;
        private System.Windows.Forms.Label lblTinhTrang;
        private System.Windows.Forms.ComboBox cboTinhTrang;
        private System.Windows.Forms.Label lblHinhAnh;
        private System.Windows.Forms.PictureBox picHinhAnh;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.Label lblTenFileAnh;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;

        private System.Windows.Forms.GroupBox grpTimKiem;
        private System.Windows.Forms.Label lblLocLoai;
        private System.Windows.Forms.ComboBox cboLocLoai;
        private System.Windows.Forms.Label lblLocTinhTrang;
        private System.Windows.Forms.ComboBox cboLocTinhTrang;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnTatCa;

        private System.Windows.Forms.DataGridView dgvPhong;
    }
}
