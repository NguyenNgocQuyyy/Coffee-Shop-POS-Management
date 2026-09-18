namespace Đồ_án_ngành
{
    partial class FrmMain
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
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnScrollUp = new System.Windows.Forms.Button();
            this.btnScrollDown = new System.Windows.Forms.Button();
            this.flpChucNang = new System.Windows.Forms.FlowLayoutPanel();
            this.lblMenuTitle = new System.Windows.Forms.Label();
            this.flpBan = new System.Windows.Forms.FlowLayoutPanel();
            this.lblNguoiDung = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.pnlHeader.Controls.Add(this.lblNguoiDung);
            this.pnlHeader.Controls.Add(this.lblSubTitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(933, 85);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(205)))), ((int)(((byte)(175)))));
            this.lblSubTitle.Location = new System.Drawing.Point(28, 52);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(228, 17);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "HỆ THỐNG QUẢN LÝ QUÁN CÀ PHÊ";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(25, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(165, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "NOVEMBER";
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.White;
            this.pnlMenu.Controls.Add(this.btnScrollUp);
            this.pnlMenu.Controls.Add(this.btnScrollDown);
            this.pnlMenu.Controls.Add(this.flpChucNang);
            this.pnlMenu.Controls.Add(this.lblMenuTitle);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMenu.Location = new System.Drawing.Point(713, 85);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(220, 503);
            this.pnlMenu.TabIndex = 1;
            // 
            // btnScrollUp
            // 
            this.btnScrollUp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnScrollUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnScrollUp.FlatAppearance.BorderSize = 0;
            this.btnScrollUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScrollUp.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScrollUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.btnScrollUp.Location = new System.Drawing.Point(100, 40);
            this.btnScrollUp.Name = "btnScrollUp";
            this.btnScrollUp.Size = new System.Drawing.Size(30, 30);
            this.btnScrollUp.TabIndex = 2;
            this.btnScrollUp.Text = "▲";
            this.btnScrollUp.UseVisualStyleBackColor = false;
            this.btnScrollUp.Click += new System.EventHandler(this.btnScrollUp_Click);
            // 
            // btnScrollDown
            // 
            this.btnScrollDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnScrollDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnScrollDown.FlatAppearance.BorderSize = 0;
            this.btnScrollDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScrollDown.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScrollDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.btnScrollDown.Location = new System.Drawing.Point(100, 520);
            this.btnScrollDown.Name = "btnScrollDown";
            this.btnScrollDown.Size = new System.Drawing.Size(30, 30);
            this.btnScrollDown.TabIndex = 0;
            this.btnScrollDown.Text = "▼";
            this.btnScrollDown.UseVisualStyleBackColor = false;
            this.btnScrollDown.Click += new System.EventHandler(this.btnScrollDown_Click);
            // 
            // flpChucNang
            // 
            this.flpChucNang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpChucNang.AutoScroll = true;
            this.flpChucNang.Location = new System.Drawing.Point(9, 76);
            this.flpChucNang.Name = "flpChucNang";
            this.flpChucNang.Size = new System.Drawing.Size(202, 361);
            this.flpChucNang.TabIndex = 1;
            // 
            // lblMenuTitle
            // 
            this.lblMenuTitle.AutoSize = true;
            this.lblMenuTitle.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(47)))), ((int)(((byte)(32)))));
            this.lblMenuTitle.Location = new System.Drawing.Point(61, 14);
            this.lblMenuTitle.Name = "lblMenuTitle";
            this.lblMenuTitle.Size = new System.Drawing.Size(113, 23);
            this.lblMenuTitle.TabIndex = 0;
            this.lblMenuTitle.Text = "CHỨC NĂNG";
            // 
            // flpBan
            // 
            this.flpBan.AutoScroll = true;
            this.flpBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpBan.Location = new System.Drawing.Point(0, 85);
            this.flpBan.Name = "flpBan";
            this.flpBan.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.flpBan.Size = new System.Drawing.Size(713, 503);
            this.flpBan.TabIndex = 2;
            // 
            // lblNguoiDung
            // 
            this.lblNguoiDung.AutoSize = true;
            this.lblNguoiDung.BackColor = System.Drawing.Color.Transparent;
            this.lblNguoiDung.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguoiDung.ForeColor = System.Drawing.Color.White;
            this.lblNguoiDung.Location = new System.Drawing.Point(1150, 46);
            this.lblNguoiDung.Name = "lblNguoiDung";
            this.lblNguoiDung.Size = new System.Drawing.Size(227, 25);
            this.lblNguoiDung.TabIndex = 2;
            this.lblNguoiDung.Text = "Người dùng: MANAGER";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(242)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(933, 588);
            this.Controls.Add(this.flpBan);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NOVEMBER";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.FlowLayoutPanel flpBan;
        private System.Windows.Forms.Label lblMenuTitle;
        private System.Windows.Forms.FlowLayoutPanel flpChucNang;
        private System.Windows.Forms.Button btnScrollDown;
        private System.Windows.Forms.Button btnScrollUp;
        private System.Windows.Forms.Label lblNguoiDung;
    }
}