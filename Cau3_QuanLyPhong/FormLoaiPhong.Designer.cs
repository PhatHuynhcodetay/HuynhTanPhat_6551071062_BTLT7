namespace Cau3_QuanLyPhong
{
    partial class FormLoaiPhong
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
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 480);
            this.Text = "Quản Lý Loại Phòng (Form Phụ)";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            this.lblMaLoai = new System.Windows.Forms.Label();
            this.txtMaLoai = new System.Windows.Forms.TextBox();
            this.lblTenLoai = new System.Windows.Forms.Label();
            this.txtTenLoai = new System.Windows.Forms.TextBox();
            this.lblGiaMoiDem = new System.Windows.Forms.Label();
            this.numGiaMoiDem = new System.Windows.Forms.NumericUpDown();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();

            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();

            this.dgvLoaiPhong = new System.Windows.Forms.DataGridView();

            // Controls positioning
            this.lblMaLoai.Text = "Mã loại:";
            this.lblMaLoai.Location = new System.Drawing.Point(20, 25);
            this.lblMaLoai.AutoSize = true;
            this.txtMaLoai.Location = new System.Drawing.Point(120, 22);
            this.txtMaLoai.Size = new System.Drawing.Size(200, 29);
            this.txtMaLoai.ReadOnly = true;

            this.lblTenLoai.Text = "Tên loại (*):";
            this.lblTenLoai.Location = new System.Drawing.Point(20, 65);
            this.lblTenLoai.AutoSize = true;
            this.txtTenLoai.Location = new System.Drawing.Point(120, 62);
            this.txtTenLoai.Size = new System.Drawing.Size(200, 29);

            this.lblGiaMoiDem.Text = "Giá/đêm (*):";
            this.lblGiaMoiDem.Location = new System.Drawing.Point(20, 105);
            this.lblGiaMoiDem.AutoSize = true;
            this.numGiaMoiDem.Location = new System.Drawing.Point(120, 102);
            this.numGiaMoiDem.Size = new System.Drawing.Size(200, 29);
            this.numGiaMoiDem.Maximum = 100000000;
            this.numGiaMoiDem.Increment = 50000;

            this.lblMoTa.Text = "Mô tả:";
            this.lblMoTa.Location = new System.Drawing.Point(20, 145);
            this.lblMoTa.AutoSize = true;
            this.txtMoTa.Location = new System.Drawing.Point(120, 142);
            this.txtMoTa.Size = new System.Drawing.Size(200, 120);
            this.txtMoTa.Multiline = true;

            this.btnThem.Text = "Thêm";
            this.btnThem.Location = new System.Drawing.Point(20, 280);
            this.btnThem.Size = new System.Drawing.Size(70, 35);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua.Text = "Sửa";
            this.btnSua.Location = new System.Drawing.Point(95, 280);
            this.btnSua.Size = new System.Drawing.Size(70, 35);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.Text = "Xóa";
            this.btnXoa.Location = new System.Drawing.Point(170, 280);
            this.btnXoa.Size = new System.Drawing.Size(70, 35);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnLamMoi.Text = "Mới";
            this.btnLamMoi.Location = new System.Drawing.Point(245, 280);
            this.btnLamMoi.Size = new System.Drawing.Size(75, 35);
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // DataGridView
            this.dgvLoaiPhong.Location = new System.Drawing.Point(340, 20);
            this.dgvLoaiPhong.Size = new System.Drawing.Size(385, 430);
            this.dgvLoaiPhong.ReadOnly = true;
            this.dgvLoaiPhong.MultiSelect = false;
            this.dgvLoaiPhong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoaiPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoaiPhong.AllowUserToAddRows = false;
            this.dgvLoaiPhong.SelectionChanged += new System.EventHandler(this.dgvLoaiPhong_SelectionChanged);

            this.Controls.Add(this.lblMaLoai);
            this.Controls.Add(this.txtMaLoai);
            this.Controls.Add(this.lblTenLoai);
            this.Controls.Add(this.txtTenLoai);
            this.Controls.Add(this.lblGiaMoiDem);
            this.Controls.Add(this.numGiaMoiDem);
            this.Controls.Add(this.lblMoTa);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.dgvLoaiPhong);
        }

        #endregion

        private System.Windows.Forms.Label lblMaLoai;
        private System.Windows.Forms.TextBox txtMaLoai;
        private System.Windows.Forms.Label lblTenLoai;
        private System.Windows.Forms.TextBox txtTenLoai;
        private System.Windows.Forms.Label lblGiaMoiDem;
        private System.Windows.Forms.NumericUpDown numGiaMoiDem;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.DataGridView dgvLoaiPhong;
    }
}
