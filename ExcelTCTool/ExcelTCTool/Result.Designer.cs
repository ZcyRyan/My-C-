namespace ExcelTCTool
{
    partial class Result
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtOverInCase = new System.Windows.Forms.TextBox();
            this.txtNotFind = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtOverInCase
            // 
            this.txtOverInCase.Location = new System.Drawing.Point(59, 87);
            this.txtOverInCase.Multiline = true;
            this.txtOverInCase.Name = "txtOverInCase";
            this.txtOverInCase.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOverInCase.Size = new System.Drawing.Size(252, 541);
            this.txtOverInCase.TabIndex = 0;
            // 
            // txtNotFind
            // 
            this.txtNotFind.Location = new System.Drawing.Point(375, 87);
            this.txtNotFind.Multiline = true;
            this.txtNotFind.Name = "txtNotFind";
            this.txtNotFind.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotFind.Size = new System.Drawing.Size(259, 542);
            this.txtNotFind.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "测试case中多的SRS号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(373, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "测试case缺少的srs号";
            // 
            // Result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 658);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNotFind);
            this.Controls.Add(this.txtOverInCase);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Result";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Result";
            this.Load += new System.EventHandler(this.Result_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOverInCase;
        private System.Windows.Forms.TextBox txtNotFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}