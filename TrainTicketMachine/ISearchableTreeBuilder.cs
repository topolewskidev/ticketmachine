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
            var tree = new CharactersTree();

            foreach (var item in stringItems)
            {
                tree.Insert(item);
            }

            return tree;
        }
    }
}