using System;
using System.Linq;

namespace TrainTicketMachine
{
    public class CharactersTree : ISearchableTree
    {
        public TreeNode Root { get; } = new TreeNode(default(char), 0);

        public void Insert(string item)
        {
            var lastExistingNode = GetParent(item);
            lastExistingNode.BuildMissingNodes(item);
        }

        public TreeNode GetParent(string text)
        {
            var currentNode = Root;
            var result = currentNode;

            foreach (var character in text)
            {
                currentNode = currentNode.TryGetChildNode(character);

                if (currentNode == TreeNode.Empty)
                {
                    break;
                }

                result = currentNode;
            }

            return result;
        }

        public TreeNode SearchForNode(string searchedText)
        {
            var currentNode = Root;

            foreach (var character in searchedText)
            {
                currentNode = currentNode.TryGetChildNode(character);

                if (currentNode == TreeNode.Empty)
                {
                    break;
                }
            }

            return currentNode;
        }
    }
}