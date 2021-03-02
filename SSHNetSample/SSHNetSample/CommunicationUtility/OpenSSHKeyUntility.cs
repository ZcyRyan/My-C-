using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace SSHNetSample.CommunicationUtility
{
    public class OpenSSHKeyUntility
    {
        private static string SSH_RSA_KEY = "id_rsa";
        private static string SSH_RSA_PUBLIC_EXT = @".pub";
        private static string KEY_GENERATE_COMMAND = @"ssh-keygen -t rsa -f {0} -N """"";

        private static byte[] privateKey = null;
        private static byte[] publicKey = null;

        // Command exe
        private const string CMD_EXE = "cmd.exe";
        // Command Argument without break
        private const string CMD_ARGUMENT_HEADER = @"/C ";

        /// <summary>
        /// Get or set PrivateKey
        /// </summary>
        public static byte[] PrivateKey
        {
            get { return privateKey; }
        }

        /// <summary>
        /// Get or set PublicKey
        /// </summary>
        public static byte[] PublicKey
        {
            get { return publicKey; }
        }

        /// <summary>
        /// Generate open ssh key
        /// </summary>
        /// <returns>sucess: true, fail: false</returns>
        public static bool GenerateOpenSSHKey()
        {
            bool ret = true;
            string filePath = string.Empty;
            string publicKeyPath = string.Empty;
            //Clear key content
            privateKey = null;
            publicKey = null;
            try
            {
                filePath = Path.GetTempPath() + Guid.NewGuid();
                //Run ssh keygen to create keys
                using (Process cmd = new Process())
                {
                    //cmd.StartInfo.FileName = "cmd.exe";
                    //cmd.StartInfo.RedirectStandardInput = true;
                    //cmd.StartInfo.RedirectStandardOutput = true;
                    //cmd.StartInfo.CreateNoWindow = true;
                    //cmd.StartInfo.UseShellExecute = false;
                    //cmd.Start();
                    //cmd.StandardInput.WriteLine(string.Format(KEY_GENERATE_COMMAND, filePath));
                    //cmd.StandardInput.Flush();
                    //cmd.StandardInput.Close();
                    //cmd.WaitForExit();

                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    cmd.StartInfo.CreateNoWindow = true;
                    cmd.StartInfo.FileName = CMD_EXE;
                    cmd.StartInfo.Arguments = CMD_ARGUMENT_HEADER + string.Format(KEY_GENERATE_COMMAND, filePath);
                    cmd.StartInfo.UseShellExecute = false;
                    cmd.Start();
                    cmd.WaitForExit();

                }

                //Private
                if (File.Exists(filePath))
                {
                    using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        using (BinaryReader rd = new BinaryReader(stream))
                        {
                            privateKey = rd.ReadBytes((int)stream.Length);
                        }
                    }
                }
                else
                {  // Key file not exists, error
                    ret = false;
                }

                //Public
                if (ret)
                {
                    publicKeyPath = filePath + SSH_RSA_PUBLIC_EXT;
                    if (File.Exists(publicKeyPath))
                    {
                        using (FileStream stream = new FileStream(publicKeyPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            using (BinaryReader rd = new BinaryReader(stream))
                            {
                                publicKey = rd.ReadBytes((int)stream.Length);
                            }
                        }
                    }
                }
            }
            catch
            {
                ret = false;
            }
            finally
            {
                //if (File.Exists(filePath))
                //{
                //    //Clear private key file
                //    File.Exists(filePath);
                //}
                //if (File.Exists(publicKeyPath))
                //{
                //    //Clear public key file
                //    File.Delete(publicKeyPath + SSH_RSA_PUBLIC_EXT);
                //}
            }
            return ret;
        }
    }
}
