using Renci.SshNet;
using Renci.SshNet.Sftp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SSHNetSample.CommunicationUtility
{
    public class SFTPUtility
    {
        //Linux path char
        private const string LINUX_PATH_CHAR = @"/";
        // Instance
        private static SFTPUtility instance = null;
        // Sftp client
        private SftpClient sftpClient = null;
        // Linux upper path flag
        private const string UPPER_PATH_1 = ".";
        private const string UPPER_PATH_2 = "..";
        /// <summary>
        /// Instance of SimulatorFormBusiness
        /// </summary>
        public static SFTPUtility Instance
        {
            get
            {
                return instance ?? (instance = new SFTPUtility());
            }
        }

        /// <summary>
        /// Check sftp client is connect or not
        /// </summary>
        /// <returns>connect or not</returns>
        public bool IsSftpClientActive()
        {
            return (sftpClient != null && sftpClient.IsConnected);
        }

        /// <summary>
        /// Initial SFTP settings
        /// </summary>
        /// <param name="user">user</param>
        /// <param name="password">password</param>
        /// <param name="ip">ip address</param>
        /// <param name="port">port</param>
        public void InitialSFTPSettings(string user, string password, string ip, int port)
        {
            // Setup Credentials and Server Information
            ConnectionInfo connectInfo = new ConnectionInfo(ip, port, user,
                // Pasword based Authentication
                new AuthenticationMethod[]{new PasswordAuthenticationMethod(user, password)});
            sftpClient = new SftpClient(connectInfo);
        }

        /// <summary>
        /// SFTP setting private key
        /// </summary>
        /// <param name="user">user</param>
        /// <param name="ip">ip</param>
        /// <param name="port">port</param>
        /// <param name="keyPath">key path</param>
        public void InitialSFTPSettingsByPrivateKey(string user, string ip, int port, List<Tuple<string, string>> keyPath)
        {
            List<AuthenticationMethod> methods = new List<AuthenticationMethod>();
            foreach (var key in keyPath)
            {
                methods.Add(new PrivateKeyAuthenticationMethod(user, new PrivateKeyFile(key.Item1, key.Item2)));
            }
            var coninfo = new ConnectionInfo(ip, port, user, methods.ToArray());
            sftpClient = new SftpClient(coninfo);
        }

        /// <summary>
        /// SFTP setting private key
        /// </summary>
        /// <param name="user">user</param>
        /// <param name="ip">ip</param>
        /// <param name="port">port</param>
        /// <param name="privateKey">key binary</param>
        public void InitialSFTPSettingsByPrivateKey(string user, string ip, int port, byte[] privateKey)
        {
            List<AuthenticationMethod> methods = new List<AuthenticationMethod>();
            MemoryStream stream = new MemoryStream(privateKey);
            methods.Add(new PrivateKeyAuthenticationMethod(user, new PrivateKeyFile(stream)));
            var coninfo = new ConnectionInfo(ip, port, user, methods.ToArray());
            sftpClient = new SftpClient(coninfo);
        }

        /// <summary>
        /// Connect SFTP client
        /// </summary>
        public bool Connect()
        {
            bool ret = false;
            if (sftpClient != null)
            {
                //Set time out
                //sftpClient.KeepAliveInterval = TimeSpan.MaxValue;
                //sftpClient.ConnectionInfo.Timeout = TimeSpan.MaxValue;
                sftpClient.Connect();
                ret = sftpClient.IsConnected;
            }
            return ret;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void DisposeSFTPClient()
        {
            try
            {
                if (sftpClient != null)
                {
                    sftpClient.Disconnect();
                    sftpClient.Dispose();
                }
            }
            finally
            {
                sftpClient = null;
            }
        }

        /// <summary>
        /// Upload files to remote target path
        /// </summary>
        /// <param name="fileStream">file stream</param>
        /// <param name="targetPath">target path</param>
        /// <returns>success or not</returns>
        public bool UploadFile(FileStream fileStream, string targetPath)
        {
            bool ret = false;
            if (IsSftpClientActive())
            {
                sftpClient.UploadFile(fileStream, targetPath);
                ret = true;
            }
            return ret;
        }

        /// <summary>
        /// Create Folder for target path
        /// </summary>
        /// <param name="folderPath">folder path</param>
        /// <returns>success or not</returns>
        public bool CreateDirectory(string folderPath)
        {
            bool ret = false;
            if (IsSftpClientActive())
            {
                sftpClient.CreateDirectory(folderPath);
                ret = true;
            }
            return ret;
        }

        /// <summary>
        /// Delete Folder for target path
        /// </summary>
        /// <param name="folderPath">folder path</param>
        /// <returns>success or not</returns>
        public bool DeleteDirectory(string folderPath)
        {
            bool ret = false;
            if (IsSftpClientActive())
            {
                IEnumerable<SftpFile> sftpFiles = sftpClient.ListDirectory(folderPath);
                foreach (var file in sftpFiles)
                {
                    if ((file.Name != UPPER_PATH_1) && (file.Name != UPPER_PATH_2))
                    {
                        if (file.IsDirectory)
                        {
                            DeleteDirectory(file.FullName);
                        }
                        else
                        {
                            sftpClient.DeleteFile(file.FullName);
                        }
                    }
                }
                sftpClient.DeleteDirectory(folderPath);
                ret = true;
            }
            return ret;
        }

        /// <summary>
        /// Check file path or directory exists
        /// </summary>
        /// <returns>exists or not</returns>
        public bool IsPathExists(string path)
        {
            bool ret = false;
            if (sftpClient != null && sftpClient.IsConnected)
            {
                ret = sftpClient.Exists(path);
            }
            return ret;
        }

        /// <summary>
        /// Upload files to remote target path
        /// </summary>
        /// <param name="sourcePath">source path</param>
        /// <param name="target">file steam to write</param>
        /// <returns>success or not</returns>
        public bool DownloadFiles(string sourcePath, FileStream target)
        {
            bool ret = false;
            if (IsSftpClientActive())
            {
                sftpClient.DownloadFile(sourcePath, target);
                ret = true;
            }
            return ret;
        }

        /// <summary>
        /// Upload all directory
        /// </summary>
        /// <param name="nvPath">nv path</param>
        /// <param name="linuxPath">linux path</param>
        /// <param name="fileFilter">file filter if necessary</param>
        /// <returns>success or not</returns>
        public void UploadDirectory(string nvPath, string linuxPath, string filterFolder = "", string fileFilter = "")
        {
            IEnumerable<FileSystemInfo> infos = new DirectoryInfo(nvPath).EnumerateFileSystemInfos();
            if (IsSftpClientActive())
            {
                foreach (FileSystemInfo info in infos)
                {
                    if (info.Attributes.HasFlag(FileAttributes.Directory))
                    {  //Sub Directory
                        string subPath = linuxPath + LINUX_PATH_CHAR + info.Name;
                        if (!sftpClient.Exists(subPath))
                        {
                            sftpClient.CreateDirectory(subPath);
                        }
                        string filter = (info.Name == filterFolder) ? fileFilter : string.Empty;
                        UploadDirectory(info.FullName, linuxPath + LINUX_PATH_CHAR + info.Name, filterFolder, filter);
                    }
                    else
                    {  //File
                        if (string.IsNullOrEmpty(fileFilter) ||
                            (!string.IsNullOrEmpty(fileFilter) && Regex.IsMatch(info.Name, fileFilter)))
                        {
                            using (Stream fileStream = new FileStream(info.FullName, FileMode.Open))
                            {
                                //Upload file
                                sftpClient.UploadFile(fileStream, linuxPath + LINUX_PATH_CHAR + info.Name);
                            }
                        }

                    }
                }
            }
        }

        /// <summary>
        /// Download Directory
        /// </summary>
        /// <param name="srcPath">source path</param>
        /// <param name="destPath">dest path</param>
        public void DownloadDirectory(string srcPath, string destPath)
        {
            Directory.CreateDirectory(destPath);
            IEnumerable<SftpFile> files = sftpClient.ListDirectory(srcPath);
            foreach (SftpFile file in files)
            {
                if ((file.Name != UPPER_PATH_1) && (file.Name != UPPER_PATH_2))
                {
                    string sourceFilePath = srcPath + LINUX_PATH_CHAR + file.Name;
                    string destFilePath = Path.Combine(destPath, file.Name);
                    if (file.IsDirectory)
                    {
                        DownloadDirectory(sourceFilePath, destFilePath);
                    }
                    else
                    {
                        using (Stream fileStream = File.Create(destFilePath))
                        {
                            sftpClient.DownloadFile(sourceFilePath, fileStream);
                        }
                    }
                }
            }
        }
    }
}
