using Simulator.Dijkstra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Simulator.Dijkstra
{
    public class ExitNode : Node
    {
        public Direction ExitDirection { get; private set; }

        public ExitNode(Position CurrentPosition, Direction ExitDirection, VehicleType[] AllowedVehicles, string Label = "", Color? NodeColor = null)
            : base(CurrentPosition, Label, AllowedVehicles)
        {
            if (NodeColor == null)
            {
                NodeColor = Colors.Red;
            }

            this.NodeColor = (Color)NodeColor;
            this.FillColor = Colors.LightGreen;
            this.ExitDirection = ExitDirection;
        }
    }
}
