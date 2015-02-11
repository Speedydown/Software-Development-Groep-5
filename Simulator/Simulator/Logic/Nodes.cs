using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Simulator
{
    public class Nodes
    {
        //StartingNodes
        public Node EntryNode1 = new EntryNode(new Position(1025, 0), Colors.Red, "s1");
        public Node EntryNode2 = new EntryNode(new Position(1050, 0), Colors.Red, "s2");
        public Node EntryNode3 = new EntryNode(new Position(1368, 318), Colors.Red, "s3");
        public Node EntryNode4 = new EntryNode(new Position(1368, 343), Colors.Red, "s4");
        
        public Node EntryNode8 = new EntryNode(new Position(0, 393), Colors.Red, "s8");

        //Intersection Nodes
        public Node NodeA = new Node(new Position(350, 343), Colors.Red, "A");
        public Node NodeB = new Node(new Position(400, 343), Colors.Red, "B");
        public Node NodeC = new Node(new Position(350, 393), Colors.Red, "C");
        public Node NodeD = new Node(new Position(400, 393), Colors.Red, "D");
        public Node NodeE1 = new Node(new Position(1050, 343), Colors.Red, "E1");
        public Node NodeE2 = new Node(new Position(1025, 343), Colors.Red, "E2");
        public Node NodeE3 = new Node(new Position(1000, 318), Colors.Red, "E3");
        public Node NodeF1 = new Node(new Position(1100, 343), Colors.Red, "F1");
        public Node NodeF2 = new Node(new Position(1125, 343), Colors.Red, "F2");
        public Node NodeF3 = new Node(new Position(1125, 293), Colors.Red, "F3");
        public Node NodeF4 = new Node(new Position(1125, 318), Colors.Red, "F4");
        public Node NodeH = new Node(new Position(1100, 393), Colors.Red, "H");
        public Node NodeI = new Node(new Position(650, 393), Colors.Red, "I");
        public Node NodeJ = new Node(new Position(720, 393), Colors.Red, "J");
        public Node NodeG = new Node(new Position(1050, 393), Colors.Red, "G");

        //ExitNodes
        public Node ExitNode1 = new ExitNode(new Position(1100, 0), Direction.Noord, Colors.Red, "e1");
        public Node ExitNode2 = new ExitNode(new Position(1125, 0), Direction.Noord, Colors.Red, "e2");
        public Node ExitNode3 = new ExitNode(new Position(1368, 393), Direction.Oost, Colors.Red, "e3");
        public Node ExitNode4 = new ExitNode(new Position(1368, 418), Direction.Oost, Colors.Red, "e4");

        //CustomNodes
        public Node Custom1 = new Node(new Position(1025, 200), Colors.Red, "c1");
        public Node Custom2 = new Node(new Position(1000, 250), Colors.Red, "c2");
        public Node Custom3 = new Node(new Position(1025, 250), Colors.Red, "c3");
        public Node Custom4 = new Node(new Position(1250, 318), Colors.Red, "c4");
        public Node Custom5 = new Node(new Position(1200, 293), Colors.Red, "c5");
        public Node Custom6 = new Node(new Position(1200, 318), Colors.Red, "c6");


        public Node Custom10 = new Node(new Position(1200, 318), Colors.Red, "c10");

        public Nodes()
        {
            
        }
    }
}
