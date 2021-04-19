using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SSHNetSample.CommunicationUtility
{
    public class FTPUtility
    {
        // Instance
        private static FTPUtility instance = null;
        // host ip
        private string hostIP;
        // user
        private string user;
        // password
        private string password;
        // encoding
        private Encoding encoding;
        // FTP port
        private string port;
        // buffer size
        private const int BUFFER_SIZE = 16 * 1024;
        // directory split
        private const string DIRECTORY_SPLIT = "|";
        // space
        private const string SPACE = " ";
        // folder flag is "d"
        private const string FOLDER_FLAG = "d";
        // Linux path flag
        private const string LINUX_PATH_FLAG = @"/";
        // All file flag
        private const string ALL_FILE = "*.*";
        // List info count = 9
        private const int DIRECTORY_INFO_COUNT = 9;
        // Post spliter
        private const string PORT_SPLITER = ":";

        /// <summary>
        /// Instance of WebSocket Utility
        /// </summary>
        public static FTPUtility Instance
        {
            get
            {
                return instance ?? (instance = new FTPUtility());
            }
        }

        /// <summary>
        /// Initial FTP connection
        /// </summary>
        /// <param name="host">host ip</param>
        /// <param name="account">account</param>
        /// <param name="pass">password</param>
        /// <param name="enc">encoding</param>
        /// <param name="ftpPort">ftp port</param>
        public void InitialFTPConnectionInfo(string host, string account, string pass, Encoding enc = null, string ftpPort = "")
        {
            hostIP = host;
            user = account;
            password = pass;
            encoding = enc ?? Encoding.Default;
            port = ftpPort;
        }

        /// <summary>
        /// Get host and file path
        /// </summary>
        /// <param name="remotePath">remote path</param>
        /// <returns>full path</returns>
        private string GetHostAndFileFullPath(string remotePath)
        {
            string ret = string.Empty;
            if (string.IsNullOrEmpty(port))
            {
                ret = hostIP + LINUX_PATH_FLAG + remotePath;
            }
            else
            {
                ret = hostIP + PORT_SPLITER + port + LINUX_PATH_FLAG + remotePath;
            }
            return ret;
        }

        private FtpWebRequest CreateFTPWebRequst(string remotePath, string ftpMethod)
        {
            FtpWebRequest ftpRequest = (FtpWebRequest)FtpWebRequest.Create(GetHostAndFileFullPath(remotePath));
            ftpRequest.Credentials = new NetworkCredential(user, password);
            ftpRequest.UseBinary = true;
            ftpRequest.UsePassive = true;
            ftpRequest.KeepAlive = true;
            ftpRequest.Method = ftpMethod;
            return ftpRequest;
        }

        /// <summary>
        /// Download file
        /// </summary>
        /// <param name="remoteFile">remote file path</param>
        /// <param name="localFile">local file path</param>
        /// <returns>success or not</returns>
        public bool DownloadFile(string remoteFile, string localFile)
        {
            bool ret = true;
            FtpWebRequest ftpRequest = CreateFTPWebRequst(remoteFile, WebRequestMethods.Ftp.DownloadFile);
            //Establish Return Communication with the FTP Server
            using (FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse())
            {
                //Get the FTP Server's Response Stream 
                using (BinaryReader ftpStream = new BinaryReader(ftpResponse.GetResponseStream(), encoding))
                {
                    //Open a File Stream to Write the Downloaded File
                    using (FileStream localFileStream = new FileStream(localFile, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        //Buffer for the Downloaded Data
                        byte[] byteBuffer = new byte[BUFFER_SIZE];
                        int bytesRead = ftpStream.Read(byteBuffer, 0, BUFFER_SIZE);
                        //Download the File by Writing the Buffered Data Until the Transfer is Complete
                        while (bytesRead > 0)
                        {
                            localFileStream.Write(byteBuffer, 0, bytesRead);
                            bytesRead = ftpStream.Read(byteBuffer, 0, BUFFER_SIZE);
                        }
                    }
                }
            }
            return ret;
        }
        /// <summary>
        /// Upload file
        /// </summary>
        /// <param name="remoteFile">remote file path</param>
        /// <param name="localFile">local file path</param>
        /// <returns>success or not</returns>
        public bool UploadFile(string remoteFile, string localFile)
        {
            bool ret = true;
            FtpWebRequest ftpRequest = CreateFTPWebRequst(remoteFile, WebRequestMethods.Ftp.UploadFile);
            //Get the FTP Server's Response Stream 
            using (Stream ftpStream = ftpRequest.GetRequestStream())
            {
                //Open a File Stream to Write the Downloaded File
                using (BinaryReader localFileStream =
                    new BinaryReader(new FileStream(localFile, FileMode.Open, FileAccess.Read), encoding))
                {
                    //Buffer for the Downloaded Data
                    byte[] byteBuffer = new byte[BUFFER_SIZE];
                    int bytesSent = localFileStream.Read(byteBuffer, 0, BUFFER_SIZE);
                    //Upload the File by Sending the Buffered Data Until the Transfer is Complete
                    while (bytesSent > 0)
                    {
                        ftpStream.Write(byteBuffer, 0, bytesSent);
                        bytesSent = localFileStream.Read(byteBuffer, 0, BUFFER_SIZE);
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// Delete file
        /// </summary>
        /// <param name="remoteFilePath">remote file path</param>
        /// <returns>success or not</returns>
        public bool DeleteFile(string remoteFilePath)
        {
            bool ret = true;
            //Create an FTP Request
            FtpWebRequest ftpRequest = CreateFTPWebRequst(remoteFilePath, WebRequestMethods.Ftp.DeleteFile);
            //Establish Return Communication with the FTP Server
            FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
            //Resource Cleanup
            ftpResponse.Close();
            ftpRequest = null;
            return ret;
        }

        /// <summary>
        /// Delete folder
        /// </summary>
        /// <param name="remoteFolderPath">remote folder path</param>
        /// <returns>success or not</returns>
        public bool DeleteFolder(string remoteFolderPath)
        {
            bool ret = true;
            //Create an FTP Request
            FtpWebRequest ftpRequest = CreateFTPWebRequst(remoteFolderPath, WebRequestMethods.Ftp.RemoveDirectory);
            //Establish Return Communication with the FTP Server
            FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
            //Resource Cleanup
            ftpResponse.Close();
            ftpRequest = null;
            return ret;
        }

        /// <summary>
        /// Rename file
        /// </summary>
        /// <param name="currentFileNameAndPath">current file name path</param>
        /// <param name="newFileName">new file name</param>
        /// <returns>success or not</returns>
        public bool RenameFile(string currentFileNameAndPath, string newFileName)
        {
            bool ret = true;
            //Create an FTP Request
            FtpWebRequest ftpRequest = CreateFTPWebRequst(currentFileNameAndPath, WebRequestMethods.Ftp.Rename);
            //Rename the File
            ftpRequest.RenameTo = newFileName;
            //Establish Return Communication with the FTP Server
            FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
            //Resource Cleanup
            ftpResponse.Close();
            ftpRequest = null;
            return ret;
        }

        /// <summary>
        /// Create a New Directory on the FTP Server
        /// </summary>
        /// <param name="newDirectory">new directory</param>
        /// <returns>success or not</returns>
        public bool CreateDirectory(string newDirectory)
        {
            bool ret = true;
            //Create an FTP Request
            FtpWebRequest ftpRequest = CreateFTPWebRequst(newDirectory, WebRequestMethods.Ftp.MakeDirectory);
            //Establish Return Communication with the FTP Server
            FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
            //Resource Cleanup
            ftpResponse.Close();
            ftpRequest = null;
            return ret;
        }

        /// <summary>
        /// List Directory Contents File/Folder Name Only
        /// </summary>
        /// <param name="newDirectory">new directory</param>
        /// <returns>directory list</returns>
        public string[] DirectoryList(string directory)
        {
            //Empty string result
            string[] result = new string[] { string.Empty };
            //Create an FTP Request
            FtpWebRequest ftpRequest = CreateFTPWebRequst(directory, WebRequestMethods.Ftp.ListDirectoryDetails);
            //Establish Return Communication with the FTP Server
            using (FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse())
            {
                ///Establish Return Communication with the FTP Server
                using (var ftpStream = ftpResponse.GetResponseStream())
                {
                    //Get the FTP Server's Response Stream
                    using (StreamReader ftpReader = new StreamReader(ftpStream, encoding))
                    {
                        //Store the Raw Response
                        StringBuilder directoryRaw = new StringBuilder();
                        while (ftpReader.Peek() != -1)
                        {
                            directoryRaw.Append(ftpReader.ReadLine() + DIRECTORY_SPLIT);
                        }
                        //Set directory list
                        result = directoryRaw.ToString().Split(DIRECTORY_SPLIT.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Check folder exists or not
        /// </summary>
        /// <param name="parentPath">parent path</param>
        /// <param name="folderPath">folder path</param>
        /// <returns>exist or not</returns>
        public bool IsDirectoryExist(string parentPath, string folderPath)
        {
            bool isExist = false;
            string[] detailList = DirectoryList(parentPath);
            foreach (var item in detailList)
            {
                string[] detail = item.Split(SPACE.ToCharArray(), DIRECTORY_INFO_COUNT, StringSplitOptions.RemoveEmptyEntries);
                if (detail.Length > 0)
                {
                    //Folder flag is "d" and last is file name
                    isExist = detail.First().First().ToString().Equals(FOLDER_FLAG) &&
                        detail.Last().Equals(Path.GetFileName(folderPath));
                    if (isExist)
                    {
                        break;
                    }
                }
            }
            return isExist;
        }

        /// <summary>
        /// Upload all directory
        /// </summary>
        /// <param name="remoteFolderPath">remote path</param>
        /// <param name="localFolderPath">local folder path</param>
        /// <returns>success or not</returns>
        public bool UploadAllDirectory(string remoteFolderPath, string localFolderPath)
        {
            bool ret = true;
            //Get all files and sub dirs
            string[] files = Directory.GetFiles(localFolderPath, ALL_FILE);
            string[] subDirs = Directory.GetDirectories(localFolderPath);

            //Upload all files
            foreach (string file in files)
            {
                UploadFile(remoteFolderPath + LINUX_PATH_FLAG + Path.GetFileName(file), file);
            }

            //Loop all sub dir
            foreach (string subDir in subDirs)
            {
                if (!IsDirectoryExist(remoteFolderPath, subDir))
                {
                    CreateDirectory(remoteFolderPath + LINUX_PATH_FLAG + Path.GetFileName(subDir));
                }
                //Loop to update all sub folders
                UploadAllDirectory(remoteFolderPath + LINUX_PATH_FLAG + Path.GetFileName(subDir), subDir);
            }
            return ret;
        }

        /// <summary>
        /// Download all directory
        /// </summary>
        /// <param name="remoteFolderPath">remote path</param>
        /// <param name="localFolderPath">local folder path</param>
        /// <returns>success or not</returns>
        public bool DownloadAllDirectory(string remoteFolderPath, string localFolderPath)
        {
            bool ret = true;
            if (!Directory.Exists(localFolderPath))
            {
                Directory.CreateDirectory(localFolderPath);
            }
            //Get remote path all folder and files
            string[] dirs = DirectoryList(remoteFolderPath);
            foreach (string dir in dirs)
            {
                //Get every dir information
                string[] tokens =
                    dir.Split(SPACE.ToCharArray(), DIRECTORY_INFO_COUNT, StringSplitOptions.RemoveEmptyEntries);
                string name = tokens.Last();
                string permissions = tokens.First();
                string filePath = localFolderPath + Path.DirectorySeparatorChar + name;
                string remotePath = remoteFolderPath + LINUX_PATH_FLAG + name;
                if (permissions.First().ToString() == FOLDER_FLAG)
                {  //When sub folder
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    //Download all sub directory
                    DownloadAllDirectory(remotePath, filePath);
                }
                else
                {  //When file, download and overwrite it.
                    //if (File.Exists(filePath))
                    //{
                    //    File.Delete(filePath);
                    //}
                    DownloadFile(remotePath, filePath);
                }
            }
            return ret;
        }

        /// <summary>
        /// Check file exist or not
        /// </summary>
        /// <param name="folderPath">folder path</param>
        /// <param name="fileName">file name</param>
        /// <returns>exist or not</returns>
        public bool IsFileExist(string folderPath, string fileName)
        {
            bool isExist = false;
            string[] detailList = DirectoryList(folderPath);
            foreach (var item in detailList)
            {
                string[] detail = item.Split(SPACE.ToCharArray(), DIRECTORY_INFO_COUNT, StringSplitOptions.RemoveEmptyEntries);
                if (detail.Length > 0)
                {
                    //file name is existed
                    isExist = item.Contains(fileName);
                    if (isExist)
                    {
                        break;
                    }
                }
            }
            return isExist;
        }

        /// <summary>
        /// Get file list by folder
        /// </summary>
        /// <param name="folderPath">folder path</param>
        /// <returns>file list in folder</returns>
        public List<string> GetFileListByFolder(string folderPath)
        {
            List<string> result = new List<string>();
            string[] detailList = DirectoryList(folderPath);
            foreach (var item in detailList)
            {
                string[] detail = item.Split(SPACE.ToCharArray(), DIRECTORY_INFO_COUNT, StringSplitOptions.RemoveEmptyEntries);
                if (detail.Length == DIRECTORY_INFO_COUNT && !detail.First().First().ToString().Equals(FOLDER_FLAG))
                {
                    result.Add(detail.Last());
                }
            }
            return result;
        }
    }
}
