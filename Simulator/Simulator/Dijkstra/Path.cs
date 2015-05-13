using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Simulator.UserControls;
using System.Windows;

namespace Simulator.Dijkstra
{
    public class Path
    {
        public int NumberOfVehicles { get; private set; } //Cost To Travel this Path
        private Canvas MapCanvas { get; set; }

        public int Length
        {
            get
            {
                float LengthX = (Source.CurrentPosition.X > Destination.CurrentPosition.X) ? Source.CurrentPosition.X - Destination.CurrentPosition.X : Destination.CurrentPosition.X - Source.CurrentPosition.X;
                float LengthY = (Source.CurrentPosition.Y > Destination.CurrentPosition.Y) ? Source.CurrentPosition.Y - Destination.CurrentPosition.Y : Destination.CurrentPosition.Y - Source.CurrentPosition.Y;

                return (int)Math.Sqrt(((LengthX * LengthX) + (LengthY * LengthY)));
            }
        }

        public Node Source { get; private set; }
        public Node Destination { get; private set; }
        private Color NodeColor { get; set; }

        public Path(Node Source, Node Destination, Color NodeColor)
        {
            this.Source = Source;
            this.Destination = Destination;
            this.NumberOfVehicles = 0;
            this.MapCanvas = Map.Instance;
            this.NodeColor = NodeColor;
        }

        public void AddVehicle()
        {
            this.NumberOfVehicles++;
        }

        public void Draw()
        {
            Line PathLine = new System.Windows.Shapes.Line();
            PathLine.X1 = this.Source.CurrentPosition.X;
            PathLine.Y1 = this.Source.CurrentPosition.Y;
            PathLine.X2 = this.Destination.CurrentPosition.X;
            PathLine.Y2 = this.Destination.CurrentPosition.Y;

            PathLine.StrokeThickness = 2;
            PathLine.Stroke = new SolidColorBrush(this.NodeColor);


            this.MapCanvas.Children.Add(PathLine);

            this.Destination.Draw();
        }

        public void RemoveVehicle()
        {
            if (this.NumberOfVehicles == 0)
            {
                throw new Exception("Number of vehicles below 0!");
            }

            this.NumberOfVehicles--;
        }

        public int CalculateCostOfRoute(Direction TargetDirection, int CurrentCost, Vehicle vehicle, List<Path> VisitedPaths)
        {
            CurrentCost += this.CalculateCost();
            VisitedPaths.Add(this);

            return this.Destination.CalculateCostOfRoute(TargetDirection, CurrentCost, vehicle, VisitedPaths);
        }

        private int CalculateCost()
        {
            //Startwaarde niet statisch geven, nodes worden gestraft voor meerdere kruispunten terwijl dat niet hoeft
            int Output = 0;

            Output += this.Length;
            Output += this.NumberOfVehicles * 5;

            return Output;
        }
    }
}
