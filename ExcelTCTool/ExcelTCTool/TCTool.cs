using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace ExcelTCTool
{
    public partial class TCTool
    {

        private const string TC_CASE_HEADERKEY = "WNV3_";
        private const int TC_CASENO_COLUMN = 1;
        private const int NON_COLOR = -4142;
        private const int FORMAT_START = 7;

        private Worksheet sheet;

        private void TCTool_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void btnSetTC_Click(object sender, RibbonControlEventArgs e)
        {

            try
            {
                sheet = Globals.ThisAddIn.Application.ActiveWorkbook.ActiveSheet;
                int MaxRow = ((Range)(sheet.Cells[sheet.Rows.Count, TC_CASENO_COLUMN]))
                     .End[Microsoft.Office.Interop.Excel.XlDirection.xlUp].Row;
                int CaseNo = 1;
                string caseHeader = string.Empty;
                bool BsetFirst = false;
                int columnCount = GetColumn();

                for (int i = 3; i <= MaxRow; i++)
                {
                    Range rg = sheet.Cells[i, TC_CASENO_COLUMN];

                    if (rg.Interior.ColorIndex != NON_COLOR)
                    {
                        Range headerRange = sheet.Range[sheet.Cells[i, 1], sheet.Cells[i, columnCount]];
                        headerRange.Borders[XlBordersIndex.xlEdgeTop].Weight = XlBorderWeight.xlMedium;
                    }

                    else
                    {

                        if (!BsetFirst)
                        {
                            string val = rg.Value;
                            if (val.Trim().StartsWith(TC_CASE_HEADERKEY))
                            {
                                CaseNo = Convert.ToInt16(val.Substring(val.Length - 3, 3));
                                caseHeader = val.Substring(0, val.Length - 3);
                            }
                            BsetFirst = true;     
                        }

                        sheet.Cells[i, TC_CASENO_COLUMN].value = caseHeader
                            + CaseNo.ToString().PadLeft(3, '0');
                        CaseNo++;
                        sheet.Rows[i].AutoFit();
                    }

                    CopyCellFormat(sheet.Cells[i, 1], sheet.Range[sheet.Cells[i, FORMAT_START], sheet.Cells[i, columnCount]]);
                }

                sheet.Cells[MaxRow, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int GetColumn()
        {
            int ret;
            sheet = Globals.ThisAddIn.Application.ActiveWorkbook.ActiveSheet;
            for (int i = 1; ; i++ )
            {
                Range rg = sheet.Cells[1, i];
                if (rg.Interior.ColorIndex != NON_COLOR)
                {
                    continue;
                }
                else
                {
                    ret = i - 1;
                    break;
                }
            }

            return ret;
        }

        private void CopyCellFormat(Range origin, Range target)
        {
            origin.Copy(Type.Missing);
            target.PasteSpecial(XlPasteType.xlPasteFormats);
        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            sheet = Globals.ThisAddIn.Application.ActiveWorkbook.ActiveSheet;
            string value = string.Empty;
            int startIndex = 1;
            string header = string.Empty;
            string content = string.Empty;
            string result = string.Empty;
            try
            {
                Range rg = Globals.ThisAddIn.Application.ActiveCell;
                if (rg != null)
                {
                    value = rg.Value;
                    var groupvalue = value.Split('\n');
                    startIndex = Convert.ToInt16(groupvalue[0].Substring(0, 1));
                    foreach (string v in groupvalue)
                    {
                        if (!string.IsNullOrEmpty(v.Trim()))
                        {
                            int pos = v.IndexOf(".");
                            if ((pos >= 0) && (pos<=4))
                            {
                                content = v.Substring(pos + 1);
                            }
                            else
                            {
                                content = v.TrimStart();
                            }
                            header = startIndex.ToString() + ". ";
                            result += header + content.Trim() + '\n';
                            startIndex++;
                        }
                    }
                }

                rg.Value = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
