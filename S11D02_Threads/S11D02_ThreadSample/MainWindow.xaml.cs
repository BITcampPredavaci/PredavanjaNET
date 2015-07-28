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
using System.Threading;

namespace S11D02_ThreadSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        void UpdateBox()
        {
            Task t = new Task(() => {
                Console.WriteLine("Hello");
                Thread.Sleep(1000);
                StatusUpdate.Text = "Hello";
                Console.WriteLine("Hello");
            });
            t.Start();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            UpdateBox();
        }

    }
}
