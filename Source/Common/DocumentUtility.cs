using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvDTE;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace SSMSTool.Common
{
    public class DocumentUtility
    {
        public static string TreateElement(string src, bool withUpperCase = true, bool treateNmark = true)
        {
            string str = src;
            try
            {
                str = Strings.Trim(str);
                if (withUpperCase)
                {
                    str = Strings.UCase(str);
                }
                str = Strings.Replace(str, "\t", null, 1, -1, CompareMethod.Binary);
                str = Strings.Replace(str, "\r\n", null, 1, -1, CompareMethod.Binary);
                if (treateNmark)
                {
                    str = Strings.Replace(str, "[", null, 1, -1, CompareMethod.Binary);
                    str = Strings.Replace(str, "]", null, 1, -1, CompareMethod.Binary);
                }
                str = Strings.Replace(str, "\r", null, 1, -1, CompareMethod.Binary);
                str = Strings.Replace(str, "\n", null, 1, -1, CompareMethod.Binary);
                if (str != null)
                {
                    str = str.Trim();
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                ProjectData.ClearProjectError();
            }

            return str;
        }

        public static void EnvAddContent(TextSelection objSel, string context)
        {
            try
            {
                if (objSel.Text != string.Empty)
                {
                    objSel.Delete(1);
                }
                EditPoint editPoint = objSel.TopPoint.CreateEditPoint();
                //editPoint.MoveToPoint

                editPoint.Insert(context);

            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                ProjectData.ClearProjectError();
            }
        }
    }
}
