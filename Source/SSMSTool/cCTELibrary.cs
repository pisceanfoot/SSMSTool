using System;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace SSMSTool
{
    public class cCTELibrary : IDisposable
    {
        private bool disposedValue = false;
        private Document DTEEnvDoc;
        private DTE2 DTESource;
        private TextDocument DTETextDoc;

        public cCTELibrary(DTE2 source)
        {
            this.DTESource = source;
            this.DTEEnvDoc = this.DTESource.ActiveDocument;
            this.DTETextDoc = (TextDocument)this.DTEEnvDoc.Object("");
        }

        public void Clear()
        {
            try
            {
                this.DTETextDoc.StartPoint.CreateEditPoint().Delete(this.DTETextDoc.EndPoint);
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                ProjectData.ClearProjectError();
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
            }
            this.disposedValue = true;
        }

        public static void EnvAddContent(TextSelection objSel, string context)
        {
            try
            {
                if (objSel.Text != "")
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

        public void EnvInsertAfter(string context, bool isToEnd = true)
        {
            try
            {
                EditPoint point = this.DTETextDoc.Selection.BottomPoint.CreateEditPoint();
                if (isToEnd)
                {
                    point.EndOfLine();
                }
                point.Insert(context);
                point = this.DTETextDoc.EndPoint.CreateEditPoint();
                NewLateBinding.LateCall(this.DTETextDoc, null, "Activate", new object[0], null, null, null, true);
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                ProjectData.ClearProjectError();
            }
        }

        public string GetContext()
        {
            string contextSelected = "";
            try
            {
                contextSelected = this.GetContextSelected();
                if (contextSelected.Length == 0)
                {
                    contextSelected = this.GetContextFull();
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                ProjectData.ClearProjectError();
            }
            return contextSelected;
        }

        public string GetContextFull()
        {
            string text = "";
            try
            {
                text = this.DTETextDoc.StartPoint.CreateEditPoint().GetText(this.DTETextDoc.EndPoint);
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                ProjectData.ClearProjectError();
            }
            return text;
        }

        public string GetContextSelected()
        {
            return this.DTETextDoc.Selection.Text;
        }

        public void InsertAfterEnd(string context, InsTypeSet InsTyp = 0)
        {
            try
            {
                EditPoint point = this.DTETextDoc.Selection.BottomPoint.CreateEditPoint();
                if (InsTyp == InsTypeSet.LineEnd)
                {
                    point.EndOfLine();
                }
                point.Insert(context);
                point = this.DTETextDoc.EndPoint.CreateEditPoint();
                this.DTEEnvDoc.Activate();
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                ProjectData.ClearProjectError();
            }
        }

        public void InsertWithCommentMarkAndFocus(string context)
        {
            try
            {
                context = Strings.Trim(context);
                if (context != "")
                {
                    int line = this.DTETextDoc.Selection.BottomPoint.CreateEditPoint().Line;
                    int length = Strings.Split(context, "\r\n", -1, CompareMethod.Binary).Length;
                    context = "\r\n/*\r\n" + context + "\r\n*/";
                    int endX = (line + length) + 2;
                    line += 2;
                    this.InsertAfterEnd(context, InsTypeSet.LineEnd);
                    this.SetSelection(line, 1, endX, 1);
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Interaction.MsgBox(exception.Message, MsgBoxStyle.Critical, "System information");
                ProjectData.ClearProjectError();
            }
        }

        public void SetSelection(int StartX, int StartY, int EndX, int EndY)
        {
            TextSelection selection = this.DTETextDoc.Selection;
            selection.MoveToLineAndOffset(StartX, StartY, false);
            selection.SwapAnchor();
            selection.MoveToLineAndOffset(EndX, EndY, true);
        }

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

        public string FullPath
        {
            get
            {
                return this.DTEEnvDoc.FullName;
            }
        }

        public enum InsTypeSet
        {
            Before,
            LineEnd
        }
    }
}