using System.Collections.Generic;

namespace TrainTicketMachine
{
    public interface ISearchableTreeBuilder
    {
        ISearchableTree Build(IEnumerable<string> stringItems);
    }

    public class SearchableTreeBuilder : ISearchableTreeBuilder
    {
        public ISearchableTree Build(IEnumerable<string> stringItems)
        {
            return null;
        }
    }
}