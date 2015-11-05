namespace T03.FileSystem
{
    using System;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// 3. Define classes File { string name, int size } and Folder { string name, File[] files, Folder[] childFolders } and 
    ///    using them build a tree keeping all files and folders on the hard drive starting from C:\WINDOWS. Implement a method 
    ///    that calculates the sum of the file sizes in given subtree of the tree and test it accordingly. Use recursive DFS traversal.
    /// </summary>
    public class StartUp
    {
        private static void Main()
        {
            Console.WriteLine("If this takes too long to calculate pik a small folder");
            var customFolder = new CustomFolder("CustomFolder");
            //TraverseDfs(new DirectoryInfo(@"C:\Temp"), customFolder);
            TraverseDfs(new DirectoryInfo(@"C:\Windows"), customFolder);
            Console.WriteLine("Total size: " + customFolder.GetSize());
        }

        private static void TraverseDfs(DirectoryInfo directory, CustomFolder customFolder)
        {
            try
            {
                var files = directory.GetFiles();

                foreach (var newCustomFile in files.Select(file => new CustomFile(file.Name, file.Length)))
                {
                    customFolder.Files.Add(newCustomFile);
                }

                foreach (var dir in directory.GetDirectories())
                {
                    var newCustomFolder = new CustomFolder(dir.Name);

                    TraverseDfs(dir, customFolder);

                    customFolder.Folders.Add(newCustomFolder);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Don't bother not accessed files
                return;
            }
        }
    }
}
