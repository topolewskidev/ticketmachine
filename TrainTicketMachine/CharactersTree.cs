namespace TrainTicketMachine
{
    public class CharactersTree : ISearchableTree
    {
        public TreeNode Root { get; } = TreeNode.Empty;

        public void Insert(string item)
        {
            var currentNode = GetParent(item);

            for (int i = currentNode.Depth; i < item.Length; i++)
            {
                var node = new TreeNode(item[i], i + 1);

                currentNode.AddChild(node);
                currentNode = node;
            }

            currentNode.AddChild(new TreeNode(default(char), currentNode.Depth + 1));
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
    }
}