using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Simulator.Dijkstra
{
    public class PedestrianNode : Node
    {
        public PedestrianNode(Position CurrentPosition, string Label = "")
            : base(CurrentPosition, Label, new VehicleType[] { VehicleType.Voetganger })
        {
            this.NodeColor = Colors.Green;
        }
    }
}
