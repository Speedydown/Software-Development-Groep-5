using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Simulator.Dijkstra
{
    public class LaneSwitchNode : Node
    {
        public bool IsEntryNode { get; set; }
        public List<Vehicle> VehicleQueue { get; private set; }
        public LaneSwitcher Parrent { get; set; }

        public LaneSwitchNode(bool IsEntryNode, Position CurrentPosition, VehicleType[] AllowedVehicles = null)
            : base(CurrentPosition, string.Empty, AllowedVehicles)
        {
            this.VehicleQueue = new List<Vehicle>();
            this.IsEntryNode = IsEntryNode;
        }

        public override Node GetNodeWithLowestCost(Direction TargetDirection, Vehicle vehicle)
        {
            Node Result = base.GetNodeWithLowestCost(TargetDirection, vehicle);

            if (this.IsEntryNode)
            {
                if (!(Result is LaneSwitchNode))
                {
                    throw new Exception("Invalid node");
                }

                this.Parrent.Lock(Result as LaneSwitchNode, vehicle);
            }
            else
            {
                this.Parrent.Unlock(this, vehicle);
            }

            return Result;
        }
    }
}
