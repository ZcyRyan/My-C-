using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ProgressIndicatorTest
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            progressIndicatorAbout.Start();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabelCredits_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://p.yusukekamiyamane.com/");
        }
    }
}
