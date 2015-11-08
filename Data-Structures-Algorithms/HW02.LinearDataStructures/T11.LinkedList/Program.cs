namespace T11.LinkedList
{
    using System;

    /// <summary>
    /// 11. Implement the data structure linked list.
    ///     Define a class ListItem<T> that has two fields: value(of type T) and NextItem(of type ListItem<T>).
    ///     Define additionally a class LinkedList<T> with a single field FirstElement(of type ListItem<T>).
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            var linkedList = new LinkedList<int>();
            Console.WriteLine(linkedList.Count);
            Console.WriteLine(linkedList.Contains(1));
            linkedList.AddFirst(1);
            Console.WriteLine(linkedList.Count);
        }
    }
}
