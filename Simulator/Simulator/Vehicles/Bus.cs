using Simulator.Dijkstra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Simulator
{
    public class Bus : Vehicle
    {
        public Bus(Node StartNode, int DefaultRotation, Direction EndDirection)
            : base(StartNode, 0.02f, 0.0015f, DefaultRotation, 10, 35, VehicleType.Bus, Colors.Purple, EndDirection, 65)
        {

        }
    }
}
