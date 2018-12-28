using SimulatorDebugTool.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimulatorDebugTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtPath_DragEnter(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData("FileNameW") as string[];
            this.txtPath.Text = data.FirstOrDefault();
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            string path = txtPath.Text.Trim();
            string content = string.Empty;
            if (Directory.Exists(path))
            {
                string dest1 = Directory.GetParent(path).FullName + @"\Source\WindLDR\MainForm.WNV.cs";
                string dest2 = Directory.GetParent(path).FullName + @"\Source\WindowsSimulator\SimulatorForm\SimulatorFormHandler.cs";
                using (StreamReader rd = new StreamReader(dest1))
                {
                    content = rd.ReadToEnd();
                }
                int index = content.IndexOf("#define SIMULATORDEBUG");
                if (index >= 0)
                {
                    string comment = content.Substring(index - 2, 2);
                    if (comment == @"//")
                    {
                        content = content.Substring(0, index - 2) + content.Substring(index);
                        using (StreamWriter wr = new StreamWriter(dest1, false, Encoding.UTF8))
                        {
                            wr.Write(content);
                            wr.Flush();
                        }
                    }
                }


                using (StreamReader rd = new StreamReader(dest2))
                {
                    content = rd.ReadToEnd();
                }
                index = content.IndexOf("#define SIMULATORDEBUG");
                if (index >= 0)
                {
                    string comment = content.Substring(index - 2, 2);
                    if (comment == @"//")
                    {
                        content = content.Substring(0, index - 2) + content.Substring(index);
                        using (StreamWriter wr = new StreamWriter(dest2, false, Encoding.UTF8))
                        {
                            wr.Write(content);
                            wr.Flush();
                        }
                    }
                }
                MessageBox.Show("Over!");
                string defaultPath = Environment.CurrentDirectory + @"\DefaultPath.txt";
                if (!File.Exists(defaultPath))
                {
                    using (var fileStream = File.CreateText(defaultPath))
                    {
                        fileStream.Write(path);
                    }
                }
                else
                {
                    using (StreamWriter wr = new StreamWriter(defaultPath, false))
                    {
                        wr.Write(path);
                    }
                }
            }
            else
            {
                MessageBox.Show("Path Error!");
            }
        }

        private void btnNotDebug_Click(object sender, EventArgs e)
        {
            string path = txtPath.Text.Trim();
            string content = string.Empty;
            if (Directory.Exists(path))
            {
                string dest1 = Directory.GetParent(path).FullName + @"\Source\WindLDR\MainForm.WNV.cs";
                string dest2 = Directory.GetParent(path).FullName + @"\Source\WindowsSimulator\SimulatorForm\SimulatorFormHandler.cs";
                using (StreamReader rd = new StreamReader(dest1))
                {
                    content = rd.ReadToEnd();
                }
                int index = content.IndexOf("#define SIMULATORDEBUG");
                if (index >= 0)
                {
                    string comment = content.Substring(index - 2, 2);
                    if (comment != @"//")
                    {
                        content = content.Substring(0, index) + @"//" + content.Substring(index);
                        using (StreamWriter wr = new StreamWriter(dest1, false, Encoding.UTF8))
                        {
                            wr.Write(content);
                            wr.Flush();
                        }
                    }
                }

                using (StreamReader rd = new StreamReader(dest2))
                {
                    content = rd.ReadToEnd();
                }
                index = content.IndexOf("#define SIMULATORDEBUG");
                if (index >= 0)
                {
                    string comment = content.Substring(index - 2, 2);
                    if (comment != @"//")
                    {
                        content = content.Substring(0, index) + @"//" + content.Substring(index);
                        using (StreamWriter wr = new StreamWriter(dest2, false, Encoding.UTF8))
                        {
                            wr.Write(content);
                            wr.Flush();
                        }
                    }
                }
                MessageBox.Show("Over!");
                string defaultPath = Environment.CurrentDirectory + @"\DefaultPath.txt";
                if (!File.Exists(defaultPath))
                {
                    using (var fileStream = File.CreateText(defaultPath))
                    {
                        fileStream.Write(path);
                    }
                }
                else
                {
                    using (StreamWriter wr = new StreamWriter(defaultPath, false))
                    {
                        wr.Write(path);
                    }
                }
            }
            else
            {
                MessageBox.Show("Path Error!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string defaultPath = Environment.CurrentDirectory + @"\DefaultPath.txt";
            if (File.Exists(defaultPath))
            {
                using (StreamReader rd = new StreamReader(defaultPath))
                {
                    txtPath.Text = rd.ReadLine();
                }
            }
        }
    }
}
