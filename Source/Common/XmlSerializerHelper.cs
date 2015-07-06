using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SSMSTool.Common
{
    public static class XmlSerializerHelper
    {
        public static T Deserialize<T>(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return default(T);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using(FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                return (T)serializer.Deserialize(fs);
            }
        }

        public static void Serialize<T>(T o, string savePath)
        {
            string path = Path.GetDirectoryName(savePath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(fs, o);
            }
        }
    }
}
