using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ExcelTCTool
{
    public partial class NotFind : Form
    {
        public List<string> SRSList = new List<string>();

        public NotFind()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var text = txtSRSPanel.Text;
                SRSList = text.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                if (SRSList.Count > 0)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ProcesscmdKey is press or not
        /// </summary>
        /// <param name="msg">Windows Message</param>
        /// <param name="keyData">Key Information</param>
        /// <returns>True, False</returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool result = true;
            //Click Enter button
            if (keyData == Keys.Enter)
            {
                button1_Click(null, null);
            }
            else
            {
                result = base.ProcessCmdKey(ref msg, keyData);
            }
            return result;
        }
    }
}
