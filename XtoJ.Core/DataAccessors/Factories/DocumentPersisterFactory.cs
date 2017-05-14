using System;
using System.Collections.Generic;
using System.Linq;
using XtoJ.Core.DataAccessors;

namespace XtoJ.Core.DataAccessors.Factories
{
    public static class DocumentPersisterFactory
    {
        private static Dictionary<Func<string, bool>, IDocumentPersister> documentPersisters
            = new Dictionary<Func<string, bool>, IDocumentPersister>();

        public static void RegisterDocumentPersister(Func<string, bool> evaluator, IDocumentPersister persister)
        {
            documentPersisters.Add(evaluator, persister);
        }

        public static IDocumentPersister ForFileName(string filename)
        {
            return documentPersisters.First(x => x.Key(filename)).Value;
        }
    }
}
