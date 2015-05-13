using Simulator.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Simulator
{
    public enum LogType { Info, Warning, Critical }

    public class LogHandler : DynamicObject
    {
        public static readonly LogHandler Instance = new LogHandler();
        public ListView LogListview = null;

        public List<string> Log
        {
            get;
            private set;
        }

        private LogHandler()
            : base()
        {
            this.Log = new List<string>();
        }

        public void Write(string Value, LogType logType = LogType.Info)
        {
            Value = "[" + logType + "][" + DateTime.Now.ToShortTimeString() + "] " + Value;
            this.Log.Add(Value);
            OnPropertyChanged("Log");

            if (this.LogListview != null)
            {
                try
                {
                    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        //this.LogListview.ItemsSource = null;
                        //this.LogListview.ItemsSource = this.Log.ToArray().Reverse();
                    }));
                }
                catch
                {

                }
            }

            System.Diagnostics.Debug.WriteLine(Value);

        }

        public override string ToString()
        {
            return "Current logfile count: " + this.Log.Count;
        }
    }
}
