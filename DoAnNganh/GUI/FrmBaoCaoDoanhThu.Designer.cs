namespace Đồ_án_ngành.GUI
{
    partial class FrmBaoCaoDoanhThu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlMonBanRa = new System.Windows.Forms.Panel();
            this.dgvMonBanRa = new System.Windows.Forms.DataGridView();
            this.colTenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuongBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDoanhThuMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboTopMon = new System.Windows.Forms.ComboBox();
            this.lblTopMon = new System.Windows.Forms.Label();
            this.lblTieuDeMonBanRa = new System.Windows.Forms.Label();
            this.pnlBieuDoDoanhThu = new System.Windows.Forms.Panel();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTieuDeBieuDo = new System.Windows.Forms.Label();
            this.pnlTongMonDaBan = new System.Windows.Forms.Panel();
            this.lblTongMonDaBan = new System.Windows.Forms.Label();
            this.lblTongMonDaBanTieuDe = new System.Windows.Forms.Label();
            this.pnlHoaDonTrungBinh = new System.Windows.Forms.Panel();
            this.lblHoaDonTrungBinh = new System.Windows.Forms.Label();
            this.lblHoaDonTrungBinhTieuDe = new System.Windows.Forms.Label();
            this.pnlTongHoaDon = new System.Windows.Forms.Panel();
            this.lblTongHoaDon = new System.Windows.Forms.Label();
            this.lblTongHoaDonTieuDe = new System.Windows.Forms.Label();
            this.pnlTongDoanhThu = new System.Windows.Forms.Panel();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.lblTongDoanhThuTieuDe = new System.Windows.Forms.Label();
            this.pnlBoLoc = new System.Windows.Forms.Panel();
            this.cboDenNam = new System.Windows.Forms.ComboBox();
            this.lblDenNam = new System.Windows.Forms.Label();
            this.cboTuNam = new System.Windows.Forms.ComboBox();
            this.lblTuNam = new System.Windows.Forms.Label();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.lblNam = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.cboLoaiThoiGian = new System.Windows.Forms.ComboBox();
            this.lblXemTheo = new System.Windows.Forms.Label();
            this.lblIcon = new System.Windows.Forms.Label();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlMonBanRa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonBanRa)).BeginInit();
            this.pnlBieuDoDoanhThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            this.pnlTongMonDaBan.SuspendLayout();
            this.pnlHoaDonTrungBinh.SuspendLayout();
            this.pnlTongHoaDon.SuspendLayout();
            this.pnlTongDoanhThu.SuspendLayout();
            this.pnlBoLoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlMonBanRa);
            this.pnlMain.Controls.Add(this.pnlBieuDoDoanhThu);
            this.pnlMain.Controls.Add(this.pnlTongMonDaBan);
            this.pnlMain.Controls.Add(this.pnlHoaDonTrungBinh);
            this.pnlMain.Controls.Add(this.pnlTongHoaDon);
            this.pnlMain.Controls.Add(this.pnlTongDoanhThu);
            this.pnlMain.Controls.Add(this.pnlBoLoc);
            this.pnlMain.Controls.Add(this.lblIcon);
            this.pnlMain.Controls.Add(this.lblMoTa);
            this.pnlMain.Controls.Add(this.lblTieuDe);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.pnlMain.Size = new System.Drawing.Size(1350, 749);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlMonBanRa
            // 
            this.pnlMonBanRa.BackColor = System.Drawing.Color.White;
            this.pnlMonBanRa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMonBanRa.Controls.Add(this.dgvMonBanRa);
            this.pnlMonBanRa.Controls.Add(this.cboTopMon);
            this.pnlMonBanRa.Controls.Add(this.lblTopMon);
            this.pnlMonBanRa.Controls.Add(this.lblTieuDeMonBanRa);
            this.pnlMonBanRa.Location = new System.Drawing.Point(870, 355);
            this.pnlMonBanRa.Name = "pnlMonBanRa";
            this.pnlMonBanRa.Size = new System.Drawing.Size(460, 320);
            this.pnlMonBanRa.TabIndex = 9;
            // 
            // dgvMonBanRa
            // 
            this.dgvMonBanRa.AllowUserToAddRows = false;
            this.dgvMonBanRa.AllowUserToDeleteRows = false;
            this.dgvMonBanRa.AllowUserToResizeRows = false;
            this.dgvMonBanRa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMonBanRa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMonBanRa.BackgroundColor = System.Drawing.Color.White;
            this.dgvMonBanRa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMonBanRa.ColumnHeadersHeight = 40;
            this.dgvMonBanRa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMonBanRa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTenMon,
            this.colSoLuongBan,
            this.colDoanhThuMon});
            this.dgvMonBanRa.Location = new System.Drawing.Point(20, 55);
            this.dgvMonBanRa.MultiSelect = false;
            this.dgvMonBanRa.Name = "dgvMonBanRa";
            this.dgvMonBanRa.ReadOnly = true;
            this.dgvMonBanRa.RowHeadersVisible = false;
            this.dgvMonBanRa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMonBanRa.Size = new System.Drawing.Size(415, 240);
            this.dgvMonBanRa.TabIndex = 3;
            // 
            // colTenMon
            // 
            this.colTenMon.DataPropertyName = "TenMon";
            this.colTenMon.FillWeight = 180F;
            this.colTenMon.HeaderText = "Tên món";
            this.colTenMon.Name = "colTenMon";
            this.colTenMon.ReadOnly = true;
            // 
            // colSoLuongBan
            // 
            this.colSoLuongBan.DataPropertyName = "SoLuongBan";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colSoLuongBan.DefaultCellStyle = dataGridViewCellStyle1;
            this.colSoLuongBan.FillWeight = 85F;
            this.colSoLuongBan.HeaderText = "Số bán ra";
            this.colSoLuongBan.Name = "colSoLuongBan";
            this.colSoLuongBan.ReadOnly = true;
            // 
            // colDoanhThuMon
            // 
            this.colDoanhThuMon.DataPropertyName = "DoanhThu";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "#,##0";
            this.colDoanhThuMon.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDoanhThuMon.FillWeight = 130F;
            this.colDoanhThuMon.HeaderText = "Doanh thu";
            this.colDoanhThuMon.Name = "colDoanhThuMon";
            this.colDoanhThuMon.ReadOnly = true;
            // 
            // cboTopMon
            // 
            this.cboTopMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTopMon.FormattingEnabled = true;
            this.cboTopMon.Location = new System.Drawing.Point(347, 14);
            this.cboTopMon.Name = "cboTopMon";
            this.cboTopMon.Size = new System.Drawing.Size(88, 25);
            this.cboTopMon.TabIndex = 2;
            this.cboTopMon.SelectedIndexChanged += new System.EventHandler(this.cboTopMon_SelectedIndexChanged);
            // 
            // lblTopMon
            // 
            this.lblTopMon.AutoSize = true;
            this.lblTopMon.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopMon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.lblTopMon.Location = new System.Drawing.Point(280, 18);
            this.lblTopMon.Name = "lblTopMon";
            this.lblTopMon.Size = new System.Drawing.Size(65, 17);
            this.lblTopMon.TabIndex = 1;
            this.lblTopMon.Text = "Lọc theo:";
            // 
            // lblTieuDeMonBanRa
            // 
            this.lblTieuDeMonBanRa.AutoSize = true;
            this.lblTieuDeMonBanRa.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDeMonBanRa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.lblTieuDeMonBanRa.Location = new System.Drawing.Point(20, 15);
            this.lblTieuDeMonBanRa.Name = "lblTieuDeMonBanRa";
            this.lblTieuDeMonBanRa.Size = new System.Drawing.Size(188, 20);
            this.lblTieuDeMonBanRa.TabIndex = 0;
            this.lblTieuDeMonBanRa.Text = "THỐNG KÊ MÓN BÁN RA";
            // 
            // pnlBieuDoDoanhThu
            // 
            this.pnlBieuDoDoanhThu.BackColor = System.Drawing.Color.White;
            this.pnlBieuDoDoanhThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBieuDoDoanhThu.Controls.Add(this.chartDoanhThu);
            this.pnlBieuDoDoanhThu.Controls.Add(this.lblTieuDeBieuDo);
            this.pnlBieuDoDoanhThu.Location = new System.Drawing.Point(30, 355);
            this.pnlBieuDoDoanhThu.Name = "pnlBieuDoDoanhThu";
            this.pnlBieuDoDoanhThu.Size = new System.Drawing.Size(820, 320);
            this.pnlBieuDoDoanhThu.TabIndex = 8;
            // 
            // chartDoanhThu
            // 
            this.chartDoanhThu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartAreaDoanhThu";
            this.chartDoanhThu.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend1);
            this.chartDoanhThu.Location = new System.Drawing.Point(20, 55);
            this.chartDoanhThu.Name = "chartDoanhThu";
            series1.ChartArea = "ChartAreaDoanhThu";
            series1.Legend = "Legend1";
            series1.Name = "DoanhThu";
            this.chartDoanhThu.Series.Add(series1);
            this.chartDoanhThu.Size = new System.Drawing.Size(780, 240);
            this.chartDoanhThu.TabIndex = 1;
            this.chartDoanhThu.Text = "chart1";
            // 
            // lblTieuDeBieuDo
            // 
            this.lblTieuDeBieuDo.AutoSize = true;
            this.lblTieuDeBieuDo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDeBieuDo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.lblTieuDeBieuDo.Location = new System.Drawing.Point(20, 15);
            this.lblTieuDeBieuDo.Name = "lblTieuDeBieuDo";
            this.lblTieuDeBieuDo.Size = new System.Drawing.Size(164, 20);
            this.lblTieuDeBieuDo.TabIndex = 0;
            this.lblTieuDeBieuDo.Text = "BIỂU ĐỒ DOANH THU";
            // 
            // pnlTongMonDaBan
            // 
            this.pnlTongMonDaBan.BackColor = System.Drawing.Color.White;
            this.pnlTongMonDaBan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTongMonDaBan.Controls.Add(this.lblTongMonDaBan);
            this.pnlTongMonDaBan.Controls.Add(this.lblTongMonDaBanTieuDe);
            this.pnlTongMonDaBan.Location = new System.Drawing.Point(1020, 225);
            this.pnlTongMonDaBan.Name = "pnlTongMonDaBan";
            this.pnlTongMonDaBan.Size = new System.Drawing.Size(310, 110);
            this.pnlTongMonDaBan.TabIndex = 7;
            // 
            // lblTongMonDaBan
            // 
            this.lblTongMonDaBan.AutoSize = true;
            this.lblTongMonDaBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.lblTongMonDaBan.Location = new System.Drawing.Point(20, 48);
            this.lblTongMonDaBan.Name = "lblTongMonDaBan";
            this.lblTongMonDaBan.Size = new System.Drawing.Size(15, 17);
            this.lblTongMonDaBan.TabIndex = 1;
            this.lblTongMonDaBan.Text = "0";
            // 
            // lblTongMonDaBanTieuDe
            // 
            this.lblTongMonDaBanTieuDe.AutoSize = true;
            this.lblTongMonDaBanTieuDe.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongMonDaBanTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(90)))), ((int)(((byte)(75)))));
            this.lblTongMonDaBanTieuDe.Location = new System.Drawing.Point(20, 15);
            this.lblTongMonDaBanTieuDe.Name = "lblTongMonDaBanTieuDe";
            this.lblTongMonDaBanTieuDe.Size = new System.Drawing.Size(135, 17);
            this.lblTongMonDaBanTieuDe.TabIndex = 0;
            this.lblTongMonDaBanTieuDe.Text = "TỔNG MÓN ĐÃ BÁN";
            // 
            // pnlHoaDonTrungBinh
            // 
            this.pnlHoaDonTrungBinh.BackColor = System.Drawing.Color.White;
            this.pnlHoaDonTrungBinh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHoaDonTrungBinh.Controls.Add(this.lblHoaDonTrungBinh);
            this.pnlHoaDonTrungBinh.Controls.Add(this.lblHoaDonTrungBinhTieuDe);
            this.pnlHoaDonTrungBinh.ForeColor = System.Drawing.Color.White;
            this.pnlHoaDonTrungBinh.Location = new System.Drawing.Point(690, 225);
            this.pnlHoaDonTrungBinh.Name = "pnlHoaDonTrungBinh";
            this.pnlHoaDonTrungBinh.Size = new System.Drawing.Size(310, 110);
            this.pnlHoaDonTrungBinh.TabIndex = 6;
            // 
            // lblHoaDonTrungBinh
            // 
            this.lblHoaDonTrungBinh.AutoSize = true;
            this.lblHoaDonTrungBinh.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoaDonTrungBinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.lblHoaDonTrungBinh.Location = new System.Drawing.Point(20, 48);
            this.lblHoaDonTrungBinh.Name = "lblHoaDonTrungBinh";
            this.lblHoaDonTrungBinh.Size = new System.Drawing.Size(57, 37);
            this.lblHoaDonTrungBinh.TabIndex = 1;
            this.lblHoaDonTrungBinh.Text = "0 đ";
            this.lblHoaDonTrungBinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHoaDonTrungBinhTieuDe
            // 
            this.lblHoaDonTrungBinhTieuDe.AutoSize = true;
            this.lblHoaDonTrungBinhTieuDe.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoaDonTrungBinhTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(90)))), ((int)(((byte)(75)))));
            this.lblHoaDonTrungBinhTieuDe.Location = new System.Drawing.Point(20, 15);
            this.lblHoaDonTrungBinhTieuDe.Name = "lblHoaDonTrungBinhTieuDe";
            this.lblHoaDonTrungBinhTieuDe.Size = new System.Drawing.Size(205, 17);
            this.lblHoaDonTrungBinhTieuDe.TabIndex = 0;
            this.lblHoaDonTrungBinhTieuDe.Text = "GIÁ TRỊ HÓA ĐƠN TRUNG BÌNH";
            // 
            // pnlTongHoaDon
            // 
            this.pnlTongHoaDon.BackColor = System.Drawing.Color.White;
            this.pnlTongHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTongHoaDon.Controls.Add(this.lblTongHoaDon);
            this.pnlTongHoaDon.Controls.Add(this.lblTongHoaDonTieuDe);
            this.pnlTongHoaDon.ForeColor = System.Drawing.Color.White;
            this.pnlTongHoaDon.Location = new System.Drawing.Point(360, 225);
            this.pnlTongHoaDon.Name = "pnlTongHoaDon";
            this.pnlTongHoaDon.Size = new System.Drawing.Size(310, 110);
            this.pnlTongHoaDon.TabIndex = 5;
            // 
            // lblTongHoaDon
            // 
            this.lblTongHoaDon.AutoSize = true;
            this.lblTongHoaDon.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongHoaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.lblTongHoaDon.Location = new System.Drawing.Point(20, 48);
            this.lblTongHoaDon.Name = "lblTongHoaDon";
            this.lblTongHoaDon.Size = new System.Drawing.Size(33, 37);
            this.lblTongHoaDon.TabIndex = 2;
            this.lblTongHoaDon.Text = "0";
            this.lblTongHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTongHoaDonTieuDe
            // 
            this.lblTongHoaDonTieuDe.AutoSize = true;
            this.lblTongHoaDonTieuDe.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongHoaDonTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(90)))), ((int)(((byte)(75)))));
            this.lblTongHoaDonTieuDe.Location = new System.Drawing.Point(20, 15);
            this.lblTongHoaDonTieuDe.Name = "lblTongHoaDonTieuDe";
            this.lblTongHoaDonTieuDe.Size = new System.Drawing.Size(112, 17);
            this.lblTongHoaDonTieuDe.TabIndex = 1;
            this.lblTongHoaDonTieuDe.Text = "TỔNG HÓA ĐƠN";
            // 
            // pnlTongDoanhThu
            // 
            this.pnlTongDoanhThu.BackColor = System.Drawing.Color.White;
            this.pnlTongDoanhThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTongDoanhThu.Controls.Add(this.lblTongDoanhThu);
            this.pnlTongDoanhThu.Controls.Add(this.lblTongDoanhThuTieuDe);
            this.pnlTongDoanhThu.ForeColor = System.Drawing.Color.White;
            this.pnlTongDoanhThu.Location = new System.Drawing.Point(30, 225);
            this.pnlTongDoanhThu.Name = "pnlTongDoanhThu";
            this.pnlTongDoanhThu.Size = new System.Drawing.Size(310, 110);
            this.pnlTongDoanhThu.TabIndex = 4;
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongDoanhThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.lblTongDoanhThu.Location = new System.Drawing.Point(20, 48);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(57, 37);
            this.lblTongDoanhThu.TabIndex = 1;
            this.lblTongDoanhThu.Text = "0 đ";
            this.lblTongDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTongDoanhThuTieuDe
            // 
            this.lblTongDoanhThuTieuDe.AutoSize = true;
            this.lblTongDoanhThuTieuDe.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongDoanhThuTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(90)))), ((int)(((byte)(75)))));
            this.lblTongDoanhThuTieuDe.Location = new System.Drawing.Point(20, 15);
            this.lblTongDoanhThuTieuDe.Name = "lblTongDoanhThuTieuDe";
            this.lblTongDoanhThuTieuDe.Size = new System.Drawing.Size(129, 17);
            this.lblTongDoanhThuTieuDe.TabIndex = 0;
            this.lblTongDoanhThuTieuDe.Text = "TỔNG DOANH THU";
            // 
            // pnlBoLoc
            // 
            this.pnlBoLoc.BackColor = System.Drawing.Color.White;
            this.pnlBoLoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBoLoc.Controls.Add(this.cboDenNam);
            this.pnlBoLoc.Controls.Add(this.lblDenNam);
            this.pnlBoLoc.Controls.Add(this.cboTuNam);
            this.pnlBoLoc.Controls.Add(this.lblTuNam);
            this.pnlBoLoc.Controls.Add(this.btnXuatExcel);
            this.pnlBoLoc.Controls.Add(this.btnXemBaoCao);
            this.pnlBoLoc.Controls.Add(this.cboNam);
            this.pnlBoLoc.Controls.Add(this.lblNam);
            this.pnlBoLoc.Controls.Add(this.dtpDenNgay);
            this.pnlBoLoc.Controls.Add(this.lblDenNgay);
            this.pnlBoLoc.Controls.Add(this.dtpTuNgay);
            this.pnlBoLoc.Controls.Add(this.lblTuNgay);
            this.pnlBoLoc.Controls.Add(this.cboLoaiThoiGian);
            this.pnlBoLoc.Controls.Add(this.lblXemTheo);
            this.pnlBoLoc.Location = new System.Drawing.Point(30, 105);
            this.pnlBoLoc.Name = "pnlBoLoc";
            this.pnlBoLoc.Size = new System.Drawing.Size(1299, 100);
            this.pnlBoLoc.TabIndex = 3;
            // 
            // cboDenNam
            // 
            this.cboDenNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDenNam.FormattingEnabled = true;
            this.cboDenNam.Location = new System.Drawing.Point(790, 45);
            this.cboDenNam.Name = "cboDenNam";
            this.cboDenNam.Size = new System.Drawing.Size(110, 25);
            this.cboDenNam.TabIndex = 15;
            // 
            // lblDenNam
            // 
            this.lblDenNam.AutoSize = true;
            this.lblDenNam.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDenNam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.lblDenNam.Location = new System.Drawing.Point(790, 17);
            this.lblDenNam.Name = "lblDenNam";
            this.lblDenNam.Size = new System.Drawing.Size(68, 17);
            this.lblDenNam.TabIndex = 14;
            this.lblDenNam.Text = "Đến năm:";
            // 
            // cboTuNam
            // 
            this.cboTuNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTuNam.FormattingEnabled = true;
            this.cboTuNam.Location = new System.Drawing.Point(640, 45);
            this.cboTuNam.Name = "cboTuNam";
            this.cboTuNam.Size = new System.Drawing.Size(110, 25);
            this.cboTuNam.TabIndex = 13;
            // 
            // lblTuNam
            // 
            this.lblTuNam.AutoSize = true;
            this.lblTuNam.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuNam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.lblTuNam.Location = new System.Drawing.Point(640, 17);
            this.lblTuNam.Name = "lblTuNam";
            this.lblTuNam.Size = new System.Drawing.Size(60, 17);
            this.lblTuNam.TabIndex = 12;
            this.lblTuNam.Text = "Từ năm:";
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.BackColor = System.Drawing.Color.Green;
            this.btnXuatExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatExcel.FlatAppearance.BorderSize = 0;
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(1130, 37);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(140, 42);
            this.btnXuatExcel.TabIndex = 11;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(67)))), ((int)(((byte)(33)))));
            this.btnXemBaoCao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXemBaoCao.FlatAppearance.BorderSize = 0;
            this.btnXemBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemBaoCao.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnXemBaoCao.Location = new System.Drawing.Point(940, 37);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(150, 42);
            this.btnXemBaoCao.TabIndex = 10;
            this.btnXemBaoCao.Text = "Xem báo cáo";
            this.btnXemBaoCao.UseVisualStyleBackColor = false;
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
            // 
            // cboNam
            // 
            this.cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Location = new System.Drawing.Point(640, 45);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(110, 25);
            this.cboNam.TabIndex = 9;
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.lblNam.Location = new System.Drawing.Point(640, 17);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(41, 17);
            this.lblNam.TabIndex = 8;
            this.lblNam.Text = "Năm:";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(430, 45);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(180, 25);
            this.dtpDenNgay.TabIndex = 5;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDenNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.lblDenNgay.Location = new System.Drawing.Point(430, 17);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(71, 17);
            this.lblDenNgay.TabIndex = 4;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(220, 45);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(180, 25);
            this.dtpTuNgay.TabIndex = 3;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.lblTuNgay.Location = new System.Drawing.Point(220, 17);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(63, 17);
            this.lblTuNgay.TabIndex = 2;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // cboLoaiThoiGian
            // 
            this.cboLoaiThoiGian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiThoiGian.FormattingEnabled = true;
            this.cboLoaiThoiGian.Location = new System.Drawing.Point(25, 45);
            this.cboLoaiThoiGian.Name = "cboLoaiThoiGian";
            this.cboLoaiThoiGian.Size = new System.Drawing.Size(160, 25);
            this.cboLoaiThoiGian.TabIndex = 1;
            this.cboLoaiThoiGian.SelectedIndexChanged += new System.EventHandler(this.cboLoaiThoiGian_SelectedIndexChanged);
            // 
            // lblXemTheo
            // 
            this.lblXemTheo.AutoSize = true;
            this.lblXemTheo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXemTheo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.lblXemTheo.Location = new System.Drawing.Point(20, 17);
            this.lblXemTheo.Name = "lblXemTheo";
            this.lblXemTheo.Size = new System.Drawing.Size(72, 17);
            this.lblXemTheo.TabIndex = 0;
            this.lblXemTheo.Text = "Xem theo:";
            // 
            // lblIcon
            // 
            this.lblIcon.AutoSize = true;
            this.lblIcon.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.lblIcon.Location = new System.Drawing.Point(71, 15);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(84, 65);
            this.lblIcon.TabIndex = 2;
            this.lblIcon.Text = "💰";
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoTa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(90)))), ((int)(((byte)(75)))));
            this.lblMoTa.Location = new System.Drawing.Point(152, 60);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(302, 20);
            this.lblMoTa.TabIndex = 1;
            this.lblMoTa.Text = "Thống kê doanh thu và số lượng món bán ra";
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.lblTieuDe.Location = new System.Drawing.Point(150, 20);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(330, 40);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "BÁO CÁO DOANH THU";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmBaoCaoDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(238)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1350, 749);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmBaoCaoDoanhThu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo doanh thu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlMonBanRa.ResumeLayout(false);
            this.pnlMonBanRa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonBanRa)).EndInit();
            this.pnlBieuDoDoanhThu.ResumeLayout(false);
            this.pnlBieuDoDoanhThu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            this.pnlTongMonDaBan.ResumeLayout(false);
            this.pnlTongMonDaBan.PerformLayout();
            this.pnlHoaDonTrungBinh.ResumeLayout(false);
            this.pnlHoaDonTrungBinh.PerformLayout();
            this.pnlTongHoaDon.ResumeLayout(false);
            this.pnlTongHoaDon.PerformLayout();
            this.pnlTongDoanhThu.ResumeLayout(false);
            this.pnlTongDoanhThu.PerformLayout();
            this.pnlBoLoc.ResumeLayout(false);
            this.pnlBoLoc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblIcon;
        private System.Windows.Forms.Panel pnlBoLoc;
        private System.Windows.Forms.ComboBox cboLoaiThoiGian;
        private System.Windows.Forms.Label lblXemTheo;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.ComboBox cboNam;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.Panel pnlTongDoanhThu;
        private System.Windows.Forms.Panel pnlTongHoaDon;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.Label lblTongDoanhThuTieuDe;
        private System.Windows.Forms.Panel pnlHoaDonTrungBinh;
        private System.Windows.Forms.Label lblTongHoaDon;
        private System.Windows.Forms.Label lblTongHoaDonTieuDe;
        private System.Windows.Forms.Panel pnlTongMonDaBan;
        private System.Windows.Forms.Label lblHoaDonTrungBinh;
        private System.Windows.Forms.Label lblHoaDonTrungBinhTieuDe;
        private System.Windows.Forms.Label lblTongMonDaBan;
        private System.Windows.Forms.Label lblTongMonDaBanTieuDe;
        private System.Windows.Forms.Panel pnlBieuDoDoanhThu;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.Label lblTieuDeBieuDo;
        private System.Windows.Forms.Panel pnlMonBanRa;
        private System.Windows.Forms.Label lblTieuDeMonBanRa;
        private System.Windows.Forms.DataGridView dgvMonBanRa;
        private System.Windows.Forms.ComboBox cboTopMon;
        private System.Windows.Forms.Label lblTopMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuongBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDoanhThuMon;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.ComboBox cboDenNam;
        private System.Windows.Forms.Label lblDenNam;
        private System.Windows.Forms.ComboBox cboTuNam;
        private System.Windows.Forms.Label lblTuNam;
    }
}