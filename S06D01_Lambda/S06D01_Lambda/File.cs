using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S06D01_Lambda
{
    class File
    {
        private string name;
        private int size;
        LinkedList<File> subfiles;

        public File(string name, int size)
            : this(name, size, new LinkedList<File>())
        { }

        public File(string name)
            : this(name, 0, new LinkedList<File>())
        { }

        public File(string name, int size, LinkedList<File> subfiles)
        {
            this.name = name;
            this.size = size;
            this.subfiles = subfiles;
        }

        public void AddFile(File f)
        {
            subfiles.AddLast(f);
        }

        public int GetSize()
        {
            int totalSize = size;
            Stack<File> toProcess = new Stack<File>(subfiles);
            while(toProcess.Count > 0)
            {
                File current = toProcess.Pop();
                if (current.subfiles.Count == 0)
                    totalSize += current.size;
                else
                {
                    foreach (File f in current.subfiles)
                        toProcess.Push(f);
                }
            }
            return totalSize;
        }

    }
}
