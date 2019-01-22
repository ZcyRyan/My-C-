using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExcelTCTool
{
    public partial class Result : Form
    {
        public List<string> SRSinCase;
        public List<string> SRSNotFind;

        public Result(List<string> list1, List<string> list2)
        {
            InitializeComponent();
            SRSinCase = list1;
            SRSNotFind = list2;
        }

        private void Result_Load(object sender, EventArgs e)
        {
            StringBuilder txt1 = new StringBuilder();
            SRSinCase.ForEach(s => txt1.Append(s + Environment.NewLine));
            StringBuilder txt2 = new StringBuilder();
            SRSNotFind.ForEach(s => txt2.Append(s + Environment.NewLine));
            txtOverInCase.Text = txt1.ToString();
            txtNotFind.Text = txt2.ToString();
        }
    }
}
