using XtoJ.Core.Entities;

namespace XtoJ.Core.Parsers
{
    public interface IInputParser
    {
        Entity Parse(string input);
    }
}
