using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Simulator.Network
{
    public class NetworkCommandHandler
    {
        public static readonly NetworkCommandHandler Instance = new NetworkCommandHandler();

        private int CommandsSend = 0;
        private int CommandsRecieved = 0;
        private Thread ProcessCommandThread;

        private NetworkCommandHandler()
        {

        }

        internal void Start()
        {
            this.ProcessCommandThread = new Thread(ProcessCommands);
            this.ProcessCommandThread.Name = "ProcessCommandThread";
            this.ProcessCommandThread.Start();
        }

        private void ProcessCommands()
        {
            LogHandler.Instance.Write(this.ProcessCommandThread.Name + " is now processing commands!");

            while (true)
            {
                byte[] Input = NetworkHandler.InputBuffer.Get();

                if (Input != null)
                {
                    if (Input[0] == (byte)1)
                    {
                        Direction StartDirection = (Direction)Input[1];
                        Direction DestinationDirection = (Direction)Input[2];
                        VehicleType VehicleType = (VehicleType)Input[3];

                        Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            try
                            {
                                VehicleHandler.Instance.SpawnVehicle(StartDirection, DestinationDirection, VehicleType);
                            }
                            catch (Exception)
                            {
                                Thread.CurrentThread.Abort();
                            }
                        }));
                    }
                    

                    this.CommandsRecieved++;
                }

                Thread.Sleep(10);
            }
        }

        public void ProcessVehicleCheckpoint(int StoplichtID)
        {
            Byte[] Output = null;

            Byte b = Byte.Parse(StoplichtID.ToString());
            Output = new byte[] { b };

            NetworkHandler.OutputBuffer.Add(Output);

            this.CommandsSend++;
        }

        
    }
}
