using Simulator.Dijkstra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Simulator.Dijkstra
{
    public class BusNode : Node
    {
        public BusNode(Position CurrentPosition, string Label = "") : base(CurrentPosition, Label, new VehicleType[] { })
        {
            this.NodeColor = Colors.Gold;
        }
    }
}
