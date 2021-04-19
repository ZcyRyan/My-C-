namespace SSHNetSample
{
    partial class Form1
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
            this.btnUpload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ipHost = new DevComponents.Editors.IpAddressInput();
            this.intInputPort = new DevComponents.Editors.IntegerInput();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUser = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtNVPath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLinuxPath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label7 = new System.Windows.Forms.Label();
            this.txtKeyPath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnKeyCreator = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDownloadPath = new DevComponents.DotNetBar.Controls.TextBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.ipHost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intInputPort)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(14, 207);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(84, 23);
            this.btnUpload.TabIndex = 0;
            this.btnUpload.Text = "Upload File";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.BtnUpload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "NV Path:";
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(102, 207);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(84, 23);
            this.btnDownload.TabIndex = 3;
            this.btnDownload.Text = "Download File";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.BtnDownload_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Linux Host IP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Port:";
            // 
            // ipHost
            // 
            this.ipHost.AutoOverwrite = true;
            // 
            // 
            // 
            this.ipHost.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ipHost.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ipHost.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.ipHost.ButtonFreeText.Visible = true;
            this.ipHost.Location = new System.Drawing.Point(104, 37);
            this.ipHost.Name = "ipHost";
            this.ipHost.Size = new System.Drawing.Size(134, 19);
            this.ipHost.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ipHost.TabIndex = 6;
            this.ipHost.Value = "192.168.80.94";
            // 
            // intInputPort
            // 
            // 
            // 
            // 
            this.intInputPort.BackgroundStyle.Class = "DateTimeInputBackground";
            this.intInputPort.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.intInputPort.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.intInputPort.Location = new System.Drawing.Point(314, 37);
            this.intInputPort.Name = "intInputPort";
            this.intInputPort.Size = new System.Drawing.Size(80, 19);
            this.intInputPort.TabIndex = 7;
            this.intInputPort.Value = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "User Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "Password:";
            // 
            // txtUser
            // 
            // 
            // 
            // 
            this.txtUser.Border.Class = "TextBoxBorder";
            this.txtUser.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUser.Location = new System.Drawing.Point(104, 63);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(109, 19);
            this.txtUser.TabIndex = 10;
            this.txtUser.Text = "u-test";
            // 
            // txtPassword
            // 
            // 
            // 
            // 
            this.txtPassword.Border.Class = "TextBoxBorder";
            this.txtPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPassword.Location = new System.Drawing.Point(104, 88);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(109, 19);
            this.txtPassword.TabIndex = 11;
            this.txtPassword.Text = "utest";
            // 
            // txtNVPath
            // 
            // 
            // 
            // 
            this.txtNVPath.Border.Class = "TextBoxBorder";
            this.txtNVPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNVPath.Location = new System.Drawing.Point(104, 6);
            this.txtNVPath.Name = "txtNVPath";
            this.txtNVPath.Size = new System.Drawing.Size(486, 19);
            this.txtNVPath.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "Linux Path:";
            // 
            // txtLinuxPath
            // 
            // 
            // 
            // 
            this.txtLinuxPath.Border.Class = "TextBoxBorder";
            this.txtLinuxPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLinuxPath.Location = new System.Drawing.Point(104, 113);
            this.txtLinuxPath.Name = "txtLinuxPath";
            this.txtLinuxPath.Size = new System.Drawing.Size(486, 19);
            this.txtLinuxPath.TabIndex = 14;
            this.txtLinuxPath.Text = "/home/u-test/zcyTest";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "Key path:";
            // 
            // txtKeyPath
            // 
            // 
            // 
            // 
            this.txtKeyPath.Border.Class = "TextBoxBorder";
            this.txtKeyPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtKeyPath.Location = new System.Drawing.Point(102, 145);
            this.txtKeyPath.Name = "txtKeyPath";
            this.txtKeyPath.Size = new System.Drawing.Size(486, 19);
            this.txtKeyPath.TabIndex = 16;
            this.txtKeyPath.Text = "C:\\Users\\chenyanz\\.ssh\\id_rsa";
            // 
            // btnKeyCreator
            // 
            this.btnKeyCreator.Location = new System.Drawing.Point(436, 207);
            this.btnKeyCreator.Name = "btnKeyCreator";
            this.btnKeyCreator.Size = new System.Drawing.Size(154, 23);
            this.btnKeyCreator.TabIndex = 17;
            this.btnKeyCreator.Text = "Generate Key(D:\\Temp)";
            this.btnKeyCreator.UseVisualStyleBackColor = true;
            this.btnKeyCreator.Click += new System.EventHandler(this.BtnKeyCreator_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "Download path:";
            // 
            // txtDownloadPath
            // 
            // 
            // 
            // 
            this.txtDownloadPath.Border.Class = "TextBoxBorder";
            this.txtDownloadPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDownloadPath.Location = new System.Drawing.Point(102, 174);
            this.txtDownloadPath.Name = "txtDownloadPath";
            this.txtDownloadPath.Size = new System.Drawing.Size(486, 19);
            this.txtDownloadPath.TabIndex = 19;
            this.txtDownloadPath.Text = "d:\\Temp\\Result";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 256);
            this.Controls.Add(this.txtDownloadPath);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnKeyCreator);
            this.Controls.Add(this.txtKeyPath);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtLinuxPath);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNVPath);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.intInputPort);
            this.Controls.Add(this.ipHost);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpload);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Linux Communication";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ipHost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intInputPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevComponents.Editors.IpAddressInput ipHost;
        private DevComponents.Editors.IntegerInput intInputPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUser;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPassword;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNVPath;
        private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.Controls.TextBoxX txtLinuxPath;
        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.Controls.TextBoxX txtKeyPath;
        private System.Windows.Forms.Button btnKeyCreator;
        private System.Windows.Forms.Label label8;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDownloadPath;
    }
}

