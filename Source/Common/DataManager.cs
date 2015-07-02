﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SSMSTool.Common
{
    public static class DataManager
    {
        private static Dictionary<Type, object> globalDataDic;
        private static string userFilePath;

        static DataManager()
        {
            globalDataDic = new Dictionary<Type, object>();
            Init();
        }

        private static void Init()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            userFilePath = Path.Combine(path, "SSMSTool");
        }


    }
}
