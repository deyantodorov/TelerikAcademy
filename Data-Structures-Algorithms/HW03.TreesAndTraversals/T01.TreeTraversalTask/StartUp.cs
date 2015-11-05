namespace T01.TreeTraversalTask
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private static void Main()
        {
            /*
                Test data:
                7
                2 4
                3 2
                5 0 
                3 5
                5 6
                5 1
            */

            var nodes = ReadData();

            // 1. the root node
            Console.WriteLine("Root values is: " + GetRootValue(nodes).Value);

            // 2. Find all leafs
            var leafs = FindAllLeafs(nodes);

            foreach (var node in leafs)
            {
                Console.WriteLine("Leaf " + node.Value);
            }

            // 3. Find all middle nodes
            var middle = FindAllMiddleNodes(nodes);

            foreach (var node in middle)
            {
                Console.WriteLine("Middle nodes: " + node.Value);
            }

            // 4. Find longest path
            var longestPath = FindLongestPath(GetRootValue(nodes)) + 1;
            Console.WriteLine("Longest path: " + longestPath);

            // 5. all paths in the tree with given sum `S` of their nodes
            var paths = new PathsInTree();
            var pathsWithSum = new List<Stack<int>>();
            paths.FindAllPathsWithSum(GetRootValue(nodes), 14, pathsWithSum);

            foreach (var path in pathsWithSum)
            {
                Console.WriteLine("Path with sum: " + string.Join(", ", path.ToArray()));
            }

            // 6. all subtrees with given sum `S` of their nodes
            paths = new PathsInTree();
            pathsWithSum = new List<Stack<int>>();
            paths.FindAllSubtreeWithSum(nodes, 6, pathsWithSum);

            foreach (var path in pathsWithSum)
            {
                Console.WriteLine("Subtree with sum: " + string.Join(", ", path.ToArray()));
            }
        }

        private static Node<int> GetRootValue(Node<int>[] nodes)
        {
            var hasParent = new bool[nodes.Length];

            foreach (var node in nodes)
            {
                foreach (var child in node.Children)
                {
                    hasParent[child.Value] = true;
                }
            }

            for (int i = 0; i < hasParent.Length; i++)
            {
                if (!hasParent[i])
                {
                    return nodes[i];
                }
            }

            throw new ArgumentException("No root found");
        }

        private static Node<int>[] ReadData()
        {
            var n = int.Parse(Console.ReadLine() ?? "0");

            var nodes = new Node<int>[n];

            for (int i = 0; i < n; i++)
            {
                nodes[i] = new Node<int>(i);
            }

            for (int i = 0; i < n - 1; i++)
            {
                var readLine = Console.ReadLine();

                if (readLine != null)
                {
                    var edge = readLine.Split(' ');

                    int parentId = int.Parse(edge[0]);
                    int childId = int.Parse(edge[1]);

                    nodes[parentId].Children.Add(nodes[childId]);
                    nodes[childId].HasParent = true;
                }
            }

            return nodes;
        }

        private static List<Node<int>> FindAllLeafs(Node<int>[] nodes)
        {
            var leafs = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.Children.Count == 0)
                {
                    leafs.Add(node);
                }
            }

            return leafs;
        }

        private static List<Node<int>> FindAllMiddleNodes(Node<int>[] nodes)
        {
            var middle = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.HasParent && node.Children.Count > 0)
                {
                    middle.Add(node);
                }
            }

            return middle;
        }

        private static int FindLongestPath(Node<int> root)
        {
            if (root.Children.Count == 0)
            {
                return 0;
            }

            int maxPath = 0;

            foreach (var node in root.Children)
            {
                maxPath = Math.Max(maxPath, FindLongestPath(node));
            }

            return maxPath + 1;
        }
    }
}
