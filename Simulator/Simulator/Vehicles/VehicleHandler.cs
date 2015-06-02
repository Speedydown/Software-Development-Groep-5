using Simulator.Dijkstra;
using Simulator.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simulator
{
    public class VehicleHandler
    {
        public static readonly VehicleHandler Instance = new VehicleHandler();
        private static readonly List<Vehicle> CurrentVehicles = new List<Vehicle>();
        public static readonly List<Vehicle> VehiclesToAdd = new List<Vehicle>();
        public static readonly List<Vehicle> VehiclesToRemove = new List<Vehicle>();
        public static readonly Random RandomNumberGenerator = new Random();
        public static readonly Dictionary<Direction, Direction> InvalidDirections = new Dictionary<Direction, Direction>();

        private Thread UpdateVehicleThread;

        private VehicleHandler()
        {
            
        }

        public void StartVehicleHandler()
        {
            this.UpdateVehicleThread = new Thread(UpdateVehicles);
            this.UpdateVehicleThread.Name = "UpdateVehicleThread";
            this.UpdateVehicleThread.Start();
        }

        public void SpawnVehicle(Direction StartDirection, Direction EndDirection, VehicleType Vehicle)
        {
            List<Node> SuitableStartNodes = new List<Node>();

            foreach (EntryNode n in Map.Instance.EntryPoints)
            {
                bool IsValid = true;

                foreach (var Entry in InvalidDirections)
                {
                    if (Entry.Key == n.StartDirection && Entry.Value == EndDirection)
                    {
                        IsValid = false;
                        break;
                    }
                }

                if (n.StartDirection == StartDirection && IsValid && n.AllowedVehicles.Contains(Vehicle))
                {
                    SuitableStartNodes.Add(n);
                }
            }

            if (SuitableStartNodes.Count == 0)
            {
                LogHandler.Instance.Write("Invalid StartDirection for this vehicle. From " + StartDirection.ToString() + " to " + EndDirection.ToString() + " as a " + Vehicle.ToString(), LogType.Warning);
                return;
            }

            int DefaultRotation = (StartDirection == Direction.Noord || StartDirection == Direction.Zuid) ? 90 : 0;
            Node StartNode = SuitableStartNodes[RandomNumberGenerator.Next(0, SuitableStartNodes.Count)];
            Vehicle vehicle = null;

            if (EndDirection == Direction.Ventweg)
            {
                return;
            }

            if (Vehicle == VehicleType.Auto)
            {
                vehicle = new Car(StartNode, DefaultRotation, EndDirection);
            }
            else if (Vehicle == VehicleType.Bus)
            {
                vehicle = new Bus(StartNode, DefaultRotation, EndDirection);
            }
            else if (Vehicle == VehicleType.Fiets)
            {
                vehicle = new Bicycle(StartNode, DefaultRotation, EndDirection);
            }
            else if (Vehicle == VehicleType.Voetganger && StartDirection != Direction.Ventweg && StartDirection != Direction.Oost && EndDirection != Direction.Oost)
            {
                vehicle = new Pedestrian(StartNode, DefaultRotation, EndDirection);
            }
        }

        private void UpdateVehicles()
        {
            LogHandler.Instance.Write("Now updating vehicles", LogType.Info);

            while (true)
            {
                try
                {
                    foreach (Vehicle v in CurrentVehicles)
                    {
                        v.Update();
                    }
                }
                catch(Exception)
                {

                }

                this.CleanUpVehicles();

                Thread.Sleep(25);
            }
        }

        private void CleanUpVehicles()
        {
            try
            {
                foreach (Vehicle v in VehiclesToAdd)
                {
                    CurrentVehicles.Add(v);
                }

                foreach (Vehicle v in VehiclesToRemove)
                {
                    CurrentVehicles.Remove(v);
                }

                VehiclesToAdd.Clear();
                VehiclesToRemove.Clear();
            }
            catch (Exception)
            {

            }
        }

    }
}
