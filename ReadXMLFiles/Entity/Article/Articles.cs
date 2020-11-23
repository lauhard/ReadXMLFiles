using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ReadXMLFiles.Entity.Article
{
    public class ARTICLES
    {
        [XmlElement(DataType = "string", ElementName = "PRICELISTID")]
        public string PRICELISTID { get; set; }
        [XmlElement("ARTICLE", typeof(ARTICLE))]
        public List<ARTICLE> ARTICLE { get; set; }
    }
}
