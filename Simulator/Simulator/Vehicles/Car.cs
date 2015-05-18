using Simulator.Dijkstra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Simulator
{
    public class Car : Vehicle
    {
        public Car(Node StartNode, int DefaultRotation, Direction EndDirection)
            : base(StartNode, 0.02f, 0.001f, DefaultRotation, 10, 20, VehicleType.Auto, Colors.Orange, EndDirection, 45)
        {
            
        }
    }
}
