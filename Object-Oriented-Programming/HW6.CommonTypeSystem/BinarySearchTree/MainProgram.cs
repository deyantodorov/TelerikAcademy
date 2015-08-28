namespace BinarySearchTree
{
    using System;
    using System.Linq;

    public class MainProgram
    {
        private static void Main()
        {
            BinarySearchTree<int, string> tree = new BinarySearchTree<int, string>();

            tree.Add(1, "Pesho");
            tree.Add(2, "Gosho");
            tree.Add(3, "Minka");

            foreach (var item in tree)
            {
                Console.WriteLine(item);
            }

            tree.Remove(1);
            Console.WriteLine();
            foreach (var item in tree)
            {
                Console.WriteLine(item);
            }

            BinarySearchTree<int, string> tree2 = new BinarySearchTree<int, string>();

            tree2.Add(1, "Pesho");
            tree2.Add(2, "Gosho");
            tree2.Add(3, "Minka");
            tree.Add(1, "Pesho");

            Console.WriteLine(tree.Equals(tree2));
        }
    }
}