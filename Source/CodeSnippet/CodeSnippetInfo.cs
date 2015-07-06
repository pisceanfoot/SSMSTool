using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SSMSTool.CodeSnippet
{
    [Serializable]
    public class CodeSnippetInfo
    {
        public string ShortKey { get; set; }

        public string Code { get; set; }
    }
}
