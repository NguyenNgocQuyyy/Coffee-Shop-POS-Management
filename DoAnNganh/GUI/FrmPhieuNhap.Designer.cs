namespace Đồ_án_ngành.GUI
{
    partial class FrmPhieuNhap
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.lblIcon = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.grpThongTinPhieuNhap = new System.Windows.Forms.GroupBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.cboNhaCungCap = new System.Windows.Forms.ComboBox();
            this.lblNhaCungCap = new System.Windows.Forms.Label();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.lblNgayNhap = new System.Windows.Forms.Label();
            this.txtMaPhieuNhap = new System.Windows.Forms.TextBox();
            this.lblMaPhieuNhap = new System.Windows.Forms.Label();
            this.grpThongTinNguyenVatLieu = new System.Windows.Forms.GroupBox();
            this.cboLoaiMatHang = new System.Windows.Forms.ComboBox();
            this.lblLoaiMatHang = new System.Windows.Forms.Label();
            this.btnThemNguyenVatLieu = new System.Windows.Forms.Button();
            this.nudDonGiaNhap = new System.Windows.Forms.NumericUpDown();
            this.nudSoLuongNhap = new System.Windows.Forms.NumericUpDown();
            this.txtDonViTinh = new System.Windows.Forms.TextBox();
            this.cboNguyenVatLieu = new System.Windows.Forms.ComboBox();
            this.lblDonGiaNhap = new System.Windows.Forms.Label();
            this.lblSoLuongNhap = new System.Windows.Forms.Label();
            this.lblDonViTinh = new System.Windows.Forms.Label();
            this.lblMatHang = new System.Windows.Forms.Label();
            this.grpChiTietPhieuNhap = new System.Windows.Forms.GroupBox();
            this.btnXoaDong = new System.Windows.Forms.Button();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblTongTienText = new System.Windows.Forms.Label();
            this.dgvChiTietPhieuNhap = new System.Windows.Forms.DataGridView();
            this.colMaNVL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenNVL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonViTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoaiMatHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnLuuPhieu = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnLichSu = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.grpThongTinPhieuNhap.SuspendLayout();
            this.grpThongTinNguyenVatLieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDonGiaNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongNhap)).BeginInit();
            this.grpChiTietPhieuNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieuNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(67)))), ((int)(((byte)(45)))));
            this.pnlHeader.Controls.Add(this.lblMoTa);
            this.pnlHeader.Controls.Add(this.lblIcon);
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1450, 105);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoTa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(210)))));
            this.lblMoTa.Location = new System.Drawing.Point(93, 65);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(228, 20);
            this.lblMoTa.TabIndex = 2;
            this.lblMoTa.Text = "Quản lý nhập kho nguyên vật liệu";
            // 
            // lblIcon
            // 
            this.lblIcon.AutoSize = true;
            this.lblIcon.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIcon.ForeColor = System.Drawing.Color.White;
            this.lblIcon.Location = new System.Drawing.Point(9, 22);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(89, 65);
            this.lblIcon.TabIndex = 1;
            this.lblIcon.Text = "📃";
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(90, 22);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(600, 40);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "PHIẾU NHẬP NGUYÊN VẬT LIỆU";
            // 
            // grpThongTinPhieuNhap
            // 
            this.grpThongTinPhieuNhap.Controls.Add(this.btnLichSu);
            this.grpThongTinPhieuNhap.Controls.Add(this.txtGhiChu);
            this.grpThongTinPhieuNhap.Controls.Add(this.lblGhiChu);
            this.grpThongTinPhieuNhap.Controls.Add(this.cboNhaCungCap);
            this.grpThongTinPhieuNhap.Controls.Add(this.lblNhaCungCap);
            this.grpThongTinPhieuNhap.Controls.Add(this.dtpNgayNhap);
            this.grpThongTinPhieuNhap.Controls.Add(this.lblNgayNhap);
            this.grpThongTinPhieuNhap.Controls.Add(this.txtMaPhieuNhap);
            this.grpThongTinPhieuNhap.Controls.Add(this.lblMaPhieuNhap);
            this.grpThongTinPhieuNhap.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpThongTinPhieuNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.grpThongTinPhieuNhap.Location = new System.Drawing.Point(20, 125);
            this.grpThongTinPhieuNhap.Name = "grpThongTinPhieuNhap";
            this.grpThongTinPhieuNhap.Size = new System.Drawing.Size(690, 285);
            this.grpThongTinPhieuNhap.TabIndex = 1;
            this.grpThongTinPhieuNhap.TabStop = false;
            this.grpThongTinPhieuNhap.Text = "Thông tin phiếu nhập";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(175, 177);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGhiChu.Size = new System.Drawing.Size(450, 70);
            this.txtGhiChu.TabIndex = 7;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(30, 180);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(59, 17);
            this.lblGhiChu.TabIndex = 6;
            this.lblGhiChu.Text = "Ghi chú:";
            // 
            // cboNhaCungCap
            // 
            this.cboNhaCungCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhaCungCap.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNhaCungCap.FormattingEnabled = true;
            this.cboNhaCungCap.Location = new System.Drawing.Point(175, 135);
            this.cboNhaCungCap.Name = "cboNhaCungCap";
            this.cboNhaCungCap.Size = new System.Drawing.Size(450, 25);
            this.cboNhaCungCap.TabIndex = 5;
            // 
            // lblNhaCungCap
            // 
            this.lblNhaCungCap.AutoSize = true;
            this.lblNhaCungCap.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhaCungCap.Location = new System.Drawing.Point(30, 135);
            this.lblNhaCungCap.Name = "lblNhaCungCap";
            this.lblNhaCungCap.Size = new System.Drawing.Size(96, 17);
            this.lblNhaCungCap.TabIndex = 4;
            this.lblNhaCungCap.Text = "Nhà cung cấp:";
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayNhap.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayNhap.Location = new System.Drawing.Point(175, 87);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(230, 25);
            this.dtpNgayNhap.TabIndex = 3;
            // 
            // lblNgayNhap
            // 
            this.lblNgayNhap.AutoSize = true;
            this.lblNgayNhap.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayNhap.Location = new System.Drawing.Point(30, 90);
            this.lblNgayNhap.Name = "lblNgayNhap";
            this.lblNgayNhap.Size = new System.Drawing.Size(79, 17);
            this.lblNgayNhap.TabIndex = 2;
            this.lblNgayNhap.Text = "Ngày nhập:";
            // 
            // txtMaPhieuNhap
            // 
            this.txtMaPhieuNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtMaPhieuNhap.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPhieuNhap.Location = new System.Drawing.Point(175, 42);
            this.txtMaPhieuNhap.Name = "txtMaPhieuNhap";
            this.txtMaPhieuNhap.ReadOnly = true;
            this.txtMaPhieuNhap.Size = new System.Drawing.Size(230, 25);
            this.txtMaPhieuNhap.TabIndex = 1;
            // 
            // lblMaPhieuNhap
            // 
            this.lblMaPhieuNhap.AutoSize = true;
            this.lblMaPhieuNhap.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaPhieuNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(45)))), ((int)(((byte)(35)))));
            this.lblMaPhieuNhap.Location = new System.Drawing.Point(30, 45);
            this.lblMaPhieuNhap.Name = "lblMaPhieuNhap";
            this.lblMaPhieuNhap.Size = new System.Drawing.Size(105, 17);
            this.lblMaPhieuNhap.TabIndex = 0;
            this.lblMaPhieuNhap.Text = "Mã phiếu nhập:";
            // 
            // grpThongTinNguyenVatLieu
            // 
            this.grpThongTinNguyenVatLieu.Controls.Add(this.cboLoaiMatHang);
            this.grpThongTinNguyenVatLieu.Controls.Add(this.lblLoaiMatHang);
            this.grpThongTinNguyenVatLieu.Controls.Add(this.btnThemNguyenVatLieu);
            this.grpThongTinNguyenVatLieu.Controls.Add(this.nudDonGiaNhap);
            this.grpThongTinNguyenVatLieu.Controls.Add(this.nudSoLuongNhap);
            this.grpThongTinNguyenVatLieu.Controls.Add(this.txtDonViTinh);
            this.grpThongTinNguyenVatLieu.Controls.Add(this.cboNguyenVatLieu);
            this.grpThongTinNguyenVatLieu.Controls.Add(this.lblDonGiaNhap);
            this.grpThongTinNguyenVatLieu.Controls.Add(this.lblSoLuongNhap);
            this.grpThongTinNguyenVatLieu.Controls.Add(this.lblDonViTinh);
            this.grpThongTinNguyenVatLieu.Controls.Add(this.lblMatHang);
            this.grpThongTinNguyenVatLieu.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpThongTinNguyenVatLieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.grpThongTinNguyenVatLieu.Location = new System.Drawing.Point(730, 125);
            this.grpThongTinNguyenVatLieu.Name = "grpThongTinNguyenVatLieu";
            this.grpThongTinNguyenVatLieu.Size = new System.Drawing.Size(700, 285);
            this.grpThongTinNguyenVatLieu.TabIndex = 2;
            this.grpThongTinNguyenVatLieu.TabStop = false;
            this.grpThongTinNguyenVatLieu.Text = "Thông tin nguyên vật liệu";
            // 
            // cboLoaiMatHang
            // 
            this.cboLoaiMatHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiMatHang.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLoaiMatHang.FormattingEnabled = true;
            this.cboLoaiMatHang.Location = new System.Drawing.Point(175, 174);
            this.cboLoaiMatHang.Name = "cboLoaiMatHang";
            this.cboLoaiMatHang.Size = new System.Drawing.Size(180, 25);
            this.cboLoaiMatHang.TabIndex = 10;
            this.cboLoaiMatHang.SelectedIndexChanged += new System.EventHandler(this.cboLoaiMatHang_SelectedIndexChanged);
            // 
            // lblLoaiMatHang
            // 
            this.lblLoaiMatHang.AutoSize = true;
            this.lblLoaiMatHang.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiMatHang.Location = new System.Drawing.Point(29, 185);
            this.lblLoaiMatHang.Name = "lblLoaiMatHang";
            this.lblLoaiMatHang.Size = new System.Drawing.Size(101, 17);
            this.lblLoaiMatHang.TabIndex = 9;
            this.lblLoaiMatHang.Text = "Loại mặt hàng:";
            // 
            // btnThemNguyenVatLieu
            // 
            this.btnThemNguyenVatLieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(67)))), ((int)(((byte)(45)))));
            this.btnThemNguyenVatLieu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemNguyenVatLieu.FlatAppearance.BorderSize = 0;
            this.btnThemNguyenVatLieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemNguyenVatLieu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemNguyenVatLieu.ForeColor = System.Drawing.Color.White;
            this.btnThemNguyenVatLieu.Location = new System.Drawing.Point(177, 225);
            this.btnThemNguyenVatLieu.Name = "btnThemNguyenVatLieu";
            this.btnThemNguyenVatLieu.Size = new System.Drawing.Size(300, 45);
            this.btnThemNguyenVatLieu.TabIndex = 8;
            this.btnThemNguyenVatLieu.Text = "➕️ THÊM VÀO PHIẾU";
            this.btnThemNguyenVatLieu.UseVisualStyleBackColor = false;
            this.btnThemNguyenVatLieu.Click += new System.EventHandler(this.btnThemNguyenVatLieu_Click);
            // 
            // nudDonGiaNhap
            // 
            this.nudDonGiaNhap.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDonGiaNhap.Location = new System.Drawing.Point(485, 132);
            this.nudDonGiaNhap.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudDonGiaNhap.Name = "nudDonGiaNhap";
            this.nudDonGiaNhap.Size = new System.Drawing.Size(130, 25);
            this.nudDonGiaNhap.TabIndex = 7;
            this.nudDonGiaNhap.ThousandsSeparator = true;
            // 
            // nudSoLuongNhap
            // 
            this.nudSoLuongNhap.DecimalPlaces = 2;
            this.nudSoLuongNhap.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSoLuongNhap.Location = new System.Drawing.Point(175, 132);
            this.nudSoLuongNhap.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudSoLuongNhap.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoLuongNhap.Name = "nudSoLuongNhap";
            this.nudSoLuongNhap.Size = new System.Drawing.Size(180, 25);
            this.nudSoLuongNhap.TabIndex = 6;
            this.nudSoLuongNhap.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtDonViTinh
            // 
            this.txtDonViTinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtDonViTinh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDonViTinh.Location = new System.Drawing.Point(175, 87);
            this.txtDonViTinh.Name = "txtDonViTinh";
            this.txtDonViTinh.ReadOnly = true;
            this.txtDonViTinh.Size = new System.Drawing.Size(180, 25);
            this.txtDonViTinh.TabIndex = 5;
            // 
            // cboNguyenVatLieu
            // 
            this.cboNguyenVatLieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNguyenVatLieu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNguyenVatLieu.FormattingEnabled = true;
            this.cboNguyenVatLieu.Location = new System.Drawing.Point(175, 42);
            this.cboNguyenVatLieu.Name = "cboNguyenVatLieu";
            this.cboNguyenVatLieu.Size = new System.Drawing.Size(400, 25);
            this.cboNguyenVatLieu.TabIndex = 4;
            this.cboNguyenVatLieu.SelectedIndexChanged += new System.EventHandler(this.cboNguyenVatLieu_SelectedIndexChanged);
            // 
            // lblDonGiaNhap
            // 
            this.lblDonGiaNhap.AutoSize = true;
            this.lblDonGiaNhap.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonGiaNhap.Location = new System.Drawing.Point(375, 135);
            this.lblDonGiaNhap.Name = "lblDonGiaNhap";
            this.lblDonGiaNhap.Size = new System.Drawing.Size(96, 17);
            this.lblDonGiaNhap.TabIndex = 3;
            this.lblDonGiaNhap.Text = "Đơn giá nhập:";
            // 
            // lblSoLuongNhap
            // 
            this.lblSoLuongNhap.AutoSize = true;
            this.lblSoLuongNhap.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuongNhap.Location = new System.Drawing.Point(30, 135);
            this.lblSoLuongNhap.Name = "lblSoLuongNhap";
            this.lblSoLuongNhap.Size = new System.Drawing.Size(103, 17);
            this.lblSoLuongNhap.TabIndex = 2;
            this.lblSoLuongNhap.Text = "Số lượng nhập:";
            // 
            // lblDonViTinh
            // 
            this.lblDonViTinh.AutoSize = true;
            this.lblDonViTinh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonViTinh.Location = new System.Drawing.Point(30, 90);
            this.lblDonViTinh.Name = "lblDonViTinh";
            this.lblDonViTinh.Size = new System.Drawing.Size(82, 17);
            this.lblDonViTinh.TabIndex = 1;
            this.lblDonViTinh.Text = "Đơn vị tính:";
            // 
            // lblMatHang
            // 
            this.lblMatHang.AutoSize = true;
            this.lblMatHang.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatHang.Location = new System.Drawing.Point(30, 45);
            this.lblMatHang.Name = "lblMatHang";
            this.lblMatHang.Size = new System.Drawing.Size(71, 17);
            this.lblMatHang.TabIndex = 0;
            this.lblMatHang.Text = "Mặt hàng:";
            // 
            // grpChiTietPhieuNhap
            // 
            this.grpChiTietPhieuNhap.Controls.Add(this.btnXoaDong);
            this.grpChiTietPhieuNhap.Controls.Add(this.lblTongTien);
            this.grpChiTietPhieuNhap.Controls.Add(this.lblTongTienText);
            this.grpChiTietPhieuNhap.Controls.Add(this.dgvChiTietPhieuNhap);
            this.grpChiTietPhieuNhap.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpChiTietPhieuNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.grpChiTietPhieuNhap.Location = new System.Drawing.Point(20, 425);
            this.grpChiTietPhieuNhap.Name = "grpChiTietPhieuNhap";
            this.grpChiTietPhieuNhap.Size = new System.Drawing.Size(1325, 210);
            this.grpChiTietPhieuNhap.TabIndex = 3;
            this.grpChiTietPhieuNhap.TabStop = false;
            this.grpChiTietPhieuNhap.Text = "Chi tiết phiếu nhập";
            // 
            // btnXoaDong
            // 
            this.btnXoaDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(80)))), ((int)(((byte)(70)))));
            this.btnXoaDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaDong.FlatAppearance.BorderSize = 0;
            this.btnXoaDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaDong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaDong.ForeColor = System.Drawing.Color.White;
            this.btnXoaDong.Location = new System.Drawing.Point(20, 165);
            this.btnXoaDong.Name = "btnXoaDong";
            this.btnXoaDong.Size = new System.Drawing.Size(130, 38);
            this.btnXoaDong.TabIndex = 3;
            this.btnXoaDong.Text = "XÓA DÒNG";
            this.btnXoaDong.UseVisualStyleBackColor = false;
            this.btnXoaDong.Click += new System.EventHandler(this.btnXoaDong_Click);
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(67)))), ((int)(((byte)(45)))));
            this.lblTongTien.Location = new System.Drawing.Point(1030, 160);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(74, 28);
            this.lblTongTien.TabIndex = 2;
            this.lblTongTien.Text = "0 VNĐ";
            this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTongTienText
            // 
            this.lblTongTienText.AutoSize = true;
            this.lblTongTienText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienText.Location = new System.Drawing.Point(930, 165);
            this.lblTongTienText.Name = "lblTongTienText";
            this.lblTongTienText.Size = new System.Drawing.Size(87, 21);
            this.lblTongTienText.TabIndex = 1;
            this.lblTongTienText.Text = "Tổng tiền:";
            // 
            // dgvChiTietPhieuNhap
            // 
            this.dgvChiTietPhieuNhap.AllowUserToAddRows = false;
            this.dgvChiTietPhieuNhap.AllowUserToDeleteRows = false;
            this.dgvChiTietPhieuNhap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietPhieuNhap.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietPhieuNhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaNVL,
            this.colTenNVL,
            this.colDonViTinh,
            this.colSoLuong,
            this.colDonGia,
            this.colThanhTien,
            this.colLoaiMatHang});
            this.dgvChiTietPhieuNhap.Location = new System.Drawing.Point(20, 25);
            this.dgvChiTietPhieuNhap.MultiSelect = false;
            this.dgvChiTietPhieuNhap.Name = "dgvChiTietPhieuNhap";
            this.dgvChiTietPhieuNhap.RowHeadersVisible = false;
            this.dgvChiTietPhieuNhap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietPhieuNhap.Size = new System.Drawing.Size(1285, 130);
            this.dgvChiTietPhieuNhap.TabIndex = 0;
            this.dgvChiTietPhieuNhap.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvChiTietPhieuNhap_CellBeginEdit);
            this.dgvChiTietPhieuNhap.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTietPhieuNhap_CellDoubleClick);
            this.dgvChiTietPhieuNhap.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTietPhieuNhap_CellEndEdit);
            // 
            // colMaNVL
            // 
            this.colMaNVL.FillWeight = 15F;
            this.colMaNVL.HeaderText = "Mã mặt hàng";
            this.colMaNVL.Name = "colMaNVL";
            this.colMaNVL.ReadOnly = true;
            // 
            // colTenNVL
            // 
            this.colTenNVL.FillWeight = 30F;
            this.colTenNVL.HeaderText = "Tên mặt hàng";
            this.colTenNVL.Name = "colTenNVL";
            this.colTenNVL.ReadOnly = true;
            // 
            // colDonViTinh
            // 
            this.colDonViTinh.FillWeight = 15F;
            this.colDonViTinh.HeaderText = "Đơn vị tính";
            this.colDonViTinh.Name = "colDonViTinh";
            this.colDonViTinh.ReadOnly = true;
            // 
            // colSoLuong
            // 
            this.colSoLuong.FillWeight = 15F;
            this.colSoLuong.HeaderText = "Số lượng";
            this.colSoLuong.Name = "colSoLuong";
            // 
            // colDonGia
            // 
            this.colDonGia.FillWeight = 20F;
            this.colDonGia.HeaderText = "Đơn giá";
            this.colDonGia.Name = "colDonGia";
            this.colDonGia.ReadOnly = true;
            // 
            // colThanhTien
            // 
            this.colThanhTien.FillWeight = 25F;
            this.colThanhTien.HeaderText = "Thành tiền";
            this.colThanhTien.Name = "colThanhTien";
            this.colThanhTien.ReadOnly = true;
            // 
            // colLoaiMatHang
            // 
            this.colLoaiMatHang.HeaderText = "Loại mặt hàng";
            this.colLoaiMatHang.Name = "colLoaiMatHang";
            this.colLoaiMatHang.ReadOnly = true;
            this.colLoaiMatHang.Visible = false;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(190)))), ((int)(((byte)(170)))));
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.btnLamMoi.Location = new System.Drawing.Point(826, 690);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(140, 45);
            this.btnLamMoi.TabIndex = 4;
            this.btnLamMoi.Text = "LÀM MỚI";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnLuuPhieu
            // 
            this.btnLuuPhieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuuPhieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(67)))), ((int)(((byte)(45)))));
            this.btnLuuPhieu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuuPhieu.FlatAppearance.BorderSize = 0;
            this.btnLuuPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuPhieu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuPhieu.ForeColor = System.Drawing.Color.White;
            this.btnLuuPhieu.Location = new System.Drawing.Point(981, 690);
            this.btnLuuPhieu.Name = "btnLuuPhieu";
            this.btnLuuPhieu.Size = new System.Drawing.Size(160, 45);
            this.btnLuuPhieu.TabIndex = 5;
            this.btnLuuPhieu.Text = "LƯU PHIẾU";
            this.btnLuuPhieu.UseVisualStyleBackColor = false;
            this.btnLuuPhieu.Click += new System.EventHandler(this.btnLuuPhieu_Click);
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btnDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(1156, 690);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(140, 45);
            this.btnDong.TabIndex = 6;
            this.btnDong.Text = "ĐÓNG";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnLichSu
            // 
            this.btnLichSu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(113)))), ((int)(((byte)(78)))));
            this.btnLichSu.FlatAppearance.BorderSize = 0;
            this.btnLichSu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLichSu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLichSu.ForeColor = System.Drawing.Color.White;
            this.btnLichSu.Location = new System.Drawing.Point(455, 42);
            this.btnLichSu.Name = "btnLichSu";
            this.btnLichSu.Size = new System.Drawing.Size(140, 45);
            this.btnLichSu.TabIndex = 10;
            this.btnLichSu.Text = "LỊCH SỬ";
            this.btnLichSu.UseVisualStyleBackColor = false;
            this.btnLichSu.Click += new System.EventHandler(this.btnLichSu_Click);
            // 
            // FrmPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnLuuPhieu);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.grpChiTietPhieuNhap);
            this.Controls.Add(this.grpThongTinNguyenVatLieu);
            this.Controls.Add(this.grpThongTinPhieuNhap);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPhieuNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu nhập nguyên vật liệu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPhieuNhap_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpThongTinPhieuNhap.ResumeLayout(false);
            this.grpThongTinPhieuNhap.PerformLayout();
            this.grpThongTinNguyenVatLieu.ResumeLayout(false);
            this.grpThongTinNguyenVatLieu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDonGiaNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongNhap)).EndInit();
            this.grpChiTietPhieuNhap.ResumeLayout(false);
            this.grpChiTietPhieuNhap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieuNhap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblIcon;
        private System.Windows.Forms.GroupBox grpThongTinPhieuNhap;
        private System.Windows.Forms.GroupBox grpThongTinNguyenVatLieu;
        private System.Windows.Forms.GroupBox grpChiTietPhieuNhap;
        private System.Windows.Forms.TextBox txtMaPhieuNhap;
        private System.Windows.Forms.Label lblMaPhieuNhap;
        private System.Windows.Forms.Label lblNgayNhap;
        private System.Windows.Forms.Label lblNhaCungCap;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.ComboBox cboNhaCungCap;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblDonViTinh;
        private System.Windows.Forms.Label lblMatHang;
        private System.Windows.Forms.Label lblDonGiaNhap;
        private System.Windows.Forms.Label lblSoLuongNhap;
        private System.Windows.Forms.NumericUpDown nudDonGiaNhap;
        private System.Windows.Forms.NumericUpDown nudSoLuongNhap;
        private System.Windows.Forms.TextBox txtDonViTinh;
        private System.Windows.Forms.ComboBox cboNguyenVatLieu;
        private System.Windows.Forms.Button btnThemNguyenVatLieu;
        private System.Windows.Forms.DataGridView dgvChiTietPhieuNhap;
        private System.Windows.Forms.Button btnXoaDong;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label lblTongTienText;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnLuuPhieu;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.ComboBox cboLoaiMatHang;
        private System.Windows.Forms.Label lblLoaiMatHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNVL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenNVL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonViTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiMatHang;
        private System.Windows.Forms.Button btnLichSu;
    }
}