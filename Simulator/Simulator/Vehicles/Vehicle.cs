using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace Simulator
{
    public abstract class Vehicle
    {
        //Default settings
        public int ID { get; private set; }
        protected int MaxSpeed { get; private set; }
        protected int DefaultRotation { get; private set; }

        public int Height { get; private set; }
        public int Width { get; private set; }
        
        public float CurrentSpeed { get; protected set; }
        public Position CurrentPosition { get; protected set; }
        public Rectangle CurrentShape { get; protected set; }

        //NodeSettings
        public Node TargetNode { get; protected set; }
        public Path CurrentPath { get; protected set; }
        public float CurrentPercentOfPathTraveled { get; protected set; }

        //Animation settings
        public float Rotation { get; protected set; }

        protected Vehicle(int MaxSpeed, int DefaultRotation, int Height, int Width)
        {
            this.ID = Vehicle.GenerateID();
            this.MaxSpeed = MaxSpeed;
            this.DefaultRotation = DefaultRotation;
            this.Height = Height;
            this.Width = Width;
        }

        private static int CurrentIDCount = 0;
        private static int GenerateID()
        {
            return ++CurrentIDCount;
        }
    }
}
