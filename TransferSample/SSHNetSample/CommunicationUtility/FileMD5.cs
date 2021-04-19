using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SSHNetSample.CommunicationUtility
{
    public class FileMD5
    {
        /// <summary>
        /// Get file md5 hash
        /// </summary>
        /// <param name="fileName">file name</param>
        /// <returns>md5 byte array</returns>
        public static byte[] GetFileMD5Hash(string fileName)
        {
            byte[] hash = null;
            using (var md5 = MD5.Create())
            {
                using (var fl = File.Open(fileName, FileMode.Open, FileAccess.Read))
                //using (var br = new BinaryReader(fl))
                {
                    //hash = md5.ComputeHash(br.ReadBytes((int)fl.Length));
                    hash = md5.ComputeHash(fl);
                }
            }
            return hash;
        }

        public static byte[] GetZipFileMD5Hash(string zipFilePath)
        {
            byte[] hash = null;
            using (var md5 = MD5.Create())
            {

                ZipEntry entry = new ZipEntry(zipFilePath);
                hash = md5.ComputeHash(entry.ExtraData);
            }
            return hash;
        }
    }
}
