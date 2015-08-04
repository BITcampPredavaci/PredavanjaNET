using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace S12D02_FtpClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FTPClient ftpClient;

        public MainWindow()
        {
            InitializeComponent();
            ftpClient = new FTPClient("camp", "123456", "10.0.82.97");

            //show the root folder content
            AddSubItems("/");
        }

       
        /// <summary>
        /// Mouse double click on a file item will start it's download
        /// </summary>
        /// <param name="sender">The clicked file</param>
        /// <param name="e"></param>
        private void File_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem selected = sender as TreeViewItem;
            //gets the path relative to the root folder
            string path = selected.Header.ToString();

            //open a save dilaog, so the file when transfered can be saved
            SaveFileDialog saveDialog = new SaveFileDialog();
            string extension = System.IO.Path.GetExtension(path).Substring(1);
            
            //set default extension to file extension
            saveDialog.DefaultExt = extension;
            //show only files with the same extension as the file being downloaded
            saveDialog.Filter = "Files |*." + extension;

            //unsafe code = need to check if a file has been selected
            saveDialog.ShowDialog();
            
            //assuming a file has been selected the stream is opened
            Stream localFile = saveDialog.OpenFile();
            //download and save the file
            ftpClient.DownloadFile(path, localFile, UpdateProgressBar);
            localFile.Close();
            UpdateProgressBar(100);

        }

        /// <summary>
        /// After clicking on a folder the folders content
        /// should become visible. This method fills the TreeViewItem with
        /// sub items.
        /// </summary>
        /// <param name="sender">The clicked folder</param>
        /// <param name="e"></param>
        private void Directory_Expanded(object sender, RoutedEventArgs e)
        {
            //TreeViewItem seleted = (TreeViewItem)sender;
            TreeViewItem selected = sender as TreeViewItem;

            if (selected.Items.Count == 1)
            {
                selected.Items.Clear();

                string path = selected.Header.ToString();
                AddSubItems(path, selected);
            }
        }

        //updates the progress bar value
        public void UpdateProgressBar(double x)
        {
            progressBar.Value = x;
        }

        private bool IsDirectory(string file)
        {
            if (file == null)
                throw new ArgumentException("Name is null");
            return !System.IO.Path.HasExtension(file);
        }

        /// <summary>
        /// Pick and upload files from local machine to server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            TreeViewItem selected = fileExplorer.SelectedItem as TreeViewItem;

            string path = FindFolderPath(selected);

            //opens a picker for the user
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Multiselect = true;

            //unsafe code = user could have closed the dialog without picking a file
            openDialog.ShowDialog();

            //get all the file names
            string[] fileNames = openDialog.FileNames;
            //get all the file streams
            Stream[] fileStreams = openDialog.OpenFiles();

            for (int i = 0; i < fileNames.Length; i++)
            {
                Stream localFile = fileStreams[i];
                string fileName = fileNames[i];

                fileName = System.IO.Path.GetFileName(fileName);
                string currentPath = path + "/" + fileName;
                ftpClient.UploadFile(currentPath, localFile, UpdateProgressBar);

                localFile.Close();
            }


            UpdateProgressBar(100);

        }

        /// <summary>
        /// Create a folder in the 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateFolder_Click(object sender, RoutedEventArgs e)
        {
            TreeViewItem selected = fileExplorer.SelectedItem as TreeViewItem;

            string path = FindFolderPath(selected);

            path += "/" + folderName.Text;
            ftpClient.CreateFolder(path);
        }

        /// <summary>
        /// Given a TreeViewItem finds the first item which refferences an element
        /// </summary>
        /// <param name="selected">the selected item</param>
        /// <returns></returns>
        private string FindFolderPath(TreeViewItem selected)
        {
            //if we can't find a folder then we take root as the selected folder
            string path = "";
            if (selected != null)
            {
           
                path = selected.Header.ToString();

                //check if the current path represents a folder
                if (IsDirectory(path) == false)
                {
                    TreeViewItem parent = selected.Parent as TreeViewItem;
                    if (parent == null)
                        path = "/";
                    else
                        path = parent.Header.ToString();
                }
            }
            return path;
        }

        /// <summary>
        /// Gets the sub items for a path and adds them to the parent item
        /// </summary>
        /// <param name="path">The path on the FTP server</param>
        /// <param name="selected">The item at which we add - root if this is null</param>
        private void AddSubItems(string path, TreeViewItem selected = null)
        {
            List<string> files = ftpClient.ListDirectory(path);
            foreach (string s in files)
            {
                TreeViewItem item = new TreeViewItem();
                item.Header = s;
                //if the item is a directory add a dummy item and a expand listener
                if (IsDirectory(s))
                {
                    TreeViewItem dummy = new TreeViewItem();
                    dummy.Header = "Nested";
                    item.Items.Add(dummy);
                    item.Expanded += Directory_Expanded;
                }
                else //add a double click listener
                {
                    item.MouseDoubleClick += File_MouseDoubleClick;
                }
                if (selected != null)
                    selected.Items.Add(item);
                else
                    fileExplorer.Items.Add(item);
            }
        }
    }
}
