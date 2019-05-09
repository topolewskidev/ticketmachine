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

        public int Depth { get; }

        public char Value { get; }

        public void AddChild(TreeNode childNode)
        {
            _children.Add(childNode);
        }

        public TreeNode TryGetChildNode(char searchValue)
        {
            var childNode = _children.SingleOrDefault(node => node.Value.Equals(searchValue));

            if (childNode is null)
            {
                childNode = TreeNode.Empty;
            }

            return childNode;
        }
    }
}