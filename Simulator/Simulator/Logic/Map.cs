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
            StartPoints.Add(this.nodes.EntryNode5);
            StartPoints.Add(this.nodes.EntryNode6);
            StartPoints.Add(this.nodes.EntryNode7);
            StartPoints.Add(this.nodes.EntryNode8);
        }

        private void BuildIntersection1()
        {

        }

        private void BuildRoadFromSouth()
        {
            this.nodes.EntryNode6.AddNode(this.nodes.Custom60);
            this.nodes.Custom60.AddNode(this.nodes.Custom61);
            this.nodes.Custom61.AddNode(this.nodes.Custom62);
            this.nodes.Custom61.AddNode(this.nodes.NodeB2);
            this.nodes.Custom62.AddNode(this.nodes.NodeB1);

            this.nodes.NodeB1.AddNode(this.nodes.ExitNode7);
            this.nodes.NodeB2.AddNode(this.nodes.ExitNode8);

            this.nodes.Custom60.AddNode(this.nodes.NodeD1);

            this.nodes.EntryNode5.AddNode(this.nodes.NodeD2);
        }


        private void BuildRoadFromWest()
        {
            this.nodes.EntryNode7.AddNode(this.nodes.Custom50);
            this.nodes.Custom50.AddNode(this.nodes.Custom51);
            this.nodes.Custom50.AddNode(this.nodes.Custom53);
            this.nodes.Custom50.AddNode(this.nodes.NodeD2);
            this.nodes.Custom51.AddNode(this.nodes.Custom52);
            this.nodes.Custom51.AddNode(this.nodes.NodeC1);
            this.nodes.Custom52.AddNode(this.nodes.NodeC2);
            this.nodes.NodeC1.AddNode(this.nodes.ExitNode5);
            this.nodes.NodeC2.AddNode(this.nodes.ExitNode6);
            this.nodes.Custom53.AddNode(this.nodes.NodeD1);
            this.nodes.NodeD2.AddNode(this.nodes.NodeI);
            this.nodes.NodeI.AddNode(this.nodes.NodeJ);
            this.nodes.NodeJ.AddNode(this.nodes.NodeG2);
            this.nodes.NodeD1.AddNode(this.nodes.Custom40);
            this.nodes.Custom40.AddNode(this.nodes.Custom41);
            this.nodes.Custom40.AddNode(this.nodes.NodeG1);
            this.nodes.Custom41.AddNode(this.nodes.Custom42);
            this.nodes.Custom41.AddNode(this.nodes.NodeH2);
            this.nodes.Custom42.AddNode(this.nodes.NodeH1);
            this.nodes.NodeG1.AddNode(this.nodes.ExitNode3);
            this.nodes.NodeG2.AddNode(this.nodes.NodeK);
            this.nodes.NodeK.AddNode(this.nodes.ExitNode4);
            this.nodes.NodeH1.AddNode(this.nodes.NodeF1);
            this.nodes.NodeH2.AddNode(this.nodes.NodeF2);
        }

        private void BuildRoadFromEast()
        {
            this.nodes.EntryNode3.AddNode(this.nodes.Custom20);
            this.nodes.Custom20.AddNode(this.nodes.Custom21);
            this.nodes.Custom21.AddNode(this.nodes.Custom22);
            this.nodes.Custom21.AddNode(this.nodes.NodeF1);
            this.nodes.Custom22.AddNode(this.nodes.NodeF2);
            this.nodes.NodeF1.AddNode(this.nodes.ExitNode1);
            this.nodes.NodeF2.AddNode(this.nodes.ExitNode2);
            this.nodes.EntryNode4.AddNode(this.nodes.NodeE1);
            this.nodes.Custom20.AddNode(this.nodes.NodeE2);
        }

        private void BuildRoadFromNorth()
        {
            this.nodes.EntryNode1.AddNode(this.nodes.Custom1);
            this.nodes.Custom1.AddNode(this.nodes.Custom2);
            this.nodes.Custom2.AddNode(this.nodes.NodeE2);
            this.nodes.Custom1.AddNode(this.nodes.NodeE1);

            this.nodes.EntryNode2.AddNode(this.nodes.NodeG2);
            this.nodes.NodeE2.AddNode(this.nodes.NodeB2);

            this.nodes.NodeE1.AddNode(this.nodes.Custom30);
            this.nodes.Custom30.AddNode(this.nodes.Custom31);
            this.nodes.Custom30.AddNode(this.nodes.NodeB1);
            this.nodes.Custom31.AddNode(this.nodes.Custom32);
            this.nodes.Custom31.AddNode(this.nodes.NodeA2);
            this.nodes.Custom32.AddNode(this.nodes.NodeA1);
            this.nodes.NodeA1.AddNode(this.nodes.NodeC1);
            this.nodes.NodeA2.AddNode(this.nodes.NodeC2);

            

        }

        private void BuidVentweg()
        {
            this.nodes.EntryNode8.AddNode(this.nodes.Custom70);
            this.nodes.Custom70.AddNode(this.nodes.NodeI);
            this.nodes.NodeJ.AddNode(this.nodes.Custom71);
            this.nodes.Custom71.AddNode(this.nodes.Custom72);
            this.nodes.Custom72.AddNode(this.nodes.NodeK);
        } 
    }
}

