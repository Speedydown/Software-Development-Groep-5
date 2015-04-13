using Simulator.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Simulator.Dijkstra
{
    public class NotificationNode : Node
    {
        public int TrafficLightID { get; private set; }
        public bool IsVehicleSignupNode { get; private set; }

        public NotificationNode(int TrafficLightID, bool IsVehicleSignupNode, Position CurrentPosition, VehicleType[] AllowedVehicles = null, Color? NodeColor = null)
            : base(CurrentPosition, TrafficLightID.ToString(), AllowedVehicles)
        {
            this.TrafficLightID = TrafficLightID;
            this.IsVehicleSignupNode = IsVehicleSignupNode;

            this.NodeColor = NodeColor == null ? Colors.Red : (Color)NodeColor;
            this.FillColor = (IsVehicleSignupNode ? Colors.Orchid : Colors.Olive);
        }

        public void Notify()
        {
            NetworkCommandHandler.Instance.ProcessVehicleCheckpoint(this.TrafficLightID, this.IsVehicleSignupNode);
        }
    }
}
