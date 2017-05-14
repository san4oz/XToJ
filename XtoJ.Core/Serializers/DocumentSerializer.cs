using Newtonsoft.Json;
using XtoJ.Core.Entities;

namespace XtoJ.Core.Serializers
{
    public class DocumentSerializer : IDocumentSerializer
    {
        public string SerializeDocument(Entity document)
        {
            return JsonConvert.SerializeObject(document);
        }
    }
}
