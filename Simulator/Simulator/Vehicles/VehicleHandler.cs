using Simulator.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class VehicleHandler
    {
        public static readonly VehicleHandler Instance = new VehicleHandler();

        public VehicleHandler()
        {

        }

        public void SpawnVehicle(Direction StartDirection, Direction EndDirection, VehicleType Vehicle)
        {
            List<Node> SuitableStartNode = new List<Node>();

            foreach (Node n in Map.Instance.EntryPoints)
            {
                if (n.Direction == StartDirection)
                {
                    SuitableStartNode.Add(n);
                }
            }

            switch (Vehicle)
            {
                //Spawn Vehicle
            }
        }

    }
}
