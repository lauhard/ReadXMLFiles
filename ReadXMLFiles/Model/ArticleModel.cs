using ReadXMLFiles.Entity.Article;
using ReadXMLFiles.Repository.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using XDocumentExtension;
using XDocumentExtension.XMLReader;
using XDocumentExtension.XMLReader.Helper;

namespace ReadXMLFiles.Model
{
    public class ArticleModel
    {
        private IXMLReader reader;

        public ArticleModel(IXMLReader _reader, IRepository repository = null)
        {
            this.reader = _reader;
        }

        public ARTICLES ReadDocument()
        {
            var element = reader.ReadDocument().GetElements().FirstOrDefault();
            ARTICLES articles = reader.XElements2Object<ARTICLES>(element);
            return articles;
        }

        public List<ARTICLE> ReadArticles()
        {
            var elements = reader.ReadDocument().GetElements().Elements("ARTICLE").ToList();
            List<ARTICLE> articles = reader.XElements2Object<ARTICLE>(elements);
            return articles;
        }

        public double GetPriceListID() => XmlConvert.ToDouble(reader.ReadDocument().GetElements().Elements("PRICELISTID").FirstOrDefault().Value);

        public List<ARTICLE> GetElementsByPriceGreaterThan(string price)
        {
            var qd = new QueryDefinition(
                xPath: "ARTICLES/ARTICLE/ARTVARIANT/LISTPRICE",
                returnElement: "ARTICLE"
            );

            var elements = reader.ReadDocument(qd)
                .Where("PRICE", Operator.GreaterThan, price, ConvertTo.Double)
                .GetElements();
            List<ARTICLE> articles = reader.XElements2Object<ARTICLE>(elements);
            return articles;
        }

        public List<ARTICLE> GetVariantElements(string id)
        {
            var qd = new QueryDefinition(
                xPath: "ARTICLES/ARTICLE/ARTVARIANT",
                returnElement: "ARTICLE"
            );

            var elements = reader.ReadDocument(qd)
                .Where("ARTVARID", Operator.GreaterThan, id, ConvertTo.Int)
                .GetElements()
                .Distinct()
                .ToList();

            List<ARTICLE> articles = reader.XElements2Object<ARTICLE>(elements);
            return articles;
        }

        public void PrintArticleWithPrice(List<ARTICLE> artilces)
        {
            foreach (var item in artilces)
            {
                Console.WriteLine($"Artikel: {item.Matchcode}:");
                if (item.ARTVARIANT.Count > 0)
                {
                    foreach (var variant in item.ARTVARIANT)
                    {
                        Console.WriteLine($"  - Variante({variant.ARTVARID}) has Price:{ variant.LISTPRICE.PRICE }");
                    }
                }
                Console.WriteLine("-----------------------------------------\n");
            }
        }
    }
}
