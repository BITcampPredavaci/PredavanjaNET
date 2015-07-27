using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace S11D01_FileCleaner
{
    class Cleaner
    {

        public Dictionary<string, Folder> Folders { get; set; }

        public string BasePath { get; set; }

        public Cleaner(string basePath)
        {
            BasePath = basePath;
            Folders = new Dictionary<string, Folder>();
            Folders.Add("Documents", new Folder() {
                FolderName = Path.Combine(BasePath, "Documents"),
                SupportedExtension = Extensions.DOCUMENT_EXTENSIONS
            });

            Folders.Add("Images", new Folder() {
                FolderName = Path.Combine(BasePath, "Images"),
                SupportedExtension = Extensions.IMAGE_EXTENSIONS
            });

            Folders.Add("Sounds", new Folder() {
                FolderName = Path.Combine(BasePath, "Sounds"),
                SupportedExtension = Extensions.SOUND_EXTENSIONS
            });

            Folders.Add("PSD", new Folder() {
                FolderName = "Photoshop",
                SupportedExtension = Extensions.PHOTOSHOP
            });
            
        }


        public void AddFile(string file)
        {
            FileInfo fileInfo = new FileInfo(file);
            foreach (Folder f in Folders.Values) {
                if (f.SupportedExtension.Contains(fileInfo.Extension)) {
                    f.Files.Add(file);
                    break;
                }
            }
        }

        public void Cleanup()
        {
            foreach (Folder f in Folders.Values) {
                f.MoveFiles();
            }

            MessageBox.Show("Clean complete");
        }


    }
}
