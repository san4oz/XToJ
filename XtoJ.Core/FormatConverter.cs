using System;
using System.IO;
using XtoJ.Core.Parsers;
using XtoJ.Core.Serializers;
using XtoJ.Core.DataAccessors.Factories;

namespace XtoJ.Core
{
    public class FormatConverter
    {
        private readonly IDocumentSerializer documentSerializer;
        private readonly IInputParser inputParser;

        public FormatConverter(IDocumentSerializer serializer, IInputParser parser)
        {
            documentSerializer = serializer;
            inputParser = parser;
        }

        public bool ConvertFormat(string sourceFileName, string targetFileName)
        {
            try
            {
                var inputRetreiver = InputRetreiverFactory.ForFileName(sourceFileName);
                var input = inputRetreiver.GetData(sourceFileName);

                var document = inputParser.Parse(input);
                var serializedDocument = documentSerializer.SerializeDocument(document);

                var documentPersister = DocumentPersisterFactory.ForFileName(sourceFileName);
                documentPersister.PersistDocument(serializedDocument, targetFileName);

                return true;
            }
            catch (FileNotFoundException)
            {
                return false;
            }
            catch(FormatException)
            {
                return false;
            }
            catch(AccessViolationException)
            {
                return false;
            }
        }
    }
}
