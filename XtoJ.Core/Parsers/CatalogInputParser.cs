using System;
using System.Xml.Linq;
using XtoJ.Core.Entities;

namespace XtoJ.Core.Parsers
{
    public class CatalogInputParser : IInputParser
    {
        public Entity Parse(string input)
        {
            try
            {
                var catalog = new Catalog();

                var xDoc = XDocument.Parse(input);
                foreach(var element in xDoc.Root.Elements())
                {
                    var book = new Book()
                    {
                        Author = element.Element("author").Value,
                        Description = element.Element("description").Value,
                        Genre = element.Element("genre").Value,
                        Id = element.Attribute("id").Value,
                        Price = decimal.Parse(element.Element("price").Value),
                        PublishDate = DateTime.Parse(element.Element("publish_date").Value),
                        Title = element.Element("title").Value
                    };
                    catalog.Books.Add(book);
                }

                return catalog;
            }
            catch
            {
                throw new FormatException();
            }
        }
    }
}
