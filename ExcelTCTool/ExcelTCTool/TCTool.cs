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
        private const string SRS_NUMBER = "SRS";
        private const int SRS_Column = 5;  //E column
        private const string RANGE_FLAG = "~";


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

        private void chkSRS_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                List<string> notFindSRS = new List<string>();
                List<string> range = new List<string>();
                NotFind dialog = new NotFind();
                List<string> InputToFindSRS = new List<string>();
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    InputToFindSRS = dialog.SRSList;
                    //Get excel sheet
                    sheet = Globals.ThisAddIn.Application.ActiveWorkbook.ActiveSheet;
                    int MaxRow = ((Range)(sheet.Cells[sheet.Rows.Count, TC_CASENO_COLUMN]))
                         .End[Microsoft.Office.Interop.Excel.XlDirection.xlUp].Row;
                    int srsCol = FindSRSColumnNumber(sheet, MaxRow);
                    for (int i = 1; i <= MaxRow; i++)
                    {
                        string value = Convert.ToString(((Range)sheet.Cells[i, srsCol]).Value);
                        if (!string.IsNullOrEmpty(value) && value.Contains("SRS"))
                        {
                            if (!string.IsNullOrEmpty(value) && value.Contains(RANGE_FLAG) && value.Contains("SRS-"))
                            {
                                AddRangeSRSToList(value, ref range);
                                foreach (string srs in range)
                                {
                                    if (InputToFindSRS.Any(s => isSameSRS(s, srs)))
                                    {  //Exists

                                    }
                                    else
                                    {
                                        notFindSRS.Add(srs);
                                    }
                                }
                            }
                            else
                            {
                                if (isSRSNumberLine(value))
                                {
                                    if (InputToFindSRS.Any(s => isSameSRS(s, value)))
                                    {  //Exists

                                    }
                                    else
                                    {
                                        notFindSRS.Add(value);
                                    }
                                }
                            }
                        }
                    }
                    if (notFindSRS.Count > 0)
                    {
                        notFindSRS = notFindSRS.Distinct().ToList();

                        List<string> list1 = new List<string>();
                        List<string> list2 = new List<string>();
                        foreach (var srs in notFindSRS)
                        {
                            if (InputToFindSRS.Any(s => isSameSRS(s, srs)))
                            {
                                list2.Add(srs);
                            }
                            else
                            {
                                list1.Add(srs);
                            }
                        }
                        Result rt = new Result(list1, list2);
                        rt.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("完全一致");
                    }
                }
                else
                {
                    MessageBox.Show("数据不对");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool isSameSRS(string srs1, string srs2)
        {
            int number1 = Convert.ToInt32(srs1.Trim().Replace("SRS-", string.Empty));
            int number2 = Convert.ToInt32(srs2.Trim().Replace("SRS-", string.Empty));
            return (number1 == number2);
        }

        private bool isSRSNumberLine(string value)
        {
            int r = 0;
            string ret = value.Trim().Replace("SRS-", string.Empty);
            return int.TryParse(ret, out r);
        }

        private void AddRangeSRSToList(string value, ref List<string> srsList)
        {
            srsList = new List<string>();
            var values = value.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach(var str in values)
            {
                if (!str.Contains(RANGE_FLAG) && isSRSNumberLine(str))
                {
                    srsList.Add(str.Trim());
                }
                else
                {
                    if (str.Contains(RANGE_FLAG) && FindStringCount(str, "SRS-") == 2)
                    {
                        string strValue = str.Trim();
                        int findIndex = strValue.IndexOf(RANGE_FLAG);
                        string startSRSNum = strValue.Substring(0, findIndex).Trim();
                        int lastSRS = strValue.Substring(findIndex).LastIndexOf("SRS");
                        string lastSRSString = "SRS-";
                        if (lastSRS >= 0)
                        {
                            string lastSRSNum = strValue.Substring(findIndex).Substring(lastSRS).Trim();
                            string checkString = lastSRSNum.Substring(4); //Remove "SRS-"
                            int temp;
                            foreach (char c in checkString)
                            {
                                if (int.TryParse(c.ToString(), out temp))
                                {
                                    lastSRSString += c.ToString();
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        //Add list
                        srsList.Add(startSRSNum);
                        string nextSRS = startSRSNum;
                        while (nextSRS != lastSRSString)
                        {
                            nextSRS = AddSRSNum(nextSRS);
                            srsList.Add(nextSRS);
                        }
                    }
                }
            }
        }

        private int FindStringCount(string content, string findStr)
        {
            int count = 0;
            int i = 0;
            while ((i = content.IndexOf(findStr, i)) != -1)
            {
                i += findStr.Length;
                count++;
            }
            return count;
        }

        private string AddSRSNum(string currentSRS)
        {
            string number = currentSRS.Trim().Replace("SRS-", string.Empty);
            int length = number.Length;
            int num = Convert.ToInt32(number) + 1;
            return "SRS-" + num.ToString().PadLeft(length, '0');
        }

        private int FindSRSColumnNumber(Worksheet sheet, int maxRow)
        {
            int findCol = -1;
            if (maxRow > 6)
            {
                //Check first five row
                for (int row = 1; row < 6; row++)
                {
                    //Check only fifth column
                    for (int i = 1; i < 6; i++)
                    {
                        Range rg = sheet.Cells[row, i];
                        if (rg != null && rg.Value != null)
                        {
                            string value = rg.ToString();
                            if (value.Contains(SRS_NUMBER))
                            {  //Find SRS
                                findCol = i;
                                break;
                            }
                        }
                    }
                    if (findCol >= 0)
                    {
                        break;
                    }
                }
            }
            //Default E column
            findCol = findCol >= 0 ? findCol : SRS_Column;
            return findCol;
        }
    }
}
