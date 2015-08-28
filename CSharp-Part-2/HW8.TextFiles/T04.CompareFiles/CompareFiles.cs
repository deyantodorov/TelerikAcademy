namespace T04.CompareFiles
{
    using System;
    using System.IO;

    /// <summary>
    /// 4. Write a program that compares two text files line by line and prints the number of lines that are the same and the number of lines that are different. 
    ///    Assume the files have equal number of lines.
    /// </summary>
    public class CompareFiles
    {
        public static void CompareTwoFiles(string firstFile, string secondFile)
        {
            StreamReader readerOne = new StreamReader(firstFile);
            StreamReader readerTwo = new StreamReader(secondFile);

            using (readerOne)
            {
                using (readerTwo)
                {
                    int sameLines = 0;
                    int differentLines = 0;
                    int linesTotal = 0;

                    string lineFileOne = readerOne.ReadLine();
                    string lineFileTwo = readerTwo.ReadLine();

                    while ((lineFileOne != null) && (lineFileTwo != null))
                    {
                        int compare = lineFileOne.CompareTo(lineFileTwo);

                        lineFileOne = readerOne.ReadLine();
                        lineFileTwo = readerTwo.ReadLine();

                        // 0 - same, -1 - different
                        if (compare == 0)
                        {
                            sameLines++;
                        }
                        else if (compare == -1)
                        {
                            differentLines++;
                        }

                        linesTotal++;
                    }

                    Console.WriteLine("Same: {0}", sameLines);
                    Console.WriteLine("Different: {0}", differentLines);
                    Console.WriteLine("Total: {0}", linesTotal);
                }
            }
        }

        private static void Main()
        {
            string first = @"..\..\..\Files\04.fileOne.txt";
            string second = @"..\..\..\Files\04.fileTwo.txt";

            CompareTwoFiles(first, second);
        }
    }
}
