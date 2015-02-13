using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Simulator
{
    public class BicycleNode : Node
    {
        public BicycleNode(Position CurrentPosition, string Label = "")
            : base(CurrentPosition, Label)
        {
            this.NodeColor = Colors.Purple;
        }

    }
}
