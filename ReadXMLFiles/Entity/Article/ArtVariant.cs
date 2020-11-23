using System.Xml.Serialization;

namespace ReadXMLFiles.Entity.Article
{
    public class ARTVARIANT
    {
        [XmlElement(DataType = "int", ElementName = "ARTVARID")]
        public int ARTVARID { get; set; }
        [XmlElement(DataType = "double", ElementName = "WEIGHT")]
        public double WEIGHT { get; set; }
        [XmlElement("LISTPRICE", typeof(LISTPRICE))]
        public LISTPRICE LISTPRICE { get; set; }
    }
}
