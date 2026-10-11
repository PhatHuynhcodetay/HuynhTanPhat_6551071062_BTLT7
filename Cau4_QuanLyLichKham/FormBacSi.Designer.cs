namespace Cau4_QuanLyLichKham
{
    partial class FormBacSi
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
            this.Text = "Quản Lý Bác Sĩ (Form Phụ)";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            this.lblMaBS = new System.Windows.Forms.Label();
            this.txtMaBS = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblChuyenKhoa = new System.Windows.Forms.Label();
            this.txtChuyenKhoa = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();

            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();

            this.dgvBacSi = new System.Windows.Forms.DataGridView();

            // Controls positioning
            this.lblMaBS.Text = "Mã BS:";
            this.lblMaBS.Location = new System.Drawing.Point(20, 25);
            this.lblMaBS.AutoSize = true;
            this.txtMaBS.Location = new System.Drawing.Point(120, 22);
            this.txtMaBS.Size = new System.Drawing.Size(200, 29);
            this.txtMaBS.ReadOnly = true;

            this.lblHoTen.Text = "Họ tên (*):";
            this.lblHoTen.Location = new System.Drawing.Point(20, 65);
            this.lblHoTen.AutoSize = true;
            this.txtHoTen.Location = new System.Drawing.Point(120, 62);
            this.txtHoTen.Size = new System.Drawing.Size(200, 29);

            this.lblChuyenKhoa.Text = "Chuyên khoa (*):";
            this.lblChuyenKhoa.Location = new System.Drawing.Point(20, 105);
            this.lblChuyenKhoa.AutoSize = true;
            this.txtChuyenKhoa.Location = new System.Drawing.Point(120, 102);
            this.txtChuyenKhoa.Size = new System.Drawing.Size(200, 29);

            this.lblSDT.Text = "Số điện thoại:";
            this.lblSDT.Location = new System.Drawing.Point(20, 145);
            this.lblSDT.AutoSize = true;
            this.txtSDT.Location = new System.Drawing.Point(120, 142);
            this.txtSDT.Size = new System.Drawing.Size(200, 29);

            this.btnThem.Text = "Thêm";
            this.btnThem.Location = new System.Drawing.Point(20, 200);
            this.btnThem.Size = new System.Drawing.Size(70, 35);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua.Text = "Sửa";
            this.btnSua.Location = new System.Drawing.Point(95, 200);
            this.btnSua.Size = new System.Drawing.Size(70, 35);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.Text = "Xóa";
            this.btnXoa.Location = new System.Drawing.Point(170, 200);
            this.btnXoa.Size = new System.Drawing.Size(70, 35);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnLamMoi.Text = "Mới";
            this.btnLamMoi.Location = new System.Drawing.Point(245, 200);
            this.btnLamMoi.Size = new System.Drawing.Size(75, 35);
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // DataGridView
            this.dgvBacSi.Location = new System.Drawing.Point(340, 20);
            this.dgvBacSi.Size = new System.Drawing.Size(385, 430);
            this.dgvBacSi.ReadOnly = true;
            this.dgvBacSi.MultiSelect = false;
            this.dgvBacSi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBacSi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBacSi.AllowUserToAddRows = false;
            this.dgvBacSi.SelectionChanged += new System.EventHandler(this.dgvBacSi_SelectionChanged);

            this.Controls.Add(this.lblMaBS);
            this.Controls.Add(this.txtMaBS);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.lblChuyenKhoa);
            this.Controls.Add(this.txtChuyenKhoa);
            this.Controls.Add(this.lblSDT);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.dgvBacSi);
        }

        #endregion

        private System.Windows.Forms.Label lblMaBS;
        private System.Windows.Forms.TextBox txtMaBS;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblChuyenKhoa;
        private System.Windows.Forms.TextBox txtChuyenKhoa;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.DataGridView dgvBacSi;
    }
}
