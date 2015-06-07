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
        private static Random Randomizer = new Random();
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

            int ZIndex = 9;

            if (this.Destination.AllowedVehicles.Contains(VehicleType.Fiets) || this.Destination == Map.Instance.nodes.Custom71)
            {
                PathLine.Stroke = new SolidColorBrush(Colors.DarkOrange);
                PathLine.StrokeThickness = 6;
                ZIndex = 11;
            }

            if (this.Destination.AllowedVehicles.Contains(VehicleType.Voetganger))
            {
                PathLine.Stroke = new SolidColorBrush(Colors.DarkGray);
                PathLine.StrokeThickness = 6;
                ZIndex = 11;
            }

            if ((this.Destination.AllowedVehicles.Contains(VehicleType.Auto) || this.Destination.AllowedVehicles.Contains(VehicleType.Bus)) && !(this.Source == Map.Instance.nodes.TrafficLight222ExitLeft || this.Source == Map.Instance.nodes.Nodec12 || this.Source == Map.Instance.nodes.Nodec8 || this.Source == Map.Instance.nodes.EntryNode12))
            {
                PathLine.Stroke = new SolidColorBrush(Colors.LightGray);
                PathLine.StrokeThickness = 14;
                ZIndex = 10;
            }

            if (Config.DisplayNodes)
            {
                PathLine.Stroke = new SolidColorBrush(this.NodeColor);
                PathLine.StrokeThickness = 2;
            }


            this.MapCanvas.Children.Add(PathLine);
            Map.SetZIndex(PathLine, ZIndex);

            this.Destination.Draw();
        }

        public void RemoveVehicle()
        {
            if (this.NumberOfVehicles == 0)
            {
                return;
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
            int Output = 0;

            Output += this.Length;

            if (this.Source is PedestrianNode || this.Destination is PedestrianNode)
            {
                Output += Randomizer.Next(0, 25);
                return Output;
            }

            Output += this.NumberOfVehicles * 75;

            if (this.Source is BusNode)
            {
                Output -= 90;
            }

            return Output;
        }
    }
}
