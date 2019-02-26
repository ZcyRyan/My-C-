using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetAppMemoryUsage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            //var p = Process.GetProcessesByName(txtName.Text).FirstOrDefault();
            //StringBuilder bd = new StringBuilder();
            //bd.Append(p.WorkingSet.ToString());
            //txtMessage.Text = bd.ToString();

            StringBuilder bd = new StringBuilder();
            var counter = new PerformanceCounter("Process", "Working Set - Private", txtName.Text);
            bd.Append(string.Format("{0}K", counter.RawValue / 1024));
            txtMessage.Text = bd.ToString();
        }
    }
}
