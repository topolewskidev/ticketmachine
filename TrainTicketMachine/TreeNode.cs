using System.Collections.Generic;
using System.Linq;

namespace TrainTicketMachine
{
    public class TreeNode
    {
        public static readonly TreeNode Empty = new TreeNode(default(char), 0);

        private readonly IList<TreeNode> _children = new List<TreeNode>();

        public TreeNode(char value, int depth)
        {
            Value = value;
            Depth = depth;
        }

        public IReadOnlyList<TreeNode> Children => _children.ToList();

        public int Depth { get; }

        public char Value { get; }

        public TreeNode TryGetChildNode(char searchValue)
        {
            var childNode = _children.SingleOrDefault(node => node.Value.Equals(searchValue));

            if (childNode is null)
            {
                childNode = TreeNode.Empty;
            }

            return childNode;
        }

        public void BuildMissingNodes(string item)
        {
            var lastNode = item.Substring(Depth)
                .Aggregate(this, (node, character) =>
                {
                    var newNode = new TreeNode(character, node.Depth + 1);

                    node.AddChild(newNode);

                    return newNode;
                });

            FinishString(lastNode);
        }

        private void FinishString(TreeNode treeNode)
        {
            treeNode.AddChild(new TreeNode(default(char), treeNode.Depth + 1));
        }

        private void AddChild(TreeNode childNode)
        {
            _children.Add(childNode);
        }
    }
}