using System.Xml.Serialization;

namespace ReadXMLFiles.Entity.Article
{
    public class LISTPRICE
    {
        [XmlElement(DataType = "double", ElementName = "PRICE")]
        public double PRICE { get; set; }
    }
}
