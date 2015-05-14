using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Dijkstra
{
    public class TrafficLightWaitNode : Node
    {
        public TrafficLightWaitNode(Position CurrentPosition, string Label = "", VehicleType[] AllowedVehicles = null)
            : base(CurrentPosition, Label, AllowedVehicles)
        {

        }
    }
}
