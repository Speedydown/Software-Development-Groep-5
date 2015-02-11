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
        public EntryNode(Canvas MapCanvas, Position CurrentPosition)
            : base(MapCanvas, CurrentPosition)
        {
            this.FillColor = Colors.Red;
        }
    }
}
