using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LockFile
{
    public partial class Form1 : Form
    {
        private StreamWriter wr = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wr = new StreamWriter(txtFilePath.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (wr != null)
            {
                wr.Close();
                wr = null;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilePath_DragEnter(object sender, DragEventArgs e)
        {
            var d = e.Data.GetFormats();
            txtFilePath.Text = ((string[])(e.Data.GetData(d[7])))[0];
        }
    }
}
