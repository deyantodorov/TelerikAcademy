namespace Point3d
{
    using System;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Problem 4. Path
    ///            Create a class Path to hold a sequence of points in the 3D space.
    ///            Create a static class PathStorage with static methods to save and load paths from a text file.
    ///            Use a file format of your choice.
    /// </summary>
    public static class PathStorage
    {
        public static void Save(Path path)
        {
            if (path != null)
            {
                StringBuilder line = new StringBuilder();
                StreamWriter writer = new StreamWriter("file.txt");

                using (writer)
                {
                    foreach (var item in path.Points)
                    {
                        line.Append(item.X);
                        line.Append(", ");
                        line.Append(item.Y);
                        line.Append(", ");
                        line.Append(item.Z);

                        writer.WriteLine(line);
                        line.Clear();
                    }
                }
            }
            else
            {
                throw new NullReferenceException("No points");
            }
        }

        public static Path Load()
        {
            Path loaded = new Path();
            StreamReader reader = new StreamReader("file.txt");

            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] currentLine;
                    Point3d currentPoint = new Point3d();
                    currentLine = ExtractPaths(line);

                    if (currentLine.Length == 3)
                    {
                        currentPoint.X = int.Parse(currentLine[0]);
                        currentPoint.Y = int.Parse(currentLine[1]);
                        currentPoint.Z = int.Parse(currentLine[2]);
                    }
                    else
                    {
                        throw new IndexOutOfRangeException("You could use exactly three points");
                    }

                    loaded.Add(currentPoint);
                    line = reader.ReadLine();
                }
            }

            return loaded;
        }

        private static string[] ExtractPaths(string line)
        {
            string[] paths = line.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            return paths;
        }
    }
}
