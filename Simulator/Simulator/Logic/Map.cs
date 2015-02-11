using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace Simulator.UserControls
{
    public class Map : Canvas
    {
        //Static instance
        public static Map Instance { get; private set; }
        

        public List<Node> StartPoints { get; private set; }
        public Nodes nodes { get; private set; }
        

        public Map() : base()
        {
            //SetMap instance
            Instance = this;

            //Initialize Node List
            this.StartPoints = new List<Node>();

            this.nodes = new Nodes();
            //Create nodes to their end points
            this.CreateNodes();

            //Draw Figures on canvas
            this.Draw();
        }

        private void CreateNodes()
        {
            //Eerst simpel daarna veel nodes maken
            this.AddStartNodes();
            this.BuildRoadFromSouth();
            this.BuildRoadFromWest();
            this.BuildRoadFromEast();
            this.BuildRoadFromNorth();
            this.BuidVentweg();
        }

        public void Draw()
        {
            foreach (Node n in this.StartPoints)
            {
                n.Draw();
            }
        }

        public void AddStartNodes()
        {
            StartPoints.Add(this.nodes.EntryNode1);
            StartPoints.Add(this.nodes.EntryNode2);
            StartPoints.Add(this.nodes.EntryNode3);
            StartPoints.Add(this.nodes.EntryNode4);
            StartPoints.Add(this.nodes.EntryNode8);
        }

        private void BuildIntersection1()
        {

        }

        private void BuildRoadFromSouth()
        {
            Color Red = Colors.Red;

            Node CurrentNode = new EntryNode(new Position(400, 786), Red);
            


            CurrentNode = CurrentNode.AddNode(this.nodes.NodeD); //Kruispunt 1 RechtsOnder
            CurrentNode.AddNode(this.nodes.NodeB);  //Kruispunt 1 RechtsBoven

            this.nodes.NodeB.AddNode(this.nodes.NodeA); //Kruispunt 1 LinksBoven

            this.nodes.NodeA.AddNode(new ExitNode(new Position(0, 343), Direction.West, Red));

            CurrentNode = CurrentNode.AddNode(this.nodes.NodeI); //EntraceFromVentweg

            CurrentNode = CurrentNode.AddNode(this.nodes.NodeJ);  //ExitFromVentweg

            CurrentNode = CurrentNode.AddNode(this.nodes.NodeG); //Kruispunt2 LinksOnder

            CurrentNode = CurrentNode.AddNode(this.nodes.NodeH);//Kruispunt2 Rechtsonder

            CurrentNode.AddNode(this.nodes.NodeF1); //Kruispunt2 RechtsBoven

            //CurrentNode.AddNode(this.nodes.NodeF3); //Kruispunt2 RechtsBoven

           // this.nodes.NodeF3.AddNode(this.nodes.ExitNode1);
          //  CurrentNode.AddNode(this.nodes.ExitNode3);
        }

        private void BuildRoadFromWest()
        {
            Color Red = Colors.Red;

            //First node (Entry point west)
            Node CurrentNode = this.nodes.EntryNode8;
            StartPoints.Add(CurrentNode);

            //Second Node (First intersection)
            CurrentNode = CurrentNode.AddNode(this.nodes.NodeC);

            CurrentNode.AddNode(new ExitNode(new Position(350, 786), Direction.Oost, Red));
            CurrentNode.AddNode(this.nodes.NodeD);
        }

        private void BuildRoadFromEast()
        {
            this.nodes.EntryNode3.AddNode(this.nodes.Custom4);
            this.nodes.Custom4.AddNode(this.nodes.Custom5);
            this.nodes.Custom4.AddNode(this.nodes.Custom6);
            this.nodes.Custom5.AddNode(this.nodes.NodeF3);
            this.nodes.NodeF3.AddNode(this.nodes.ExitNode2);
            
            //this.nodes.Custom6.AddNode(this.nodes.NodeE3); uitgecomment om overzichtelijk te houden

            //this.nodes.EntryNode4.AddNode(this.nodes.NodeE2); uitgecomment om overzichtelijk te houden
        }

        private void BuildRoadFromNorth()
        {
            this.nodes.EntryNode1.AddNode(this.nodes.Custom1);
            this.nodes.Custom1.AddNode(this.nodes.Custom2);
            this.nodes.Custom2.AddNode(this.nodes.NodeE3);
            this.nodes.Custom1.AddNode(this.nodes.Custom3);
            this.nodes.Custom3.AddNode(this.nodes.NodeE2);

            this.nodes.EntryNode2.AddNode(this.nodes.NodeE1);

            

        }

        private void BuidVentweg()
        {
            //First node (Entry point Ventweg)
            Node CurrentNode = new EntryNode(new Position(580, 786), Colors.Red);
            StartPoints.Add(CurrentNode);
            CurrentNode = CurrentNode.AddNode(new Node(new Position(580, 443), Colors.Red));
            CurrentNode.AddNode(this.nodes.NodeI);

            CurrentNode = this.nodes.NodeJ.AddNode(new Node(new Position(790, 463), Colors.Red));
            CurrentNode = CurrentNode.AddNode(new Node(new Position(1150, 463), Colors.Red));
            CurrentNode.AddNode(new ExitNode(new Position(1368, 463), Direction.Ventweg, Colors.Red));
        } 
    }
}

