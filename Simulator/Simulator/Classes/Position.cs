using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Position
    {
        public float X { get; private set; }
        public float Y { get; private set; }

        public Position(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public override string ToString()
        {
            return "[" + this.X + "][" + this.Y + "]";
        }
    }
}
