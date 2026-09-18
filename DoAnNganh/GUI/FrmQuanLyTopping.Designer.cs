namespace Đồ_án_ngành.GUI
{
    partial class FrmQuanLyTopping
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTopping = new System.Windows.Forms.Label();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.pnlCongCu = new System.Windows.Forms.Panel();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.cboLocTrangThai = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.pnlNoiDung = new System.Windows.Forms.Panel();
            this.tlpNoiDung = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvTopping = new System.Windows.Forms.DataGridView();
            this.colMaTopping = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenTopping = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuongTon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMucCanhBao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonViTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonViQuyDoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHeSoQuyDoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlThongTin = new System.Windows.Forms.Panel();
            this.nudHeSoQuyDoi = new System.Windows.Forms.NumericUpDown();
            this.lblHeSoQuyDoi = new System.Windows.Forms.Label();
            this.txtDonViTinhQuyDoi = new System.Windows.Forms.TextBox();
            this.lblDonViQuyDoi = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.txtDonViTinh = new System.Windows.Forms.TextBox();
            this.lblDonViTinh = new System.Windows.Forms.Label();
            this.txtMucCanhBao = new System.Windows.Forms.TextBox();
            this.lblMucCanhBao = new System.Windows.Forms.Label();
            this.txtSoLuongTon = new System.Windows.Forms.TextBox();
            this.lblSoLuongTon = new System.Windows.Forms.Label();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.lblGiaBan = new System.Windows.Forms.Label();
            this.txtTenTopping = new System.Windows.Forms.TextBox();
            this.lblTenTopping = new System.Windows.Forms.Label();
            this.txtMaTopping = new System.Windows.Forms.TextBox();
            this.lblMaTopping = new System.Windows.Forms.Label();
            this.lblThongTin = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlCongCu.SuspendLayout();
            this.pnlNoiDung.SuspendLayout();
            this.tlpNoiDung.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopping)).BeginInit();
            this.pnlThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeSoQuyDoi)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(232)))), ((int)(((byte)(213)))));
            this.pnlHeader.Controls.Add(this.lblTopping);
            this.pnlHeader.Controls.Add(this.lblMoTa);
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(75)))), ((int)(((byte)(55)))));
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1370, 130);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTopping
            // 
            this.lblTopping.AutoSize = true;
            this.lblTopping.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopping.Location = new System.Drawing.Point(40, 30);
            this.lblTopping.Name = "lblTopping";
            this.lblTopping.Size = new System.Drawing.Size(95, 65);
            this.lblTopping.TabIndex = 2;
            this.lblTopping.Text = "🍱";
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoTa.Location = new System.Drawing.Point(130, 75);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(244, 20);
            this.lblMoTa.TabIndex = 1;
            this.lblMoTa.Text = "Quản lý danh sách topping của quán";
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.lblTieuDe.Location = new System.Drawing.Point(126, 30);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(197, 45);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "NOVEMBER";
            // 
            // pnlCongCu
            // 
            this.pnlCongCu.Controls.Add(this.btnSua);
            this.pnlCongCu.Controls.Add(this.btnThem);
            this.pnlCongCu.Controls.Add(this.cboLocTrangThai);
            this.pnlCongCu.Controls.Add(this.btnTimKiem);
            this.pnlCongCu.Controls.Add(this.txtTimKiem);
            this.pnlCongCu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCongCu.Location = new System.Drawing.Point(0, 130);
            this.pnlCongCu.Name = "pnlCongCu";
            this.pnlCongCu.Size = new System.Drawing.Size(1370, 85);
            this.pnlCongCu.TabIndex = 1;
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(111)))), ((int)(((byte)(66)))));
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(1154, 22);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 40);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "✎ CẬP NHẬT";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(112)))), ((int)(((byte)(71)))));
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(994, 23);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(150, 40);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "➕ THÊM TOPPING";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // cboLocTrangThai
            // 
            this.cboLocTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTrangThai.FormattingEnabled = true;
            this.cboLocTrangThai.Location = new System.Drawing.Point(490, 23);
            this.cboLocTrangThai.Name = "cboLocTrangThai";
            this.cboLocTrangThai.Size = new System.Drawing.Size(217, 25);
            this.cboLocTrangThai.TabIndex = 2;
            this.cboLocTrangThai.SelectedIndexChanged += new System.EventHandler(this.cboLocTrangThai_SelectedIndexChanged);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(429, 22);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(40, 40);
            this.btnTimKiem.TabIndex = 1;
            this.btnTimKiem.Text = "🔍";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(40, 23);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(377, 25);
            this.txtTimKiem.TabIndex = 0;
            // 
            // pnlNoiDung
            // 
            this.pnlNoiDung.Controls.Add(this.tlpNoiDung);
            this.pnlNoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNoiDung.Location = new System.Drawing.Point(0, 215);
            this.pnlNoiDung.Name = "pnlNoiDung";
            this.pnlNoiDung.Padding = new System.Windows.Forms.Padding(30, 10, 30, 15);
            this.pnlNoiDung.Size = new System.Drawing.Size(1370, 534);
            this.pnlNoiDung.TabIndex = 2;
            // 
            // tlpNoiDung
            // 
            this.tlpNoiDung.ColumnCount = 2;
            this.tlpNoiDung.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tlpNoiDung.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpNoiDung.Controls.Add(this.panel1, 0, 0);
            this.tlpNoiDung.Controls.Add(this.pnlThongTin, 1, 0);
            this.tlpNoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpNoiDung.Location = new System.Drawing.Point(30, 10);
            this.tlpNoiDung.Name = "tlpNoiDung";
            this.tlpNoiDung.RowCount = 1;
            this.tlpNoiDung.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNoiDung.Size = new System.Drawing.Size(1310, 509);
            this.tlpNoiDung.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.dgvTopping);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(972, 509);
            this.panel1.TabIndex = 0;
            // 
            // dgvTopping
            // 
            this.dgvTopping.AllowUserToAddRows = false;
            this.dgvTopping.AllowUserToDeleteRows = false;
            this.dgvTopping.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopping.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopping.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTopping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopping.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaTopping,
            this.colTenTopping,
            this.colGiaBan,
            this.colSoLuongTon,
            this.colMucCanhBao,
            this.colDonViTinh,
            this.colDonViQuyDoi,
            this.colHeSoQuyDoi,
            this.colTrangThai});
            this.dgvTopping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopping.Location = new System.Drawing.Point(0, 0);
            this.dgvTopping.MultiSelect = false;
            this.dgvTopping.Name = "dgvTopping";
            this.dgvTopping.ReadOnly = true;
            this.dgvTopping.RowHeadersVisible = false;
            this.dgvTopping.RowTemplate.Height = 40;
            this.dgvTopping.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopping.Size = new System.Drawing.Size(972, 509);
            this.dgvTopping.TabIndex = 0;
            this.dgvTopping.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTopping_CellClick);
            // 
            // colMaTopping
            // 
            this.colMaTopping.DataPropertyName = "MaTopping";
            this.colMaTopping.HeaderText = "Mã topping";
            this.colMaTopping.Name = "colMaTopping";
            this.colMaTopping.ReadOnly = true;
            // 
            // colTenTopping
            // 
            this.colTenTopping.DataPropertyName = "TenTopping";
            this.colTenTopping.HeaderText = "Tên topping";
            this.colTenTopping.Name = "colTenTopping";
            this.colTenTopping.ReadOnly = true;
            // 
            // colGiaBan
            // 
            this.colGiaBan.DataPropertyName = "GiaBan";
            dataGridViewCellStyle3.Format = "N0";
            this.colGiaBan.DefaultCellStyle = dataGridViewCellStyle3;
            this.colGiaBan.HeaderText = "Giá bán";
            this.colGiaBan.Name = "colGiaBan";
            this.colGiaBan.ReadOnly = true;
            // 
            // colSoLuongTon
            // 
            this.colSoLuongTon.DataPropertyName = "SoLuongTon";
            this.colSoLuongTon.HeaderText = "Số lượng tồn";
            this.colSoLuongTon.Name = "colSoLuongTon";
            this.colSoLuongTon.ReadOnly = true;
            // 
            // colMucCanhBao
            // 
            this.colMucCanhBao.DataPropertyName = "MucCanhBao";
            this.colMucCanhBao.HeaderText = "Mức cảnh báo";
            this.colMucCanhBao.Name = "colMucCanhBao";
            this.colMucCanhBao.ReadOnly = true;
            // 
            // colDonViTinh
            // 
            this.colDonViTinh.DataPropertyName = "DonViTinh";
            this.colDonViTinh.HeaderText = "Đơn vị tính";
            this.colDonViTinh.Name = "colDonViTinh";
            this.colDonViTinh.ReadOnly = true;
            // 
            // colDonViQuyDoi
            // 
            this.colDonViQuyDoi.DataPropertyName = "DonViTinhQuyDoi";
            this.colDonViQuyDoi.HeaderText = "Đơn vị quy đổi";
            this.colDonViQuyDoi.Name = "colDonViQuyDoi";
            this.colDonViQuyDoi.ReadOnly = true;
            // 
            // colHeSoQuyDoi
            // 
            this.colHeSoQuyDoi.DataPropertyName = "HeSoQuyDoi";
            this.colHeSoQuyDoi.HeaderText = "Hệ số quy đổi";
            this.colHeSoQuyDoi.Name = "colHeSoQuyDoi";
            this.colHeSoQuyDoi.ReadOnly = true;
            // 
            // colTrangThai
            // 
            this.colTrangThai.DataPropertyName = "TrangThai";
            this.colTrangThai.HeaderText = "Trạng thái";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.ReadOnly = true;
            // 
            // pnlThongTin
            // 
            this.pnlThongTin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(232)))), ((int)(((byte)(213)))));
            this.pnlThongTin.Controls.Add(this.nudHeSoQuyDoi);
            this.pnlThongTin.Controls.Add(this.lblHeSoQuyDoi);
            this.pnlThongTin.Controls.Add(this.txtDonViTinhQuyDoi);
            this.pnlThongTin.Controls.Add(this.lblDonViQuyDoi);
            this.pnlThongTin.Controls.Add(this.cboTrangThai);
            this.pnlThongTin.Controls.Add(this.lblTrangThai);
            this.pnlThongTin.Controls.Add(this.txtDonViTinh);
            this.pnlThongTin.Controls.Add(this.lblDonViTinh);
            this.pnlThongTin.Controls.Add(this.txtMucCanhBao);
            this.pnlThongTin.Controls.Add(this.lblMucCanhBao);
            this.pnlThongTin.Controls.Add(this.txtSoLuongTon);
            this.pnlThongTin.Controls.Add(this.lblSoLuongTon);
            this.pnlThongTin.Controls.Add(this.txtGiaBan);
            this.pnlThongTin.Controls.Add(this.lblGiaBan);
            this.pnlThongTin.Controls.Add(this.txtTenTopping);
            this.pnlThongTin.Controls.Add(this.lblTenTopping);
            this.pnlThongTin.Controls.Add(this.txtMaTopping);
            this.pnlThongTin.Controls.Add(this.lblMaTopping);
            this.pnlThongTin.Controls.Add(this.lblThongTin);
            this.pnlThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlThongTin.Location = new System.Drawing.Point(992, 0);
            this.pnlThongTin.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.pnlThongTin.Name = "pnlThongTin";
            this.pnlThongTin.Size = new System.Drawing.Size(318, 509);
            this.pnlThongTin.TabIndex = 1;
            this.pnlThongTin.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlThongTin_Paint);
            // 
            // nudHeSoQuyDoi
            // 
            this.nudHeSoQuyDoi.Location = new System.Drawing.Point(170, 417);
            this.nudHeSoQuyDoi.Name = "nudHeSoQuyDoi";
            this.nudHeSoQuyDoi.Size = new System.Drawing.Size(120, 25);
            this.nudHeSoQuyDoi.TabIndex = 23;
            // 
            // lblHeSoQuyDoi
            // 
            this.lblHeSoQuyDoi.AutoSize = true;
            this.lblHeSoQuyDoi.Location = new System.Drawing.Point(170, 397);
            this.lblHeSoQuyDoi.Name = "lblHeSoQuyDoi";
            this.lblHeSoQuyDoi.Size = new System.Drawing.Size(94, 17);
            this.lblHeSoQuyDoi.TabIndex = 22;
            this.lblHeSoQuyDoi.Text = "Hệ số quy đổi";
            // 
            // txtDonViTinhQuyDoi
            // 
            this.txtDonViTinhQuyDoi.Location = new System.Drawing.Point(20, 417);
            this.txtDonViTinhQuyDoi.Name = "txtDonViTinhQuyDoi";
            this.txtDonViTinhQuyDoi.Size = new System.Drawing.Size(125, 25);
            this.txtDonViTinhQuyDoi.TabIndex = 20;
            // 
            // lblDonViQuyDoi
            // 
            this.lblDonViQuyDoi.AutoSize = true;
            this.lblDonViQuyDoi.Location = new System.Drawing.Point(20, 397);
            this.lblDonViQuyDoi.Name = "lblDonViQuyDoi";
            this.lblDonViQuyDoi.Size = new System.Drawing.Size(100, 17);
            this.lblDonViQuyDoi.TabIndex = 19;
            this.lblDonViQuyDoi.Text = "Đơn vị quy đổi";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Location = new System.Drawing.Point(20, 357);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(250, 25);
            this.cboTrangThai.TabIndex = 18;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(20, 337);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(71, 17);
            this.lblTrangThai.TabIndex = 17;
            this.lblTrangThai.Text = "Trạng thái";
            // 
            // txtDonViTinh
            // 
            this.txtDonViTinh.Location = new System.Drawing.Point(20, 297);
            this.txtDonViTinh.Name = "txtDonViTinh";
            this.txtDonViTinh.Size = new System.Drawing.Size(125, 25);
            this.txtDonViTinh.TabIndex = 16;
            // 
            // lblDonViTinh
            // 
            this.lblDonViTinh.AutoSize = true;
            this.lblDonViTinh.Location = new System.Drawing.Point(20, 277);
            this.lblDonViTinh.Name = "lblDonViTinh";
            this.lblDonViTinh.Size = new System.Drawing.Size(78, 17);
            this.lblDonViTinh.TabIndex = 15;
            this.lblDonViTinh.Text = "Đơn vị tính";
            // 
            // txtMucCanhBao
            // 
            this.txtMucCanhBao.Location = new System.Drawing.Point(170, 242);
            this.txtMucCanhBao.Name = "txtMucCanhBao";
            this.txtMucCanhBao.Size = new System.Drawing.Size(125, 25);
            this.txtMucCanhBao.TabIndex = 14;
            // 
            // lblMucCanhBao
            // 
            this.lblMucCanhBao.AutoSize = true;
            this.lblMucCanhBao.Location = new System.Drawing.Point(170, 222);
            this.lblMucCanhBao.Name = "lblMucCanhBao";
            this.lblMucCanhBao.Size = new System.Drawing.Size(95, 17);
            this.lblMucCanhBao.TabIndex = 13;
            this.lblMucCanhBao.Text = "Mức cảnh báo";
            // 
            // txtSoLuongTon
            // 
            this.txtSoLuongTon.Location = new System.Drawing.Point(20, 242);
            this.txtSoLuongTon.Name = "txtSoLuongTon";
            this.txtSoLuongTon.ReadOnly = true;
            this.txtSoLuongTon.Size = new System.Drawing.Size(125, 25);
            this.txtSoLuongTon.TabIndex = 12;
            // 
            // lblSoLuongTon
            // 
            this.lblSoLuongTon.AutoSize = true;
            this.lblSoLuongTon.Location = new System.Drawing.Point(20, 222);
            this.lblSoLuongTon.Name = "lblSoLuongTon";
            this.lblSoLuongTon.Size = new System.Drawing.Size(89, 17);
            this.lblSoLuongTon.TabIndex = 11;
            this.lblSoLuongTon.Text = "Số lượng tồn";
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Location = new System.Drawing.Point(20, 135);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(120, 25);
            this.txtGiaBan.TabIndex = 10;
            // 
            // lblGiaBan
            // 
            this.lblGiaBan.AutoSize = true;
            this.lblGiaBan.Location = new System.Drawing.Point(20, 115);
            this.lblGiaBan.Name = "lblGiaBan";
            this.lblGiaBan.Size = new System.Drawing.Size(55, 17);
            this.lblGiaBan.TabIndex = 9;
            this.lblGiaBan.Text = "Giá bán";
            // 
            // txtTenTopping
            // 
            this.txtTenTopping.Location = new System.Drawing.Point(20, 187);
            this.txtTenTopping.Name = "txtTenTopping";
            this.txtTenTopping.Size = new System.Drawing.Size(250, 25);
            this.txtTenTopping.TabIndex = 8;
            // 
            // lblTenTopping
            // 
            this.lblTenTopping.AutoSize = true;
            this.lblTenTopping.Location = new System.Drawing.Point(20, 167);
            this.lblTenTopping.Name = "lblTenTopping";
            this.lblTenTopping.Size = new System.Drawing.Size(83, 17);
            this.lblTenTopping.TabIndex = 7;
            this.lblTenTopping.Text = "Tên topping";
            // 
            // txtMaTopping
            // 
            this.txtMaTopping.Location = new System.Drawing.Point(20, 83);
            this.txtMaTopping.Name = "txtMaTopping";
            this.txtMaTopping.ReadOnly = true;
            this.txtMaTopping.Size = new System.Drawing.Size(120, 25);
            this.txtMaTopping.TabIndex = 6;
            // 
            // lblMaTopping
            // 
            this.lblMaTopping.AutoSize = true;
            this.lblMaTopping.Location = new System.Drawing.Point(20, 63);
            this.lblMaTopping.Name = "lblMaTopping";
            this.lblMaTopping.Size = new System.Drawing.Size(80, 17);
            this.lblMaTopping.TabIndex = 5;
            this.lblMaTopping.Text = "Mã topping";
            // 
            // lblThongTin
            // 
            this.lblThongTin.AutoSize = true;
            this.lblThongTin.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongTin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.lblThongTin.Location = new System.Drawing.Point(20, 20);
            this.lblThongTin.Name = "lblThongTin";
            this.lblThongTin.Size = new System.Drawing.Size(206, 25);
            this.lblThongTin.TabIndex = 4;
            this.lblThongTin.Text = "THÔNG TIN TOPPING";
            // 
            // FrmQuanLyTopping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.pnlNoiDung);
            this.Controls.Add(this.pnlCongCu);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FrmQuanLyTopping";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Topping";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlCongCu.ResumeLayout(false);
            this.pnlCongCu.PerformLayout();
            this.pnlNoiDung.ResumeLayout(false);
            this.tlpNoiDung.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopping)).EndInit();
            this.pnlThongTin.ResumeLayout(false);
            this.pnlThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeSoQuyDoi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Panel pnlCongCu;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.ComboBox cboLocTrangThai;
        private System.Windows.Forms.Panel pnlNoiDung;
        private System.Windows.Forms.TableLayoutPanel tlpNoiDung;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlThongTin;
        private System.Windows.Forms.DataGridView dgvTopping;
        private System.Windows.Forms.Label lblThongTin;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.TextBox txtDonViTinh;
        private System.Windows.Forms.Label lblDonViTinh;
        private System.Windows.Forms.TextBox txtMucCanhBao;
        private System.Windows.Forms.Label lblMucCanhBao;
        private System.Windows.Forms.TextBox txtSoLuongTon;
        private System.Windows.Forms.Label lblSoLuongTon;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.Label lblGiaBan;
        private System.Windows.Forms.TextBox txtTenTopping;
        private System.Windows.Forms.Label lblTenTopping;
        private System.Windows.Forms.TextBox txtMaTopping;
        private System.Windows.Forms.Label lblMaTopping;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Label lblTopping;
        private System.Windows.Forms.TextBox txtDonViTinhQuyDoi;
        private System.Windows.Forms.Label lblDonViQuyDoi;
        private System.Windows.Forms.Label lblHeSoQuyDoi;
        private System.Windows.Forms.NumericUpDown nudHeSoQuyDoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaTopping;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenTopping;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuongTon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMucCanhBao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonViTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonViQuyDoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeSoQuyDoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
    }
}