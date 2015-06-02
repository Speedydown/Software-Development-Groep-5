using Simulator.Dijkstra;
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
                byte[] Input = null;

                try
                {
                   Input = NetworkHandler.InputBuffer.Get();
                }
                catch (Exception)
                {

                }

                if (Input != null)
                {
                    if (Input[0] == (byte)1)
                    {
                        //VehiclePacket
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
                    else if (Input[0] == (byte)2)
                    {
                        //TrafficLightPacket
                        int TrafficLightID = (int)Input[1];
                        TrafficLightState State = (TrafficLightState)Input[2];

                        foreach (TrafficLight TL in TrafficLight.TrafficLights)
                        {
                            if (TrafficLightID == TL.TrafficLightID)
                            {
                                try
                                {
                                    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                                    {
                                        try
                                        {
                                            TL.ChangeState(State);
                                        }
                                        catch (Exception)
                                        {
                                            LogHandler.Instance.Write(Thread.CurrentThread.Name + " is terminated!");
                                            Thread.CurrentThread.Abort();
                                        }
                                    }));
                                }
                                catch (Exception)
                                {
                                    LogHandler.Instance.Write(Thread.CurrentThread.Name + " is terminated!");
                                    Thread.CurrentThread.Abort();
                                }
                            }
                        }
                    }
                    

                    this.CommandsRecieved++;
                }

                Thread.Sleep(10);
            }
        }

        public void ProcessVehicleCheckpoint(int StoplichtID, bool CheckinNode)
        {
            byte[] Output = null;

            byte TrafficLightID = byte.Parse(StoplichtID.ToString());
            byte NodeType = CheckinNode ? (byte)1 : (byte)0;
            Output = new byte[] { (byte)3, TrafficLightID , NodeType, (byte)0 };

            NetworkHandler.OutputBuffer.Add(Output);

            this.CommandsSend++;
        }

        
    }
}
