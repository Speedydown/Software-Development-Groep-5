using Simulator.Dijkstra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Simulator
{
    public class Pedestrian : Vehicle
    {
        public Pedestrian(Node StartNode, int DefaultRotation, Direction EndDirection)
            : base(StartNode, 0.01f, 0.01f, DefaultRotation, 5, 5, VehicleType.Voetganger, Colors.DarkRed, EndDirection, 10)
        {
            
        }
    }
}
