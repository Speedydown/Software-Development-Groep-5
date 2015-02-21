using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public enum LogType { Info, Warning, Critical }

    public class LogHandler
    {
        public static readonly LogHandler Instance = new LogHandler();

        public List<string> Log { get; private set; }

        private LogHandler()
        {
            this.Log = new List<string>();
        }

        public void Write(string Value, LogType logType = LogType.Info)
        {
            Value = "[" + logType + "][" + DateTime.Now.ToShortTimeString() + "] " + Value;

            this.Log.Add(Value);
            System.Diagnostics.Debug.WriteLine(Value);
        }

        public override string ToString()
        {
            return "Current logfile count: " + this.Log.Count;
        }
    }
}
