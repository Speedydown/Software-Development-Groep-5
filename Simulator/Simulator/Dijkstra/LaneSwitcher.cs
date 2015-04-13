using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Dijkstra
{
    public class LaneSwitcher
    {
        public DateTime LastPassed { get; private set; }
        public Node EntryNodeLeft { get; private set; }
        public Node EntryNodeRight { get; private set; }
        public Node ExitNodeLeft { get; private set; }
        public Node ExitNodeRight { get; private set; }

        public LaneSwitcher()
        {
            //#Afmaken
        }
    }
}
