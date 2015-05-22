using Simulator.Dijkstra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Simulator
{
    public class Bicycle : Vehicle
    {
        public Bicycle(Node StartNode, int DefaultRotation, Direction EndDirection)
            : base(StartNode, 0.015f, 0.015f, DefaultRotation, 6, 12, VehicleType.Fiets, Colors.DarkGreen, EndDirection, 16)
        {

        }
    }
}
