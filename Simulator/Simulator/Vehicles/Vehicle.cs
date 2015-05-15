using Simulator.Dijkstra;
using Simulator.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Simulator
{
    public abstract class Vehicle : DynamicObject
    {
        //Default settings
        public int ID { get; private set; }
        protected float MaxSpeed { get; private set; }
        protected float Acceleration { get; private set; }
        protected int DefaultRotation { get; private set; }
        public VehicleType VehicleType { get; private set; }
        public Direction EndDirection { get; private set; }
        public VehicleState vehicleState { get; protected set; }
        protected Vehicle VehicleInFront { get; private set; }
        protected Vehicle SecondVehicleInFront { get; private set; }
        private bool Disposed = false;

        public int Height { get; private set; }
        public int Width { get; private set; }
        
        public float CurrentSpeed { get; protected set; }
        public Position CurrentPosition { get; protected set; }
        public Rectangle CurrentShape { get; protected set; }

        //NodeSettings
        public Node TargetNode { get; protected set; }
        public Node CurrentNode { get; protected set; }
        public Simulator.Dijkstra.Path CurrentPath { get; protected set; }
        public float CurrentPercentOfPathTraveled { get; protected set; }
        public float CurrentDistanceOfPathTraveled { get; protected set; }

        //Animation settings
        public float Rotation { get; protected set; }
        public Color Color { get; protected set; }
        

        protected Vehicle(Node StartNode, float MaxSpeed, float Acceleration, int DefaultRotation, int Height, int Width, VehicleType VehicleType, Color VehicleColor, Direction EndDirection) : base()
        {
            this.ID = Vehicle.GenerateID();
            this.CurrentNode = StartNode;

            if (this.CurrentNode.LastPassedVehicle != null && !this.CurrentNode.LastPassedVehicle.Disposed)
            {
                this.VehicleInFront = this.CurrentNode.LastPassedVehicle;
            }

            if (this.CurrentNode.LastPassedSecondLaneVehicle != null && !this.CurrentNode.LastPassedSecondLaneVehicle.Disposed)
            {
                this.SecondVehicleInFront = this.CurrentNode.LastPassedSecondLaneVehicle;
            }

            this.CurrentSpeed = MaxSpeed;
            this.MaxSpeed = MaxSpeed;
            this.Acceleration = Acceleration;
            this.DefaultRotation = DefaultRotation;
            this.Height = Height;
            this.Width = Width;
            this.VehicleType = VehicleType;
            this.Color = VehicleColor;
            this.CurrentSpeed = 0;
            this.CurrentPosition = this.CurrentNode.CurrentPosition;
            this.EndDirection = EndDirection;
            this.Rotation = DefaultRotation;

            this.CurrentShape = new Rectangle();
            this.CurrentShape.Height = this.Height;
            this.CurrentShape.Width = this.Width;
            this.CurrentShape.RenderTransformOrigin = new Point(0.5, 0.5);
            this.CurrentShape.HorizontalAlignment = HorizontalAlignment.Center;
            this.CurrentShape.VerticalAlignment = VerticalAlignment.Center;

            this.UpdateCarShape();

            this.CurrentShape.Fill = new SolidColorBrush(this.Color);
            Map.Instance.Children.Add(this.CurrentShape);
            Map.SetZIndex(this.CurrentShape, 255);

            VehicleHandler.CurrentVehicles.Add(this);
            this.TargetNode = DijkstraCalculationHandler.Instance.CalculateNextNodeForVehicle(this);

            this.CurrentPath = this.CurrentNode.GetPathByDestinationNode(this.TargetNode);
        }

        private static int CurrentIDCount = 0;
        private static int GenerateID()
        {
            return ++CurrentIDCount;
        }

        public virtual void Update()
        {
            try
            {
                this.Rotation = (float)Position.GetAngleBetweenPoints(this.CurrentNode.CurrentPosition, this.TargetNode.CurrentPosition);
                this.DetermineVehicleState();
                this.DetermineSpeed();

                this.CurrentDistanceOfPathTraveled += this.CurrentSpeed;
                this.CurrentPercentOfPathTraveled = (float)(((float)this.CurrentDistanceOfPathTraveled / (float)this.CurrentPath.Length)) * 100;

                float DifferenceX = this.CurrentNode.CurrentPosition.X - this.TargetNode.CurrentPosition.X;
                float DifferenceY = this.CurrentNode.CurrentPosition.Y - this.TargetNode.CurrentPosition.Y;

                this.CurrentPosition = new Position((this.CurrentNode.CurrentPosition.X - DifferenceX * this.CurrentPercentOfPathTraveled), (this.CurrentNode.CurrentPosition.Y - DifferenceY * this.CurrentPercentOfPathTraveled));

                if (this.CurrentPercentOfPathTraveled >= 1)
                {
                    if (this.TargetNode is ExitNode)
                    {
                        this.Dispose();
                        return;
                    }

                    this.CurrentNode = this.TargetNode;
                    this.VehicleInFront = this.CurrentNode.LastPassedVehicle;
                    this.SecondVehicleInFront = this.CurrentNode.LastPassedSecondLaneVehicle;
                    this.TargetNode = DijkstraCalculationHandler.Instance.CalculateNextNodeForVehicle(this);

                    this.CurrentPath.RemoveVehicle();
                    this.CurrentPath = this.CurrentNode.GetPathByDestinationNode(this.TargetNode);
                    this.CurrentPath.AddVehicle();
                    this.CurrentDistanceOfPathTraveled = 0;
                }

                

                this.UpdateCarShape();
            }
            catch (Exception)
            {

            }
        }

        private void DetermineVehicleState()
        {
            VehicleState vehicleState = VehicleState.Driving;

            vehicleState = this.DetermineVehicleStateByVehicleInFront(this.VehicleInFront);

            if (vehicleState == VehicleState.Driving)
            {
                vehicleState = this.DetermineVehicleStateByVehicleInFront(this.SecondVehicleInFront);
            }

            if (CurrentNode is TrafficLightWaitNode && ((CurrentNode as TrafficLightWaitNode).Paths.First().Destination as TrafficLight).State != TrafficLightState.Groen)
            {
                vehicleState = VehicleState.Stopping;
            }

            if (this.TargetNode is LaneSwitchNode && (this.TargetNode as LaneSwitchNode).VehicleQueue.Count > 0 &&
                (this.TargetNode as LaneSwitchNode).VehicleQueue.First() != this && this.TargetNode.LastPassed > DateTime.Now.AddMilliseconds(-1500))
            {
                vehicleState = VehicleState.Stopping;
                this.CurrentSpeed = 0;
            }

            this.vehicleState = vehicleState;
        }

        private VehicleState DetermineVehicleStateByVehicleInFront(Vehicle vehicle)
        {
            VehicleState vehicleState = VehicleState.Driving;

            if (vehicle != null && !vehicle.Disposed && vehicle != this &&
                (
                (this.TargetNode == vehicle.TargetNode || this.TargetNode == vehicle.CurrentNode)
                || this.CurrentNode.Paths.Count == 1))
            {
                //calculate vehicle diffrene
                float DifX = vehicle.CurrentPosition.X - CurrentPosition.X;
                float DifY = vehicle.CurrentPosition.Y - CurrentPosition.Y;

                DifX = (DifX < 0) ? DifX * -1 : DifX;
                DifY = (DifY < 0) ? DifY * -1 : DifY;

                if (DifX < 45 && DifY < 45)
                {
                    vehicleState = VehicleState.Stopping;
                }

                if (DifX < 20 && DifY < 20)
                {
                    this.CurrentSpeed = 0;
                }
            }

            return vehicleState;
        }

        private void DetermineSpeed()
        {
            if (this.vehicleState == VehicleState.Driving && this.CurrentSpeed < this.MaxSpeed)
            {
                this.CurrentSpeed += Acceleration;

                if (this.CurrentSpeed > this.MaxSpeed)
                {
                    this.CurrentSpeed = this.MaxSpeed;
                }
            }

            if (this.vehicleState == VehicleState.Stopping && this.CurrentSpeed > 0)
            {
                this.CurrentSpeed -= Acceleration;

                if (this.CurrentSpeed < 0)
                {
                    this.CurrentSpeed = 0;
                }
            }
        }

        private void UpdateCarShape()
        {
            Thread CurrentThread = Thread.CurrentThread;

            try
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    try
                    {
                        //Rotation arround center, bounding box required arround rotated rectangle
                        RotateTransform CurrentTransformation = new RotateTransform(this.Rotation, this.CurrentPosition.X, this.CurrentPosition.Y);

                        Point TransformedTopLeft = CurrentTransformation.Transform(new Point(this.CurrentPosition.X - (this.Width / 2), this.CurrentPosition.Y - (this.Height / 2)));
                        Point TransformedTopRight = CurrentTransformation.Transform(new Point(this.CurrentPosition.X + (this.Width / 2), this.CurrentPosition.Y - (this.Height / 2)));
                        Point TransformedBottomLeft = CurrentTransformation.Transform(new Point(this.CurrentPosition.X - (this.Width / 2), this.CurrentPosition.Y + (this.Height / 2)));
                        Point TransformedBottomRight = CurrentTransformation.Transform(new Point(this.CurrentPosition.X + (this.Width / 2), this.CurrentPosition.Y + (this.Height / 2)));

                        Rect BoundingBox = this.GetBoundingBox(new Point[] { TransformedTopLeft, TransformedTopRight, TransformedBottomLeft, TransformedBottomRight });

                        try
                        {
                            this.CurrentShape.Margin = new Thickness(this.CurrentPosition.X - (BoundingBox.Width / 2), this.CurrentPosition.Y - (BoundingBox.Height / 2), 0, 0);
                            this.CurrentShape.LayoutTransform = CurrentTransformation;
                        }
                        catch
                        {

                        }
                    }
                    catch (Exception)
                    {
                        CurrentThread.Abort();
                        Thread.CurrentThread.Abort();
                    }
                }));
            }
            catch (Exception)
            {
                Thread.CurrentThread.Abort();
            }
        }

        private Rect GetBoundingBox(Point[] Points)
        {
            Double LowestX = double.MaxValue;
            Double HighestX = 0;
            Double LowestY =  double.MaxValue;
            Double HighestY = 0;

            foreach (Point p in Points)
            {
                if (p.X < LowestX)
                {
                    LowestX = p.X;
                }

                if (p.X > HighestX)
                {
                    HighestX = p.X;
                }

                 if (p.Y < LowestY)
                {
                    LowestY = p.Y;
                }

                if (p.Y > HighestY)
                {
                    HighestY = p.Y;
                }
            }

            return new Rect(new Point(LowestX, LowestY), new Point(HighestX, HighestY));
        }

        public void Dispose()
        {
            VehicleHandler.CurrentVehicles.Remove(this);
            this.Disposed = true;

            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                try
                {
                    Map.Instance.Children.Remove(this.CurrentShape);
                }
                catch (Exception)
                {
                    LogHandler.Instance.Write("Could not remove vehicle from the map", LogType.Warning);
                }
            }));  
        }
    }
}
