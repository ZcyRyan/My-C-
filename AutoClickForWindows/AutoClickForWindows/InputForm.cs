using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoClickForWindows
{
    public partial class InputForm : Form
    {
        public MouseActionEntity MouseResult = null;

        public InputForm()
        {
            InitializeComponent();
        }

        public InputForm(MouseActionEntity mouseInfo) : this()
        {
            MouseResult = mouseInfo;
            txtX.Text = mouseInfo.X.ToString();
            txtY.Text = mouseInfo.Y.ToString();
            txtClickEvent.Text = MouseActionEntity.GetDisplayType(mouseInfo.Type);
            txtComment.Text = mouseInfo.Comment;
            numWaiting.Value = mouseInfo.Interval;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            MouseResult.X = Convert.ToInt32(txtX.Text);
            MouseResult.Y = Convert.ToInt32(txtY.Text);
            MouseResult.Comment = txtComment.Text;
            MouseResult.Interval = (int)numWaiting.Value;
            this.DialogResult = DialogResult.OK;
        }


    }
}
