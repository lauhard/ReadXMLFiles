using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ReadXMLFiles.Entity.Article
{
    public class ARTICLE
    {
        [XmlAttribute(AttributeName = "TEST")]
        public string TEST { get; set; }
        [XmlElement(DataType = "string", ElementName = "ARTID")]
        public string Artikelnummer { get; set; }
        [XmlElement(ElementName = "MATCH")]
        public string Matchcode { get; set; }
        [XmlElement(ElementName = "DESC1")]
        public string Bezeichnung1 { get; set; }
        [XmlElement(ElementName = "DESC2")]
        public string Bezeichnung2 { get; set; }
        [XmlElement("ARTVARIANT", typeof(ARTVARIANT))]
        public List<ARTVARIANT> ARTVARIANT { get; set; }
    }
}
