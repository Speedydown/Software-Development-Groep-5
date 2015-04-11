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

        public NotificationNode(int TrafficLightID, bool IsVehicleSignupNode, Position CurrentPosition, VehicleType[] AllowedVehicles = null)
            : base(CurrentPosition, TrafficLightID.ToString(), AllowedVehicles)
        {
            this.TrafficLightID = TrafficLightID;
            this.IsVehicleSignupNode = IsVehicleSignupNode;

            this.NodeColor = Colors.Black;
            this.FillColor = (IsVehicleSignupNode ? Colors.Lime : Colors.LightCoral);
        }
    }
}
