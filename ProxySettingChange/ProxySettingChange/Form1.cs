using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProxySettingChange
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int enabled = 1;
            ChangeProxy(enabled);
            MessageBox.Show("Change OK! Enabled!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int enabled = 0;
            ChangeProxy(enabled);
            MessageBox.Show("Change OK! Disabled!");
        }

        private void ChangeProxy(int enabled)
        {
            RegistryKey key = Registry.CurrentUser;
            var subkey = key.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Internet Settings", true);
            subkey.SetValue("ProxyEnable", enabled);
        }
    }
}
