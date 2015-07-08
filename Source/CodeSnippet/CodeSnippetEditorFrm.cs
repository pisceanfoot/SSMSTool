using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace SSMSTool.CodeSnippet
{
    public partial class CodeSnippetEditorFrm : Form
    {
        public CodeSnippetEditorFrm()
        {
            InitializeComponent();
        }

        public CodeSnippetConnect CodeSnippetConnect
        {
            get;
            set;
        }

        private void CodeSnippetEditorFrm_Load(object sender, EventArgs e)
        {
            CodeSnippetSetting setting = this.CodeSnippetConnect.LoadData();
            if (setting == null)
            {
                ButtonDisable.Checked = true;
                ButtonEnable.Checked = true;
                return;
            }

            this.ButtonEnable.Checked = setting.Enabled;
            this.ButtonDisable.Checked = !this.ButtonEnable.Checked;

            if (setting.CodeList != null)
            {
                List<CodeSnippetUIInfo> uiList = new List<CodeSnippetUIInfo>();

                foreach (CodeSnippetInfo code in setting.CodeList)
                {
                    uiList.Add(new CodeSnippetUIInfo(code.ShortKey,
                        code.Content,
                        code.Active));
                }

                this.listView.SetObjects(uiList);
            }
        }

        /// <summary>
        /// ui
        /// </summary>
        private class CodeSnippetUIInfo
        {
            public CodeSnippetUIInfo(string shortcut, string content, bool active)
            {
                this.Shortcut = shortcut;
                this.Content = content;
                this.Active = active;
            }

            [OLVIgnore]
            public int Index { get; set; }

            [OLVColumn(ImageAspectName = "ShortKey")]
            public string Shortcut { get; set; }

            [OLVColumn(ImageAspectName = "Content")]
            public string Content { get; set; }

            [OLVColumn(ImageAspectName = "Active")]
            public bool Active { get; set; }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            List<CodeSnippetUIInfo> list = new List<CodeSnippetUIInfo>();
            list.Add(new CodeSnippetUIInfo("", "", false));

            this.listView.AddObjects(list);
        }

        private void BtnRemvoe_Click(object sender, EventArgs e)
        {
            if (this.listView.SelectedObjects != null && this.listView.SelectedObjects.Count != 0)
            {
                this.listView.RemoveObjects(this.listView.SelectedObjects);
            }
        }

        private CodeSnippetUIInfo selecteditem;

        private void listView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (this.listView.SelectedObjects != null && this.listView.SelectedObjects.Count != 0)
            {
                selecteditem = this.listView.SelectedObjects[0] as CodeSnippetUIInfo;
                this.TxtBoxCode.Text = selecteditem.Content;
            }
        }

        private void TxtBoxCode_TextChanged(object sender, EventArgs e)
        {
            if (this.selecteditem != null)
            {
                this.selecteditem.Content = this.TxtBoxCode.Text;

                if (this.listView.SelectedItem != null)
                {
                    this.listView.RefreshItem(this.listView.SelectedItem);
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            CodeSnippetSetting setting = this.CodeSnippetConnect.LoadData();
            if (setting == null)
            {
                setting = new CodeSnippetSetting();
            }
            setting.Enabled = this.ButtonEnable.Checked;

            if (this.listView.Objects != null)
            {
                List<CodeSnippetInfo> list = new List<CodeSnippetInfo>();
                foreach (var o in this.listView.Objects)
                {
                    CodeSnippetUIInfo item = o as CodeSnippetUIInfo;

                    CodeSnippetInfo info = new CodeSnippetInfo();
                    info.Active = item.Active;
                    info.Content = item.Content;
                    info.ShortKey = item.Shortcut;
                    list.Add(info);
                }

                setting.CodeList = list;
            }
            else
            {
                setting.CodeList = null;
            }

            this.CodeSnippetConnect.SaveData(setting);
            this.CodeSnippetConnect.InitCodeSnippetData(setting);

            MessageBox.Show("Saved");
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}