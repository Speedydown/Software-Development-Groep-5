using Simulator.UserControls;
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
using System.Windows.Shapes;

namespace Simulator
{
    public partial class TestControls : Window
    {

        public TestControls()
        {
            InitializeComponent();
            this.Left = Convert.ToInt32(SystemParameters.PrimaryScreenWidth - this.Width - 17);
            this.Top = Convert.ToInt32(SystemParameters.PrimaryScreenHeight - this.Height - 17);

            this.VehicleTypeComboBox.ItemsSource = Enum.GetValues(typeof(VehicleType)).Cast<VehicleType>();
            this.VehicleStartDirectionComboBox.ItemsSource = Enum.GetValues(typeof(Direction)).Cast<Direction>();
            this.VehicleEndDirectionComboBox.ItemsSource = Enum.GetValues(typeof(Direction)).Cast<Direction>();

            this.TrafficLigtStateComboBox.ItemsSource = Enum.GetValues(typeof(TrafficLightState)).Cast<TrafficLightState>();
        }

        private void SpawnVehicleButton_Click(object sender, RoutedEventArgs e)
        {
            VehicleHandler.Instance.SpawnVehicle((Direction)this.VehicleStartDirectionComboBox.SelectedItem, (Direction)this.VehicleEndDirectionComboBox.SelectedItem, (VehicleType)this.VehicleTypeComboBox.SelectedItem);
        }

        private void ChangeLightButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
