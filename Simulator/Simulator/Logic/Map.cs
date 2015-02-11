using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Simulator.UserControls
{
    public class Map : Canvas
    {
        public List<Node> StartPoints { get; private set; }

        private Node GreenLaneToVentwegNode;
        private Node VentwegToGreenLaneNode;

        public Map() : base()
        {
            this.StartPoints = new List<Node>();
            this.CreateNodes();
        }

        private void CreateNodes()
        {
            //Eerst simpel daarna veel nodes maken
            this.BuildGreenLane();
            
        }

        public void Draw()
        {
            foreach (Node n in this.StartPoints)
            {
                n.Draw();
            }
        }

        private void BuildGreenLane()
        {
            //First node (green line Fom Bottem)
            Node CurrentNode = new Node(this, new Position(300, 786));
            StartPoints.Add(CurrentNode);

            //Second Node (First intersection)
            CurrentNode = CurrentNode.AddNode(new Node(this, new Position(300, 220)));
            //Third node (Up/ Then left)
            Node TempNode = CurrentNode.AddNode(new Node(this, new Position(300, 170)));
            TempNode.AddNode(new Node(this, new Position(0, 170), Direction.West));
            //Fourth node (right (Ventweg entrance)) // Add VentwegOptions
            CurrentNode = CurrentNode.AddNode(new Node(this, new Position(700, 220)));
            this.VentwegToGreenLaneNode = CurrentNode;
            //Fifth node (right (Ventweg Exit)) // Add VentwegOptions
            CurrentNode = CurrentNode.AddNode(new Node(this, new Position(783, 220)));
            this.GreenLaneToVentwegNode = CurrentNode;

            //Sixth Node (second intersection)
            CurrentNode = CurrentNode.AddNode(new Node(this, new Position(1320, 220)));

            //Seventh node (NorthExit(upper))
            CurrentNode.AddNode(new Node(this, new Position(1320, 0), Direction.Noord));

            //Eight node (EastExit(right))
            CurrentNode.AddNode(new Node(this, new Position(1368, 220), Direction.Oost));
        }
    }
}
