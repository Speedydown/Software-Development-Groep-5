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
        //Static instance
        public static Map Instance { get; private set; }


        public List<Node> StartPoints { get; private set; }

        private Node NodeA;
        private Node NodeB;
        private Node NodeC;
        private Node NodeD;
        private Node NodeE;
        private Node NodeF;
        private Node NodeG;
        private Node NodeH;
        private Node NodeI;
        private Node NodeJ;

        public Map() : base()
        {
            //SetMap instance
            Instance = this;

            //Initialize Node List
            this.StartPoints = new List<Node>();

            //Create nodes to their end points
            this.CreateNodes();

            //Draw Figures on canvas
            this.Draw();
        }

        private void CreateNodes()
        {
            //Eerst simpel daarna veel nodes maken
            this.BuildRoadFromSouth();
            this.BuildRoadFromWest();
            this.BuildRoadFromEast();
            this.BuildRoadFromNorth();
        }

        public void Draw()
        {
            foreach (Node n in this.StartPoints)
            {
                n.Draw();
            }
        }

        private void BuildRoadFromSouth()
        {
            Node CurrentNode = new EntryNode(this, new Position(400, 786));
            StartPoints.Add(CurrentNode);

            
            CurrentNode = CurrentNode.AddNode(new Node(this, new Position(400, 393)));
            this.NodeA = CurrentNode;
            this.NodeA.SetLabel("A"); //Kruispunt 1 RechtsOnder

            this.NodeB = CurrentNode.AddNode(new Node(this, new Position(400, 343)));
            this.NodeB.SetLabel("B"); //Kruispunt 1 RechtsBoven

            this.NodeC = this.NodeB.AddNode(new Node(this, new Position(350, 343)));
            this.NodeC.SetLabel("C"); //Kruispunt 1 LinksBoven

            this.NodeC.AddNode(new ExitNode(this, new Position(0, 343), Direction.West));
            
            CurrentNode = CurrentNode.AddNode(new Node(this, new Position(650, 393)));
            this.NodeD = CurrentNode;
            this.NodeD.SetLabel("D"); //EntraceFromVentweg

            CurrentNode = CurrentNode.AddNode(new Node(this, new Position(720, 393)));
            this.NodeE = CurrentNode;
            this.NodeE.SetLabel("E"); //ExitFromVentweg

            CurrentNode = CurrentNode.AddNode(new Node(this, new Position(1050, 393)));
            this.NodeF = CurrentNode;
            this.NodeF.SetLabel("F"); //Kruispunt2 LinksOnder

            CurrentNode = CurrentNode.AddNode(new Node(this, new Position(1100, 393)));
            this.NodeJ = CurrentNode;
            this.NodeJ.SetLabel("J"); //Kruispunt2 Rechtsonder

            this.NodeG = CurrentNode.AddNode(new Node(this, new Position(1100, 343)));
            this.NodeG.SetLabel("G"); //Kruispunt2 RechtsBoven

            this.NodeG.AddNode(new ExitNode(this, new Position(1100, 0), Direction.Noord));
            CurrentNode.AddNode(new ExitNode(this, new Position(1368, 393), Direction.Oost));
        }

        private void BuildRoadFromWest()
        {
            //First node (Entry point west)
            Node CurrentNode = new EntryNode(this, new Position(0, 393));
            StartPoints.Add(CurrentNode);

            //Second Node (First intersection)
            CurrentNode = CurrentNode.AddNode(new Node(this, new Position(350, 393)));
            this.NodeH = CurrentNode;
            this.NodeH.SetLabel("H"); // Kruispunt1 LinksOnder
            CurrentNode.AddNode(new ExitNode(this, new Position(350, 786), Direction.Oost));
            CurrentNode.AddNode(this.NodeA);
        }

        private void BuildRoadFromEast()
        {
            //First node (Entry point East)
            Node CurrentNode = new EntryNode(this, new Position(1368, 343));
            StartPoints.Add(CurrentNode);

            CurrentNode = CurrentNode.AddNode(this.NodeG);
            CurrentNode = CurrentNode.AddNode(new Node(this, new Position(1050, 343)));
            this.NodeI = CurrentNode;
            this.NodeI.SetLabel("I");
            CurrentNode.AddNode(NodeB);

            this.NodeC.AddNode(this.NodeH);

        }

        private void BuildRoadFromNorth()
        {
            //First node (Entry point North)
            Node CurrentNode = new EntryNode(this, new Position(1050, 0));
            StartPoints.Add(CurrentNode);

            CurrentNode.AddNode(this.NodeI);
            this.NodeI.AddNode(this.NodeF);
        }
    }
}
