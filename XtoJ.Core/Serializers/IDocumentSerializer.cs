using XtoJ.Core.Entities;

namespace XtoJ.Core.Serializers
{
    public interface IDocumentSerializer
    {
        string SerializeDocument(Entity doc);
    }
}
