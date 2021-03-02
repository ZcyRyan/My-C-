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
    public class httpback
    {
        // Instance
        private static httpback instance = null;
        // Boundary
        private static string BOUNDARY = "--IDECHttp";
        // Boundary binary start
        private static byte[] BOUNDARY_START_BYTES = Encoding.UTF8.GetBytes("\r\n--" + BOUNDARY + "\r\n");
        // Boundary binary end
        private static byte[] BOUNDARY_END_BYTES = Encoding.UTF8.GetBytes("\r\n--" + BOUNDARY + "--\r\n");
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
        public static httpback Instance
        {
            get
            {
                return instance ?? (instance = new httpback());
            }
        }

        private HttpWebRequest CreateWebRequest(string url, bool isPost = true)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = HTTP_CONTENT_TYPE;
            request.Method = isPost ? HTTP_POST : HTTP_GET;
            request.KeepAlive = true;
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Timeout = 24 * 60 * 60 * 1000;
            request.ContinueTimeout = 24 * 60 * 60 * 1000;
            request.ReadWriteTimeout = 24 * 60 * 60 * 1000;
            return request;
        }

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

        public bool HttpUploadFile(string url, string file, string paramName, string contentType, NameValueCollection nvc = null)
        {
            bool ret = false;
            // Create the Post Request
            HttpWebRequest request = CreateWebRequest(url);
            // string for form data
            //StringBuilder formdata = new StringBuilder();
            // Get request stream
            using (Stream requestStream = request.GetRequestStream())
            {
                if (nvc != null)
                {
                    //Form data template
                    string formdataTemplate = "content-disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
                    foreach (string key in nvc.Keys)
                    {
                        //formdata.Append("\r\n--" + BOUNDARY + "\r\n");
                        requestStream.Write(BOUNDARY_START_BYTES, 0, BOUNDARY_START_BYTES.Length);
                        string formitem = string.Format(formdataTemplate, key, nvc[key]);
                        //formdata.Append(formitem);
                        byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                        requestStream.Write(formitembytes, 0, formitembytes.Length);
                    }
                }
                //formdata.Append("\r\n--" + BOUNDARY + "\r\n");
                //Boundary start
                requestStream.Write(BOUNDARY_START_BYTES, 0, BOUNDARY_START_BYTES.Length);

                //Header
                string headerTemplate = "content-disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
                string header = string.Format(headerTemplate, paramName, Path.GetFileName(file), contentType);
                byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
                //formdata.Append(header);
                requestStream.Write(headerbytes, 0, headerbytes.Length);

                //Write file
                using (FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    byte[] buffer = new byte[STEAM_SIZE];
                    int bytesRead = 0;
                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        requestStream.Write(buffer, 0, bytesRead);
                    }
                }

                //formdata.Append("\r\n--" + BOUNDARY + "--\r\n");
                //Debug.Write(formdata.ToString());
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
            catch (WebException ex)
            {
                using (StreamReader rd1 = new StreamReader(ex.Response.GetResponseStream()))
                {
                    string pageContent = rd1.ReadToEnd();
                    MessageBox.Show(pageContent);
                }

                if (wresp != null)
                {
                    wresp.Close();
                    wresp = null;
                }
            }
            finally
            {
                request = null;
            }
            return ret;
        }

        public bool HttpUploadFolder(string url, string folderPath, string paramName, string contentType)
        {
            bool ret = false;
            ZipFile.CreateFromDirectory(folderPath, ZIP_TEMP_PATH);
            HttpUploadFile(url, ZIP_TEMP_PATH, HTTP_FILE_HEADER, HTTP_BINARY_TYPE_HEADER);
            return ret;
        }
    }
}
