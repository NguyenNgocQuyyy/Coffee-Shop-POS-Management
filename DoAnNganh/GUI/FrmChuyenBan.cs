using Đồ_án_ngành.BUS;
using MODEL;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Đồ_án_ngành.GUI
{
    public partial class FrmChuyenBan : Form
    {
        private readonly BanBUS _banBUS = new BanBUS();
        public Ban BanDuocChon { get; private set; }

        public FrmChuyenBan(Ban banHienTai)
        {
            InitializeComponent();
            LoadDanhSachBanTrong(banHienTai.MaBan);
        }

        private void LoadDanhSachBanTrong(string maBanHienTai)
        {
            var danhSachBan = _banBUS.GetAll()
                .Where(x =>
                x.TrangThai == "Trống" &&
                x.MaBan != maBanHienTai)
                .ToList();

            flpDanhSachBan.Controls.Clear();

            foreach (var ban in danhSachBan)
            {
                Button btnBan = new Button();

                btnBan.Text = "Bàn " + ban.SoBan;
                btnBan.Tag = ban.MaBan;

                btnBan.Width = 100;
                btnBan.Height = 70;

                btnBan.BackColor = Color.FromArgb(230, 205, 175);
                btnBan.ForeColor = Color.FromArgb(78, 47, 32);

                btnBan.FlatStyle = FlatStyle.Flat;
                btnBan.FlatAppearance.BorderSize = 0;

                btnBan.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btnBan.Cursor = Cursors.Hand;

                btnBan.Click += BtnBan_Click;
                flpDanhSachBan.Controls.Add(btnBan);
            }
        }

        private void BtnBan_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn == null)
                return;

            string maBan = btn.Tag.ToString();

            BanDuocChon = _banBUS.GetById(maBan);

            if (BanDuocChon == null)
                return;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
