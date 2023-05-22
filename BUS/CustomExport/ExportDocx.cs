using BUS.Helper;
using DAL;
using Novacode;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility;

namespace BUS.CustomExport
{
    public class ExportDocx : DocxHelper
    {
        public static string CreateBillAtShopTemplate(string filename, Dictionary<string, string> dictionaryData, List<CTHDTaiQuan> data)
        {
            string res = "";
            try
            {
                using (DocX document = DocX.Load(filename))
                {
                    ReplaceTime(document, null);
                    ReplaceData(dictionaryData, null, document);
                    int cRow = 1;
                    if (data != null && data.Count > 0)
                    {
                        Novacode.Table myTable = FindTableWithText(document.Tables, fTempTableData, out int Row, out int cCell);
                        if (data.Count > 0)
                        {
                            for (int i = 0; i < data.Count; i++)
                            {
                                Novacode.Row newRow = myTable.InsertRow(myTable.Rows[cRow], cRow + i + 1);
                                newRow.Cells[0].Paragraphs.First().Append((i + 1).ToString()).ReplaceText(fTempTableData, "");
                                newRow.Cells[1].Paragraphs.First().Append(data[i].SanPham.Ten);
                                newRow.Cells[2].Paragraphs.First().Append(data[i].SoLuong.ToString());
                                newRow.Cells[3].Paragraphs.First().Append(Tools.ConvertToCurrency(data[i].SanPham.DonGia));
                                newRow.Cells[4].Paragraphs.First().Append(Tools.ConvertToCurrency(data[i].SoLuong * data[i].SanPham.DonGia));
                            }
                            cRow += 1;
                        }
                        myTable.RemoveRow(1);
                    }
                    document.ReplaceText(fTempTableData, "");
                    document.Save();
                    document.Dispose();
                }
            }
            catch (Exception ex)
            {
                res = ex.Message;
            }
            return res;
        }

        public static string CreateBillDeliveryTemplate(string filename, Dictionary<string, string> dictionaryData, List<CTHDGiaoHang> data)
        {
            string res = "";
            try
            {
                using (DocX document = DocX.Load(filename))
                {
                    ReplaceTime(document, null);
                    ReplaceData(dictionaryData, null, document);
                    int cRow = 1;
                    if (data != null && data.Count > 0)
                    {
                        Novacode.Table myTable = FindTableWithText(document.Tables, fTempTableData, out int Row, out int cCell);
                        if (data.Count > 0)
                        {
                            for (int i = 0; i < data.Count; i++)
                            {
                                Novacode.Row newRow = myTable.InsertRow(myTable.Rows[cRow], cRow + i + 1);
                                newRow.Cells[0].Paragraphs.First().Append((i + 1).ToString()).ReplaceText(fTempTableData, "");
                                newRow.Cells[1].Paragraphs.First().Append(data[i].SanPham.Ten);
                                newRow.Cells[2].Paragraphs.First().Append(data[i].SoLuong.ToString());
                                newRow.Cells[3].Paragraphs.First().Append(Tools.ConvertToCurrency(data[i].SanPham.DonGia));
                                newRow.Cells[4].Paragraphs.First().Append(Tools.ConvertToCurrency(data[i].SoLuong * data[i].SanPham.DonGia));
                            }
                            cRow += 1;
                        }
                        myTable.RemoveRow(1);
                    }
                    document.ReplaceText(fTempTableData, "");
                    document.Save();
                    document.Dispose();
                }
            }
            catch (Exception ex)
            {
                res = ex.Message;
            }
            return res;
        }
    }
}