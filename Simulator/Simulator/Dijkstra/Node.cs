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

        private Canvas MapCanvas = Map.Instance;
        public Position CurrentPosition { get; private set; }
        public List<Path> Paths { get; private set; }
        private string Label = "";
        private bool DrawnOnCanvas = false;
        public Color NodeColor { get; protected set; }

        //Local variables
        protected Color FillColor = Colors.White;

        public Node(Position CurrentPosition, string Label = "")
            : base()
        {
            this.NodeColor = Colors.Red;
            this.Paths = new List<Path>();
            this.CurrentPosition = CurrentPosition;
            this.NodeColor = NodeColor;
            this.Label = Label;
        }

        public Node AddNode(Node DestinationNode)
        {
            if (this is BusNode)
            {
                this.Paths.Add(new Path(this, DestinationNode, this.NodeColor)); 
            }
            else
            {
                this.Paths.Add(new Path(this, DestinationNode, DestinationNode.NodeColor)); 
            }

            return DestinationNode;
        }

        public void Draw()
        {
            if (!this.DrawnOnCanvas)
            {
                this.DrawnOnCanvas = true;
                Ellipse NodeEllipse = new System.Windows.Shapes.Ellipse();
                NodeEllipse.Height = 20;
                NodeEllipse.Width = 20;
                NodeEllipse.StrokeThickness = 2;
                NodeEllipse.Stroke = new SolidColorBrush(this.NodeColor);
                NodeEllipse.Fill = new SolidColorBrush(this.FillColor);

                NodeEllipse.Margin = new Thickness(CurrentPosition.X - 10, CurrentPosition.Y - 10, 0, 0);

                TextBlock IDNumberTextblock = new TextBlock();
                IDNumberTextblock.Text = this.Label;
                IDNumberTextblock.FontWeight = FontWeight.FromOpenTypeWeight(500);
                IDNumberTextblock.Margin = new Thickness(CurrentPosition.X - 5, CurrentPosition.Y - 8, 0, 0);



                foreach (Path p in this.Paths)
                {
                    p.Draw();
                }

                this.MapCanvas.Children.Add(NodeEllipse);
                this.MapCanvas.Children.Add(IDNumberTextblock);
                Map.SetZIndex(NodeEllipse, 254);
                Map.SetZIndex(IDNumberTextblock, 255);
            }
        }

        public void SetLabel(string Label)
        {
            this.Label = Label;
        }

        public override string ToString()
        {
            return CurrentPosition.ToString();
        }

        private static int CurrentIDCount = 0;
        private static int GenerateID()
        {
            return ++CurrentIDCount;
        }
    }
}
