using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvDTE;
using EnvDTE80;

namespace SSMSTool.CodeSnippet
{
    public class CodeSnippet
    {
        private DTE2 applicationObject;
        private AddIn addInInstance;
        private TextDocumentKeyPressEvents textPanelKeyEvent;

        public CodeSnippet(DTE2 applicationObject, AddIn addInInstance)
        {
            this.applicationObject = applicationObject;
            this.addInInstance = addInInstance;

            //this.Init();
        }


        private void Init()
        {
            this.textPanelKeyEvent = (TextDocumentKeyPressEvents)this.applicationObject.Events.GetObject("TextDocumentKeyPressEvents");
            _dispTextDocumentKeyPressEvents_BeforeKeyPressEventHandler handler = new _dispTextDocumentKeyPressEvents_BeforeKeyPressEventHandler(this.textPanelKeyEvent_BeforeKeyPress);
            if (this.textPanelKeyEvent != null)
            {
                this.textPanelKeyEvent.BeforeKeyPress -= handler;
            }

            if (this.textPanelKeyEvent != null)
            {
                this.textPanelKeyEvent.BeforeKeyPress += handler;
            }
        }


        private void textPanelKeyEvent_BeforeKeyPress(string Keypress, TextSelection Selection, bool InStatementCompletion, ref bool CancelKeypress)
        {
            //if (Keypress != "\t")
            //{
            //    return;
            //}

            //string key = HitAndMatchPreviousKeyHidden(Selection);
            //if (string.IsNullOrEmpty(key))
            //{
            //    return;
            //}

            //Selection.Delete(key.Length);

            //CancelKeypress = true;
            //this.applicationObject.UndoContext.Open("cCOM template insert", false);
            //cCTELibrary.EnvAddContent(Selection, "SELECT TOP 100 ");
            //this.applicationObject.UndoContext.Close();
        }

        public string HitAndMatchPreviousKeyHidden(TextSelection objSel)
        {
            //TextPoint point3 = objSel.AnchorPoint.CreateEditPoint();
            //TextPoint point2 = objSel.ActivePoint.CreateEditPoint();

            //string key = cCTELibrary.TreateElement(objSel.Text, true, true);
            //if (!string.IsNullOrEmpty(key))
            //{
            //    return key;
            //}

            //EditPoint point = objSel.ActivePoint.CreateEditPoint();
            //if (string.IsNullOrEmpty(cCTELibrary.TreateElement(point.GetText(1), true, true)))
            //{
            //    point.CharLeft(1);
            //    if (string.IsNullOrEmpty(cCTELibrary.TreateElement(point.GetText(1), true, true)))
            //    {
            //        point.CharRight(1);
            //    }
            //    else
            //    {
            //        point.CharRight(1);
            //        objSel.WordLeft(true, 1);
            //        key = cCTELibrary.TreateElement(objSel.Text, true, true);
            //        //if (mDefault.GlobalDBProxy.ActiveCollection.Contains(key))
            //        //{

            //        //}

            //        return cCTELibrary.TreateElement(objSel.Text, true, true);
            //    }
            //}

            //objSel.MoveToAbsoluteOffset(point3.AbsoluteCharOffset, false);
            //objSel.SwapAnchor();
            //objSel.MoveToAbsoluteOffset(point2.AbsoluteCharOffset, true);

            return string.Empty;
        }
    }
}
