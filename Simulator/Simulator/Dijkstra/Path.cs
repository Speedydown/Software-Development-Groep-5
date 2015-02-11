using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Simulator.UserControls;

namespace Simulator
{
    public class Path
    {
        public int NumberOfVehicles { get; private set; } //Cost To Travel this Path
        private Canvas MapCanvas { get; set; }

        public int Length
        {
            get
            {
                int LengthX = (Source.CurrentPosition.X > Destination.CurrentPosition.X) ? Source.CurrentPosition.X - Destination.CurrentPosition.X : Destination.CurrentPosition.X - Source.CurrentPosition.X;
                int LengthY = (Source.CurrentPosition.Y > Destination.CurrentPosition.Y) ? Source.CurrentPosition.Y - Destination.CurrentPosition.Y : Destination.CurrentPosition.Y - Source.CurrentPosition.Y;

                return (int)Math.Sqrt(((LengthX * LengthX) + (LengthY * LengthY)));
            }
        }

        public Node Source { get; private set; }
        public Node Destination { get; private set; }

        public Path(Canvas MapCanvas, Node Source, Node Destination)
        {
            this.Source = Source;
            this.Destination = Destination;
            this.NumberOfVehicles = 0;
            this.MapCanvas = MapCanvas;
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
            PathLine.Stroke = new SolidColorBrush(Colors.Red);


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
    }
}
