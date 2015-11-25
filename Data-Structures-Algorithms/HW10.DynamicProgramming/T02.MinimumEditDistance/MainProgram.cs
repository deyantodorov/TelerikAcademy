namespace T02.MinimumEditDistance
{
    using System;
    using System.Linq;

    /// <summary>
    /// 2. Write a program to calculate the "Minimum Edit Distance" (MED) between two words. MED(x, y) is the minimal sum of costs of edit operations used to transform x to y. 
    ///    Sample costs are given below:
    ///    
    ///    cost (replace a letter) = 1
    ///    cost (delete a letter) = 0.9
    ///    cost (insert a letter) = 0.8
    ///    
    ///    Example: x = "developer", y = "enveloped"  cost = 2.7 
    ///    delete ‘d’:  "developer"  "eveloper", cost = 0.9
    ///    insert ‘n’:  "eveloper"  "enveloper", cost = 0.8
    ///    replace ‘r’  ‘d’:  "enveloper"  "enveloped", cost = 1
    /// </summary>
    public class MainProgram
    {
        private static void Main()
        {
            var cost = new Cost()
            {
                Replace = 1.0,
                Delete = 0.9,
                Insert = 0.8
            };

            var startWord = "developer";
            var endWord = "enveloped";
            Console.WriteLine("{0} -> {1} cost is {2}", startWord, endWord, LevenshteinDistance.Calculate(startWord, endWord, cost));

            startWord = "developer";
            endWord = "eveloper";
            Console.WriteLine("{0} -> {1} cost is {2}", startWord, endWord, LevenshteinDistance.Calculate(startWord, endWord, cost));

            startWord = "eveloper";
            endWord = "enveloper";
            Console.WriteLine("{0} -> {1} cost is {2}", startWord, endWord, LevenshteinDistance.Calculate(startWord, endWord, cost));
        }
    }
}
