using Novacode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;

namespace BUS.Helper
{
    public class DocxHelper
    {
        public static string fTempTableData = "#tbd";

        public static string space = "  ";

        public enum Document
        { DOCX, XLSX, PPTX }

        public static Novacode.Table FindTableWithText(List<Novacode.Table> tables, string temp, out int row, out int cell)
        {
            row = -1;
            cell = -1;
            foreach (var table in tables)
            {
                for (int r = 0; r < table.RowCount; ++r)
                {
                    for (int c = 0; c < table.Rows[r].Cells.Count; ++c)
                    {
                        if (table.Rows[r].Cells[c].Xml.Value == temp)
                        {
                            row = r;
                            cell = c;
                            return table;
                        }
                    }
                }
            }
            return null;
        }

        public static string GetAgeFromText(string age)
        {
            if (age == "00:00:00")
                return "0 tháng";
            var arr = age.Split(' ');
            var length = arr.Length;
            int year = 0, month = 0, day = 0;
            for (int i = 0; i < arr.Length - 1; i += 2)
            {
                var text = arr[i + 1];
                if (text.Contains("year"))
                    year = Convert.ToInt32(arr[i]);
                if (text.Contains("mon"))
                    month = Convert.ToInt32(arr[i]);
                if (text.Contains("day"))
                    day = Convert.ToInt32(arr[i]);
            }
            if (year == 0 && month == 0)
                return day + " ngày";
            return year > 6 ? arr[length - 1].ToString() : year * 12 + month + " tháng";
        }

        public static void ReplaceData(Dictionary<string, string> dictionaryData, DataTable dtInfo, DocX doc, bool hidden = false)
        {
            if (dictionaryData != null && dictionaryData.Count > 0)
            {
                foreach (var item in dictionaryData)
                {
                    string value = "";
                    var lines = (item.Value + "").Split(new[] { Environment.NewLine },
                        StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < lines.Length; i++)
                        if (i == 0)
                            value = lines[i];
                        else value = value + "\r" + lines[i];
                    if (item.Key.StartsWith("wd_char"))
                    {
                        var format = new Formatting();
                        format.Size = item.Key.Split('|').Length > 1 ? int.Parse(item.Key.Split('|')[1]) : 15;
                        format.FontFamily = new Novacode.Font("Wingdings 2");
                        format.Hidden = false;
                        var tmp = int.Parse(value);
                        char tick = (char)tmp;
                        doc.ReplaceText("{" + item.Key.Split('|')[0].Replace("wd_char_", "") + "}", tick.ToString(), newFormatting: format);
                    }
                    else if (item.Key.StartsWith("wd1_char"))
                    {
                        var format = new Formatting();
                        format.Size = 9;
                        format.FontFamily = new Novacode.Font("Wingdings");
                        format.Hidden = false;
                        var tmp = int.Parse(value);
                        char tick = (char)tmp;
                        doc.ReplaceText("{" + item.Key.Replace("wd1_char_", "") + "}", tick.ToString(), newFormatting: format);
                    }
                    else
                    {
                        var format = new Formatting();
                        format.Hidden = false;
                        doc.ReplaceText("{" + item.Key + "}", ReplaceHexadecimalSymbols(value), newFormatting: hidden || value == "(" || value == ")" ? format : null);
                    }
                }
            }
            else if (dtInfo != null && dtInfo.Rows.Count > 0)
            {
                foreach (DataRow r in dtInfo.Rows)
                {
                    foreach (DataColumn c in dtInfo.Columns)
                    {
                        string value = "";
                        var lines = Convert.ToString(r[c.ColumnName]).Split(new[] { Environment.NewLine },
                            StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < lines.Length; i++)
                            if (i == 0)
                                value = lines[i];
                            else value = value + "\r" + lines[i];
                        if (c.ColumnName == "age")
                            value = GetAgeFromText(value);
                        doc.ReplaceText("{" + c.ColumnName + "}", ReplaceHexadecimalSymbols(value));
                    }
                }
            }
        }

        public static void ReplaceTime(DocX doc, DateTime? dateprint)
        {
            if (dateprint == null)
                dateprint = DateTime.Now;
            doc.ReplaceText("{location}", "Hưng yên");
            doc.ReplaceText("{hour}", string.Format("{0:00}", dateprint.Value.Hour));
            doc.ReplaceText("{minute}", string.Format("{0:00}", dateprint.Value.Minute));
            doc.ReplaceText("{year}", dateprint.Value.Year.ToString());
            doc.ReplaceText("{month}", string.Format("{0:00}", dateprint.Value.Month));
            doc.ReplaceText("{day}", string.Format("{0:00}", dateprint.Value.Day));
        }

        private static string ReplaceHexadecimalSymbols(string txt)
        {
            string r = "[\x00-\x08\x0B\x0C\x0E-\x1F\x26]";
            return Regex.Replace(txt, r, "", RegexOptions.Compiled);
        }
    }
}