using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.CommandBars;
using SSMSTool.Common;
using SSMSTool.Common.Command;

namespace SSMSTool.CodeSnippet
{
    public class CodeSnippetConnect : CommonConnect
    {
        private const string SYMBOL_CURSOR = "{C}";
        private const string ACTION_KEY = "\t";
        
        
        private TextDocumentKeyPressEvents textPanelKeyEvent;
        private Dictionary<string, string> codeSnippetsDic;

        public CodeSnippetConnect(PluginManager pluginManager)
            : base(pluginManager)
        {
            CodeSnippetSetting setting = LoadData();
            if (setting != null && setting.Enabled)
            {
                this.Init();
                this.InitCodeSnippetData(setting);
            }

            this.SetUI();
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

        private void SetUI()
        {
            CommandBarPopup sqlToolCommandBar = pluginManager.MenuManager.CreatePopupMenu("MenuBar", "SQL Tools", 4);
            CommandBarPopup commandBar = pluginManager.MenuManager.AddSubPopupMenu(sqlToolCommandBar, "Code Snippet", 1);

            OptionCommand command = new OptionCommand("Options", "");
            command.CodeSnippetConnect = this;
            pluginManager.MenuManager.AddCommandMenu(commandBar, command, 1);
        }

        private void TempSave()
        {
            List<CodeSnippetInfo> list = new List<CodeSnippetInfo>();
            CodeSnippetInfo info = new CodeSnippetInfo();
            info.ShortKey = "aa";
            info.Content = "sdfsdf";

            list.Add(info);
            XmlSerializerHelper.Serialize<List<CodeSnippetInfo>>(list, DataManager.GetPath("CodeSnippet.priavte.xml"));
        }

        public CodeSnippetSetting LoadData() 
        {
            CodeSnippetSetting setting = XmlSerializerHelper.Deserialize<CodeSnippetSetting>(DataManager.GetPath("CodeSnippet.priavte.xml"));
            return setting;
        }

        public void SaveData(CodeSnippetSetting setting)
        {
            XmlSerializerHelper.Serialize<CodeSnippetSetting>(setting, DataManager.GetPath("CodeSnippet.priavte.xml"));
            
            // reload
            this.InitCodeSnippetData(setting);
        }

        public void InitCodeSnippetData(CodeSnippetSetting setting)
        {
            this.codeSnippetsDic = new Dictionary<string, string>();

            if (setting == null) return;
            if (!setting.Enabled) return;

            List<CodeSnippetInfo> list = setting.CodeList;
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    if (item.Active &&
                        !string.IsNullOrEmpty(item.ShortKey) && 
                        !this.codeSnippetsDic.ContainsKey(item.ShortKey) &&
                        !string.IsNullOrEmpty(item.Content))
                    {
                        this.codeSnippetsDic.Add(item.ShortKey.ToUpper(), item.Content);
                    }
                }
            }
        }

        private void textPanelKeyEvent_BeforeKeyPress(string Keypress, TextSelection Selection, bool InStatementCompletion, ref bool CancelKeypress)
        {
            if (Keypress != ACTION_KEY)
            {
                return;
            }

            string key = HitAndMatchPreviousKeyHidden(Selection);
            if (string.IsNullOrEmpty(key))
            {
                return;
            }

            CancelKeypress = true; 

            string code = this.codeSnippetsDic[key];
            Selection.Delete(key.Length);
            TextPoint currentPoint = Selection.AnchorPoint.CreateEditPoint();
            
            this.applicationObject.UndoContext.Open("template insert mycodesnippet", false);
            DocumentUtility.EnvAddContent(Selection, code);
            SetCursor(Selection, currentPoint, code);
            this.applicationObject.UndoContext.Close();
        }

        private string HitAndMatchPreviousKeyHidden(TextSelection objSel)
        {
            string key = null;
            TextPoint point3 = objSel.AnchorPoint.CreateEditPoint();
            TextPoint point2 = objSel.ActivePoint.CreateEditPoint();
            key = DocumentUtility.TreateElement(objSel.Text, true, true);
            if (!string.IsNullOrEmpty(key))
            {
                if (this.codeSnippetsDic.ContainsKey(key))
                {
                    return DocumentUtility.TreateElement(objSel.Text, true, true);
                }
                else
                {
                    return null;
                }
            }

            EditPoint point = objSel.ActivePoint.CreateEditPoint();
            if (string.IsNullOrEmpty(DocumentUtility.TreateElement(point.GetText(1), true, true)))
            {
                point.CharLeft(1);
                if (string.IsNullOrEmpty(DocumentUtility.TreateElement(point.GetText(1), true, true)))
                {
                    point.CharRight(1);
                }
                else
                {
                    point.CharRight(1);
                    objSel.WordLeft(true, 1);
                    key = DocumentUtility.TreateElement(objSel.Text, true, true);
                    if (this.codeSnippetsDic.ContainsKey(key))
                    {
                        return DocumentUtility.TreateElement(objSel.Text, true, true);
                    }
                }
            }

            objSel.MoveToAbsoluteOffset(point3.AbsoluteCharOffset, false);
            objSel.SwapAnchor();
            objSel.MoveToAbsoluteOffset(point2.AbsoluteCharOffset, true);
            return null;
        }

        private void SetCursor(TextSelection objSel, TextPoint currentPoint, string code)
        {
            if (!code.ToUpper().Contains(SYMBOL_CURSOR))
            {
                return;
            }

            objSel.MoveToPoint(currentPoint);
            if (objSel.FindText(SYMBOL_CURSOR))
            {
                objSel.Delete();
            }
        }
    }
}
