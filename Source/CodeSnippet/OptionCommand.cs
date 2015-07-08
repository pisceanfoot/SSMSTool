using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SSMSTool.CodeSnippet
{
    public class OptionCommand : Common.Command.CommandBase
    {
        private CodeSnippetEditorFrm editorFrm;

        public OptionCommand(string caption, string tooltipText)
            : base(caption, tooltipText)
        {
        }

        public CodeSnippetConnect CodeSnippetConnect
        {
            get;
            set;
        }

        public override void Perform()
        {
            if (editorFrm == null || editorFrm.IsDisposed)
            {
                editorFrm = new CodeSnippetEditorFrm();
            }

            editorFrm.CodeSnippetConnect = this.CodeSnippetConnect;
            editorFrm.ShowDialog();
        }
    }
}
