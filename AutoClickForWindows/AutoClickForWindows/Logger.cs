using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AutoClickForWindows
{
    public class Logger
    {
        private static string LoggerPath = Path.GetTempPath() + "AutoMouse" + DateTime.Now.ToString("yyyyMMddHHmmss");

        public static void WriteLog(string line)
        {
            using (var wr = new StreamWriter(LoggerPath,true))
            {
                wr.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "------" + line);
                wr.Flush();
            }
        }

        public static void CleanLogger()
        {
            var direct = new DirectoryInfo(Path.GetTempPath());
            var files = direct.GetFiles("AutoMouse*", SearchOption.TopDirectoryOnly);
            foreach (var info in files)
            {
                File.Delete(info.FullName);
            }
        }
    }
}
