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
        public EntryNode(Position CurrentPosition, Color NodeColor, string Label = "")
            : base(CurrentPosition, NodeColor, Label)
        {
            this.FillColor = Colors.Red;
        }
    }
}
