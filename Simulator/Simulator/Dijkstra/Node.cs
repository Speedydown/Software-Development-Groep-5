using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Simulator.UserControls;

namespace Simulator
{
    public class Node
    {
        private int _ID;
        public int ID
        {
            get
            {
                if (this._ID == 0)
                {
                    _ID = Node.GenerateID();
                }

                return _ID;
            }
        }

        private Canvas MapCanvas { get; set; }
        public Position CurrentPosition { get; private set; }
        public List<Path> Paths { get; private set; }
        public bool ExitNode { get; private set; }
        public Direction? ExitDirection { get; private set; }

        public Node(Canvas MapCanvas, Position CurrentPosition, Direction? ExitDirection = null)
            : base()
        {
            this.Paths = new List<Path>();
            this.CurrentPosition = CurrentPosition;
            this.MapCanvas = MapCanvas;

            if (ExitDirection != null)
            {
                this.ExitDirection = ExitDirection;
                this.ExitNode = true;
            }
        }

        public Node AddNode(Node DestinationNode)
        {
            this.Paths.Add(new Path(this.MapCanvas, this, DestinationNode));

            return DestinationNode;
        }

        public void Draw()
        {
            Ellipse NodeEllipse = new System.Windows.Shapes.Ellipse();
            NodeEllipse.Height = 20;
            NodeEllipse.Width = 20;
            NodeEllipse.StrokeThickness = 2;
            NodeEllipse.Stroke = new SolidColorBrush(Colors.Red);
            NodeEllipse.Fill = new SolidColorBrush(Colors.Transparent);

            NodeEllipse.Margin = new Thickness(CurrentPosition.X - 10, CurrentPosition.Y - 10, 0, 0);

            this.MapCanvas.Children.Add(NodeEllipse);

            foreach (Path p in this.Paths)
            {
                p.Draw();
            }
        }

        public override string ToString()
        {
            return CurrentPosition.ToString() + ((this.ExitNode) ? " (Exit)" : string.Empty);
        }

        private static int CurrentIDCount = 0;
        private static int GenerateID()
        {
            return CurrentIDCount++;
        }
    }
}
