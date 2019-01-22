using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace AutoClickForWindows
{
    public class CommonUtility
    {
        private static string configPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            + Path.DirectorySeparatorChar + "Setting.xml";

        /// <summary>
        /// Save configuration
        /// </summary>
        public static void SaveConfiguration(List<MouseActionEntity> config)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<MouseActionEntity>));
            using (var wr = new StreamWriter(configPath, false))
            {
                serializer.Serialize(wr, config);
            }
        }

        /// <summary>
        /// Config file exists or not
        /// </summary>
        /// <returns></returns>
        public static bool IsConfigFileExists()
        {
            return File.Exists(configPath);
        }

        /// <summary>
        /// Get configuration settings
        /// </summary>
        /// <returns>config data</returns>
        public static List<MouseActionEntity> ReadConfiguration()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<MouseActionEntity>));
            List<MouseActionEntity> config = null;
            using (var rd = new StreamReader(configPath))
            {
                config = (List<MouseActionEntity>)serializer.Deserialize(rd);
            }
            return config;
        }
    }
}
