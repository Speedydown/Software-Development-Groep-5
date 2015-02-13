using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Simulator
{
    public class EntryNode : Node
    {
        public EntryNode(Position CurrentPosition, string Label = "", Color? NodeColor = null)
            : base(CurrentPosition, Label)
        {
            if (NodeColor == null)
            {
                NodeColor = Colors.Red;
            }

            this.NodeColor = (Color)NodeColor;
            this.FillColor = Colors.Red;
        }
    }
}
