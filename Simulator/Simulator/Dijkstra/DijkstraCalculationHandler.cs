using Simulator.Dijkstra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class DijkstraCalculationHandler
    {
        public static readonly DijkstraCalculationHandler Instance = new DijkstraCalculationHandler();

        private DijkstraCalculationHandler()
        {

        }

        public Node CalculateNextNodeForVehicle(Vehicle vehicle)
        {
            Node CurrentNode = vehicle.CurrentNode.GetNodeWithLowestCost(vehicle.EndDirection, vehicle);
            return CurrentNode;
        }

    }
}
