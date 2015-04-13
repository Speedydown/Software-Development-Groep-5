using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Simulator.Dijkstra
{
    public class TrafficLight : Node
    {
        public static readonly List<TrafficLight> TrafficLights = new List<TrafficLight>();

        public int TrafficLightID { get; private set; }

        private TrafficLightState _State;
        public TrafficLightState State
        {
            get
            {
                return _State;
            }
            private set
            {
                _State = value;
                OnPropertyChanged("State");
                OnPropertyChanged("FillColor");
            }
        }


        public TrafficLight(int TrafficLightID, Position CurrentPosition, VehicleType[] AllowedVehicles = null, Color? NodeColor = null)
            : base(CurrentPosition, TrafficLightID.ToString(), AllowedVehicles)
        {
            this.State = TrafficLightState.Rood;
            this.TrafficLightID = TrafficLightID;
            this.NodeColor = NodeColor == null ? Colors.Red : (Color)NodeColor;
            this.FillColor = Colors.Red;
            TrafficLight.TrafficLights.Add(this);
        }

        public void ChangeState(TrafficLightState State)
        {
            this.State = State;

            if (this.State == TrafficLightState.Groen)
            {
                this.FillColor = Colors.Green;
            }
            else if (this.State == TrafficLightState.Oranje)
            {
                this.FillColor = Colors.Orange;
            }
            else
            {
                this.FillColor = Colors.Red;
            }
            
            this.NodeEllipse.Fill = (new SolidColorBrush(this.FillColor));
        }
    }
}
