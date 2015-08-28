namespace T03.ReadFile
{
    using System;
    using System.IO;
    using System.Security;

    /// <summary>
    /// 3. Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini), 
    ///    reads its contents and prints it on the console. Find in MSDN how to use System.IO.File.ReadAllText(…). 
    ///    Be sure to catch all possible exceptions and print user-friendly error messages.
    /// </summary>
    public class ReadFile
    {
        public static void ReadAndPrintFile(string file)
        {
            try
            {
                string readText = File.ReadAllText(file);
                Console.WriteLine(readText);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid path");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("The specified path, file name, or both exceed the system-defined maximum length");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The specified path is invalid");
            }
            catch (IOException)
            {
                Console.WriteLine("Error occurred while opening the file");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You don't have required permissions");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Path is in an invalid format");
            }
            catch (SecurityException)
            {
                Console.WriteLine("The caller does not have the required permission");
            }
        }

        private static void Main()
        {
            Console.Write("Enter file path: ");
            ReadAndPrintFile(Console.ReadLine());
        }
    }
}
