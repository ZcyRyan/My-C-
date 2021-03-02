using SSHNetSample.CommunicationUtility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SSHNetSample
{
    public partial class Form1 : Form
    {
        //NV path
        private string nvPath = string.Empty;
        //Linux path
        private string linuxPath = string.Empty;
        //File filter
        private const string NV_FILE_FILTER = @"[2f]$";
        //Filter folder name
        private const string FILTER_FOLDER = "WNV3";

        /// <summary>
        /// Form
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Upload file to Linux path
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                //InitSettings();
                //InitSettingsByPrivateKey();
                InitSettingsByPrivateKeyStream();

                //Create root Path
                string rootName = linuxPath + @"/" + Path.GetFileName(nvPath);
                if (SFTPUtility.Instance.IsPathExists(rootName))
                {  //Delete
                    SFTPUtility.Instance.DeleteDirectory(rootName);
                }
                if (SFTPUtility.Instance.CreateDirectory(rootName))
                {  //Create and copy all file and directory
                    SFTPUtility.Instance.UploadDirectory(nvPath, rootName, FILTER_FOLDER, NV_FILE_FILTER);
                    MessageBox.Show("Upload over!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Download file to from path
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                InitSettingsByPrivateKey();
                InitSettingsByPrivateKeyStream();
                //Create root Path
                string rootName = linuxPath + @"/" + Path.GetFileName(nvPath);
                if (SFTPUtility.Instance.IsPathExists(rootName))
                {  //Create and copy all file and directory
                    SFTPUtility.Instance.DownloadDirectory(rootName, txtDownloadPath.Text.Trim());
                    MessageBox.Show("download over!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Initial settings
        /// </summary>
        private void InitSettings()
        {
            if (!SFTPUtility.Instance.IsSftpClientActive())
            {
                //Connect to Linux
                SFTPUtility.Instance.InitialSFTPSettings(txtUser.Text, txtPassword.Text, ipHost.Value.ToString(), intInputPort.Value);
                SFTPUtility.Instance.Connect();
            }
            nvPath = txtNVPath.Text.Trim();
            linuxPath = txtLinuxPath.Text.Trim();
        }

        /// <summary>
        /// Initial settings by private key
        /// </summary>
        private void InitSettingsByPrivateKey()
        {
            if (!SFTPUtility.Instance.IsSftpClientActive())
            {
                List<Tuple<string, string>> keyCollection = new List<Tuple<string, string>>();
                keyCollection.Add(new Tuple<string, string>(txtKeyPath.Text.Trim(), string.Empty));
                SFTPUtility.Instance.InitialSFTPSettingsByPrivateKey(txtUser.Text, ipHost.Value.ToString(),
                    intInputPort.Value, keyCollection);
                SFTPUtility.Instance.Connect();
            }

            nvPath = txtNVPath.Text.Trim();
            linuxPath = txtLinuxPath.Text.Trim();
        }

        private void InitSettingsByPrivateKeyStream()
        {
            if (!SFTPUtility.Instance.IsSftpClientActive() && OpenSSHKeyUntility.PrivateKey != null)
            {
                SFTPUtility.Instance.InitialSFTPSettingsByPrivateKey(txtUser.Text, ipHost.Value.ToString(),
                    intInputPort.Value, OpenSSHKeyUntility.PrivateKey);
                SFTPUtility.Instance.Connect();
            }

            nvPath = txtNVPath.Text.Trim();
            linuxPath = txtLinuxPath.Text.Trim();
        }

        /// <summary>
        /// Form closing event handler
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            SFTPUtility.Instance.DisposeSFTPClient();
        }

        /// <summary>
        /// SSH key creator handler
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnKeyCreator_Click(object sender, EventArgs e)
        {
            try
            {
                OpenSSHKeyUntility.GenerateOpenSSHKey();
                MessageBox.Show("Create Over!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
