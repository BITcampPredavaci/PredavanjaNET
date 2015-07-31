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
using ChatHelper;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;

namespace S11D05_Recap
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int _port = 7321;
        private StreamReader sr;
        private StreamWriter sw;

        public MainWindow()
        {
            InitializeComponent();
            SendButton.IsEnabled = false;
           
        }

        private void DisableConnections()
        {
            ServerStart.IsEnabled = false;
            ClientStart.IsEnabled = false;
            NickName.IsEnabled = false;
            ServerIP.IsEnabled = false;
            if (NickName.Text == "")
            {
                NickName.Text = "Guest" + new Random().Next(1, 100);
            }
        }

        private void EnableSend()
        {
            SendButton.IsEnabled = true;
        }

        private void ListenOnStream()
        {
            Task t = new Task(() =>
            {
                while (true)
                {

                    string line = sr.ReadLine();
                    if (line != "")
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            ChatBox.AppendText("\n"+ line);
                        });
                    }

                }
            });
            t.Start();
        }

        private void ServerStart_Click(object sender, RoutedEventArgs e)
        {
            SocketConnector.StartServer(_port);
            ChatBox.AppendText("Server connected");
            DisableConnections();

            Task listener = new Task(() =>
            {
                NetworkStream ns = SocketConnector.GetServerStream();
                sr = new StreamReader(ns);
                sw = new StreamWriter(ns);
                MessageBox.Show("Client connected");
               

            });

            listener.Start();
            listener.GetAwaiter().OnCompleted(ListenOnStream);
        }

        private void ClientStart_Click(object sender, RoutedEventArgs e)
        {
            if(ServerIP.Text == "")
            {
                MessageBox.Show("Eneter Server IP!");
                return;
            }
            NetworkStream str = SocketConnector.GetClientStream("10.0.82."+ServerIP.Text, _port);
            sr = new StreamReader(str);
            sw = new StreamWriter(str);

            Task listener = new Task(ListenOnStream);
            listener.Start();
            MessageBox.Show("Connected to Server");
            DisableConnections();
           
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            if(sw == null)
            {
                MessageBox.Show("No connection");
                return;
            }
            string line = SendBox.Text;
            sw.WriteLine(NickName.Text+": " + line);
            sw.Flush();
            ChatBox.AppendText("\nMe: " + line);
            SendBox.Clear();
            SendButton.IsEnabled = false;
        }

        private void SendBox_KeyDown(object sender, KeyEventArgs e)
        {
            bool hasMessage = SendBox.Text.Trim().Length > 0;
            if (e.Key == Key.Enter && hasMessage)
            {
                SendButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            SendButton.IsEnabled = hasMessage;
        }
    }
}
