using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace S11D03_SecurityGrep
{
    static class Search
    {
        private static Queue<string> filePaths;
        private static SearchParam sp;
        
        public static void StartSearch(SearchParam searchParam)
        {
            string[] files = Directory.GetFiles(".", searchParam.Pattern, SearchOption.AllDirectories);
            filePaths = new Queue<string>(files);
            sp = searchParam;

            Thread[] searchThreads = new Thread[5];
            for (int i = 0; i < searchThreads.Length; i++) {
                searchThreads[i] = new Thread(SearchFile);
                searchThreads[i].Start();
            }

            foreach (Thread t in searchThreads) {
                t.Join();
            }
        }


        private static void SearchFile()
        {
            while (filePaths.Count > 0) {
                string currentFile;
                lock (filePaths) {
                    currentFile = filePaths.Dequeue();
                }
                TextReader read = File.OpenText(currentFile);
                string line = sp.Keyword;
                while ((line = read.ReadLine()) != null) {
                    if (line.Contains(sp.Keyword))
                        Console.WriteLine(currentFile + ": " + line);
                }


                read.Close();
            }
        }

    
    }
}
