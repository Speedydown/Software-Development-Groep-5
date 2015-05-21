using Simulator.Dijkstra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Simulator.Dijkstra
{
    public class BicycleNode : Node
    {
        public BicycleNode(Position CurrentPosition, string Label = "")
            : base(CurrentPosition, Label, new VehicleType[] { VehicleType.Fiets })
        {
            this.NodeColor = Colors.Purple;
        }

    }
}
