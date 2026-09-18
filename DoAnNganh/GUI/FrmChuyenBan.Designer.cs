namespace Đồ_án_ngành.GUI
{
    partial class FrmChuyenBan
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
            this.flpDanhSachBan = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpDanhSachBan
            // 
            this.flpDanhSachBan.AutoScroll = true;
            this.flpDanhSachBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpDanhSachBan.Location = new System.Drawing.Point(0, 0);
            this.flpDanhSachBan.Name = "flpDanhSachBan";
            this.flpDanhSachBan.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.flpDanhSachBan.Size = new System.Drawing.Size(404, 261);
            this.flpDanhSachBan.TabIndex = 0;
            // 
            // FrmChuyenBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 261);
            this.Controls.Add(this.flpDanhSachBan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChuyenBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyển bàn";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpDanhSachBan;
    }
}