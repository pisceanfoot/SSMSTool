using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SSMSTool.CodeSnippet
{
    /// <summary>
    /// 
    /// </summary>
    [XmlRoot("codesnippet")]
    [Serializable]
    public class CodeSnippetSetting
    {
        [XmlElement("enabled")]
        public bool Enabled { get; set; }

        [XmlArray("list")]
        [XmlArrayItem("code")]
        public List<CodeSnippetInfo> CodeList { get; set; }
    }
}
