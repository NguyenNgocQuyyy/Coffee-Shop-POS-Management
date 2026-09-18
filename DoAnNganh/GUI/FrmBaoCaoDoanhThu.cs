using Đồ_án_ngành.BUS;
using MODEL;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.IO;

namespace Đồ_án_ngành.GUI
{
    public partial class FrmBaoCaoDoanhThu : Form
    {
        private readonly BaoCaoDoanhThuBUS _baoCaoBUS = new BaoCaoDoanhThuBUS();
        private BaoCaoDoanhThuDTO _baoCaoHienTai;

        public FrmBaoCaoDoanhThu()
        {
            InitializeComponent();

            chartDoanhThu.Series["DoanhThu"].Color = Color.FromArgb(139, 94, 60);

            cboLoaiThoiGian.Items.Add("Theo ngày");
            cboLoaiThoiGian.Items.Add("Theo tháng");
            cboLoaiThoiGian.Items.Add("Theo năm");

            for (int nam = DateTime.Now.Year - 5;
                 nam <= DateTime.Now.Year + 1;
                 nam++)
            {
                cboNam.Items.Add(nam);
                cboTuNam.Items.Add(nam);
                cboDenNam.Items.Add(nam);
            }

            cboTopMon.Items.Add("Top 5");
            cboTopMon.Items.Add("Top 10");
            cboTopMon.Items.Add("Tất cả");

            cboLoaiThoiGian.SelectedIndex = 0;

            cboNam.SelectedItem = DateTime.Now.Year;
            cboTuNam.SelectedItem = DateTime.Now.Year - 4;
            cboDenNam.SelectedItem = DateTime.Now.Year;

            cboTopMon.SelectedIndex = 0;

            CapNhatBoLoc();

            CauHinhBieuDo();
        }

        private void CapNhatBoLoc()
        {
            string loai = cboLoaiThoiGian.SelectedItem?.ToString();

            bool theoNgay = loai == "Theo ngày";
            bool theoThang = loai == "Theo tháng";
            bool theoNam = loai == "Theo năm";

            // Theo ngày
            lblTuNgay.Visible = theoNgay;
            dtpTuNgay.Visible = theoNgay;

            lblDenNgay.Visible = theoNgay;
            dtpDenNgay.Visible = theoNgay;

            // Theo tháng
            lblNam.Visible = theoThang;
            cboNam.Visible = theoThang;

            // Theo năm
            lblTuNam.Visible = theoNam;
            cboTuNam.Visible = theoNam;

            lblDenNam.Visible = theoNam;
            cboDenNam.Visible = theoNam;
        }

        private void cboLoaiThoiGian_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatBoLoc();
        }

        private void LayKhoangThoiGian(out DateTime tuNgay, out DateTime denNgay)
        {
            string loai = cboLoaiThoiGian.SelectedItem?.ToString();

            if (loai == "Theo ngày")
            {
                tuNgay = dtpTuNgay.Value.Date;
                denNgay = dtpDenNgay.Value.Date;

                if (tuNgay > denNgay)
                {
                    throw new ArgumentException(
                        "Từ ngày không được lớn hơn đến ngày.");
                }

                return;
            }

            if (loai == "Theo tháng")
            {
                int nam = Convert.ToInt32(cboNam.SelectedItem);

                tuNgay = new DateTime(nam, 1, 1);
                denNgay = new DateTime(nam, 12, 31);

                return;
            }

            if (loai == "Theo năm")
            {
                int tuNam = Convert.ToInt32(cboTuNam.SelectedItem);
                int denNam = Convert.ToInt32(cboDenNam.SelectedItem);

                if (tuNam > denNam)
                {
                    throw new ArgumentException(
                        "Từ năm không được lớn hơn đến năm.");
                }

                tuNgay = new DateTime(tuNam, 1, 1);
                denNgay = new DateTime(denNam, 12, 31);

                return;
            }

            throw new ArgumentException(
                "Vui lòng chọn loại báo cáo.");
        }

        private void HienThiTongQuan(BaoCaoDoanhThuDTO baoCao)
        {
            lblTongDoanhThu.Text =
                baoCao.TongDoanhThu.ToString("#,##0") + " đ";

            lblTongHoaDon.Text =
                baoCao.SoHoaDon.ToString("#,##0");

            decimal hoaDonTrungBinh =
                baoCao.SoHoaDon > 0
                    ? baoCao.TongDoanhThu / baoCao.SoHoaDon
                    : 0;

            lblHoaDonTrungBinh.Text =
                hoaDonTrungBinh.ToString("#,##0") + " đ";

            lblTongMonDaBan.Text =
                baoCao.TongSoMonBan.ToString("#,##0");
        }

        private void HienThiMonBanRa(BaoCaoDoanhThuDTO baoCao)
        {
            var danhSach = baoCao.DanhSachMonBanChay;

            string luaChon = cboTopMon.SelectedItem?.ToString();

            if (luaChon == "Top 5")
            {
                danhSach = danhSach.Take(5).ToList();
            }
            else if (luaChon == "Top 10")
            {
                danhSach = danhSach.Take(10).ToList();
            }

            dgvMonBanRa.AutoGenerateColumns = false;
            dgvMonBanRa.DataSource = null;
            dgvMonBanRa.DataSource = danhSach;
        }

        private void HienThiBieuDoTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            var duLieu = _baoCaoBUS.GetDoanhThuTheoNgay(tuNgay, denNgay);

            chartDoanhThu.Series["DoanhThu"].Points.Clear();

            foreach (var item in duLieu)
            {
                chartDoanhThu.Series["DoanhThu"].Points.AddXY(
                    item.Ngay.ToString("dd/MM"),
                    item.DoanhThu
                );
            }
        }

        private void HienThiBieuDoTheoThang(int nam)
        {
            var duLieu = _baoCaoBUS.GetDoanhThuTheoThang(nam);

            chartDoanhThu.Series["DoanhThu"].Points.Clear();

            foreach (var item in duLieu)
            {
                chartDoanhThu.Series["DoanhThu"].Points.AddXY(
                    "T" + item.Thang,
                    item.DoanhThu
                );
            }
        }

        private void HienThiBieuDoTheoNam(int tuNam, int denNam)
        {
            var duLieu = _baoCaoBUS.GetDoanhThuTheoNam(tuNam, denNam);

            chartDoanhThu.Series["DoanhThu"].Points.Clear();

            foreach (var item in duLieu)
            {
                chartDoanhThu.Series["DoanhThu"].Points.AddXY(
                    item.Nam.ToString(),
                    item.DoanhThu
                );
            }
        }

        private void CauHinhBieuDo()
        {
            var chartArea = chartDoanhThu.ChartAreas["ChartAreaDoanhThu"];

            chartArea.AxisY.LabelStyle.Format = "#,##0";
            chartArea.AxisX.Interval = 1;

            chartDoanhThu.Series["DoanhThu"].IsValueShownAsLabel = false;
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. LẤY KHOẢNG THỜI GIAN
                LayKhoangThoiGian(out DateTime tuNgay, out DateTime denNgay);

                // 2. LẤY DỮ LIỆU TỔNG QUAN
                BaoCaoDoanhThuDTO baoCao = _baoCaoBUS.GetBaoCao(tuNgay, denNgay);

                _baoCaoHienTai = baoCao;

                // 3. HIỂN THỊ TỔNG QUAN
                HienThiTongQuan(baoCao);

                // 4. HIỂN THỊ MÓN BÁN RA
                HienThiMonBanRa(baoCao);

                // 5. HIỂN THỊ BIỂU ĐỒ
                string loai = cboLoaiThoiGian.SelectedItem?.ToString();

                if (loai == "Theo ngày")
                {
                    HienThiBieuDoTheoNgay(tuNgay, denNgay);
                }
                else if (loai == "Theo tháng")
                {
                    int nam = Convert.ToInt32(cboNam.SelectedItem);

                    HienThiBieuDoTheoThang(nam);
                }
                else if (loai == "Theo năm")
                {
                    int tuNam = Convert.ToInt32(cboTuNam.SelectedItem);
                    int denNam = Convert.ToInt32(cboDenNam.SelectedItem);

                    HienThiBieuDoTheoNam(tuNam, denNam);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void cboTopMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_baoCaoHienTai == null)
                return;

            HienThiMonBanRa(_baoCaoHienTai);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (_baoCaoHienTai == null)
            {
                MessageBox.Show(
                    "Vui lòng xem báo cáo trước khi xuất Excel.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                saveFileDialog.FileName =
                    "BaoCaoDoanhThu_" +
                    DateTime.Now.ToString("ddMMyyyy_HHmmss") +
                    ".xlsx";

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                using (XLWorkbook workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("BaoCaoDoanhThu");

                    worksheet.Cell("A1").Value = "BÁO CÁO DOANH THU";
                    worksheet.Range("A1:D1").Merge();

                    worksheet.Cell("A3").Value = "Tổng doanh thu";
                    worksheet.Cell("B3").Value = _baoCaoHienTai.TongDoanhThu;

                    worksheet.Cell("A4").Value = "Tổng giảm giá";
                    worksheet.Cell("B4").Value = _baoCaoHienTai.TongGiamGia;

                    worksheet.Cell("A5").Value = "Số hóa đơn";
                    worksheet.Cell("B5").Value = _baoCaoHienTai.SoHoaDon;

                    decimal hoaDonTrungBinh =
                        _baoCaoHienTai.SoHoaDon > 0
                            ? _baoCaoHienTai.TongDoanhThu /
                              _baoCaoHienTai.SoHoaDon
                            : 0;

                    worksheet.Cell("A6").Value = "Hóa đơn trung bình";
                    worksheet.Cell("B6").Value = hoaDonTrungBinh;

                    worksheet.Cell("A7").Value = "Tổng món đã bán";
                    worksheet.Cell("B7").Value = _baoCaoHienTai.TongSoMonBan;

                    worksheet.Cell("A9").Value = "Mã món";
                    worksheet.Cell("B9").Value = "Tên món";
                    worksheet.Cell("C9").Value = "Số lượng bán";
                    worksheet.Cell("D9").Value = "Doanh thu";

                    int dong = 10;

                    foreach (var item in _baoCaoHienTai.DanhSachMonBanChay)
                    {
                        worksheet.Cell(dong, 1).Value = item.MaMon;
                        worksheet.Cell(dong, 2).Value = item.TenMon;
                        worksheet.Cell(dong, 3).Value = item.SoLuongBan;
                        worksheet.Cell(dong, 4).Value = item.DoanhThu;

                        dong++;
                    }

                    worksheet.Column("B").Width = 25;
                    worksheet.Columns("A:D").AdjustToContents();

                    worksheet.Column("B").Width = 25;

                    worksheet.Cell("B3").Style.NumberFormat.Format = "#,##0";
                    worksheet.Cell("B4").Style.NumberFormat.Format = "#,##0";
                    worksheet.Cell("B6").Style.NumberFormat.Format = "#,##0";

                    if (dong > 10)
                    {
                        worksheet.Range(
                            "D10:D" + (dong - 1)
                        ).Style.NumberFormat.Format = "#,##0";
                    }

                    workbook.SaveAs(saveFileDialog.FileName);
                }

                MessageBox.Show(
                    "Xuất Excel thành công.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }
    }
}
