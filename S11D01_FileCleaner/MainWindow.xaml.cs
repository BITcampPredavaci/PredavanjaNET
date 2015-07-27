using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace S11D01_FileCleaner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Cleaner cleaner = null;
        public MainWindow()
        {
            InitializeComponent();
        }

         private void SelectFiles_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select Files";
            dialog.Multiselect = true;

            bool? result = dialog.ShowDialog();
            if (result != null && result == true) {

                foreach (string file in dialog.FileNames) {
                    cleaner.AddFile(file);
                    FilesSelected.AppendText(file+"\r\n");
                }
                StartClean.IsEnabled = true;
            } else {
                MessageBox.Show("Select at least one file");
            }
        }

        private void SelectDestination_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult res = folderBrowser.ShowDialog();

            if(res == System.Windows.Forms.DialogResult.OK){
                string destination = folderBrowser.SelectedPath;
                SelectFiles.IsEnabled = true;
                cleaner = new Cleaner(destination);
                (sender as Button).IsEnabled = false;
            } else {
                MessageBox.Show("You must select a destination folder");
            }
        }

        private void StartClean_Click(object sender, RoutedEventArgs e)
        {
            cleaner.Cleanup();
        }
    
    }
}
