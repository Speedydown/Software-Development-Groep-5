using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simulator.Network
{
    public class NetworkHandler
    {
        public static readonly NetworkHandler Instance = new NetworkHandler();
        internal static readonly NetworkBuffer InputBuffer = new NetworkBuffer("InputBuffer");
        internal static readonly NetworkBuffer OutputBuffer = new NetworkBuffer("OutputBuffer");

        public bool Connected { get; private set; }
        private TcpClient clientSocket = new TcpClient();
        private NetworkStream serverStream;
        private Thread InputThread;
        private Thread OutputThread;

        private NetworkHandler()
        {
            this.Connected = false;
        }

        public async Task<string> Connect(string Address, int Port)
        {
            if (Connected)
            {
                return "Allready connected";
            }

            try
            {
                this.clientSocket.Connect(Address, Port);
                this.serverStream = clientSocket.GetStream();
                this.Connected = true;

                //Run threads
                this.OutputThread = new Thread(Send);
                this.OutputThread.Name = "OutputThread";
                this.OutputThread.Start();

                this.InputThread = new Thread(Recv);
                this.InputThread.Name = "InputThread";
                this.InputThread.Start();

                return "Connected";
            }
            catch (ArgumentNullException)
            {
                return "Hostname not valid";
            }
            catch (ArgumentOutOfRangeException)
            {
                return "The port parameter is not between MinPort and MaxPort.";
            }
            catch (SocketException e)
            {
                return "Socket returned: " + e.ErrorCode;
            }
            catch (ObjectDisposedException)
            {
                return "Server closed the connection";
            }
        }


        internal void Send()
        {
            LogHandler.Instance.Write("NetworkHandler is now sending commands");

            while (Connected)
            {
                byte[] outStream = NetworkHandler.OutputBuffer.Get();

                if (outStream != null)
                {
                    try
                    {
                        this.serverStream.Write(outStream, 0, outStream.Length);
                        this.serverStream.Flush();
                    }
                    catch (Exception e)
                    {
                        //Something went wrong?
                        LogHandler.Instance.Write("Could not send data because: \n" + e.ToString(), LogType.Critical);

                        this.Disconnect();
                        break;
                    }
                }

                Thread.Sleep(10);
            }
        }

        internal void Recv()
        {
            LogHandler.Instance.Write("NetworkHandler is now recieving commands");

            while (Connected)
            {
                //NetworkHandler.InputBuffer.Add(new byte[] { 1, 2, 3, 0 });

                byte[] inStream = new byte[4];

                try
                {
                    serverStream.Read(inStream, 0, 4);

                    if (inStream != null)
                    {
                        NetworkHandler.InputBuffer.Add(inStream);
                    }
                }
                catch (IndexOutOfRangeException)
                {

                }
                catch (Exception e)
                {
                    //Something went wrong?
                    LogHandler.Instance.Write("Could not recieve data because: \n" + e.ToString(), LogType.Critical);

                    this.Disconnect();
                    break;
                }

                Thread.Sleep(10);
            }
        }

        public void Disconnect()
        {
            if (clientSocket == null)
            {
                return;
            }

            clientSocket.Close();
            serverStream.Close();
            clientSocket = null;
            serverStream = null;
        }
    }
}
