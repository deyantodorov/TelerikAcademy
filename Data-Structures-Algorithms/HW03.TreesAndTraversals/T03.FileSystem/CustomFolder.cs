namespace T03.FileSystem
{
    using System.Collections.Generic;
    using System.Linq;

    public class CustomFolder
    {
        public CustomFolder(string name)
        {
            this.Name = name;
            this.Files = new List<CustomFile>();
            this.Folders = new List<CustomFolder>();
        }

        public string Name { get; private set; }

        public ICollection<CustomFile> Files { get; private set; }

        public ICollection<CustomFolder> Folders { get; private set; }

        public long GetSize()
        {
            long sizeSum = 0;

            sizeSum += this.Files.Sum(file => file.Size);
            sizeSum += this.Folders.Sum(folder => folder.GetSize());

            return sizeSum;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
