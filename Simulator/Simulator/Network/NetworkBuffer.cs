using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simulator.Network
{
    internal class NetworkBuffer
    {
        private string Name;
        private ConcurrentQueue<byte[]> Buffer = new ConcurrentQueue<byte[]>();

        public NetworkBuffer(string Name)
        {
            this.Name = Name;
        }

        public void Add(byte[] ByteArray)
        {
            Buffer.Enqueue(ByteArray);

            if (Config.EnableNetworkLogging)
            {
                LogHandler.Instance.Write(this.Name + " recieved: " + BitConverter.ToString(ByteArray).Replace("-", ""));
            }
        }

        public int GetQueueCount()
        {
            return Buffer.Count;
        }

        public byte[] Get()
        {
            byte[] Output;

            if (this.Buffer.TryDequeue(out Output))
            {
                try
                {
                    if (Config.EnableNetworkLogging)
                    {
                        LogHandler.Instance.Write(this.Name + " removed: " + BitConverter.ToString(Output).Replace("-", ""));
                    }
                }
                catch
                {

                }

                return Output;

            }

            return null;
        }

        public override string ToString()
        {
            return "Enqueueed items: " + Buffer.Count.ToString();
        }
    }
}
