using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace S10D03_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToFile =
                @"c:\Users\bttalic\Desktop\TestFolder\File.txt";

            string pathToFolder = @"c:\Users\bttalic\Desktop\TestFolder";

            Console.WriteLine(File.Exists(pathToFile));
            Console.WriteLine(Directory.Exists(pathToFolder));

            FileInfo f = new FileInfo(pathToFile);

            //ZipFile.CreateFromDirectory(
            //    pathToFolder,
            //    @"c:\Users\bttalic\Desktop\compress.zip"
            //    );

            ZipArchive zar = ZipFile.Open(@"c:\Users\bttalic\Desktop\compress.zip", ZipArchiveMode.Read);
            




        }
    }
}
