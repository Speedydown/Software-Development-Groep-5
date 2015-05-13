using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Dijkstra
{
    public class LaneSwitcher
    {
        public Node EntryNodeLeft { get; private set; }
        public Node EntryNodeRight { get; private set; }
        public Node ExitNodeLeft { get; private set; }
        public Node ExitNodeRight { get; private set; }

        public LaneSwitcher(Node EntryNodeLeft, Node EntryNodeRight, Node ExitNodeLeft, Node ExitNodeRight)
        {
            this.EntryNodeLeft = EntryNodeLeft;
            this.EntryNodeRight = EntryNodeRight;
            this.ExitNodeLeft = ExitNodeLeft;
            this.ExitNodeRight = ExitNodeRight;

            this.EntryNodeLeft.AddNode(this.ExitNodeLeft);
            this.EntryNodeRight.AddNode(this.ExitNodeRight);

            this.EntryNodeLeft.AddNode(this.ExitNodeRight);
            this.EntryNodeRight.AddNode(this.ExitNodeLeft);
        }
    }
}
