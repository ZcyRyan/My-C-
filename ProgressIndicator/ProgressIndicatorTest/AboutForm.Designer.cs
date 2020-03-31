namespace ProgressIndicatorTest
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelAbout = new System.Windows.Forms.Label();
            this.linkLabelCredits = new System.Windows.Forms.LinkLabel();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.progressIndicatorAbout = new ProgressControls.ProgressIndicator();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(377, 227);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelAbout
            // 
            this.labelAbout.AutoSize = true;
            this.labelAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAbout.Location = new System.Drawing.Point(177, 12);
            this.labelAbout.Name = "labelAbout";
            this.labelAbout.Size = new System.Drawing.Size(275, 20);
            this.labelAbout.TabIndex = 2;
            this.labelAbout.Text = "Progress Indicator Example Form";
            // 
            // linkLabelCredits
            // 
            this.linkLabelCredits.AutoSize = true;
            this.linkLabelCredits.LinkArea = new System.Windows.Forms.LinkArea(63, 70);
            this.linkLabelCredits.Location = new System.Drawing.Point(220, 86);
            this.linkLabelCredits.Name = "linkLabelCredits";
            this.linkLabelCredits.Size = new System.Drawing.Size(203, 30);
            this.linkLabelCredits.TabIndex = 3;
            this.linkLabelCredits.TabStop = true;
            this.linkLabelCredits.Text = "Icons used are part of the Fugue Icons\r\nby Yusuke Kamiyamane - WebSite";
            this.linkLabelCredits.UseCompatibleTextRendering = true;
            this.linkLabelCredits.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCredits_LinkClicked);
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.Location = new System.Drawing.Point(12, 232);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(184, 13);
            this.labelCopyright.TabIndex = 4;
            this.labelCopyright.Text = "Copyright © Emilio Simões 2008-2010";
            // 
            // progressIndicatorAbout
            // 
            this.progressIndicatorAbout.Location = new System.Drawing.Point(12, 12);
            this.progressIndicatorAbout.Name = "progressIndicatorAbout";
            this.progressIndicatorAbout.Percentage = 0F;
            this.progressIndicatorAbout.Size = new System.Drawing.Size(159, 159);
            this.progressIndicatorAbout.TabIndex = 0;
            this.progressIndicatorAbout.Text = "progressIndicator1";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 262);
            this.Controls.Add(this.progressIndicatorAbout);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.linkLabelCredits);
            this.Controls.Add(this.labelAbout);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About Progress Indicator";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProgressControls.ProgressIndicator progressIndicatorAbout;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelAbout;
        private System.Windows.Forms.LinkLabel linkLabelCredits;
        private System.Windows.Forms.Label labelCopyright;
    }
}