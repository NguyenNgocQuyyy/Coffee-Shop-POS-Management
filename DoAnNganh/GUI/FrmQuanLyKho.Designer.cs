namespace Đồ_án_ngành.GUI
{
    partial class FrmQuanLyKho
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
            this.pnlTieuDe = new System.Windows.Forms.Panel();
            this.lblIcon = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.pnlNoiDung = new System.Windows.Forms.Panel();
            this.pnlThongTin = new System.Windows.Forms.Panel();
            this.txtDonViTinhQuyDoi = new System.Windows.Forms.TextBox();
            this.lblDonViTinhQuyDoi = new System.Windows.Forms.Label();
            this.lblThongTin = new System.Windows.Forms.Label();
            this.lblMaNVL = new System.Windows.Forms.Label();
            this.txtMaNVL = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.txtDonViTinh = new System.Windows.Forms.TextBox();
            this.txtMucCanhBao = new System.Windows.Forms.TextBox();
            this.txtSoLuongTon = new System.Windows.Forms.TextBox();
            this.txtTenNVL = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.lblTrangThaiNVL = new System.Windows.Forms.Label();
            this.lblDonViTinh = new System.Windows.Forms.Label();
            this.lblMucCanhBao = new System.Windows.Forms.Label();
            this.lblSoLuongTon = new System.Windows.Forms.Label();
            this.lblTenNVL = new System.Windows.Forms.Label();
            this.cboTrangThaiNVL = new System.Windows.Forms.ComboBox();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvNguyenVatLieu = new System.Windows.Forms.DataGridView();
            this.pnlTimKiem = new System.Windows.Forms.Panel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.lblHeSoQuyDoi = new System.Windows.Forms.Label();
            this.txtHeSoQuyDoi = new System.Windows.Forms.TextBox();
            this.MaNVL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNVL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongTon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MucCanhBao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonViTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonViTinhQuyDoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeSoQuyDoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTieuDe.SuspendLayout();
            this.pnlNoiDung.SuspendLayout();
            this.pnlThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguyenVatLieu)).BeginInit();
            this.pnlTimKiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTieuDe
            // 
            this.pnlTieuDe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.pnlTieuDe.Controls.Add(this.lblIcon);
            this.pnlTieuDe.Controls.Add(this.lblTieuDe);
            this.pnlTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTieuDe.Location = new System.Drawing.Point(0, 0);
            this.pnlTieuDe.Name = "pnlTieuDe";
            this.pnlTieuDe.Size = new System.Drawing.Size(1350, 100);
            this.pnlTieuDe.TabIndex = 0;
            // 
            // lblIcon
            // 
            this.lblIcon.AutoSize = true;
            this.lblIcon.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIcon.ForeColor = System.Drawing.Color.White;
            this.lblIcon.Location = new System.Drawing.Point(77, 23);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(73, 50);
            this.lblIcon.TabIndex = 1;
            this.lblIcon.Text = "📦️";
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(142, 38);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(441, 37);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "QUẢN LÝ KHO NGUYÊN VẬT LIỆU";
            // 
            // pnlNoiDung
            // 
            this.pnlNoiDung.Controls.Add(this.pnlThongTin);
            this.pnlNoiDung.Controls.Add(this.dgvNguyenVatLieu);
            this.pnlNoiDung.Controls.Add(this.pnlTimKiem);
            this.pnlNoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNoiDung.Location = new System.Drawing.Point(0, 100);
            this.pnlNoiDung.Name = "pnlNoiDung";
            this.pnlNoiDung.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.pnlNoiDung.Size = new System.Drawing.Size(1350, 629);
            this.pnlNoiDung.TabIndex = 1;
            // 
            // pnlThongTin
            // 
            this.pnlThongTin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlThongTin.BackColor = System.Drawing.Color.White;
            this.pnlThongTin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThongTin.Controls.Add(this.txtHeSoQuyDoi);
            this.pnlThongTin.Controls.Add(this.lblHeSoQuyDoi);
            this.pnlThongTin.Controls.Add(this.txtDonViTinhQuyDoi);
            this.pnlThongTin.Controls.Add(this.lblDonViTinhQuyDoi);
            this.pnlThongTin.Controls.Add(this.lblThongTin);
            this.pnlThongTin.Controls.Add(this.lblMaNVL);
            this.pnlThongTin.Controls.Add(this.txtMaNVL);
            this.pnlThongTin.Controls.Add(this.txtGhiChu);
            this.pnlThongTin.Controls.Add(this.txtDonViTinh);
            this.pnlThongTin.Controls.Add(this.txtMucCanhBao);
            this.pnlThongTin.Controls.Add(this.txtSoLuongTon);
            this.pnlThongTin.Controls.Add(this.txtTenNVL);
            this.pnlThongTin.Controls.Add(this.lblGhiChu);
            this.pnlThongTin.Controls.Add(this.lblTrangThaiNVL);
            this.pnlThongTin.Controls.Add(this.lblDonViTinh);
            this.pnlThongTin.Controls.Add(this.lblMucCanhBao);
            this.pnlThongTin.Controls.Add(this.lblSoLuongTon);
            this.pnlThongTin.Controls.Add(this.lblTenNVL);
            this.pnlThongTin.Controls.Add(this.cboTrangThaiNVL);
            this.pnlThongTin.Controls.Add(this.btnCapNhat);
            this.pnlThongTin.Controls.Add(this.btnThem);
            this.pnlThongTin.Location = new System.Drawing.Point(940, 90);
            this.pnlThongTin.Name = "pnlThongTin";
            this.pnlThongTin.Size = new System.Drawing.Size(400, 525);
            this.pnlThongTin.TabIndex = 5;
            // 
            // txtDonViTinhQuyDoi
            // 
            this.txtDonViTinhQuyDoi.Location = new System.Drawing.Point(25, 350);
            this.txtDonViTinhQuyDoi.Name = "txtDonViTinhQuyDoi";
            this.txtDonViTinhQuyDoi.Size = new System.Drawing.Size(165, 25);
            this.txtDonViTinhQuyDoi.TabIndex = 12;
            // 
            // lblDonViTinhQuyDoi
            // 
            this.lblDonViTinhQuyDoi.AutoSize = true;
            this.lblDonViTinhQuyDoi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonViTinhQuyDoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.lblDonViTinhQuyDoi.Location = new System.Drawing.Point(25, 325);
            this.lblDonViTinhQuyDoi.Name = "lblDonViTinhQuyDoi";
            this.lblDonViTinhQuyDoi.Size = new System.Drawing.Size(115, 17);
            this.lblDonViTinhQuyDoi.TabIndex = 11;
            this.lblDonViTinhQuyDoi.Text = "Đơn vị công thức";
            // 
            // lblThongTin
            // 
            this.lblThongTin.AutoSize = true;
            this.lblThongTin.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongTin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.lblThongTin.Location = new System.Drawing.Point(25, 20);
            this.lblThongTin.Name = "lblThongTin";
            this.lblThongTin.Size = new System.Drawing.Size(290, 25);
            this.lblThongTin.TabIndex = 6;
            this.lblThongTin.Text = "THÔNG TIN NGUYÊN VẬT LIỆU";
            // 
            // lblMaNVL
            // 
            this.lblMaNVL.AutoSize = true;
            this.lblMaNVL.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNVL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.lblMaNVL.Location = new System.Drawing.Point(25, 65);
            this.lblMaNVL.Name = "lblMaNVL";
            this.lblMaNVL.Size = new System.Drawing.Size(127, 17);
            this.lblMaNVL.TabIndex = 7;
            this.lblMaNVL.Text = "Mã nguyên vật liệu";
            // 
            // txtMaNVL
            // 
            this.txtMaNVL.Location = new System.Drawing.Point(25, 88);
            this.txtMaNVL.Name = "txtMaNVL";
            this.txtMaNVL.ReadOnly = true;
            this.txtMaNVL.Size = new System.Drawing.Size(350, 25);
            this.txtMaNVL.TabIndex = 8;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(25, 410);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(350, 29);
            this.txtGhiChu.TabIndex = 10;
            // 
            // txtDonViTinh
            // 
            this.txtDonViTinh.Location = new System.Drawing.Point(25, 283);
            this.txtDonViTinh.Name = "txtDonViTinh";
            this.txtDonViTinh.Size = new System.Drawing.Size(165, 25);
            this.txtDonViTinh.TabIndex = 8;
            // 
            // txtMucCanhBao
            // 
            this.txtMucCanhBao.Location = new System.Drawing.Point(210, 218);
            this.txtMucCanhBao.Name = "txtMucCanhBao";
            this.txtMucCanhBao.Size = new System.Drawing.Size(165, 25);
            this.txtMucCanhBao.TabIndex = 7;
            // 
            // txtSoLuongTon
            // 
            this.txtSoLuongTon.Location = new System.Drawing.Point(25, 218);
            this.txtSoLuongTon.Name = "txtSoLuongTon";
            this.txtSoLuongTon.ReadOnly = true;
            this.txtSoLuongTon.Size = new System.Drawing.Size(165, 25);
            this.txtSoLuongTon.TabIndex = 6;
            // 
            // txtTenNVL
            // 
            this.txtTenNVL.Location = new System.Drawing.Point(25, 153);
            this.txtTenNVL.Name = "txtTenNVL";
            this.txtTenNVL.Size = new System.Drawing.Size(350, 25);
            this.txtTenNVL.TabIndex = 5;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGhiChu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.lblGhiChu.Location = new System.Drawing.Point(25, 388);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(55, 17);
            this.lblGhiChu.TabIndex = 10;
            this.lblGhiChu.Text = "Ghi chú";
            // 
            // lblTrangThaiNVL
            // 
            this.lblTrangThaiNVL.AutoSize = true;
            this.lblTrangThaiNVL.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThaiNVL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.lblTrangThaiNVL.Location = new System.Drawing.Point(210, 260);
            this.lblTrangThaiNVL.Name = "lblTrangThaiNVL";
            this.lblTrangThaiNVL.Size = new System.Drawing.Size(71, 17);
            this.lblTrangThaiNVL.TabIndex = 9;
            this.lblTrangThaiNVL.Text = "Trạng thái";
            // 
            // lblDonViTinh
            // 
            this.lblDonViTinh.AutoSize = true;
            this.lblDonViTinh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonViTinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.lblDonViTinh.Location = new System.Drawing.Point(25, 260);
            this.lblDonViTinh.Name = "lblDonViTinh";
            this.lblDonViTinh.Size = new System.Drawing.Size(78, 17);
            this.lblDonViTinh.TabIndex = 8;
            this.lblDonViTinh.Text = "Đơn vị tính";
            // 
            // lblMucCanhBao
            // 
            this.lblMucCanhBao.AutoSize = true;
            this.lblMucCanhBao.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMucCanhBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.lblMucCanhBao.Location = new System.Drawing.Point(210, 195);
            this.lblMucCanhBao.Name = "lblMucCanhBao";
            this.lblMucCanhBao.Size = new System.Drawing.Size(95, 17);
            this.lblMucCanhBao.TabIndex = 7;
            this.lblMucCanhBao.Text = "Mức cảnh báo";
            // 
            // lblSoLuongTon
            // 
            this.lblSoLuongTon.AutoSize = true;
            this.lblSoLuongTon.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuongTon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.lblSoLuongTon.Location = new System.Drawing.Point(25, 195);
            this.lblSoLuongTon.Name = "lblSoLuongTon";
            this.lblSoLuongTon.Size = new System.Drawing.Size(89, 17);
            this.lblSoLuongTon.TabIndex = 6;
            this.lblSoLuongTon.Text = "Số lượng tồn";
            // 
            // lblTenNVL
            // 
            this.lblTenNVL.AutoSize = true;
            this.lblTenNVL.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNVL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.lblTenNVL.Location = new System.Drawing.Point(25, 130);
            this.lblTenNVL.Name = "lblTenNVL";
            this.lblTenNVL.Size = new System.Drawing.Size(130, 17);
            this.lblTenNVL.TabIndex = 5;
            this.lblTenNVL.Text = "Tên nguyên vật liệu";
            // 
            // cboTrangThaiNVL
            // 
            this.cboTrangThaiNVL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThaiNVL.Enabled = false;
            this.cboTrangThaiNVL.FormattingEnabled = true;
            this.cboTrangThaiNVL.Items.AddRange(new object[] {
            "Hết hàng",
            "Sắp hết",
            "Còn hàng"});
            this.cboTrangThaiNVL.Location = new System.Drawing.Point(210, 283);
            this.cboTrangThaiNVL.Name = "cboTrangThaiNVL";
            this.cboTrangThaiNVL.Size = new System.Drawing.Size(165, 25);
            this.cboTrangThaiNVL.TabIndex = 5;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(90)))), ((int)(((byte)(55)))));
            this.btnCapNhat.FlatAppearance.BorderSize = 0;
            this.btnCapNhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhat.ForeColor = System.Drawing.Color.White;
            this.btnCapNhat.Location = new System.Drawing.Point(210, 454);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(165, 37);
            this.btnCapNhat.TabIndex = 6;
            this.btnCapNhat.Text = "✎ CẬP NHẬT";
            this.btnCapNhat.UseVisualStyleBackColor = false;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(105)))), ((int)(((byte)(65)))));
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(25, 454);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(165, 37);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "➕️ THÊM NVL";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvNguyenVatLieu
            // 
            this.dgvNguyenVatLieu.AllowUserToAddRows = false;
            this.dgvNguyenVatLieu.AllowUserToDeleteRows = false;
            this.dgvNguyenVatLieu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvNguyenVatLieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNguyenVatLieu.BackgroundColor = System.Drawing.Color.White;
            this.dgvNguyenVatLieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNguyenVatLieu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNVL,
            this.TenNVL,
            this.SoLuongTon,
            this.MucCanhBao,
            this.DonViTinh,
            this.DonViTinhQuyDoi,
            this.HeSoQuyDoi,
            this.TrangThai,
            this.GhiChu});
            this.dgvNguyenVatLieu.Location = new System.Drawing.Point(20, 90);
            this.dgvNguyenVatLieu.MultiSelect = false;
            this.dgvNguyenVatLieu.Name = "dgvNguyenVatLieu";
            this.dgvNguyenVatLieu.ReadOnly = true;
            this.dgvNguyenVatLieu.RowHeadersVisible = false;
            this.dgvNguyenVatLieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNguyenVatLieu.Size = new System.Drawing.Size(900, 525);
            this.dgvNguyenVatLieu.TabIndex = 1;
            this.dgvNguyenVatLieu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNguyenVatLieu_CellClick);
            this.dgvNguyenVatLieu.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvNguyenVatLieu_CellFormatting);
            // 
            // pnlTimKiem
            // 
            this.pnlTimKiem.Controls.Add(this.btnLamMoi);
            this.pnlTimKiem.Controls.Add(this.cboTrangThai);
            this.pnlTimKiem.Controls.Add(this.lblTrangThai);
            this.pnlTimKiem.Controls.Add(this.txtTimKiem);
            this.pnlTimKiem.Controls.Add(this.lblTimKiem);
            this.pnlTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTimKiem.Location = new System.Drawing.Point(20, 0);
            this.pnlTimKiem.Name = "pnlTimKiem";
            this.pnlTimKiem.Size = new System.Drawing.Size(1330, 100);
            this.pnlTimKiem.TabIndex = 0;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(700, 16);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(120, 38);
            this.btnLamMoi.TabIndex = 4;
            this.btnLamMoi.Text = "LÀM MỚI";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Items.AddRange(new object[] {
            "Tất cả",
            "Còn hàng",
            "Sắp hết",
            "Hết hàng"});
            this.cboTrangThai.Location = new System.Drawing.Point(490, 19);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(180, 25);
            this.cboTrangThai.TabIndex = 3;
            this.cboTrangThai.SelectedIndexChanged += new System.EventHandler(this.cboTrangThai_SelectedIndexChanged);
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.Location = new System.Drawing.Point(400, 25);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(75, 17);
            this.lblTrangThai.TabIndex = 2;
            this.lblTrangThai.Text = "Trạng thái:\n";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(105, 19);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(260, 25);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimKiem.Location = new System.Drawing.Point(20, 25);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(70, 17);
            this.lblTimKiem.TabIndex = 0;
            this.lblTimKiem.Text = "Tìm kiếm:";
            // 
            // lblHeSoQuyDoi
            // 
            this.lblHeSoQuyDoi.AutoSize = true;
            this.lblHeSoQuyDoi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeSoQuyDoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.lblHeSoQuyDoi.Location = new System.Drawing.Point(210, 325);
            this.lblHeSoQuyDoi.Name = "lblHeSoQuyDoi";
            this.lblHeSoQuyDoi.Size = new System.Drawing.Size(94, 17);
            this.lblHeSoQuyDoi.TabIndex = 13;
            this.lblHeSoQuyDoi.Text = "Hệ số quy đổi";
            // 
            // txtHeSoQuyDoi
            // 
            this.txtHeSoQuyDoi.Location = new System.Drawing.Point(210, 350);
            this.txtHeSoQuyDoi.Name = "txtHeSoQuyDoi";
            this.txtHeSoQuyDoi.Size = new System.Drawing.Size(165, 25);
            this.txtHeSoQuyDoi.TabIndex = 14;
            // 
            // MaNVL
            // 
            this.MaNVL.DataPropertyName = "MaNVL";
            this.MaNVL.HeaderText = "Mã NVL";
            this.MaNVL.Name = "MaNVL";
            this.MaNVL.ReadOnly = true;
            // 
            // TenNVL
            // 
            this.TenNVL.DataPropertyName = "TenNVL";
            this.TenNVL.HeaderText = "Tên nguyên vật liệu\n";
            this.TenNVL.Name = "TenNVL";
            this.TenNVL.ReadOnly = true;
            // 
            // SoLuongTon
            // 
            this.SoLuongTon.DataPropertyName = "SoLuongTon";
            this.SoLuongTon.HeaderText = "Số lượng tồn";
            this.SoLuongTon.Name = "SoLuongTon";
            this.SoLuongTon.ReadOnly = true;
            // 
            // MucCanhBao
            // 
            this.MucCanhBao.DataPropertyName = "MucCanhBao";
            this.MucCanhBao.HeaderText = "Mức cảnh báo";
            this.MucCanhBao.Name = "MucCanhBao";
            this.MucCanhBao.ReadOnly = true;
            // 
            // DonViTinh
            // 
            this.DonViTinh.DataPropertyName = "DonViTinh";
            this.DonViTinh.HeaderText = "Đơn vị tính";
            this.DonViTinh.Name = "DonViTinh";
            this.DonViTinh.ReadOnly = true;
            // 
            // DonViTinhQuyDoi
            // 
            this.DonViTinhQuyDoi.DataPropertyName = "DonViTinhQuyDoi";
            this.DonViTinhQuyDoi.HeaderText = "ĐVT công thức";
            this.DonViTinhQuyDoi.Name = "DonViTinhQuyDoi";
            this.DonViTinhQuyDoi.ReadOnly = true;
            // 
            // HeSoQuyDoi
            // 
            this.HeSoQuyDoi.DataPropertyName = "HeSoQuyDoi";
            this.HeSoQuyDoi.HeaderText = "Hệ số quy đổi";
            this.HeSoQuyDoi.Name = "HeSoQuyDoi";
            this.HeSoQuyDoi.ReadOnly = true;
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "Trạng thái";
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi chú";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.ReadOnly = true;
            // 
            // FrmQuanLyKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(239)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.pnlNoiDung);
            this.Controls.Add(this.pnlTieuDe);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmQuanLyKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý kho nguyên vật liệu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.FrmQuanLyKho_Shown);
            this.pnlTieuDe.ResumeLayout(false);
            this.pnlTieuDe.PerformLayout();
            this.pnlNoiDung.ResumeLayout(false);
            this.pnlThongTin.ResumeLayout(false);
            this.pnlThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguyenVatLieu)).EndInit();
            this.pnlTimKiem.ResumeLayout(false);
            this.pnlTimKiem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTieuDe;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblIcon;
        private System.Windows.Forms.Panel pnlNoiDung;
        private System.Windows.Forms.Panel pnlTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.DataGridView dgvNguyenVatLieu;
        private System.Windows.Forms.Panel pnlThongTin;
        private System.Windows.Forms.Label lblMaNVL;
        private System.Windows.Forms.Label lblThongTin;
        private System.Windows.Forms.TextBox txtMaNVL;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.TextBox txtDonViTinh;
        private System.Windows.Forms.TextBox txtMucCanhBao;
        private System.Windows.Forms.TextBox txtSoLuongTon;
        private System.Windows.Forms.TextBox txtTenNVL;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.Label lblTrangThaiNVL;
        private System.Windows.Forms.Label lblDonViTinh;
        private System.Windows.Forms.Label lblMucCanhBao;
        private System.Windows.Forms.Label lblSoLuongTon;
        private System.Windows.Forms.Label lblTenNVL;
        private System.Windows.Forms.ComboBox cboTrangThaiNVL;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label lblDonViTinhQuyDoi;
        private System.Windows.Forms.TextBox txtDonViTinhQuyDoi;
        private System.Windows.Forms.TextBox txtHeSoQuyDoi;
        private System.Windows.Forms.Label lblHeSoQuyDoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNVL;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNVL;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongTon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MucCanhBao;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonViTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonViTinhQuyDoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeSoQuyDoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
    }
}