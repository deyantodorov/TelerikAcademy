namespace T01.TreeTraversalTask
{
    using System.Collections.Generic;
    using System.Linq;

    public class PathsInTree
    {
        private Stack<int> currentValues;

        public PathsInTree()
        {
            this.currentValues = new Stack<int>();
        }

        public void FindAllPathsWithSum(Node<int> node, int sum, ICollection<Stack<int>> result)
        {
            this.currentValues.Push(node.Value);

            if (node.Children.Count == 0)
            {
                var currentSum = this.currentValues.Sum();

                if (currentSum != sum)
                {
                    return;
                }

                var stackToAdd = new Stack<int>();
                foreach (var currentValue in this.currentValues)
                {
                    stackToAdd.Push(currentValue);
                }

                result.Add(new Stack<int>(stackToAdd));

                return;
            }

            foreach (var child in node.Children)
            {
                this.FindAllPathsWithSum(child, sum, result);
                this.currentValues.Pop();
            }
        }

        public void FindAllSubtreeWithSum(ICollection<Node<int>> nodes, int sum, ICollection<Stack<int>> result)
        {
            foreach (var node in nodes)
            {
                this.currentValues = new Stack<int>();

                this.FindAllPathsWithSum(node, sum, result);
            }
        }
    }
}
