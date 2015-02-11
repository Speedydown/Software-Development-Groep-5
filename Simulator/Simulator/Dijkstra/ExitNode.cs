using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Simulator
{
    public class ExitNode : Node
    {
        public Direction ExitDirection { get; private set; }

        public ExitNode(Canvas MapCanvas, Position CurrentPosition, Direction ExitDirection) : base(MapCanvas, CurrentPosition)
        {
            this.FillColor = Colors.LightGreen;
            this.ExitDirection = ExitDirection;
        }
    }
}
