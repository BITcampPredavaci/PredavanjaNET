using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace S11D01_FileCleaner
{

    public static class Extensions
    {
        public static string[] IMAGE_EXTENSIONS = new string[] { ".png", ".gif", ".jpg" };
        public static string[] DOCUMENT_EXTENSIONS = new string[] { ".pdf", ".txt", ".docx" };
        public static string[] SOUND_EXTENSIONS = new string[] { ".png", ".gif", ".jpg" };
        public static string[] PHOTOSHOP = new string[] { ".psd" };

    }

    class Folder
    {

        public string FolderName { get; set; }
        public string[] SupportedExtension { get; set; }

        public List<string> Files { get; private set; }

        public Folder()
        {
            Files = new List<string>();
        }


        public void MoveFiles()
        {
            if (!Directory.Exists(FolderName))
                Directory.CreateDirectory(FolderName);

            foreach (string file in Files) {
                FileInfo fileInfo = new FileInfo(file);
                fileInfo.MoveTo(Path.Combine(FolderName, fileInfo.Name));
            }
        }

    }
}
