namespace XtoJ.Core.DataAccessors
{
    public abstract class DocumentStorage : IInputRetreiver, IDocumentPersister
    {
        public abstract string GetData(string sourceFileName);

        public abstract void PersistDocument(string serializedDocument, string targetFileName);       
    }

    public interface IInputRetreiver
    {
        string GetData(string sourceFileName);
    }

    public interface IDocumentPersister
    {
        void PersistDocument(string serializerDocument, string targetFileName);
    }
}
