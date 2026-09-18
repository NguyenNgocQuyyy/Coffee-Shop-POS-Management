namespace Đồ_án_ngành.GUI
{
    partial class FrmQuanLyCongThuc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblMon = new System.Windows.Forms.Label();
            this.cboMon = new System.Windows.Forms.ComboBox();
            this.lblChiTietCongThuc = new System.Windows.Forms.Label();
            this.dgvCongThuc = new System.Windows.Forms.DataGridView();
            this.colMaNVL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenNVL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonViTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNguyenVatLieu = new System.Windows.Forms.Label();
            this.cboNguyenVatLieu = new System.Windows.Forms.ComboBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.lblDonViTinh = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoaNguyenLieu = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnXoaCongThuc = new System.Windows.Forms.Button();
            this.lblDanhMuc = new System.Windows.Forms.Label();
            this.cboDanhMuc = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongThuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.lblTieuDe.Location = new System.Drawing.Point(290, 20);
            this.lblTieuDe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(266, 32);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "QUẢN LÝ CÔNG THỨC";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMon
            // 
            this.lblMon.AutoSize = true;
            this.lblMon.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.lblMon.Location = new System.Drawing.Point(40, 85);
            this.lblMon.Name = "lblMon";
            this.lblMon.Size = new System.Drawing.Size(45, 20);
            this.lblMon.TabIndex = 1;
            this.lblMon.Text = "Món:";
            // 
            // cboMon
            // 
            this.cboMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMon.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMon.FormattingEnabled = true;
            this.cboMon.Location = new System.Drawing.Point(120, 82);
            this.cboMon.Name = "cboMon";
            this.cboMon.Size = new System.Drawing.Size(300, 28);
            this.cboMon.TabIndex = 2;
            this.cboMon.SelectedIndexChanged += new System.EventHandler(this.cboMon_SelectedIndexChanged);
            // 
            // lblChiTietCongThuc
            // 
            this.lblChiTietCongThuc.AutoSize = true;
            this.lblChiTietCongThuc.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChiTietCongThuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.lblChiTietCongThuc.Location = new System.Drawing.Point(40, 135);
            this.lblChiTietCongThuc.Name = "lblChiTietCongThuc";
            this.lblChiTietCongThuc.Size = new System.Drawing.Size(133, 20);
            this.lblChiTietCongThuc.TabIndex = 3;
            this.lblChiTietCongThuc.Text = "Chi tiết công thức";
            // 
            // dgvCongThuc
            // 
            this.dgvCongThuc.AllowUserToAddRows = false;
            this.dgvCongThuc.AllowUserToDeleteRows = false;
            this.dgvCongThuc.AllowUserToResizeRows = false;
            this.dgvCongThuc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCongThuc.BackgroundColor = System.Drawing.Color.White;
            this.dgvCongThuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCongThuc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaNVL,
            this.colTenNVL,
            this.colSoLuong,
            this.colDonViTinh});
            this.dgvCongThuc.Location = new System.Drawing.Point(40, 170);
            this.dgvCongThuc.MultiSelect = false;
            this.dgvCongThuc.Name = "dgvCongThuc";
            this.dgvCongThuc.ReadOnly = true;
            this.dgvCongThuc.RowHeadersVisible = false;
            this.dgvCongThuc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCongThuc.Size = new System.Drawing.Size(820, 260);
            this.dgvCongThuc.TabIndex = 4;
            // 
            // colMaNVL
            // 
            this.colMaNVL.HeaderText = "Mã NVL";
            this.colMaNVL.Name = "colMaNVL";
            this.colMaNVL.ReadOnly = true;
            // 
            // colTenNVL
            // 
            this.colTenNVL.HeaderText = "Tên nguyên vật liệu";
            this.colTenNVL.Name = "colTenNVL";
            this.colTenNVL.ReadOnly = true;
            // 
            // colSoLuong
            // 
            this.colSoLuong.HeaderText = "Số lượng";
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.ReadOnly = true;
            // 
            // colDonViTinh
            // 
            this.colDonViTinh.HeaderText = "Đơn vị tính";
            this.colDonViTinh.Name = "colDonViTinh";
            this.colDonViTinh.ReadOnly = true;
            // 
            // lblNguyenVatLieu
            // 
            this.lblNguyenVatLieu.AutoSize = true;
            this.lblNguyenVatLieu.Location = new System.Drawing.Point(40, 455);
            this.lblNguyenVatLieu.Name = "lblNguyenVatLieu";
            this.lblNguyenVatLieu.Size = new System.Drawing.Size(101, 17);
            this.lblNguyenVatLieu.TabIndex = 5;
            this.lblNguyenVatLieu.Text = "Nguyên vật liệu:";
            // 
            // cboNguyenVatLieu
            // 
            this.cboNguyenVatLieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNguyenVatLieu.FormattingEnabled = true;
            this.cboNguyenVatLieu.Location = new System.Drawing.Point(180, 452);
            this.cboNguyenVatLieu.Name = "cboNguyenVatLieu";
            this.cboNguyenVatLieu.Size = new System.Drawing.Size(250, 25);
            this.cboNguyenVatLieu.TabIndex = 6;
            this.cboNguyenVatLieu.SelectedIndexChanged += new System.EventHandler(this.cboNguyenVatLieu_SelectedIndexChanged);
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(455, 455);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(64, 17);
            this.lblSoLuong.TabIndex = 7;
            this.lblSoLuong.Text = "Số lượng:";
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Location = new System.Drawing.Point(525, 452);
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(120, 25);
            this.nudSoLuong.TabIndex = 8;
            // 
            // lblDonViTinh
            // 
            this.lblDonViTinh.AutoSize = true;
            this.lblDonViTinh.Location = new System.Drawing.Point(670, 455);
            this.lblDonViTinh.Name = "lblDonViTinh";
            this.lblDonViTinh.Size = new System.Drawing.Size(73, 17);
            this.lblDonViTinh.TabIndex = 9;
            this.lblDonViTinh.Text = "Đơn vị tính:";
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(67)))), ((int)(((byte)(46)))));
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(755, 450);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 34);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "➕ THÊM";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoaNguyenLieu
            // 
            this.btnXoaNguyenLieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(80)))), ((int)(((byte)(70)))));
            this.btnXoaNguyenLieu.FlatAppearance.BorderSize = 0;
            this.btnXoaNguyenLieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaNguyenLieu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaNguyenLieu.ForeColor = System.Drawing.Color.White;
            this.btnXoaNguyenLieu.Location = new System.Drawing.Point(40, 520);
            this.btnXoaNguyenLieu.Name = "btnXoaNguyenLieu";
            this.btnXoaNguyenLieu.Size = new System.Drawing.Size(110, 40);
            this.btnXoaNguyenLieu.TabIndex = 12;
            this.btnXoaNguyenLieu.Text = "XÓA NVL";
            this.btnXoaNguyenLieu.UseVisualStyleBackColor = false;
            this.btnXoaNguyenLieu.Click += new System.EventHandler(this.btnXoaNguyenLieu_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(67)))), ((int)(((byte)(46)))));
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(545, 520);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(170, 40);
            this.btnLuu.TabIndex = 13;
            this.btnLuu.Text = "LƯU CÔNG THỨC";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(745, 520);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 40);
            this.btnDong.TabIndex = 14;
            this.btnDong.Text = "ĐÓNG";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnXoaCongThuc
            // 
            this.btnXoaCongThuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(80)))), ((int)(((byte)(70)))));
            this.btnXoaCongThuc.FlatAppearance.BorderSize = 0;
            this.btnXoaCongThuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaCongThuc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaCongThuc.ForeColor = System.Drawing.Color.White;
            this.btnXoaCongThuc.Location = new System.Drawing.Point(355, 520);
            this.btnXoaCongThuc.Name = "btnXoaCongThuc";
            this.btnXoaCongThuc.Size = new System.Drawing.Size(160, 40);
            this.btnXoaCongThuc.TabIndex = 15;
            this.btnXoaCongThuc.Text = "XÓA CÔNG THỨC";
            this.btnXoaCongThuc.UseVisualStyleBackColor = false;
            this.btnXoaCongThuc.Click += new System.EventHandler(this.btnXoaCongThuc_Click);
            // 
            // lblDanhMuc
            // 
            this.lblDanhMuc.AutoSize = true;
            this.lblDanhMuc.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDanhMuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.lblDanhMuc.Location = new System.Drawing.Point(460, 85);
            this.lblDanhMuc.Name = "lblDanhMuc";
            this.lblDanhMuc.Size = new System.Drawing.Size(84, 20);
            this.lblDanhMuc.TabIndex = 16;
            this.lblDanhMuc.Text = "Danh mục:";
            // 
            // cboDanhMuc
            // 
            this.cboDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDanhMuc.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDanhMuc.FormattingEnabled = true;
            this.cboDanhMuc.Location = new System.Drawing.Point(550, 82);
            this.cboDanhMuc.Name = "cboDanhMuc";
            this.cboDanhMuc.Size = new System.Drawing.Size(300, 28);
            this.cboDanhMuc.TabIndex = 17;
            this.cboDanhMuc.SelectedIndexChanged += new System.EventHandler(this.cboDanhMuc_SelectedIndexChanged);
            // 
            // FrmQuanLyCongThuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(884, 581);
            this.Controls.Add(this.cboDanhMuc);
            this.Controls.Add(this.lblDanhMuc);
            this.Controls.Add(this.btnXoaCongThuc);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoaNguyenLieu);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.lblDonViTinh);
            this.Controls.Add(this.nudSoLuong);
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.cboNguyenVatLieu);
            this.Controls.Add(this.lblNguyenVatLieu);
            this.Controls.Add(this.dgvCongThuc);
            this.Controls.Add(this.lblChiTietCongThuc);
            this.Controls.Add(this.cboMon);
            this.Controls.Add(this.lblMon);
            this.Controls.Add(this.lblTieuDe);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmQuanLyCongThuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý công thức";
            this.Load += new System.EventHandler(this.FrmQuanLyCongThuc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongThuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMon;
        private System.Windows.Forms.ComboBox cboMon;
        private System.Windows.Forms.Label lblChiTietCongThuc;
        private System.Windows.Forms.DataGridView dgvCongThuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNVL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenNVL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonViTinh;
        private System.Windows.Forms.Label lblNguyenVatLieu;
        private System.Windows.Forms.ComboBox cboNguyenVatLieu;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Label lblDonViTinh;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoaNguyenLieu;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnXoaCongThuc;
        private System.Windows.Forms.Label lblDanhMuc;
        private System.Windows.Forms.ComboBox cboDanhMuc;
    }
}