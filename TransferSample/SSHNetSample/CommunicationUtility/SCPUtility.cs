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
    public class SCPUtility
    {
        // Instance
        private static SCPUtility instance = null;
        // Sftp client
        private ScpClient scpClient = null;
        // Linux upper path flag
        private const string UPPER_PATH_1 = ".";
        private const string UPPER_PATH_2 = "..";
        /// <summary>
        /// Instance of SimulatorFormBusiness
        /// </summary>
        public static SCPUtility Instance
        {
            get
            {
                return instance ?? (instance = new SCPUtility());
            }
        }

        /// <summary>
        /// Check scp client is connect or not
        /// </summary>
        /// <returns>connect or not</returns>
        public bool IsSCPClientActive()
        {
            return (scpClient != null && scpClient.IsConnected);
        }

        /// <summary>
        /// Initial SCP settings
        /// </summary>
        /// <param name="user">user</param>
        /// <param name="password">password</param>
        /// <param name="ip">ip address</param>
        /// <param name="port">port</param>
        public void InitialSCPSettings(string user, string password, string ip, int port)
        {
            // Setup Credentials and Server Information
            ConnectionInfo connectInfo = new ConnectionInfo(ip, port, user,
                // Pasword based Authentication
                new AuthenticationMethod[] { new PasswordAuthenticationMethod(user, password) });
            scpClient = new ScpClient(connectInfo);
        }

        /// <summary>
        /// SCP setting private key
        /// </summary>
        /// <param name="user">user</param>
        /// <param name="ip">ip</param>
        /// <param name="port">port</param>
        /// <param name="keyPath">key path</param>
        public void InitialSCPSettingsByPrivateKey(string user, string ip, int port, List<Tuple<string, string>> keyPath)
        {
            List<AuthenticationMethod> methods = new List<AuthenticationMethod>();
            foreach (var key in keyPath)
            {
                methods.Add(new PrivateKeyAuthenticationMethod(user, new PrivateKeyFile(key.Item1, key.Item2)));
            }
            var coninfo = new ConnectionInfo(ip, port, user, methods.ToArray());
            scpClient = new ScpClient(coninfo);
        }

        /// <summary>
        /// SCP setting private key
        /// </summary>
        /// <param name="user">user</param>
        /// <param name="ip">ip</param>
        /// <param name="port">port</param>
        /// <param name="privateKey">key binary</param>
        public void InitialSCPSettingsByPrivateKey(string user, string ip, int port, byte[] privateKey)
        {
            List<AuthenticationMethod> methods = new List<AuthenticationMethod>();
            MemoryStream stream = new MemoryStream(privateKey);
            methods.Add(new PrivateKeyAuthenticationMethod(user, new PrivateKeyFile(stream)));
            var coninfo = new ConnectionInfo(ip, port, user, methods.ToArray());
            scpClient = new ScpClient(coninfo);
        }

        /// <summary>
        /// Connect SCP client
        /// </summary>
        public bool Connect()
        {
            bool ret = false;
            if (scpClient != null)
            {
                scpClient.Connect();
                ret = scpClient.IsConnected;
            }
            return ret;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void DisposeSCPClient()
        {
            try
            {
                if (scpClient != null)
                {
                    scpClient.Disconnect();
                    scpClient.Dispose();
                }
            }
            finally
            {
                scpClient = null;
            }
        }

        /// <summary>
        /// Upload files to remote target path
        /// </summary>
        /// <param name="filePath">file path</param>
        /// <param name="targetPath">target path</param>
        /// <returns>success or not</returns>
        public bool UploadFile(string filePath, string targetPath)
        {
            bool ret = false;
            if (IsSCPClientActive())
            {
                scpClient.Upload(new FileInfo(filePath), targetPath);
                ret = true;
            }
            return ret;
        }

        /// <summary>
        /// Upload all directory
        /// </summary>
        /// <param name="srcDirect">src direct</param>
        /// <param name="hostPath">host path</param>
        /// <returns>success or not</returns>
        public void UploadDirectory(DirectoryInfo srcDirect, string hostPath)
        {
            scpClient.Upload(srcDirect, hostPath);
        }

        /// <summary>
        /// Download file to local path
        /// </summary>
        /// <param name="filePath">file path</param>
        /// <param name="targetPath">target path</param>
        /// <returns>success or not</returns>
        public bool DownloadFile(string filePath, string targetPath)
        {
            bool ret = false;
            if (IsSCPClientActive())
            {
                Stream fileContent = null;
                scpClient.Download(filePath, fileContent);
                using (FileStream output = File.OpenWrite(targetPath))
                {
                    fileContent.CopyTo(output);
                    ret = true;
                }
            }
            return ret;
        }

        /// <summary>
        /// Download Directory
        /// </summary>
        /// <param name="srcDirect">source path</param>
        /// <param name="localPath">local path</param>
        public void DownloadDirectory(string srcDirect, DirectoryInfo localPath)
        {
            scpClient.Download(srcDirect, localPath);
        }
    }
}
