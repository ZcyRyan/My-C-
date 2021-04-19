using SSHNetSample.CommunicationUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Compression;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;
using System.IO.Compression;
using System.Xml.Serialization;
using System.Xml;
using System.Collections.Specialized;

namespace SSHNetSample
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string ret = string.Empty;
                string folderPath = @"D:\ZcyWork\Testing data\Linux Copy\WNV4~202008110153130532(small)";
                string zipFile = @"D:\aa.zip";
                //FastZip zip = new FastZip();
                //zip.CreateEmptyDirectories = true;
                //zip.CreateZip
                //    (zipFile, folderPath, true, "");

                System.IO.Compression.ZipFile.CreateFromDirectory(folderPath, zipFile);

                var hash = FileMD5.GetFileMD5Hash(zipFile);
                using (var fl = File.Create(@"D:\aa.md5"))
                {
                    using (BinaryWriter wr = new BinaryWriter(fl))
                    {
                        wr.Write(hash);
                    }
                }

                ret = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                ret += "  aa.zip";
                using (var fl = File.Create(@"D:\aa.zip.md5"))
                {
                    using (StreamWriter wr = new StreamWriter(fl))
                    {
                        wr.Write(ret);
                    }
                }

                //var hash = FileMD5.GetFileMD5Hash(textBox1.Text.Trim());
                //var file =  .Create(@"D:\ZcyWork\Testing data\Linux Copy\WNV4~202008110153130532(small)");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string user = "root";
            string password = "root";
            string ip = "192.168.80.65";
            int port = 22;
            string localPath = @"D:\aa.zip";
            string hostPath = @"/home/idec/aa.zip";
            string bigLocalPath = @"D:\ZcyWork\Testing data\Linux Copy\WNV4~202008180137040121(17MB)";
            string hostFolderPath = @"/home/idec/Project";
            try
            {
                SCPUtility.Instance.InitialSCPSettings(user, password, ip, port);
                SCPUtility.Instance.Connect();
                if (SCPUtility.Instance.IsSCPClientActive())
                {
                    //SCPUtility.Instance.UploadFile(localPath, hostPath);
                    SCPUtility.Instance.UploadDirectory(new DirectoryInfo(bigLocalPath), hostFolderPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("over!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string usr = TOTPUtility.GetTimeBasedUser(16);
            string a = TOTPUtility.TOTPGenerator(15);
            TOTPUtility.SplitStringToHex(usr, 32);
            TOTPUtility.EncryptPassword(a);
            MessageBox.Show("User: " + usr + Environment.NewLine + "Pass: " + a);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //string path = @"C:\Users\chenyanz\AppData\Local\Temp\91246b46-9349-4950-8b4a-72197f7a8494.pub";
            string privatepath = @"D:\Temp\9d85de85-7160-41f6-b0cc-d2f3c0a485e8";
            byte[] buffer = null;
            using (FileStream stream = new FileStream(privatepath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (BinaryReader rd = new BinaryReader(stream))
                {
                    buffer = rd.ReadBytes((int)stream.Length);
                }
            }
            //SFTPUtility.Instance.InitialSFTPSettingsByPrivateKey("root", "192.168.80.79", 10387, buffer);
            SFTPUtility.Instance.InitialSFTPSettings("root", "root","192.168.80.198", 10387);
            SFTPUtility.Instance.Connect();

            using (FileStream steam = new FileStream(@"C:\Users\chenyanz\Documents\DPMK8_18060917 (Original)_5g-test.znv", FileMode.Open))
            {
                SFTPUtility.Instance.UploadFile(steam, @"\home\idec");
            }

            
        }




        public static char[] SplitStringToHex(string stringWord, int lenght)
        {
            int index = 0;
            char[] originalString = new char[lenght];

            for (int i = 0; i < originalString.Length; i++)
            {
                originalString[i] = (char)0x30;
            }

            for (int i = 0; i < stringWord.Length; i++)
            {
                string hexOutput = String.Format("{0:X}", Convert.ToInt32(stringWord[i]));
                originalString[index++] = hexOutput[0];
                originalString[index++] = hexOutput.Length > 1 ? hexOutput[1] : (char)0x30;
            }

            return originalString;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string version1 = "01.11.02.01";
            string version2 = "01.11.02.00";
            var r = CompareVersionAABBCCDD(version1, version2);


            //string s = @"C:\Users\chenyanz\AppData\Local\Temp\4562801b-fcbe-43e7-88d6-23ab2f929980.pub";
            //string name = Path.GetFileName(s);
            //using (StreamReader rd = new StreamReader(@"C:\Users\chenyanz\AppData\Local\Temp\4562801b-fcbe-43e7-88d6-23ab2f929980.pub"))
            //{
            //    string temp = rd.ReadToEnd();
            //    var array = SplitStringToHex(temp, temp.Length * 2);
            //}
        }

        private void button7_Click(object sender, EventArgs e)
        {
            XmlSerializer temp = new XmlSerializer(typeof(SystemInfoCDC));
            SystemInfoCDC tempCDC;
            using (StreamReader reader = new StreamReader(@"D:\ZcyWork\My Tasks\20201027_SSH linux\20200805_Linux Support SSH\SSHNetSample\SSHNetSample\testXML.xml"))
            {
                tempCDC = (SystemInfoCDC)temp.Deserialize(reader);
            }
            
            //byte[] array = Convert.FromBase64String(tempCDC.ProjectName);
            //string result = Encoding.Default.GetString(array);
        }

        int port = 22;
        //string srcFile = @"D:\ZcyWork\Software setup\Understand-5.1.1017-Windows-64bit.exe";
        //string targetFile = @"/home/idec";
        //string user = "idec";
        //string pass = "idec";
        //string ip = "192.168.80.197";

        //string user = "u-test";
        //string pass = "utest";
        //string ip = "192.168.80.79";
        //string srcFile = @"D:\linuxkeys\test\ccc";
        //string targetFile = @"/home/u-test/zcyTest";

        string user = "idec";
        string pass = "idec";
        string ip = "192.168.80.194";
        string srcFile = @"D:\HGDATA01\NVDATA\project01V13.ZNV";
        string targetFile = @"/home/idec/project01V13.ZNV";

        private void button8_Click(object sender, EventArgs e)
        {  //SCP
            SCPUtility.Instance.InitialSCPSettings(user, pass, ip, port);
            SCPUtility.Instance.Connect();
            txtResult.Text = string.Empty;
            txtResult.Text = DateTime.Now.ToString("yyyy:MM:dd,HH:mm:ss:ms.fff") + "-------------Start SCP update---------";
            SCPUtility.Instance.UploadFile(srcFile, targetFile);
            //DirectoryInfo dic = new DirectoryInfo(srcFile);
            //SCPUtility.Instance.UploadDirectory(dic, targetFile);
            SCPUtility.Instance.DisposeSCPClient();
            txtResult.Text += Environment.NewLine +
                DateTime.Now.ToString("yyyy:MM:dd,HH:mm:ss:ms.fff") + "-------------End SCP update---------";
        }

        private void button9_Click(object sender, EventArgs e)
        {  //SFTP
            SFTPUtility.Instance.InitialSFTPSettings(user, pass, ip, port);
            SFTPUtility.Instance.Connect();
            txtResult.Text = string.Empty;
            txtResult.Text = DateTime.Now.ToString("yyyy:MM:dd,HH:mm:ss:ms.fff") + "-------------Start SFTP update---------";
            using (FileStream sf = File.Open(srcFile, FileMode.Open, FileAccess.Read))
            {
                SFTPUtility.Instance.UploadFile(sf, targetFile);
            }
            //SFTPUtility.Instance.UploadDirectory(srcFile, targetFile);
            SFTPUtility.Instance.DisposeSFTPClient();
            txtResult.Text += Environment.NewLine +
                DateTime.Now.ToString("yyyy:MM:dd,HH:mm:ss:ms.fff") + "-------------End SFTP update---------";
        }

        private async void button11_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;
            txtResult.Text = DateTime.Now.ToString("yyyy:MM:dd,HH:mm:ss:ms.fff") + "-------------Start Http update---------";

            //HttpUtility.Instance.InitialHttpClient("http://192.168.80.177:8080");
            //bool ret = await HttpUtility.Instance.UploadFile(@"D:\linuxkeys\test\1.cxob");
            //HttpUtility.Instance.sendHttpRequest("http://192.168.80.199:8080/filepost", @"D:\linuxkeys\test\1.cxob");


            //NameValueCollection nvc = new NameValueCollection();
            //nvc.Add("filed1", "zcy");
            //HttpUtility.Instance.HttpUploadFile("http://192.168.80.199:8080", @"D:\linuxkeys\test\SSH.NET-2020.0.0-bin.zip", "file", "application/octet-stream", null);
            bool ret = HttpUtility.Instance.HttpUploadFile("http://192.168.80.199:8080", @"D:\linuxkeys\test\2.exe", "file", "application/octet-stream");
            txtResult.Text += DateTime.Now.ToString("yyyy:MM:dd,HH:mm:ss:ms.fff") + "-------------End Http update---------";
            if (ret)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;
            txtResult.Text = DateTime.Now.ToString("yyyy:MM:dd,HH:mm:ss:ms.fff") + "-------------Start Http update---------";

            bool ret = HttpUtility.Instance.HttpDownloadFile("http://192.168.80.199:8080", @"D:\test");

            txtResult.Text += DateTime.Now.ToString("yyyy:MM:dd,HH:mm:ss:ms.fff") + "-------------End Http update---------";
            if (ret)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;
            txtResult.Text = DateTime.Now.ToString("yyyy:MM:dd,HH:mm:ss:ms.fff") + "-------------Start Http update---------";

            bool ret = HttpUtility.Instance.HttpUploadFolder("http://192.168.80.199:8080", @"D:\Temp\IP192.168.80.193");
            txtResult.Text += DateTime.Now.ToString("yyyy:MM:dd,HH:mm:ss:ms.fff") + "-------------End Http update---------";
            if (ret)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void ftpupload_click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;
            txtResult.Text = DateTime.Now.ToString("yyyy:MM:dd,HH:mm:ss:ms.fff") + "-------------Start FTP update---------";
            FTPUtility.Instance.InitialFTPConnectionInfo(@"ftp://192.168.80.199", "abc", "abc", Encoding.Default, "2538");
            bool ret = FTPUtility.Instance.UploadFile(@"ccc.rar", @"D:\linuxkeys\test\ccc.rar");
            txtResult.Text += DateTime.Now.ToString("yyyy:MM:dd,HH:mm:ss:ms.fff") + "-------------End FTP update---------";
            if (ret)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void ftp_download(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;
            txtResult.Text = DateTime.Now.ToString("yyyy:MM:dd,HH:mm:ss:ms.fff") + "-------------Start FTP download---------";
            FTPUtility.Instance.InitialFTPConnectionInfo(@"ftp://192.168.80.199", "idecsh", "000000", Encoding.Default, "21");
            bool ret = FTPUtility.Instance.DownloadFile(@"aa/ccc.rar", @"D:\linuxkeys\test\ccc.rar");
            txtResult.Text += DateTime.Now.ToString("yyyy:MM:dd,HH:mm:ss:ms.fff") + "-------------End FTP download---------";
            if (ret)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void ftp_getdirectory(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;
            txtResult.Text = DateTime.Now.ToString("yyyy:MM:dd,HH:mm:ss:ms.fff") + "-------------Start Get direct---------";
            FTPUtility.Instance.InitialFTPConnectionInfo(@"ftp://192.168.80.69", "root", "root", Encoding.Default);
            string[] list = FTPUtility.Instance.DirectoryList(@"/home/root");
            txtResult.Text += DateTime.Now.ToString("yyyy:MM:dd,HH:mm:ss:ms.fff") + "-------------End Get direct---------";
        }

        private void ftp_createfolder(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;
            txtResult.Text = DateTime.Now.ToString("yyyy:MM:dd,HH:mm:ss:ms.fff") + "-------------Start Create direct---------";
            FTPUtility.Instance.InitialFTPConnectionInfo(@"ftp://192.168.80.69", "root", "root", Encoding.Default);
            bool ret = FTPUtility.Instance.CreateDirectory(@"/home/root/zcytest");
            txtResult.Text += DateTime.Now.ToString("yyyy:MM:dd,HH:mm:ss:ms.fff") + "-------------End Create direct---------";
            if (ret)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void uploadAllFolder(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;
            txtResult.Text = DateTime.Now.ToString("yyyy:MM:dd,HH:mm:ss:ms.fff") + "-------------Start upload direct---------";
            FTPUtility.Instance.InitialFTPConnectionInfo(@"ftp://192.168.80.69", "root", "root", ftpPort:"2538");
            string remote = @"/home/idec/A/yyy";
            string local = @"D:\Temp\ccc";
            if (!FTPUtility.Instance.IsDirectoryExist(@"/home/idec/A", remote))
            {
                if (FTPUtility.Instance.CreateDirectory(remote))
                {
                    bool ret = FTPUtility.Instance.UploadAllDirectory(remote, local);
                    txtResult.Text += DateTime.Now.ToString("yyyy:MM:dd,HH:mm:ss:ms.fff") + "-------------End upload direct---------";
                    if (ret)
                    {
                        MessageBox.Show("OK");
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }
            }
            else
            {
                bool ret = FTPUtility.Instance.UploadAllDirectory(remote, local);
                txtResult.Text += DateTime.Now.ToString("yyyy:MM:dd,HH:mm:ss:ms.fff") + "-------------End upload direct---------";
                if (ret)
                {
                    MessageBox.Show("OK");
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void ftpDownloadAll(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;
            txtResult.Text = DateTime.Now.ToString("yyyy:MM:dd,HH:mm:ss:ms.fff") + "-------------Start upload direct---------";
            FTPUtility.Instance.InitialFTPConnectionInfo(@"ftp://192.168.80.69", "root", "root", ftpPort: "2538");
            string remote = @"/home/idec/A/yyy";
            string local = @"D:\temp\mmm";
            FTPUtility.Instance.DownloadAllDirectory(remote, local);
            txtResult.Text += DateTime.Now.ToString("yyyy:MM:dd,HH:mm:ss:ms.fff") + "-------------End upload direct---------";
        }

        /// <summary>
        /// Compare version for aa.bb.cc.dd format
        /// </summary>
        /// <returns>compare result</returns>
        public VersionCompareResult CompareVersionAABBCCDD(string ver1, string ver2)
        {
            VersionCompareResult ret = VersionCompareResult.IsInvalid;
            int[] ver1Array = FormatVersion(ver1.Split('.'));
            int[] ver2Array = FormatVersion(ver2.Split('.'));
            // Format for aa.bb.cc.dd
            if (ver1Array.Length == 4 && ver2Array.Length == 4)
            {
                if (ver1Array.SequenceEqual(ver2Array))
                {  //Same
                    ret = VersionCompareResult.IsSame;
                }
                else
                {
                    int ver1aabbcc = ver1Array[0] * 10000 + ver1Array[1] * 100 + ver1Array[2];
                    int ver2aabbcc = ver2Array[0] * 10000 + ver2Array[1] * 100 + ver2Array[2];
                    if (ver1aabbcc > ver2aabbcc)
                    {  //Bigger
                        ret = VersionCompareResult.IsBigger;
                    }
                    else if (ver1aabbcc < ver2aabbcc)
                    {  //Less
                        ret = VersionCompareResult.IsLess;
                    }
                    else
                    {  //Same, to compare dd, but for dd, 00 is biggest
                        int ver1dd = ver1Array[3];
                        int ver2dd = ver2Array[3];
                        if ((ver1dd > ver2dd && ver2dd != 0)
                            || (ver1dd < ver2dd && ver1dd == 0))
                        {
                            //Bigger
                            ret = VersionCompareResult.IsBigger;
                        }
                        else
                        {  //Less
                            ret = VersionCompareResult.IsLess;
                        }
                    }
                }
            }
            return ret;
        }

        public enum VersionCompareResult
        {
            IsSame = 0,
            IsLess,
            IsBigger,
            IsOnlyCCDifferent,
            IsInvalid
        }

        /// <summary>
        /// Change format of version.(From string to int)
        /// For example: 01.02.03.04 -> 1.2.3.4
        /// </summary>
        /// <param name="version">Original version.(String type)</param>
        /// <returns>Formated version.(Int type)</returns>
        public int[] FormatVersion(string[] version)
        {
            int CDCLength = version.Length;

            int[] resultVersion = new int[CDCLength];

            for (int index = 0; index < CDCLength; index++)
            {// Loop the version element
                try
                {
                    // change the element from string to int
                    resultVersion[index] = Int16.Parse(version[index]);
                }
                catch (Exception ex)
                {
                    // if change fail, defaut to 0
                    resultVersion[index] = 0;
                }
            }
            return resultVersion;
        }

        private void filecheck_Click(object sender, EventArgs e)
        {
            //FTPUtility.Instance.InitialFTPConnectionInfo(@"ftp://192.168.80.197", "john", "1234", ftpPort: "2121");
            //var list = FTPUtility.Instance.GetFileListByFolder("test");
            //string ext = Path.GetExtension("a.txt");
            //string ver1 = "1.2.3.00";
            //string ver2 = "1.2.3.44";
            //ver1 = GetFormatVersionAABBCCDD(ver1);
            //ver2 = GetFormatVersionAABBCCDD(ver2);

            DateTime myTime = new DateTime(1970, 1, 1);
            myTime = myTime.AddSeconds(1616505023);
        }

        /// <summary>
        /// Get format version string for AABBCCDD
        /// </summary>
        /// <param name="version">version</param>
        /// <returns>format string</returns>
        public string GetFormatVersionAABBCCDD(string version)
        {
            string result = version;
            int[] verArray = FormatVersion(version.Split('.'));
            if (verArray.Length > 3)
            {
                if (verArray[3] == 0)
                {  //When DD = 0, do not show DD
                    result = version.Substring(0, version.LastIndexOf('.'));
                }
            }
            return result;
        }
    }

    /// <summary>
    /// Project information for XML
    /// </summary>
    public class SystemInfoCDC
    {
        /// <summary>
        /// Get or set ProjectName
        /// </summary>
        [XmlElementAttribute("Project_Name")]
        public string ProjectName { get; set; }


    }
}
