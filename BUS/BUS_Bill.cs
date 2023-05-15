using BusinessLogicLayer;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BUS
{
    public class BUS_Bill
    {
        private DAL_Bill dalBill = new DAL_Bill();
        private DAL_BillAtShop dalBillAtShop = new DAL_BillAtShop();
        private DAL_BillDelivery dalBillDelivery = new DAL_BillDelivery();

        public int CountNumBills(DateTime startDate, DateTime endDate)
        {
            return dalBillAtShop.GetAll()
                .Where(x => x.ThoiGianRa >= startDate && x.ThoiGianRa <= endDate).Count() +
                dalBillDelivery.GetAll()
                .Where(x => x.ThoiGianNhan >= startDate && x.ThoiGianNhan <= endDate).Count();
        }

        public List<DoanhThuTheoLoaiHD_Result> RevenueByBillType(DateTime startDate, DateTime endDate)
        {
            return dalBill.RevenueByBillType(startDate, endDate);
        }

        public List<DoanhThuTheoNgay_Result> RevenueByDate(DateTime startDate, DateTime endDate)
        {
            return dalBill.RevenueByDate(startDate, endDate);
        }

        public List<TopDoanhThuSP_Result> TopProducts(DateTime startDate, DateTime endDate)
        {
            return dalBill.TopProduct(startDate, endDate);
        }

        public int GetTotalSale(DateTime startDate, DateTime endDate)
        {
            return RevenueByBillType(startDate, endDate).Sum(x => (int)x.TongTien);
        }

        public void ExportBillAtShopToExcel(DateTime startDate, DateTime endDate, string templatePath, string exportPath)
        {
            var list = dalBill.GetBillAtShopUnPaied(startDate, endDate);

            DataTable dataExport = new DataTable();
            dataExport.Columns.Add("Ma", typeof(int));
            dataExport.Columns.Add("Ban");
            dataExport.Columns.Add("TenKH");
            dataExport.Columns.Add("TenNV");
            dataExport.Columns.Add("GiamGia");
            dataExport.Columns.Add("TongTien", typeof(int));
            dataExport.Columns.Add("ThoiGianVao");
            dataExport.Columns.Add("ThoiGianRa");
            List<ExcelDataExtention> staticDataValue = new List<ExcelDataExtention>();
            staticDataValue.Add(new ExcelDataExtention
            {
                IsEnd = false,
                StartColumnName = "H",
                EndColumnName = "H",
                StartRowIndex = 4,
                EndRowIndex = 4,
                Value = "Hưng yên, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year
            }); ;
            int start_row = 6;
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    DataRow row = dataExport.NewRow();

                    row["Ma"] = item.Ma;

                    row["Ban"] = item.Ban.Ten;

                    if (string.IsNullOrEmpty(item.MaKH))
                        row["TenKH"] = DBNull.Value;
                    else
                        row["TenKH"] = item.MaKH + " - " + item.KhachHang.Ten;

                    if (string.IsNullOrEmpty(item.MaNV))
                        row["TenNV"] = DBNull.Value;
                    else
                        row["TenNV"] = item.MaNV + " - " + item.NhanVien.Ten;

                    if (string.IsNullOrEmpty(item.GiamGia))
                        row["GiamGia"] = DBNull.Value;
                    else
                        row["GiamGia"] = item.GiamGia;

                    row["TongTien"] = item.TongTien;

                    row["ThoiGianVao"] = item.ThoiGianVao;

                    row["ThoiGianRa"] = item.ThoiGianRa;

                    dataExport.Rows.Add(row);
                }
                ExcelHelper.ExportDataTableToExcel(exportPath, templatePath, dataExport, 1, start_row + 1, staticDataValue, true, "", "", false, "");
            }
        }

        public void ExportBillTakeAwayToExcel(DateTime startDate, DateTime endDate, string templatePath, string exportPath)
        {
            var list = dalBill.GetBillTakeAwayUnPaied(startDate, endDate);

            DataTable dataExport = new DataTable();
            dataExport.Columns.Add("Ma", typeof(int));
            dataExport.Columns.Add("TenKH");
            dataExport.Columns.Add("TenNV");
            dataExport.Columns.Add("GiamGia");
            dataExport.Columns.Add("TongTien", typeof(int));
            dataExport.Columns.Add("ThoiGianVao");
            dataExport.Columns.Add("ThoiGianRa");
            List<ExcelDataExtention> staticDataValue = new List<ExcelDataExtention>();
            staticDataValue.Add(new ExcelDataExtention
            {
                IsEnd = false,
                StartColumnName = "G",
                EndColumnName = "G",
                StartRowIndex = 4,
                EndRowIndex = 4,
                Value = "Hưng yên, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year
            }); ;
            int start_row = 6;
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    DataRow row = dataExport.NewRow();

                    row["Ma"] = item.Ma;

                    if (string.IsNullOrEmpty(item.MaKH))
                        row["TenKH"] = DBNull.Value;
                    else
                        row["TenKH"] = item.MaKH + " - " + item.KhachHang.Ten;

                    if (string.IsNullOrEmpty(item.MaNV))
                        row["TenNV"] = DBNull.Value;
                    else
                        row["TenNV"] = item.MaNV + " - " + item.NhanVien.Ten;

                    if (string.IsNullOrEmpty(item.GiamGia))
                        row["GiamGia"] = DBNull.Value;
                    else
                        row["GiamGia"] = item.GiamGia;

                    row["TongTien"] = item.TongTien;

                    row["ThoiGianVao"] = item.ThoiGianVao;

                    row["ThoiGianRa"] = item.ThoiGianRa;

                    dataExport.Rows.Add(row);
                }
                ExcelHelper.ExportDataTableToExcel(exportPath, templatePath, dataExport, 1, start_row + 1, staticDataValue, true, "", "", false, "");
            }
        }

        public void ExportBillDeliveryToExcel(DateTime startDate, DateTime endDate, string templatePath, string exportPath)
        {
            var list = dalBill.GetBillDeliveryUnPaied(startDate, endDate);

            DataTable dataExport = new DataTable();
            dataExport.Columns.Add("Ma", typeof(int));
            dataExport.Columns.Add("TenKH");
            dataExport.Columns.Add("DiaChi");
            dataExport.Columns.Add("GiamGia");
            dataExport.Columns.Add("TongTien", typeof(int));
            dataExport.Columns.Add("ThoiGianNhan");
            List<ExcelDataExtention> staticDataValue = new List<ExcelDataExtention>();
            staticDataValue.Add(new ExcelDataExtention
            {
                IsEnd = false,
                StartColumnName = "F",
                EndColumnName = "F",
                StartRowIndex = 4,
                EndRowIndex = 4,
                Value = "Hưng yên, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year
            }); ;
            int start_row = 6;
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    DataRow row = dataExport.NewRow();

                    row["Ma"] = item.Ma;

                    if (string.IsNullOrEmpty(item.MaKH))
                        row["TenKH"] = DBNull.Value;
                    else
                        row["TenKH"] = item.MaKH + " - " + item.KhachHang.Ten;

                    if (string.IsNullOrEmpty(item.DiaChi))
                        row["DiaChi"] = DBNull.Value;
                    else
                        row["DiaChi"] = item.DiaChi;

                    if (string.IsNullOrEmpty(item.GiamGia))
                        row["GiamGia"] = DBNull.Value;
                    else
                        row["GiamGia"] = item.GiamGia;

                    row["TongTien"] = item.TongTien;

                    row["ThoiGianNhan"] = item.ThoiGianNhan;

                    dataExport.Rows.Add(row);
                }
                ExcelHelper.ExportDataTableToExcel(exportPath, templatePath, dataExport, 1, start_row + 1, staticDataValue, true, "", "", false, "");
            }
        }
    }
}