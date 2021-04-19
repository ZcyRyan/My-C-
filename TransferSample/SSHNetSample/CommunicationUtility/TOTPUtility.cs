using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SSHNetSample.CommunicationUtility
{
    public class TOTPUtility
    {
        // Password padding char
        private const char PASSWORD_PADDING = '0';
        // User header
        private const string USER_HEADER = "IDEC";

        /// <summary>
        /// Password length
        /// </summary>
        /// <param name="passCount">password length</param>
        /// <param name="specialSeed">special seed</param>
        /// <returns>Timebased One-time password</returns>
        public static string TOTPGenerator(int dataLength, string specialSeed = "")
        {
            string oneTimePassword = string.Empty;
            DateTime dateTime = DateTime.Now;
            //Get time related string
            string timeRelatedString = dateTime.Day.ToString();
            timeRelatedString += dateTime.Month.ToString();
            timeRelatedString += dateTime.Year.ToString();
            timeRelatedString += dateTime.Hour.ToString();
            timeRelatedString += dateTime.Minute.ToString();
            timeRelatedString += dateTime.Second.ToString();
            timeRelatedString += dateTime.Millisecond.ToString();
            timeRelatedString += specialSeed;
            //Get hash string
            oneTimePassword = GetSha256String(timeRelatedString);

            //Password length = parameter length
            if (oneTimePassword.Length < dataLength)
            {
                oneTimePassword = oneTimePassword.PadLeft(dataLength, PASSWORD_PADDING);
            }
            else if (oneTimePassword.Length > dataLength)
            {
                oneTimePassword = oneTimePassword.Substring(0, dataLength);
            }
            return oneTimePassword;
        }

        /// <summary>
        /// Get time based ont-time user
        /// </summary>
        /// <param name="userLength">user length</param>
        /// <returns>user</returns>
        public static string GetTimeBasedUser(int userLength)
        {
            return TOTPGenerator(userLength, USER_HEADER);
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
                if (hexOutput.Length == 1)
                {  //When only one hex out put, set 0x30 at first byte - when 0x0D, 0x0A
                    originalString[index++] = (char)0x30;
                    originalString[index++] = hexOutput[0];
                }
                else
                {
                    originalString[index++] = hexOutput[0];
                    originalString[index++] = hexOutput[1];
                }
            }

            return originalString;
        }

        /// <summary>
        /// Encrypt password
        /// </summary>
        /// <param name="passWord">passWord</param>
        /// <returns>Encrypt password</returns>
        public static string EncryptPassword(string passWord)
        {
            char[] originalPassWord = passWord.ToCharArray();
            char[] encryptedPassWord = new char[originalPassWord.Length];

            for (int i = 0; i < encryptedPassWord.Length; i++)
            {
                encryptedPassWord[i] = (char)0x30;
            }

            for (int pass = 0; pass < encryptedPassWord.Length; pass++)
            {
                encryptedPassWord[pass] = (char)((originalPassWord[pass] << 1) & 0x00FF);
            }

            return new string(SplitStringToHex(new string(encryptedPassWord), 16 * 2));
        }

        /// <summary>
        /// Get Sha256 string
        /// </summary>
        /// <param name="value"></param>
        /// <returns>sha string</returns>
        private static String GetSha256String(String value)
        {
            StringBuilder ret = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));
                foreach (Byte b in result)
                {
                    ret.Append(b.ToString("x2"));
                }
            }
            return ret.ToString();
        }
    }
}
