namespace T02.TraverseWindowsDirectory
{
    using System;
    using System.IO;

    /// <summary>
    /// 2. Write a program to traverse the directory C:\WINDOWS and all its subdirectories recursively and to display all files matching the 
    ///    mask *.exe. Use the class System.IO.Directory.
    /// </summary>
    public class Searching
    {
        private const string SearchPath = @"C:\Windows";
        private const string Pattern = @"*.exe";

        private static void Main()
        {
            FindFiles(SearchPath, Pattern);
        }

        private static void FindFiles(string path, string match)
        {

            try
            {
                foreach (var file in Directory.GetFiles(path, match))
                {
                    // Recursion bottom
                    Console.WriteLine(file);
                }

                foreach (var directory in Directory.GetDirectories(path))
                {
                    FindFiles(directory, match);
                }
            }
            catch (UnauthorizedAccessException exception)
            {
                Console.WriteLine("Access denied! With message: " + exception.Message);
            }

        }
    }
}
