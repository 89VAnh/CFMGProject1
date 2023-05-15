using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;

namespace BusinessLogicLayer
{
    public class ExcelHelper
    {
        public static DataTable ReadFromExcelFile(string path, int headerRow, out string messageError)
        {
            DataTable result = new DataTable();
            try
            {
                if (string.IsNullOrEmpty(path) || !System.IO.File.Exists(path))
                {
                    messageError = "FILE_NOT_EXISTS";
                    return null;
                }

                if (!string.IsNullOrEmpty(path) && Path.HasExtension(path) && Path.GetExtension(path).ToLower() != ".xlsx")
                {
                    messageError = "WRONG_FORMAT_FILE";
                    return null;
                }
                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                using (ExcelPackage package = new ExcelPackage(new FileInfo(path)))
                {
                    var workBook = package.Workbook;
                    if (workBook == null || workBook.Worksheets.Count == 0)
                    {
                        messageError = "EMPTY_DATA";
                        return null;
                    }
                    var workSheet = workBook.Worksheets.First();
                    //Read all header column from first row in file excel
                    int columnCount = 0;
                    foreach (var firstRowCell in workSheet.Cells[headerRow, 1, headerRow, workSheet.Dimension.End.Column])
                    {
                        string columnName = "" + firstRowCell.Text.Trim();
                        if (string.IsNullOrEmpty(columnName))
                            break;
                        columnCount++;
                        result.Columns.Add(firstRowCell.Text.Trim());
                    }
                    //Read data into datatable from second row in file excel

                    for (var rowNumber = headerRow + 1; rowNumber <= workSheet.Dimension.End.Row; rowNumber++)
                    {
                        var row = workSheet.Cells[rowNumber, 1, rowNumber, columnCount];
                        var newRow = result.NewRow();
                        bool isRowData = false;
                        string str = "";
                        //Read and check row data not Empty
                        foreach (var cell in row)
                        {
                            if (cell != null)
                                isRowData = true;

                            newRow[cell.Start.Column - 1] = cell.Value;
                            str += cell.Value != null ? cell.Value : "";
                        }
                        //Add row data to Datatable
                        if (isRowData && !string.IsNullOrEmpty(str.Trim()))
                            result.Rows.Add(newRow);
                        if (string.IsNullOrEmpty(str.Trim())) break;
                    }
                }
                messageError = "";
            }
            catch (Exception ex) { messageError = "ERROR:" + ex.Message; }

            return result;
        }

        public static DataTable ReadFromExcelFile(string path, string sheetName, int headerRow, out string messageError)
        {
            DataTable result = new DataTable();
            try
            {
                if (string.IsNullOrEmpty(path) || !File.Exists(path))
                {
                    messageError = "FILE_NOT_EXISTS";
                    return null;
                }

                if (!string.IsNullOrEmpty(path) && Path.HasExtension(path) && Path.GetExtension(path).ToLower() != ".xlsx")
                {
                    messageError = "WRONG_FORMAT_FILE";
                    return null;
                }
                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                using (ExcelPackage package = new ExcelPackage(new FileInfo(path)))
                {
                    var workBook = package.Workbook;
                    if (workBook == null || workBook.Worksheets.Count == 0)
                    {
                        messageError = "EMPTY_DATA";
                        return null;
                    }

                    var workSheet = workBook.Worksheets.FirstOrDefault(x => x.Name == sheetName);
                    if (!string.IsNullOrEmpty(sheetName) && workSheet == null)
                    {
                        messageError = "WRONG_TEMPLATE";
                        return null;
                    }

                    //Read all header column from first row in file excel
                    foreach (var firstRowCell in workSheet.Cells[headerRow, 1, headerRow, workSheet.Dimension.End.Column])
                    {
                        string columnName = "" + firstRowCell.Text.Trim();
                        if (string.IsNullOrEmpty(columnName))
                            break;
                        result.Columns.Add(firstRowCell.Text);
                    }
                    //Read data into datatable from second row in file excel
                    for (var rowNumber = headerRow + 1; rowNumber <= workSheet.Dimension.End.Row; rowNumber++)
                    {
                        var row = workSheet.Cells[rowNumber, 1, rowNumber, workSheet.Dimension.End.Column];
                        var newRow = result.NewRow();

                        bool isRowData = false;

                        //Read and check row data not Empty
                        foreach (var cell in row)
                        {
                            //string textValue = ("" + cell.Text).Trim();
                            if (cell != null)
                                isRowData = true;

                            newRow[cell.Start.Column - 1] = cell.Value;
                        }
                        //Add row data to Datatable
                        if (isRowData)
                            result.Rows.Add(newRow);
                    }
                }
                messageError = "";
            }
            catch (Exception ex) { messageError = "ERROR:" + ex.Message; }

            return result;
        }

        public static DataTable ReadFromExcelFile(string path, string sheetName, int headerRow, List<Type> types, out string messageError)
        {
            DataTable result = new DataTable();
            try
            {
                if (string.IsNullOrEmpty(path) || !File.Exists(path))
                {
                    messageError = "FILE_NOT_EXISTS";
                    return null;
                }

                if (!string.IsNullOrEmpty(path) && Path.HasExtension(path) && Path.GetExtension(path).ToLower() != ".xlsx")
                {
                    messageError = "WRONG_FORMAT_FILE";
                    return null;
                }
                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                using (ExcelPackage package = new ExcelPackage(new FileInfo(path)))
                {
                    var workBook = package.Workbook;
                    if (workBook == null || workBook.Worksheets.Count == 0)
                    {
                        messageError = "EMPTY_DATA";
                        return null;
                    }

                    var workSheet = workBook.Worksheets.First();
                    if (!string.IsNullOrEmpty(sheetName) && workSheet.Name != sheetName)
                    {
                        messageError = "WRONG_TEMPLATE";
                        return null;
                    }

                    //Read all header column from first row in file excel
                    int typeIndex = -1;
                    foreach (var firstRowCell in workSheet.Cells[headerRow, 1, headerRow, workSheet.Dimension.End.Column])
                    {
                        typeIndex++;

                        string columnName = "" + firstRowCell.Text.Trim();
                        if (string.IsNullOrEmpty(columnName))
                            break;
                        if (types != null && types.Count > typeIndex)
                            result.Columns.Add(firstRowCell.Text, types[typeIndex]);
                        else result.Columns.Add(firstRowCell.Text);
                    }
                    //Read data into datatable from second row in file excel
                    for (var rowNumber = headerRow + 1; rowNumber <= workSheet.Dimension.End.Row; rowNumber++)
                    {
                        var row = workSheet.Cells[rowNumber, 1, rowNumber, workSheet.Dimension.End.Column];
                        var newRow = result.NewRow();

                        bool isRowData = false;

                        //Read and check row data not Empty
                        foreach (var cell in row)
                        {
                            //string textValue = ("" + cell.Text).Trim();
                            if (cell != null)
                                isRowData = true;

                            //Catch error when data input cannot mapping with type column
                            try
                            {
                                newRow[cell.Start.Column - 1] = cell.Value == null ? DBNull.Value : cell.Value;
                            }
                            catch (Exception ex)
                            {
                                newRow[cell.Start.Column - 1] = DBNull.Value;
                            }
                        }
                        //Add row data to Datatable
                        if (isRowData)
                            result.Rows.Add(newRow);
                    }
                }
                messageError = "";
            }
            catch (Exception ex) { messageError = "ERROR:" + ex.StackTrace; }

            return result;
        }

        public static string ExportDataTableToExcel(string pathFileExport, string pathFileTemplate, DataTable data, int tableDataStartColumn, int tableDataStartRow,
            List<ExcelDataExtention> reportStaticValue, bool fistColumnIsOrdNumber, string formatDateTime, string formatNumber, bool endRowIsSumValue, string sumValueText, int headerRowSpan = 1, bool contentDashBottomBorder = false, double dataRowHeight = 14.0, DataTable data2 = null, int isBoldGroup = 0, int fontSizeGroup = 0, int heightGroup = 0, List<ColumnColor> columnColors = null, bool default_number = false, bool coppy_file = true, string sheet_name = null)
        {
            try
            {
                string pathTemplateFolder = Path.GetDirectoryName(pathFileTemplate);
                if (!File.Exists(pathFileTemplate))
                    pathFileTemplate = pathTemplateFolder + @"\EMPTY_TEMPLATE.xlsx";

                if (data == null || data.Rows.Count == 0)
                    return "DATA_EXPORT_EMPTY";
                if (coppy_file)
                    File.Copy(pathFileTemplate, pathFileExport, true);
                var existingFile = new FileInfo(pathFileExport);
                if (!existingFile.Exists)
                    return "PATH_FILE_EXPORT_NOT_EXISTS";
                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                using (var package = new ExcelPackage(existingFile))
                {
                    //Get the work book in the file
                    var workBook = package.Workbook;
                    if (workBook != null)
                        if (workBook.Worksheets.Count > 0)
                        {
                            //Get the first worksheet
                            var worksheet = workBook.Worksheets.First();
                            if (sheet_name + "" != "")
                            {
                                var sheet = workBook.Worksheets.FirstOrDefault(x => x.Name == sheet_name);
                                if (sheet != null)
                                    worksheet = sheet;
                            }

                            var indexRow = tableDataStartRow;
                            var indexColumn = tableDataStartColumn;
                            // Fill data header static data to file excel
                            var listHeaderReport = reportStaticValue.Where(x => x.IsEnd == false).ToList();
                            foreach (var headerItem in listHeaderReport)
                            {
                                if (headerItem.IsMerge)
                                    worksheet.Cells[headerItem.StartColumnName + headerItem.StartRowIndex + ":" + (headerItem.EndColumnName ?? headerItem.StartColumnName) + headerItem.EndRowIndex].Merge = true;

                                if (headerItem.TextRotation != null)
                                    worksheet.Cells[headerItem.StartColumnName + headerItem.StartRowIndex + ":" + (headerItem.EndColumnName ?? headerItem.StartColumnName) + headerItem.EndRowIndex].Style.TextRotation = headerItem.TextRotation.Value;

                                if (headerItem.FontBold)
                                    worksheet.Cells[headerItem.StartColumnName + headerItem.StartRowIndex + ":" + (headerItem.EndColumnName ?? headerItem.StartColumnName) + headerItem.EndRowIndex].Style.Font.Bold = true;

                                if (headerItem.FontUnderline)
                                    worksheet.Cells[headerItem.StartColumnName + headerItem.StartRowIndex + ":" + (headerItem.EndColumnName ?? headerItem.StartColumnName) + headerItem.EndRowIndex].Style.Font.UnderLine = true;

                                if (headerItem.FontItalic)
                                    worksheet.Cells[headerItem.StartColumnName + headerItem.StartRowIndex + ":" + (headerItem.EndColumnName ?? headerItem.StartColumnName) + headerItem.EndRowIndex].Style.Font.Italic = true;

                                if (headerItem.FontSize > 0)
                                    worksheet.Cells[headerItem.StartColumnName + headerItem.StartRowIndex + ":" + (headerItem.EndColumnName ?? headerItem.StartColumnName) + headerItem.EndRowIndex].Style.Font.Size = headerItem.FontSize;

                                if (!string.IsNullOrEmpty(headerItem.FontName))
                                    worksheet.Cells[headerItem.StartColumnName + headerItem.StartRowIndex + ":" + (headerItem.EndColumnName ?? headerItem.StartColumnName) + headerItem.EndRowIndex].Style.Font.Name = headerItem.FontName;

                                if (headerItem.AlignmentCenter)
                                    worksheet.Cells[headerItem.StartColumnName + headerItem.StartRowIndex + ":" + (headerItem.EndColumnName ?? headerItem.StartColumnName) + headerItem.EndRowIndex].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                                if (headerItem.AlignmentLeft)
                                    worksheet.Cells[headerItem.StartColumnName + headerItem.StartRowIndex + ":" + (headerItem.EndColumnName ?? headerItem.StartColumnName) + headerItem.EndRowIndex].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                                if (headerItem.AlignmentRight)
                                    worksheet.Cells[headerItem.StartColumnName + headerItem.StartRowIndex + ":" + (headerItem.EndColumnName ?? headerItem.StartColumnName) + headerItem.EndRowIndex].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                if (headerItem.IsDirectTextRotation90)
                                    worksheet.Cells[headerItem.StartColumnName + headerItem.StartRowIndex + ":" + (headerItem.EndColumnName ?? headerItem.StartColumnName) + headerItem.EndRowIndex].Style.TextRotation = 90;

                                if (headerItem.Value != null)
                                    worksheet.Cells[headerItem.StartColumnName + headerItem.StartRowIndex + ":" + (headerItem.EndColumnName ?? headerItem.StartColumnName) + headerItem.EndRowIndex].Value = headerItem.Value;
                                if (headerItem.WidthColumn > 0)
                                    worksheet.Column(GetExcelColumnIndex(headerItem.StartColumnName)).Width = headerItem.WidthColumn;
                                if (headerItem.WidthColumn == -1)
                                    worksheet.Column(GetExcelColumnIndex(headerItem.StartColumnName)).Width = 0;
                            }
                            //Fill dataTable to file excel
                            int ord = 1;
                            int columnCount = data.Columns.Count;
                            int columnTableCount = data.Columns.Count + (tableDataStartColumn - 1);
                            if (fistColumnIsOrdNumber)
                                columnTableCount++;
                            foreach (DataRow dr in data.Rows)
                            {
                                int startColumnIndex = tableDataStartColumn;

                                //Set Row Height
                                if (dataRowHeight > 0)
                                    worksheet.Row(indexRow).Height = dataRowHeight;

                                if (fistColumnIsOrdNumber)
                                {
                                    worksheet.Cells[indexRow, tableDataStartColumn].Value = ord;
                                    startColumnIndex = startColumnIndex + 1;
                                }
                                //
                                int indColumn = 0;
                                bool isBoldValue = false;

                                for (int c = startColumnIndex; c < columnCount + startColumnIndex; c++)
                                {
                                    object value = ParseCellValue(dr[indColumn], formatNumber, formatDateTime, default_number);
                                    if (isBoldGroup > 0 && c == startColumnIndex && string.IsNullOrEmpty(value + ""))
                                    {
                                        isBoldValue = true;
                                        c = c + isBoldGroup;
                                        worksheet.Cells[indexRow, c - isBoldGroup, indexRow, c].Merge = true;
                                        worksheet.Cells[indexRow, c - isBoldGroup, indexRow, c].Style.Font.Bold = isBoldValue;
                                        worksheet.Cells[indexRow, c - isBoldGroup, indexRow, c].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                                        worksheet.Cells[indexRow, c - isBoldGroup, indexRow, c].Style.WrapText = true;
                                        indColumn++;
                                        value = ParseCellValue(dr[indColumn], formatNumber, formatDateTime, default_number) + "";
                                        worksheet.Cells[indexRow, c - isBoldGroup, indexRow, c].Value = value;
                                        worksheet.Cells[indexRow, c - isBoldGroup, indexRow, c].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                        worksheet.Cells[indexRow, c - isBoldGroup, indexRow, c].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                                        //worksheet.Cells[indexRow, c - isBoldGroup, indexRow, c].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 0, 0));
                                        if (fontSizeGroup > 0)
                                            worksheet.Cells[indexRow, c - isBoldGroup, indexRow, c].Style.Font.Size = fontSizeGroup;
                                        if (heightGroup > 0)
                                        {
                                            worksheet.Row(indexRow).Height = heightGroup;
                                        }
                                        indColumn += isBoldGroup;
                                        continue;
                                    }
                                    worksheet.Cells[indexRow, c].Value = value;
                                    worksheet.Cells[indexRow, c].Style.Font.Bold = isBoldValue;
                                    if (columnColors != null && columnColors.Count > 0)
                                    {
                                        var col = columnColors.FindIndex(x => x.ColumnIdx == c);
                                        if (col >= 0)
                                        {
                                            var color = columnColors[col];
                                            worksheet.Cells[indexRow, c].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                            worksheet.Cells[indexRow, c].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(color.R, color.G, color.B));
                                        }
                                    }
                                    indColumn++;
                                }
                                //
                                ord++;
                                indexRow++;
                            }
                            bool fisrtMatch = false;
                            //If EndRowTable is Sum Value
                            if (endRowIsSumValue)
                            {
                                int mergeIndex = 0;
                                for (int cl = 0; cl < columnCount; cl++)
                                {
                                    if (!IsColumnDataTypeNumber(data.Columns[cl].DataType))
                                    {
                                        if (!fisrtMatch)
                                            mergeIndex++;
                                    }
                                    else
                                    {
                                        fisrtMatch = true;
                                        string columnName = GetExcelColumnName(cl + (fistColumnIsOrdNumber == true ? tableDataStartColumn : tableDataStartColumn));
                                        worksheet.Cells[indexRow, cl + (fistColumnIsOrdNumber == true ? tableDataStartColumn : tableDataStartColumn)].Formula = string.Format("SUM({0}{1}:{2}{3})", columnName, tableDataStartRow, columnName, indexRow - 1);
                                    }
                                }

                                worksheet.Cells[indexRow, tableDataStartColumn, indexRow, mergeIndex + tableDataStartColumn - 1].Merge = true;
                                worksheet.Cells[indexRow, tableDataStartColumn, indexRow, mergeIndex + tableDataStartColumn - 1].Value = sumValueText;
                                worksheet.Cells[indexRow, tableDataStartColumn, indexRow, mergeIndex + tableDataStartColumn - 1].Style.Font.Bold = true;
                            }
                            //Fill border to table
                            if (!contentDashBottomBorder)
                            {
                                worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, endRowIsSumValue == true ? indexRow : indexRow - 1, columnTableCount].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, endRowIsSumValue == true ? indexRow : indexRow - 1, columnTableCount].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, endRowIsSumValue == true ? indexRow : indexRow - 1, columnTableCount].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, endRowIsSumValue == true ? indexRow : indexRow - 1, columnTableCount].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, endRowIsSumValue == true ? indexRow : indexRow - 1, columnTableCount].Style.Border.Left.Color.SetColor(Color.FromArgb(128, 128, 128));
                                worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, endRowIsSumValue == true ? indexRow : indexRow - 1, columnTableCount].Style.Border.Right.Color.SetColor(Color.FromArgb(128, 128, 128));
                                worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, endRowIsSumValue == true ? indexRow : indexRow - 1, columnTableCount].Style.Border.Top.Color.SetColor(Color.FromArgb(128, 128, 128));
                                worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, endRowIsSumValue == true ? indexRow : indexRow - 1, columnTableCount].Style.Border.Bottom.Color.SetColor(Color.FromArgb(128, 128, 128));
                            }
                            else
                            {
                                // Thin header
                                worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, tableDataStartRow, columnTableCount].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, tableDataStartRow, columnTableCount].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, tableDataStartRow, columnTableCount].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, tableDataStartRow, columnTableCount].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, tableDataStartRow, columnTableCount].Style.Border.Left.Color.SetColor(Color.FromArgb(128, 128, 128));
                                worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, tableDataStartRow, columnTableCount].Style.Border.Right.Color.SetColor(Color.FromArgb(128, 128, 128));
                                worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, tableDataStartRow, columnTableCount].Style.Border.Top.Color.SetColor(Color.FromArgb(128, 128, 128));
                                worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, tableDataStartRow, columnTableCount].Style.Border.Bottom.Color.SetColor(Color.FromArgb(128, 128, 128));
                                if (endRowIsSumValue)
                                {
                                    // Dash bottom content
                                    worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Top.Style = ExcelBorderStyle.Hair;
                                    worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Bottom.Style = ExcelBorderStyle.Hair;
                                    worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Left.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Right.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Top.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Bottom.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    // Thin sum row
                                    worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow, columnTableCount].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow, columnTableCount].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow, columnTableCount].Style.Border.Top.Style = ExcelBorderStyle.Hair;
                                    worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow, columnTableCount].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow, columnTableCount].Style.Border.Left.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow, columnTableCount].Style.Border.Right.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow, columnTableCount].Style.Border.Top.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow, columnTableCount].Style.Border.Bottom.Color.SetColor(Color.FromArgb(128, 128, 128));
                                }
                                else
                                {
                                    // Dash bottom content
                                    if (indexRow - tableDataStartRow >= 2)
                                    {
                                        worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 2, columnTableCount].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                        worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 2, columnTableCount].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                        worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 2, columnTableCount].Style.Border.Top.Style = ExcelBorderStyle.Hair;
                                        worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 2, columnTableCount].Style.Border.Bottom.Style = ExcelBorderStyle.Hair;
                                        worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 2, columnTableCount].Style.Border.Left.Color.SetColor(Color.FromArgb(128, 128, 128));
                                        worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 2, columnTableCount].Style.Border.Right.Color.SetColor(Color.FromArgb(128, 128, 128));
                                        worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 2, columnTableCount].Style.Border.Top.Color.SetColor(Color.FromArgb(128, 128, 128));
                                        worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 2, columnTableCount].Style.Border.Bottom.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    }
                                    // Thin last row
                                    worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Top.Style = ExcelBorderStyle.Hair;
                                    worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Left.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Right.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Top.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Bottom.Color.SetColor(Color.FromArgb(128, 128, 128));
                                }
                                if (isBoldGroup > 0)
                                {
                                    for (int idx = 0; idx < data.Rows.Count; idx++)
                                    {
                                        if ((data.Rows[idx][0] + "") == "")
                                        {
                                            worksheet.Cells[tableDataStartRow + idx, tableDataStartColumn, tableDataStartRow + idx, columnTableCount].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                            worksheet.Cells[tableDataStartRow + idx, tableDataStartColumn, tableDataStartRow + idx, columnTableCount].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                        }
                                    }
                                }
                            }

                            if (data2 != null)
                            {
                                //Fill Middle Static Value
                                var listMiddleReport = reportStaticValue.Where(x => x.IsEnd == null).OrderByDescending(x => x.StartRowIndex).ToList();
                                foreach (var middleItem in listMiddleReport)
                                {
                                    if (middleItem.IsMerge)
                                        worksheet.Cells[middleItem.StartColumnName + (middleItem.StartRowIndex + indexRow) + ":" + (middleItem.EndColumnName ?? middleItem.StartColumnName) + (middleItem.EndRowIndex + indexRow)].Merge = true;
                                    if (middleItem.TextRotation != null)
                                        worksheet.Cells[middleItem.StartColumnName + middleItem.StartRowIndex + ":" + (middleItem.EndColumnName ?? middleItem.StartColumnName) + middleItem.EndRowIndex].Style.TextRotation = middleItem.TextRotation.Value;
                                    if (middleItem.FontBold)
                                        worksheet.Cells[middleItem.StartColumnName + (middleItem.StartRowIndex + indexRow) + ":" + (middleItem.EndColumnName ?? middleItem.StartColumnName) + (middleItem.EndRowIndex + indexRow)].Style.Font.Bold = true;

                                    if (middleItem.FontUnderline)
                                        worksheet.Cells[middleItem.StartColumnName + (middleItem.StartRowIndex + indexRow) + ":" + (middleItem.EndColumnName ?? middleItem.StartColumnName) + (middleItem.EndRowIndex + indexRow)].Style.Font.UnderLine = true;

                                    if (middleItem.FontItalic)
                                        worksheet.Cells[middleItem.StartColumnName + (middleItem.StartRowIndex + indexRow) + ":" + (middleItem.EndColumnName ?? middleItem.StartColumnName) + (middleItem.EndRowIndex + indexRow)].Style.Font.Italic = true;

                                    if (middleItem.FontSize > 0)
                                        worksheet.Cells[middleItem.StartColumnName + (middleItem.StartRowIndex + indexRow) + ":" + (middleItem.EndColumnName ?? middleItem.StartColumnName) + (middleItem.EndRowIndex + indexRow)].Style.Font.Size = middleItem.FontSize;

                                    if (!string.IsNullOrEmpty(middleItem.FontName))
                                        worksheet.Cells[middleItem.StartColumnName + (middleItem.StartRowIndex + indexRow) + ":" + (middleItem.EndColumnName ?? middleItem.StartColumnName) + (middleItem.EndRowIndex + indexRow)].Style.Font.Name = middleItem.FontName;

                                    if (middleItem.AlignmentCenter)
                                        worksheet.Cells[middleItem.StartColumnName + (middleItem.StartRowIndex + indexRow) + ":" + (middleItem.EndColumnName ?? middleItem.StartColumnName) + (middleItem.EndRowIndex + indexRow)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                                    if (middleItem.AlignmentLeft)
                                        worksheet.Cells[middleItem.StartColumnName + middleItem.StartRowIndex + ":" + (middleItem.EndColumnName ?? middleItem.StartColumnName) + middleItem.EndRowIndex].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                                    if (middleItem.AlignmentRight)
                                        worksheet.Cells[middleItem.StartColumnName + middleItem.StartRowIndex + ":" + (middleItem.EndColumnName ?? middleItem.StartColumnName) + middleItem.EndRowIndex].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                    if (middleItem.IsDirectTextRotation90)
                                        worksheet.Cells[middleItem.StartColumnName + middleItem.StartRowIndex + ":" + (middleItem.EndColumnName ?? middleItem.StartColumnName) + middleItem.EndRowIndex].Style.TextRotation = 90;

                                    if (middleItem.Value != null)
                                        worksheet.Cells[middleItem.StartColumnName + (middleItem.StartRowIndex + indexRow) + ":" + (middleItem.EndColumnName ?? middleItem.StartColumnName) + (middleItem.EndRowIndex + indexRow)].Value = middleItem.Value;
                                }
                                ord = 1;
                                columnCount = data2.Columns.Count;
                                columnTableCount = data2.Columns.Count + (tableDataStartColumn - 1);
                                if (fistColumnIsOrdNumber)
                                    columnTableCount++;

                                indexRow = indexRow + (listMiddleReport.Count > 0 ? listMiddleReport[0].StartRowIndex : 0) + 1;
                                tableDataStartRow = indexRow - 1;
                                foreach (DataRow dr in data2.Rows)
                                {
                                    int startColumnIndex = tableDataStartColumn;

                                    //Set Row Height
                                    if (dataRowHeight > 0)
                                        worksheet.Row(indexRow).Height = dataRowHeight;
                                    if (fistColumnIsOrdNumber)
                                    {
                                        worksheet.Cells[indexRow, tableDataStartColumn].Value = ord;
                                        startColumnIndex = startColumnIndex + 1;
                                    }
                                    //
                                    int indColumn = 0;
                                    for (int c = startColumnIndex; c < columnCount + startColumnIndex; c++)
                                    {
                                        worksheet.Cells[indexRow, c].Value = ParseCellValue(dr[indColumn], formatNumber, formatDateTime, default_number);
                                        indColumn++;
                                    }
                                    ord++;
                                    indexRow++;
                                }

                                fisrtMatch = false;
                                //If EndRowTable 2 is Sum Value
                                if (endRowIsSumValue)
                                {
                                    int mergeIndex = 0;
                                    for (int cl = 0; cl < columnCount; cl++)
                                    {
                                        if (!IsColumnDataTypeNumber(data2.Columns[cl].DataType))
                                        {
                                            if (!fisrtMatch)
                                                mergeIndex++;
                                        }
                                        else
                                        {
                                            fisrtMatch = true;
                                            string columnName = GetExcelColumnName(cl + (fistColumnIsOrdNumber == true ? tableDataStartColumn : tableDataStartColumn));
                                            worksheet.Cells[indexRow, cl + (fistColumnIsOrdNumber == true ? tableDataStartColumn : tableDataStartColumn)].Formula = string.Format("SUM({0}{1}:{2}{3})", columnName, tableDataStartRow, columnName, indexRow - 1);

                                            //string columnName = GetExcelColumnName(cl + 1 + (fistColumnIsOrdNumber == true ? tableDataStartColumn : tableDataStartColumn + 1));
                                            //worksheet.Cells[indexRow, cl + 1 + (fistColumnIsOrdNumber == true ? tableDataStartColumn : tableDataStartColumn + 1)].Formula = string.Format("SUM({0}{1}:{2}{3})", columnName, tableDataStartRow, columnName, indexRow - 1);
                                        }
                                    }
                                    worksheet.Cells[indexRow, tableDataStartColumn, indexRow, mergeIndex + tableDataStartColumn - 1].Merge = true;
                                    worksheet.Cells[indexRow, tableDataStartColumn, indexRow, mergeIndex + tableDataStartColumn - 1].Value = sumValueText;
                                    worksheet.Cells[indexRow, tableDataStartColumn, indexRow, mergeIndex + tableDataStartColumn - 1].Style.Font.Bold = true;
                                }

                                //Fill border to table 2
                                if (!contentDashBottomBorder)
                                {
                                    worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, endRowIsSumValue == true ? indexRow : indexRow - 1, columnTableCount].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, endRowIsSumValue == true ? indexRow : indexRow - 1, columnTableCount].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, endRowIsSumValue == true ? indexRow : indexRow - 1, columnTableCount].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, endRowIsSumValue == true ? indexRow : indexRow - 1, columnTableCount].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, endRowIsSumValue == true ? indexRow : indexRow - 1, columnTableCount].Style.Border.Left.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, endRowIsSumValue == true ? indexRow : indexRow - 1, columnTableCount].Style.Border.Right.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, endRowIsSumValue == true ? indexRow : indexRow - 1, columnTableCount].Style.Border.Top.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, endRowIsSumValue == true ? indexRow : indexRow - 1, columnTableCount].Style.Border.Bottom.Color.SetColor(Color.FromArgb(128, 128, 128));
                                }
                                else
                                {
                                    // Thin header
                                    worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, tableDataStartRow, columnTableCount].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, tableDataStartRow, columnTableCount].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, tableDataStartRow, columnTableCount].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, tableDataStartRow, columnTableCount].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, tableDataStartRow, columnTableCount].Style.Border.Left.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, tableDataStartRow, columnTableCount].Style.Border.Right.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, tableDataStartRow, columnTableCount].Style.Border.Top.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, tableDataStartRow, columnTableCount].Style.Border.Bottom.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    if (endRowIsSumValue)
                                    {
                                        // Dash bottom content
                                        worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                        worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                        worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Top.Style = ExcelBorderStyle.Hair;
                                        worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Bottom.Style = ExcelBorderStyle.Hair;
                                        worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Left.Color.SetColor(Color.FromArgb(128, 128, 128));
                                        worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Right.Color.SetColor(Color.FromArgb(128, 128, 128));
                                        worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Top.Color.SetColor(Color.FromArgb(128, 128, 128));
                                        worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Bottom.Color.SetColor(Color.FromArgb(128, 128, 128));

                                        // Thin sum row
                                        worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow, columnTableCount].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                        worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow, columnTableCount].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                        worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow, columnTableCount].Style.Border.Top.Style = ExcelBorderStyle.Hair;
                                        worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow, columnTableCount].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                        worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow, columnTableCount].Style.Border.Left.Color.SetColor(Color.FromArgb(128, 128, 128));
                                        worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow, columnTableCount].Style.Border.Right.Color.SetColor(Color.FromArgb(128, 128, 128));
                                        worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow, columnTableCount].Style.Border.Top.Color.SetColor(Color.FromArgb(128, 128, 128));
                                        worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow, columnTableCount].Style.Border.Bottom.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    }
                                    else
                                    {
                                        // Dash bottom content
                                        if (indexRow - tableDataStartRow >= 2)
                                        {
                                            worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 2, columnTableCount].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                            worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 2, columnTableCount].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                            worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 2, columnTableCount].Style.Border.Top.Style = ExcelBorderStyle.Hair;
                                            worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 2, columnTableCount].Style.Border.Bottom.Style = ExcelBorderStyle.Hair;
                                            worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 2, columnTableCount].Style.Border.Left.Color.SetColor(Color.FromArgb(128, 128, 128));
                                            worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 2, columnTableCount].Style.Border.Right.Color.SetColor(Color.FromArgb(128, 128, 128));
                                            worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 2, columnTableCount].Style.Border.Top.Color.SetColor(Color.FromArgb(128, 128, 128));
                                            worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 2, columnTableCount].Style.Border.Bottom.Color.SetColor(Color.FromArgb(128, 128, 128));
                                        }
                                        // Thin last row
                                        worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                        worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                        worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Top.Style = ExcelBorderStyle.Hair;
                                        worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                        worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Left.Color.SetColor(Color.FromArgb(128, 128, 128));
                                        worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Right.Color.SetColor(Color.FromArgb(128, 128, 128));
                                        worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Top.Color.SetColor(Color.FromArgb(128, 128, 128));
                                        worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Bottom.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    }
                                }
                            }

                            //Fill Footer Static Value
                            var listFooterReport = reportStaticValue.Where(x => x.IsEnd == true).ToList();
                            foreach (var footerItem in listFooterReport)
                            {
                                if (footerItem.IsMerge)
                                    worksheet.Cells[footerItem.StartColumnName + (footerItem.StartRowIndex + indexRow) + ":" + (footerItem.EndColumnName ?? footerItem.StartColumnName) + (footerItem.EndRowIndex + indexRow)].Merge = true;

                                if (footerItem.FontBold)
                                    worksheet.Cells[footerItem.StartColumnName + (footerItem.StartRowIndex + indexRow) + ":" + (footerItem.EndColumnName ?? footerItem.StartColumnName) + (footerItem.EndRowIndex + indexRow)].Style.Font.Bold = true;

                                if (footerItem.FontUnderline)
                                    worksheet.Cells[footerItem.StartColumnName + (footerItem.StartRowIndex + indexRow) + ":" + (footerItem.EndColumnName ?? footerItem.StartColumnName) + (footerItem.EndRowIndex + indexRow)].Style.Font.UnderLine = true;

                                if (footerItem.FontItalic)
                                    worksheet.Cells[footerItem.StartColumnName + (footerItem.StartRowIndex + indexRow) + ":" + (footerItem.EndColumnName ?? footerItem.StartColumnName) + (footerItem.EndRowIndex + indexRow)].Style.Font.Italic = true;

                                if (footerItem.FontSize > 0)
                                    worksheet.Cells[footerItem.StartColumnName + (footerItem.StartRowIndex + indexRow) + ":" + (footerItem.EndColumnName ?? footerItem.StartColumnName) + (footerItem.EndRowIndex + indexRow)].Style.Font.Size = footerItem.FontSize;

                                if (!string.IsNullOrEmpty(footerItem.FontName))
                                    worksheet.Cells[footerItem.StartColumnName + (footerItem.StartRowIndex + indexRow) + ":" + (footerItem.EndColumnName ?? footerItem.StartColumnName) + (footerItem.EndRowIndex + indexRow)].Style.Font.Name = footerItem.FontName;

                                if (footerItem.AlignmentCenter)
                                    worksheet.Cells[footerItem.StartColumnName + (footerItem.StartRowIndex + indexRow) + ":" + (footerItem.EndColumnName ?? footerItem.StartColumnName) + (footerItem.EndRowIndex + indexRow)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                                if (footerItem.AlignmentLeft)
                                    worksheet.Cells[footerItem.StartColumnName + (footerItem.StartRowIndex + indexRow) + ":" + (footerItem.EndColumnName ?? footerItem.StartColumnName) + (footerItem.EndRowIndex + indexRow)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                                if (footerItem.AlignmentRight)
                                    worksheet.Cells[footerItem.StartColumnName + (footerItem.StartRowIndex + indexRow) + ":" + (footerItem.EndColumnName ?? footerItem.StartColumnName) + (footerItem.EndRowIndex + indexRow)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                if (footerItem.IsDirectTextRotation90)
                                    worksheet.Cells[footerItem.StartColumnName + footerItem.StartRowIndex + ":" + (footerItem.EndColumnName ?? footerItem.StartColumnName) + footerItem.EndRowIndex].Style.TextRotation = 90;

                                if (footerItem.Value != null)
                                    worksheet.Cells[footerItem.StartColumnName + (footerItem.StartRowIndex + indexRow) + ":" + (footerItem.EndColumnName ?? footerItem.StartColumnName) + (footerItem.EndRowIndex + indexRow)].Value = footerItem.Value;
                            }
                        }
                    // save our new workbook and we are done!
                    package.Save();
                }
            }
            catch (Exception ex)
            {
                return "Error:" + ex.Message;
            }
            return "";
        }

        #region Helper method

        public static object ParseCellValue(object dataValue, string formatedNumber, string formatedDateTime, bool defaul_number)
        {
            if (dataValue == null || dataValue is string)
                return dataValue;

            if (dataValue is int || dataValue is double || dataValue is float || dataValue is long)
            {
                if (dataValue == null && defaul_number)
                {
                    return "0";
                }
                else
                {
                    if (!string.IsNullOrEmpty(formatedNumber))
                        return ((double)dataValue).ToString(formatedNumber);
                    else return dataValue;
                }
            }

            if (dataValue is DateTime)
            {
                if (!string.IsNullOrEmpty(formatedDateTime))
                    return ((DateTime)dataValue).ToString(formatedDateTime);
                else return dataValue;
            }

            if (dataValue is bool)
                return ((bool)dataValue == true) ? "x" : "";

            return dataValue;
        }

        public static bool IsColumnDataTypeNumber(Type dataValue)
        {
            if (dataValue == typeof(System.Int16) || dataValue == typeof(System.Int32) || dataValue == typeof(System.Int64) || dataValue == typeof(System.Single) || dataValue == typeof(System.Double) || dataValue == typeof(System.Decimal))
                return true;

            return false;
        }

        public static string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }

        public static int GetExcelColumnIndex(string colAdress)
        {
            int[] digits = new int[colAdress.Length];
            for (int i = 0; i < colAdress.Length; ++i)
            {
                digits[i] = Convert.ToInt32(colAdress[i]) - 64;
            }
            int mul = 1; int res = 0;
            for (int pos = digits.Length - 1; pos >= 0; --pos)
            {
                res += digits[pos] * mul;
                mul *= 26;
            }
            return res;
        }

        public static List<ExcelDataExtention> AddTextColumnName(DataTable dt, int start_row, bool to_upper_text = false)
        {
            int i = -1;
            List<ExcelDataExtention> list = new List<ExcelDataExtention>();
            foreach (DataColumn c in dt.Columns)
            {
                string columnName = GetColumnNameExcel()[++i];
                list.Add(new ExcelDataExtention()
                {
                    IsEnd = false,
                    StartColumnName = columnName,
                    EndColumnName = columnName,
                    StartRowIndex = start_row,
                    EndRowIndex = start_row,
                    Value = to_upper_text ? c.ColumnName.ToUpper() : c.ColumnName
                });
            }
            return list;
        }

        public static string[] GetColumnNameExcel()
        {
            string columnNameExcel = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z," +
                "AA,AB,AC,AD,AE,AF,AG,AH,AI,AJ,AK,AL,AM,AN,AO,AP,AQ,AR,AS,AT,AU,AV,AW,AY,AZ,AY,AZ," +
                "BA,BB,BC,BD,BE,BF,BG,BH,BI,BJ,BK,BL,BM,BN,BO,BP,BQ,BR,BS,BT,BU,BV,BW,BY,BZ,BY,BZ,";
            return columnNameExcel.Split(',');
        }

        #endregion Helper method
    }

    public class ExcelDataExtention
    {
        public Guid Id { get; set; }
        public bool SetBackgroupColor { get; set; } = false;
        public List<string> ListSumColumnName { get; set; }
        public bool IsMerge { get; set; } = false;
        public bool? IsEnd { get; set; } = false;
        public bool FontUnderline { get; set; } = false;
        public bool FontBold { get; set; } = false;
        public bool FontItalic { get; set; } = false;
        public float FontSize { get; set; } = 0;
        public string FontName { get; set; }
        public string StartColumnName { get; set; }
        public string EndColumnName { get; set; }
        public int StartRowIndex { get; set; }
        public int EndRowIndex { get; set; }
        public bool AlignmentCenter { get; set; } = false;
        public double WidthColumn { get; set; } = 0;
        public bool AlignmentLeft { get; set; } = false;
        public bool AlignmentRight { get; set; } = false;
        public string Value { get; set; }
        public bool IsDirectTextRotation90 { get; set; } = false;
        public int? TextRotation { get; set; } = 0;
    }

    public class ColumnColor
    {
        public int ColumnIdx { get; set; }
        public int R { get; set; } = 0;
        public int G { get; set; } = 0;
        public int B { get; set; } = 0;
    }
}