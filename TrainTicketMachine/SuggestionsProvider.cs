using System.Collections.Generic;
using System.Linq;

namespace TrainTicketMachine
{
    public class SuggestionsProvider
    {
        public Suggestions Get(string searchedText, ISearchableTree searchableTree)
        {
            var result = new Suggestions();
            var treeNode = searchableTree.SearchForNode(searchedText);

            result.NextCharacters = BuildNextCharacters(treeNode);

            result.MatchedItems = treeNode.Children
                .SelectMany(child => BuildMatchedItemsList(child, searchedText))
                .ToList();

            return result;
        }

        private IEnumerable<string> BuildMatchedItemsList(TreeNode treeNode, string currentBranchValue)
        {
            if (treeNode.Value.Equals(default(char)))
            {
                return new[] { currentBranchValue };
            }

            currentBranchValue += treeNode.Value;

            return treeNode.Children.
                SelectMany(child => BuildMatchedItemsList(child, currentBranchValue));
        }

        private IEnumerable<char> BuildNextCharacters(TreeNode treeNode)
        {
            return treeNode.Children
                .Where(node => !node.Value.Equals(default(char)))
                .Select(node => node.Value).ToList();
        }
    }
}
