using ReadXMLFiles.Model;
using System;
using System.IO;
using XDocumentExtension.XMLReader;

namespace ReadXMLFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello XML Reader\n");

            var path = getFilePath();
            XMLReader reader = new XMLReader(path);
            ArticleModel articles = new ArticleModel(reader, null);

            var articlePriceID = articles.GetPriceListID();
            if (articlePriceID > 0)
            {
                var articleList = articles.ReadArticles();
                articles.PrintArticleWithPrice(articleList);
            }

            var articlesFilteredPrice = articles.GetElementsByPriceGreaterThan("299,90");
            articles.PrintArticleWithPrice(articlesFilteredPrice);

            var articlesFilterdVariant = articles.GetVariantElements("1");
            articles.PrintArticleWithPrice(articlesFilterdVariant);
        }

        public static string getFilePath()
        {
            var fileName = "Article.xml";
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string path = Path.Combine(projectDirectory, fileName);
            return path;
        }
    }
}
