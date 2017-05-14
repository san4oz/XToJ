using System;
using System.Xml.Linq;
using XtoJ.Core.Entities;

namespace XtoJ.Core.Parsers
{
    public class DocumentInputParser : IInputParser
    {
        public virtual Entity Parse(string input)
        {
            try
            {
                var xDoc = XDocument.Parse(input);
                return new Document()
                {
                    Title = xDoc.Root.Element("Title").Value,
                    Text = xDoc.Root.Element("Text").Value
                };
            }
            catch(Exception)
            {
                throw new FormatException();
            }
        }
    }
}
