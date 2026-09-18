namespace Đồ_án_ngành.GUI
{
    partial class FrmPhieuXuat
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
            this.lblIcon = new System.Windows.Forms.Label();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.grpThongTinPhieuXuat = new System.Windows.Forms.GroupBox();
            this.lblGiaTriHaoHut = new System.Windows.Forms.Label();
            this.chkLaHaoHut = new System.Windows.Forms.CheckBox();
            this.lblLyDoXuat = new System.Windows.Forms.Label();
            this.txtLyDoXuat = new System.Windows.Forms.TextBox();
            this.dtpNgayXuat = new System.Windows.Forms.DateTimePicker();
            this.lblNgayXuat = new System.Windows.Forms.Label();
            this.txtMaPhieuXuat = new System.Windows.Forms.TextBox();
            this.lblMaPhieuXuat = new System.Windows.Forms.Label();
            this.grpThemMatHang = new System.Windows.Forms.GroupBox();
            this.lblHuongDan = new System.Windows.Forms.Label();
            this.btnThemMatHang = new System.Windows.Forms.Button();
            this.nudSoLuongXuat = new System.Windows.Forms.NumericUpDown();
            this.lblSoLuongXuat = new System.Windows.Forms.Label();
            this.cboMatHang = new System.Windows.Forms.ComboBox();
            this.lblMatHang = new System.Windows.Forms.Label();
            this.cboLoaiMatHang = new System.Windows.Forms.ComboBox();
            this.lblLoaiMatHang = new System.Windows.Forms.Label();
            this.grpDanhSachXuat = new System.Windows.Forms.GroupBox();
            this.dgvChiTietXuat = new System.Windows.Forms.DataGridView();
            this.colLoaiMatHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaMatHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenMatHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonViTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXoaDong = new System.Windows.Forms.Button();
            this.btnLuuPhieu = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnLichSu = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.grpThongTinPhieuXuat.SuspendLayout();
            this.grpThemMatHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongXuat)).BeginInit();
            this.grpDanhSachXuat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietXuat)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(242)))));
            this.pnlHeader.Controls.Add(this.lblIcon);
            this.pnlHeader.Controls.Add(this.lblMoTa);
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1358, 115);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblIcon
            // 
            this.lblIcon.AutoSize = true;
            this.lblIcon.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIcon.Location = new System.Drawing.Point(29, 25);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(94, 65);
            this.lblIcon.TabIndex = 2;
            this.lblIcon.Text = "📜";
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.BackColor = System.Drawing.Color.Transparent;
            this.lblMoTa.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoTa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(65)))), ((int)(((byte)(50)))));
            this.lblMoTa.Location = new System.Drawing.Point(118, 70);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(272, 20);
            this.lblMoTa.TabIndex = 1;
            this.lblMoTa.Text = "Xuất nguyên vật liệu / Topping khỏi kho";
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.BackColor = System.Drawing.Color.Transparent;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 23.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(25)))));
            this.lblTieuDe.Location = new System.Drawing.Point(115, 24);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(239, 42);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Phiếu xuất kho";
            // 
            // grpThongTinPhieuXuat
            // 
            this.grpThongTinPhieuXuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(242)))));
            this.grpThongTinPhieuXuat.Controls.Add(this.lblGiaTriHaoHut);
            this.grpThongTinPhieuXuat.Controls.Add(this.chkLaHaoHut);
            this.grpThongTinPhieuXuat.Controls.Add(this.lblLyDoXuat);
            this.grpThongTinPhieuXuat.Controls.Add(this.txtLyDoXuat);
            this.grpThongTinPhieuXuat.Controls.Add(this.dtpNgayXuat);
            this.grpThongTinPhieuXuat.Controls.Add(this.lblNgayXuat);
            this.grpThongTinPhieuXuat.Controls.Add(this.txtMaPhieuXuat);
            this.grpThongTinPhieuXuat.Controls.Add(this.lblMaPhieuXuat);
            this.grpThongTinPhieuXuat.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpThongTinPhieuXuat.Location = new System.Drawing.Point(20, 130);
            this.grpThongTinPhieuXuat.Name = "grpThongTinPhieuXuat";
            this.grpThongTinPhieuXuat.Size = new System.Drawing.Size(560, 245);
            this.grpThongTinPhieuXuat.TabIndex = 1;
            this.grpThongTinPhieuXuat.TabStop = false;
            this.grpThongTinPhieuXuat.Text = "Thông tin phiếu xuất";
            // 
            // lblGiaTriHaoHut
            // 
            this.lblGiaTriHaoHut.AutoSize = true;
            this.lblGiaTriHaoHut.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiaTriHaoHut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(101)))), ((int)(((byte)(79)))));
            this.lblGiaTriHaoHut.Location = new System.Drawing.Point(300, 210);
            this.lblGiaTriHaoHut.Name = "lblGiaTriHaoHut";
            this.lblGiaTriHaoHut.Size = new System.Drawing.Size(146, 17);
            this.lblGiaTriHaoHut.TabIndex = 9;
            this.lblGiaTriHaoHut.Text = "Giá trị hao hụt: 0 VNĐ";
            this.lblGiaTriHaoHut.Visible = false;
            // 
            // chkLaHaoHut
            // 
            this.chkLaHaoHut.AutoSize = true;
            this.chkLaHaoHut.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLaHaoHut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(101)))), ((int)(((byte)(79)))));
            this.chkLaHaoHut.Location = new System.Drawing.Point(125, 210);
            this.chkLaHaoHut.Name = "chkLaHaoHut";
            this.chkLaHaoHut.Size = new System.Drawing.Size(133, 21);
            this.chkLaHaoHut.TabIndex = 8;
            this.chkLaHaoHut.Text = "Tính vào hao hụt";
            this.chkLaHaoHut.UseVisualStyleBackColor = true;
            this.chkLaHaoHut.CheckedChanged += new System.EventHandler(this.chkLaHaoHut_CheckedChanged);
            // 
            // lblLyDoXuat
            // 
            this.lblLyDoXuat.AutoSize = true;
            this.lblLyDoXuat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLyDoXuat.Location = new System.Drawing.Point(20, 95);
            this.lblLyDoXuat.Name = "lblLyDoXuat";
            this.lblLyDoXuat.Size = new System.Drawing.Size(73, 17);
            this.lblLyDoXuat.TabIndex = 7;
            this.lblLyDoXuat.Text = "Lý do xuất";
            // 
            // txtLyDoXuat
            // 
            this.txtLyDoXuat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLyDoXuat.Location = new System.Drawing.Point(125, 90);
            this.txtLyDoXuat.Multiline = true;
            this.txtLyDoXuat.Name = "txtLyDoXuat";
            this.txtLyDoXuat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLyDoXuat.Size = new System.Drawing.Size(410, 110);
            this.txtLyDoXuat.TabIndex = 6;
            // 
            // dtpNgayXuat
            // 
            this.dtpNgayXuat.CalendarFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayXuat.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayXuat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayXuat.Location = new System.Drawing.Point(375, 43);
            this.dtpNgayXuat.Name = "dtpNgayXuat";
            this.dtpNgayXuat.Size = new System.Drawing.Size(160, 27);
            this.dtpNgayXuat.TabIndex = 3;
            // 
            // lblNgayXuat
            // 
            this.lblNgayXuat.AutoSize = true;
            this.lblNgayXuat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayXuat.Location = new System.Drawing.Point(300, 48);
            this.lblNgayXuat.Name = "lblNgayXuat";
            this.lblNgayXuat.Size = new System.Drawing.Size(71, 17);
            this.lblNgayXuat.TabIndex = 2;
            this.lblNgayXuat.Text = "Ngày xuất";
            // 
            // txtMaPhieuXuat
            // 
            this.txtMaPhieuXuat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPhieuXuat.Location = new System.Drawing.Point(125, 43);
            this.txtMaPhieuXuat.Name = "txtMaPhieuXuat";
            this.txtMaPhieuXuat.ReadOnly = true;
            this.txtMaPhieuXuat.Size = new System.Drawing.Size(150, 25);
            this.txtMaPhieuXuat.TabIndex = 1;
            // 
            // lblMaPhieuXuat
            // 
            this.lblMaPhieuXuat.AutoSize = true;
            this.lblMaPhieuXuat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaPhieuXuat.Location = new System.Drawing.Point(20, 48);
            this.lblMaPhieuXuat.Name = "lblMaPhieuXuat";
            this.lblMaPhieuXuat.Size = new System.Drawing.Size(97, 17);
            this.lblMaPhieuXuat.TabIndex = 0;
            this.lblMaPhieuXuat.Text = "Mã phiếu xuất";
            // 
            // grpThemMatHang
            // 
            this.grpThemMatHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(242)))));
            this.grpThemMatHang.Controls.Add(this.lblHuongDan);
            this.grpThemMatHang.Controls.Add(this.btnThemMatHang);
            this.grpThemMatHang.Controls.Add(this.nudSoLuongXuat);
            this.grpThemMatHang.Controls.Add(this.lblSoLuongXuat);
            this.grpThemMatHang.Controls.Add(this.cboMatHang);
            this.grpThemMatHang.Controls.Add(this.lblMatHang);
            this.grpThemMatHang.Controls.Add(this.cboLoaiMatHang);
            this.grpThemMatHang.Controls.Add(this.lblLoaiMatHang);
            this.grpThemMatHang.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpThemMatHang.Location = new System.Drawing.Point(600, 130);
            this.grpThemMatHang.Name = "grpThemMatHang";
            this.grpThemMatHang.Size = new System.Drawing.Size(560, 245);
            this.grpThemMatHang.TabIndex = 2;
            this.grpThemMatHang.TabStop = false;
            this.grpThemMatHang.Text = "Tìm và thêm nguyên liệu / Topping";
            // 
            // lblHuongDan
            // 
            this.lblHuongDan.AutoSize = true;
            this.lblHuongDan.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHuongDan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(100)))), ((int)(((byte)(85)))));
            this.lblHuongDan.Location = new System.Drawing.Point(20, 195);
            this.lblHuongDan.Name = "lblHuongDan";
            this.lblHuongDan.Size = new System.Drawing.Size(338, 17);
            this.lblHuongDan.TabIndex = 7;
            this.lblHuongDan.Text = "Chọn loại mặt hàng, mặt hàng và số lượng cần xuất.";
            // 
            // btnThemMatHang
            // 
            this.btnThemMatHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(67)))), ((int)(((byte)(45)))));
            this.btnThemMatHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemMatHang.FlatAppearance.BorderSize = 0;
            this.btnThemMatHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemMatHang.ForeColor = System.Drawing.Color.White;
            this.btnThemMatHang.Location = new System.Drawing.Point(315, 133);
            this.btnThemMatHang.Name = "btnThemMatHang";
            this.btnThemMatHang.Size = new System.Drawing.Size(220, 35);
            this.btnThemMatHang.TabIndex = 6;
            this.btnThemMatHang.Text = "➕ Thêm vào danh sách  ";
            this.btnThemMatHang.UseVisualStyleBackColor = false;
            this.btnThemMatHang.Click += new System.EventHandler(this.btnThemMatHang_Click);
            // 
            // nudSoLuongXuat
            // 
            this.nudSoLuongXuat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSoLuongXuat.Location = new System.Drawing.Point(145, 135);
            this.nudSoLuongXuat.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudSoLuongXuat.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoLuongXuat.Name = "nudSoLuongXuat";
            this.nudSoLuongXuat.Size = new System.Drawing.Size(120, 25);
            this.nudSoLuongXuat.TabIndex = 5;
            this.nudSoLuongXuat.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblSoLuongXuat
            // 
            this.lblSoLuongXuat.AutoSize = true;
            this.lblSoLuongXuat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuongXuat.Location = new System.Drawing.Point(20, 140);
            this.lblSoLuongXuat.Name = "lblSoLuongXuat";
            this.lblSoLuongXuat.Size = new System.Drawing.Size(95, 17);
            this.lblSoLuongXuat.TabIndex = 4;
            this.lblSoLuongXuat.Text = "Số lượng xuất";
            // 
            // cboMatHang
            // 
            this.cboMatHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMatHang.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMatHang.FormattingEnabled = true;
            this.cboMatHang.Location = new System.Drawing.Point(145, 90);
            this.cboMatHang.Name = "cboMatHang";
            this.cboMatHang.Size = new System.Drawing.Size(390, 25);
            this.cboMatHang.TabIndex = 3;
            // 
            // lblMatHang
            // 
            this.lblMatHang.AutoSize = true;
            this.lblMatHang.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatHang.Location = new System.Drawing.Point(20, 95);
            this.lblMatHang.Name = "lblMatHang";
            this.lblMatHang.Size = new System.Drawing.Size(67, 17);
            this.lblMatHang.TabIndex = 2;
            this.lblMatHang.Text = "Mặt hàng";
            // 
            // cboLoaiMatHang
            // 
            this.cboLoaiMatHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiMatHang.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLoaiMatHang.FormattingEnabled = true;
            this.cboLoaiMatHang.Location = new System.Drawing.Point(145, 45);
            this.cboLoaiMatHang.Name = "cboLoaiMatHang";
            this.cboLoaiMatHang.Size = new System.Drawing.Size(390, 25);
            this.cboLoaiMatHang.TabIndex = 1;
            this.cboLoaiMatHang.SelectedIndexChanged += new System.EventHandler(this.cboLoaiMatHang_SelectedIndexChanged);
            // 
            // lblLoaiMatHang
            // 
            this.lblLoaiMatHang.AutoSize = true;
            this.lblLoaiMatHang.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiMatHang.Location = new System.Drawing.Point(20, 50);
            this.lblLoaiMatHang.Name = "lblLoaiMatHang";
            this.lblLoaiMatHang.Size = new System.Drawing.Size(97, 17);
            this.lblLoaiMatHang.TabIndex = 0;
            this.lblLoaiMatHang.Text = "Loại mặt hàng";
            // 
            // grpDanhSachXuat
            // 
            this.grpDanhSachXuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(242)))));
            this.grpDanhSachXuat.Controls.Add(this.dgvChiTietXuat);
            this.grpDanhSachXuat.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDanhSachXuat.Location = new System.Drawing.Point(20, 390);
            this.grpDanhSachXuat.Name = "grpDanhSachXuat";
            this.grpDanhSachXuat.Size = new System.Drawing.Size(1140, 235);
            this.grpDanhSachXuat.TabIndex = 3;
            this.grpDanhSachXuat.TabStop = false;
            this.grpDanhSachXuat.Text = "Danh sách mặt hàng xuất";
            // 
            // dgvChiTietXuat
            // 
            this.dgvChiTietXuat.AllowUserToAddRows = false;
            this.dgvChiTietXuat.AllowUserToDeleteRows = false;
            this.dgvChiTietXuat.AllowUserToResizeRows = false;
            this.dgvChiTietXuat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietXuat.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietXuat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChiTietXuat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietXuat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLoaiMatHang,
            this.colMaMatHang,
            this.colTenMatHang,
            this.colSoLuong,
            this.colDonViTinh});
            this.dgvChiTietXuat.Location = new System.Drawing.Point(15, 35);
            this.dgvChiTietXuat.MultiSelect = false;
            this.dgvChiTietXuat.Name = "dgvChiTietXuat";
            this.dgvChiTietXuat.RowHeadersVisible = false;
            this.dgvChiTietXuat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietXuat.Size = new System.Drawing.Size(1110, 180);
            this.dgvChiTietXuat.TabIndex = 0;
            this.dgvChiTietXuat.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvChiTietXuat_CellBeginEdit);
            this.dgvChiTietXuat.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTietXuat_CellDoubleClick);
            this.dgvChiTietXuat.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTietXuat_CellEndEdit);
            // 
            // colLoaiMatHang
            // 
            this.colLoaiMatHang.FillWeight = 110F;
            this.colLoaiMatHang.HeaderText = "Loại mặt hàng";
            this.colLoaiMatHang.Name = "colLoaiMatHang";
            this.colLoaiMatHang.ReadOnly = true;
            // 
            // colMaMatHang
            // 
            this.colMaMatHang.HeaderText = "Mã mặt hàng";
            this.colMaMatHang.Name = "colMaMatHang";
            this.colMaMatHang.ReadOnly = true;
            // 
            // colTenMatHang
            // 
            this.colTenMatHang.FillWeight = 180F;
            this.colTenMatHang.HeaderText = "Tên mặt hàng";
            this.colTenMatHang.Name = "colTenMatHang";
            this.colTenMatHang.ReadOnly = true;
            // 
            // colSoLuong
            // 
            this.colSoLuong.FillWeight = 80F;
            this.colSoLuong.HeaderText = "Số lượng xuất";
            this.colSoLuong.Name = "colSoLuong";
            // 
            // colDonViTinh
            // 
            this.colDonViTinh.FillWeight = 90F;
            this.colDonViTinh.HeaderText = "Đơn vị tính";
            this.colDonViTinh.Name = "colDonViTinh";
            this.colDonViTinh.ReadOnly = true;
            // 
            // btnXoaDong
            // 
            this.btnXoaDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(101)))), ((int)(((byte)(79)))));
            this.btnXoaDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaDong.FlatAppearance.BorderSize = 0;
            this.btnXoaDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaDong.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaDong.ForeColor = System.Drawing.Color.White;
            this.btnXoaDong.Location = new System.Drawing.Point(20, 645);
            this.btnXoaDong.Name = "btnXoaDong";
            this.btnXoaDong.Size = new System.Drawing.Size(140, 42);
            this.btnXoaDong.TabIndex = 4;
            this.btnXoaDong.Text = "Xóa dòng";
            this.btnXoaDong.UseVisualStyleBackColor = false;
            this.btnXoaDong.Click += new System.EventHandler(this.btnXoaDong_Click);
            // 
            // btnLuuPhieu
            // 
            this.btnLuuPhieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(67)))), ((int)(((byte)(45)))));
            this.btnLuuPhieu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuuPhieu.FlatAppearance.BorderSize = 0;
            this.btnLuuPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuPhieu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuPhieu.ForeColor = System.Drawing.Color.White;
            this.btnLuuPhieu.Location = new System.Drawing.Point(716, 645);
            this.btnLuuPhieu.Name = "btnLuuPhieu";
            this.btnLuuPhieu.Size = new System.Drawing.Size(140, 42);
            this.btnLuuPhieu.TabIndex = 5;
            this.btnLuuPhieu.Text = "Lưu phiếu";
            this.btnLuuPhieu.UseVisualStyleBackColor = false;
            this.btnLuuPhieu.Click += new System.EventHandler(this.btnLuuPhieu_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(196)))), ((int)(((byte)(170)))));
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.Location = new System.Drawing.Point(868, 645);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(140, 42);
            this.btnLamMoi.TabIndex = 6;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(1020, 645);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(140, 42);
            this.btnDong.TabIndex = 7;
            this.btnDong.Text = "Đóng";
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
            this.btnLichSu.Location = new System.Drawing.Point(562, 645);
            this.btnLichSu.Name = "btnLichSu";
            this.btnLichSu.Size = new System.Drawing.Size(140, 42);
            this.btnLichSu.TabIndex = 8;
            this.btnLichSu.Text = "Lịch sử";
            this.btnLichSu.UseVisualStyleBackColor = false;
            this.btnLichSu.Click += new System.EventHandler(this.btnLichSu_Click);
            // 
            // FrmPhieuXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(239)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1358, 749);
            this.Controls.Add(this.btnLichSu);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnLuuPhieu);
            this.Controls.Add(this.btnXoaDong);
            this.Controls.Add(this.grpDanhSachXuat);
            this.Controls.Add(this.grpThemMatHang);
            this.Controls.Add(this.grpThongTinPhieuXuat);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(25)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPhieuXuat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu xuất kho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPhieuXuat_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpThongTinPhieuXuat.ResumeLayout(false);
            this.grpThongTinPhieuXuat.PerformLayout();
            this.grpThemMatHang.ResumeLayout(false);
            this.grpThemMatHang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongXuat)).EndInit();
            this.grpDanhSachXuat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietXuat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblIcon;
        private System.Windows.Forms.GroupBox grpThongTinPhieuXuat;
        private System.Windows.Forms.DateTimePicker dtpNgayXuat;
        private System.Windows.Forms.Label lblNgayXuat;
        private System.Windows.Forms.TextBox txtMaPhieuXuat;
        private System.Windows.Forms.Label lblMaPhieuXuat;
        private System.Windows.Forms.Label lblLyDoXuat;
        private System.Windows.Forms.TextBox txtLyDoXuat;
        private System.Windows.Forms.GroupBox grpThemMatHang;
        private System.Windows.Forms.NumericUpDown nudSoLuongXuat;
        private System.Windows.Forms.Label lblSoLuongXuat;
        private System.Windows.Forms.ComboBox cboMatHang;
        private System.Windows.Forms.Label lblMatHang;
        private System.Windows.Forms.ComboBox cboLoaiMatHang;
        private System.Windows.Forms.Label lblLoaiMatHang;
        private System.Windows.Forms.Label lblHuongDan;
        private System.Windows.Forms.Button btnThemMatHang;
        private System.Windows.Forms.GroupBox grpDanhSachXuat;
        private System.Windows.Forms.DataGridView dgvChiTietXuat;
        private System.Windows.Forms.Button btnXoaDong;
        private System.Windows.Forms.Button btnLuuPhieu;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiMatHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaMatHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenMatHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonViTinh;
        private System.Windows.Forms.CheckBox chkLaHaoHut;
        private System.Windows.Forms.Label lblGiaTriHaoHut;
        private System.Windows.Forms.Button btnLichSu;
    }
}