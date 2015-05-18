using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Dijkstra
{
    public class LaneSwitcher
    {
        public LaneSwitchNode EntryNodeLeft { get; private set; }
        public LaneSwitchNode EntryNodeRight { get; private set; }
        public LaneSwitchNode ExitNodeLeft { get; private set; }
        public LaneSwitchNode ExitNodeRight { get; private set; }

        public List<Vehicle> Last5Vehicle { get; private set; }

        public LaneSwitcher(LaneSwitchNode EntryNodeLeft, LaneSwitchNode EntryNodeRight, LaneSwitchNode ExitNodeLeft, LaneSwitchNode ExitNodeRight)
        {
            this.Last5Vehicle = new List<Vehicle>();
            this.EntryNodeLeft = EntryNodeLeft;
            this.EntryNodeLeft.Parrent = this;
            this.EntryNodeRight = EntryNodeRight;
            this.EntryNodeRight.Parrent = this;
            this.ExitNodeLeft = ExitNodeLeft;
            this.ExitNodeLeft.Parrent = this;
            this.ExitNodeRight = ExitNodeRight;
            this.ExitNodeRight.Parrent = this;

            this.EntryNodeLeft.AddNode(this.ExitNodeLeft);
            this.EntryNodeRight.AddNode(this.ExitNodeRight);

            this.EntryNodeLeft.AddNode(this.ExitNodeRight);
            this.EntryNodeRight.AddNode(this.ExitNodeLeft);
        }

        public void Lock(LaneSwitchNode Node, Vehicle vehicle)
        {
            if (Node == ExitNodeLeft)
            {
                ExitNodeLeft.VehicleQueue.Add(vehicle);
                EntryNodeLeft.LastPassedSecondLaneVehicle = vehicle;
                EntryNodeRight.LastPassedSecondLaneVehicle = vehicle;

                if (vehicle.CurrentNode == EntryNodeRight)
                {
                    ExitNodeRight.VehicleQueue.Add(vehicle);
                    EntryNodeLeft.LastPassedVehicle = EntryNodeRight.LastPassedVehicle;
                }
            }
            else if (Node == ExitNodeRight)
            {
                ExitNodeRight.VehicleQueue.Add(vehicle);

                if (vehicle.CurrentNode == EntryNodeLeft)
                {
                    ExitNodeLeft.VehicleQueue.Add(vehicle);
                    EntryNodeRight.LastPassedVehicle = EntryNodeLeft.LastPassedVehicle;
                }
            }
            else
            {
                throw new Exception("Invalid node");
            }
        }

        public void Unlock(LaneSwitchNode Node, Vehicle vehicle)
        {
            if (this.Last5Vehicle.Count == 5)
            {
                this.Last5Vehicle.Remove(this.Last5Vehicle.Last());
            }

            this.Last5Vehicle.Insert(0, vehicle);

            ExitNodeLeft.VehicleQueue.Remove(vehicle);
            ExitNodeRight.VehicleQueue.Remove(vehicle);

            if (Node == ExitNodeLeft)
            {
                EntryNodeRight.LastPassedVehicle = EntryNodeLeft.LastPassedVehicle;
            }
            else if (Node == ExitNodeRight)
            {
                EntryNodeLeft.LastPassedVehicle = EntryNodeRight.LastPassedVehicle;
            }
        }
    }
}
