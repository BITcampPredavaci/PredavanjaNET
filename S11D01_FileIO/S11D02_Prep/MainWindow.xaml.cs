
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

namespace S11D02_Prep
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string PICKED_FILE = null;
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void FilePick_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            

            dialog.Title = "Pick a file to read";
           // dialog.Filter = "Text Files | *.txt";
            dialog.Multiselect = true;
            bool? picked = dialog.ShowDialog();
            
            Preview.FontSize = FontSlider.Value;
            FontSlider.ValueChanged += FontSlider_ValueChanged;

            if (picked == true) {
               PICKED_FILE = dialog.FileName;

                StreamReader sr = new StreamReader(PICKED_FILE);
                string line = null;
                while ((line = sr.ReadLine()) != null) {
                    Preview.AppendText(line+"\r\n");
                }
                sr.Close();
            }

        }

        private void FontSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Preview.FontSize = FontSlider.Value;
        }

        private void FileSave_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter(PICKED_FILE);
            sw.Write(Preview.Text);
            sw.Close();
            System.Windows.MessageBox.Show(Preview.Text);
        } 

        
    }
}
