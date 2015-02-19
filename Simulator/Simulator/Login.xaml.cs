using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Simulator
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window, INotifyPropertyChanged
    {
        private string _StatusMessage = "";
        public string StatusMessage
        {
            get
            {
                return _StatusMessage;
            }
            private set
            {
                _StatusMessage = value;
                OnPropertyChanged("StatusMessage");
            }
        }

        public Login()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private async void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            this.ConnectButton.IsEnabled = false;

            string IP = this.IPTextbox.Text;
            int Port = Convert.ToInt32(this.PortTextbox.Text);

            this.StatusMessage = await Task.Run(() => NetworkHandler.Instance.Connect(IP, Port));

            if (NetworkHandler.Instance.Connected)
            {
                this.Close();
            }

            this.ConnectButton.IsEnabled = true;
        }
    }
}
