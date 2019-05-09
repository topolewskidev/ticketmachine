using System.Collections.Generic;
using System.Linq;

namespace TrainTicketMachine
{
    public class Suggestions
    {
        public IEnumerable<string> MatchedItems { get; set; } = Enumerable.Empty<string>();
        public IEnumerable<char> NextCharacters { get; set; } = Enumerable.Empty<char>();
    }
}