using System;
using System.IO;

namespace XtoJ.Core.DataAccessors
{
    public class FileDocumentStorage : DocumentStorage
    {
        public override string GetData(string sourceFileName)
        {
            if (!File.Exists(sourceFileName))
                throw new FileNotFoundException();

            using (var stream = File.OpenRead(sourceFileName))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public override void PersistDocument(string serializedDocument, string targetFileName)
        {
            try
            {
                using (var stream = File.Open(targetFileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (var writer = new StreamWriter(stream))
                    {
                        writer.Write(serializedDocument);
                        writer.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw new AccessViolationException();
            }
        }
    }
}
