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
        [XmlElement("shortkey")]
        public string ShortKey { get; set; }

        [XmlElement("content")]
        public string Content { get; set; }

        [XmlElement("active")]
        public bool Active { get; set; }
    }
}
