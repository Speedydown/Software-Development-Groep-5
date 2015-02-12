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
        public Node EntryNode1 = new EntryNode(new Position(1000, 0), Colors.Red, "s1");
        public Node EntryNode2 = new EntryNode(new Position(1025, 0), Colors.Red, "s2");
        public Node EntryNode3 = new EntryNode(new Position(1368, 300), Colors.Red, "s3");
        public Node EntryNode4 = new EntryNode(new Position(1368, 325), Colors.Red, "s4");
        public Node EntryNode5 = new EntryNode(new Position(450, 786), Colors.Red, "s5");
        public Node EntryNode6 = new EntryNode(new Position(425, 786), Colors.Red, "s6");
        public Node EntryNode7 = new EntryNode(new Position(0, 425), Colors.Red, "s7");

        public Node EntryNode8 = new EntryNode(new Position(500, 786), Colors.Red, "s8");

        //Intersection Nodes
        public Node NodeA1 = new Node(new Position(350, 375), Colors.Red, "A1");
        public Node NodeA2 = new Node(new Position(325, 350), Colors.Red, "A2");
        public Node NodeB1 = new Node(new Position(375, 325), Colors.Red, "B1");
        public Node NodeB2 = new Node(new Position(400, 300), Colors.Red, "B2");
        public Node NodeC1 = new Node(new Position(350, 450), Colors.Red, "C1");
        public Node NodeC2 = new Node(new Position(325, 475), Colors.Red, "C2");
        public Node NodeD1 = new Node(new Position(425, 400), Colors.Red, "D1");
        public Node NodeD2 = new Node(new Position(450, 425), Colors.Red, "D2");
        public Node NodeE1 = new Node(new Position(1000, 325), Colors.Red, "E1");
        public Node NodeE2 = new Node(new Position(975, 300), Colors.Red, "E2");
        public Node NodeF1 = new Node(new Position(1075, 275), Colors.Red, "F1");
        public Node NodeF2 = new Node(new Position(1100, 250), Colors.Red, "F2");
        public Node NodeH1 = new Node(new Position(1075, 350), Colors.Red, "H1");
        public Node NodeH2 = new Node(new Position(1100, 375), Colors.Red, "H2");
        public Node NodeI = new Node(new Position(550, 425), Colors.Red, "I");
        public Node NodeJ = new Node(new Position(620, 425), Colors.Red, "J");
        public Node NodeK = new Node(new Position(1275, 425), Colors.Red, "K");
        public Node NodeG1 = new Node(new Position(1050, 400), Colors.Red, "G1");
        public Node NodeG2 = new Node(new Position(1025, 425), Colors.Red, "G2");

        //ExitNodes
        public Node ExitNode1 = new ExitNode(new Position(1075, 0), Direction.Noord, Colors.Red, "e1");
        public Node ExitNode2 = new ExitNode(new Position(1100, 0), Direction.Noord, Colors.Red, "e2");
        public Node ExitNode3 = new ExitNode(new Position(1368, 400), Direction.Oost, Colors.Red, "e3");
        public Node ExitNode4 = new ExitNode(new Position(1368, 425), Direction.Oost, Colors.Red, "e4");
        public Node ExitNode5 = new ExitNode(new Position(350, 786), Direction.Zuid, Colors.Red, "e5");
        public Node ExitNode6 = new ExitNode(new Position(325, 786), Direction.Zuid, Colors.Red, "e6");
        public Node ExitNode7 = new ExitNode(new Position(0, 325), Direction.West, Colors.Red, "e7");
        public Node ExitNode8 = new ExitNode(new Position(0, 300), Direction.West, Colors.Red, "e8");

        //CustomNodes
        public Node Custom1 = new Node(new Position(1000, 100), Colors.Red, "1");
        public Node Custom2 = new Node(new Position(975, 150), Colors.Red, "2");

        public Node Custom20 = new Node(new Position(1300, 300), Colors.Red, "20");
        public Node Custom21 = new Node(new Position(1250, 275), Colors.Red, "21");
        public Node Custom22 = new Node(new Position(1200, 250), Colors.Red, "22");

        public Node Custom30 = new Node(new Position(770, 325), Colors.Red, "30");
        public Node Custom31 = new Node(new Position(720, 350), Colors.Red, "31");
        public Node Custom32 = new Node(new Position(670, 375), Colors.Red, "32");

        public Node Custom10 = new Node(new Position(1200, 318), Colors.Red, "10");

        public Node Custom40 = new Node(new Position(720, 400), Colors.Red, "40");
        public Node Custom41 = new Node(new Position(770, 375), Colors.Red, "41");
        public Node Custom42 = new Node(new Position(820, 350), Colors.Red, "42");

        public Node Custom50 = new Node(new Position(100, 425), Colors.Red, "50");
        public Node Custom51 = new Node(new Position(150, 450), Colors.Red, "51");
        public Node Custom52 = new Node(new Position(200, 475), Colors.Red, "52");
        public Node Custom53 = new Node(new Position(150, 400), Colors.Red, "53");

        public Node Custom60 = new Node(new Position(425, 700), Colors.Red, "60");
        public Node Custom61 = new Node(new Position(400, 650), Colors.Red, "61");
        public Node Custom62 = new Node(new Position(375, 600), Colors.Red, "62");

        public Node Custom70 = new Node(new Position(500, 500), Colors.Red, "70");
        public Node Custom71 = new Node(new Position(690, 475), Colors.Red, "71");
        public Node Custom72 = new Node(new Position(1225, 475), Colors.Red, "72");
        

        public Nodes()
        {
            
        }
    }
}
