using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace SSHNetSample.CommunicationUtility
{
    public class HttpUtility
    {
        // Instance
        private static HttpUtility instance = null;
        // Boundary
        private static string BOUNDARY = "--IDECHttp";
        // Boundary binary start
        private static byte[] BOUNDARY_START_BYTES = Encoding.UTF8.GetBytes("\r\n--" + BOUNDARY + "\r\n");
        // Boundary binary end
        private static byte[] BOUNDARY_END_BYTES = Encoding.UTF8.GetBytes("\r\n--" + BOUNDARY + "--\r\n");
        // Http header template
        private static string HTTP_HEADER_TEMPLATE = "content-disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
        // Content string
        private static string HTTP_CONTENT_TYPE = "multipart/form-data; boundary=" + BOUNDARY;
        // Post method of HTTP
        private const string HTTP_POST = "POST";
        // Get method of HTTP
        private const string HTTP_GET = "GET";
        // Post/Get steam size = 16KB every time
        private const int STEAM_SIZE = 16 * 1024;
        // Upload success string
        private const string SUCCESS_UPLOAD_RESPONSE = "The upload has been completed.";
        // Temp Zip file path
        private static string ZIP_TEMP_PATH = Path.GetTempPath() + "temp.zip";
        // File http header
        public const string HTTP_FILE_HEADER = "file";
        // Binary transfer type
        public const string HTTP_BINARY_TYPE_HEADER = "application/octet-stream";

        /// <summary>
        /// Instance of WebSocket Utility
        /// </summary>
        public static HttpUtility Instance
        {
            get
            {
                return instance ?? (instance = new HttpUtility());
            }
        }

        /// <summary>
        /// Creat Web Request
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="isPost">post or get</param>
        /// <returns>http web request</returns>
        private HttpWebRequest CreateWebRequest(string url, bool isPost = true)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = HTTP_CONTENT_TYPE;
            request.Method = isPost ? HTTP_POST : HTTP_GET;
            request.KeepAlive = true;
            request.Credentials = CredentialCache.DefaultCredentials;
            return request;
        }

        /// <summary>
        /// Download file
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="filePath">file path</param>
        /// <returns>success or not</returns>
        public bool HttpDownloadFile(string url, string filePath)
        {
            //Create the Get Request
            HttpWebRequest webRequest = CreateWebRequest(url, false);
            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                byte[] buffer = new byte[STEAM_SIZE];
                //Get web response
                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    using (Stream output = webResponse.GetResponseStream())
                    {  //Get stream from server
                        int received = 0;
                        do
                        {
                            //Write local file
                            received = output.Read(buffer, 0, STEAM_SIZE);
                            fileStream.Write(buffer, 0, received);
                        } while (received > 0);
                    }
                }
            }
            return File.Exists(filePath);
        }

        /// <summary>
        /// Upload file
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="filePath">file path</param>
        /// <param name="paramName">param name</param>
        /// <param name="contentType">content type</param>
        /// <returns>success or not</returns>
        public bool HttpUploadFile(string url, string filePath, string paramName, string contentType)
        {
            bool ret = false;
            // Create the Post Request
            HttpWebRequest request = CreateWebRequest(url);
            // Get request stream
            using (Stream requestStream = request.GetRequestStream())
            {
                //Boundary start
                requestStream.Write(BOUNDARY_START_BYTES, 0, BOUNDARY_START_BYTES.Length);

                //Header
                string header = string.Format(HTTP_HEADER_TEMPLATE, paramName, Path.GetFileName(filePath), contentType);
                byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
                requestStream.Write(headerbytes, 0, headerbytes.Length);

                //Write file
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    byte[] buffer = new byte[STEAM_SIZE];
                    int bytesRead = 0;
                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        requestStream.Write(buffer, 0, bytesRead);
                    }
                }
                //Wite end boundary
                requestStream.Write(BOUNDARY_END_BYTES, 0, BOUNDARY_END_BYTES.Length);
            }

            WebResponse wresp = null;
            string resultString = string.Empty;
            try
            {
                wresp = request.GetResponse();
                Stream responseStream = wresp.GetResponseStream();
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    resultString = reader.ReadToEnd();
                }
                //Get success response from server
                ret = !string.IsNullOrEmpty(resultString) && resultString.Contains(SUCCESS_UPLOAD_RESPONSE);
            }
            finally
            {
                if (wresp != null)
                {
                    wresp.Close();
                    wresp = null;
                }
                request = null;
            }
            return ret;
        }

        /// <summary>
        /// Http upload folder
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="folderPath">folder path</param>
        /// <returns>success or not</returns>
        public bool HttpUploadFolder(string url, string folderPath)
        {
            bool ret = false;
            try
            {
                ZipFile.CreateFromDirectory(folderPath, ZIP_TEMP_PATH);
                ret = HttpUploadFile(url, ZIP_TEMP_PATH, HTTP_FILE_HEADER, HTTP_BINARY_TYPE_HEADER);
            }
            finally
            {
                //Delete temp zip file
                if (File.Exists(ZIP_TEMP_PATH))
                {
                    File.Delete(ZIP_TEMP_PATH);
                }
            }
            return ret;
        }
    }
}
