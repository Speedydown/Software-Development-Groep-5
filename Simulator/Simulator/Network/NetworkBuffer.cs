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
        private Semaphore BufferSemaphore = new Semaphore(1, 1);
        private ConcurrentQueue<byte[]> Buffer = new ConcurrentQueue<byte[]>();

        public NetworkBuffer(string Name)
        {
            this.Name = Name;
        }

        public void Add(byte[] ByteArray)
        {
            Buffer.Enqueue(ByteArray);
            LogHandler.Instance.Write(this.Name + " recieved: " + ByteArray);
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
                LogHandler.Instance.Write(this.Name + " removed: " + Output);
                System.Diagnostics.Debug.WriteLine("[Info] " + this.Name + " Removed: " + Output);
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
