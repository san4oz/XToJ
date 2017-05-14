using System;
using System.IO;
using XtoJ.Core.Parsers;
using XtoJ.Core.Serializers;
using XtoJ.Core.DataAccessors;
using XtoJ.Core.DataAccessors.Factories;

namespace XtoJ.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Input Documents\\Catalog.xml");
            var targetFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Output Documents\\Catalog.json");

            ConfigureStorage();

            var inputParser = new CatalogInputParser();
            var serializer = new DocumentSerializer();

            var formatConverter = new FormatConverter(serializer, inputParser);
            if(!formatConverter.ConvertFormat(sourceFileName, targetFileName))
            {
                Console.WriteLine("Conversion failed...");
                Console.ReadKey();
            }
        }

        public static void ConfigureStorage()
        {
            var fileStorage = new FileDocumentStorage();

            InputRetreiverFactory.RegisterInputRetreiver(x => true, fileStorage);
            DocumentPersisterFactory.RegisterDocumentPersister(x => true, fileStorage);
        }
    }
}
