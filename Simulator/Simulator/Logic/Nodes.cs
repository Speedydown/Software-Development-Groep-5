using Simulator.Dijkstra;
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
        public Node EntryNode1 = new EntryNode(new Position(1200, -100), Direction.Noord, new VehicleType[] { VehicleType.Auto, VehicleType.Bus }, "s1");
        public Node EntryNode2 = new EntryNode(new Position(1218, -100), Direction.Noord, new VehicleType[] { VehicleType.Auto, VehicleType.Bus }, "s2");
        public Node EntryNode3 = new EntryNode(new Position(2015, 300), Direction.Oost, new VehicleType[] { VehicleType.Auto, VehicleType.Bus }, "s3");
        public Node EntryNode4 = new EntryNode(new Position(2015, 318), Direction.Oost, new VehicleType[] { VehicleType.Auto, VehicleType.Bus }, "s4");
        public Node EntryNode5 = new EntryNode(new Position(443, 1055), Direction.Zuid, new VehicleType[] { VehicleType.Auto, VehicleType.Bus }, "s5");
        public Node EntryNode6 = new EntryNode(new Position(425, 1055), Direction.Zuid, new VehicleType[] { VehicleType.Auto, VehicleType.Bus }, "s6");
        public Node EntryNode7 = new EntryNode(new Position(0, 418), Direction.West, new VehicleType[] { VehicleType.Auto, VehicleType.Bus }, "s7");
        public Node EntryNode8 = new EntryNode(new Position(1000, 675), Direction.Ventweg, new VehicleType[] { VehicleType.Auto, VehicleType.Bus, VehicleType.Fiets, VehicleType.Voetganger }, "s8");
        public Node EntryNode9 = new EntryNode(new Position(0, 495), Direction.West, new VehicleType[] { VehicleType.Fiets }, "s9", Colors.Purple);
        public Node EntryNode10 = new EntryNode(new Position(395, 0), Direction.Noord, new VehicleType[] { VehicleType.Fiets }, "s10", Colors.Purple);
        public Node EntryNode11 = new EntryNode(new Position(1915, 240), Direction.Oost, new VehicleType[] { VehicleType.Fiets }, "s11", Colors.Purple);
        public Node EntryNode12 = new EntryNode(new Position(510, 1055), Direction.Zuid, new VehicleType[] { VehicleType.Fiets }, "s12", Colors.Purple);
        public Node EntryNode13 = new EntryNode(new Position(0, 505), Direction.West, new VehicleType[] { VehicleType.Voetganger }, "s13", Colors.Green);
        public Node EntryNode14 = new EntryNode(new Position(0, 261), Direction.West, new VehicleType[] { VehicleType.Voetganger }, "s14", Colors.Green);
        public Node EntryNode15 = new EntryNode(new Position(415, 0), Direction.Noord, new VehicleType[] { VehicleType.Voetganger }, "s15", Colors.Green);
        public Node EntryNode16 = new EntryNode(new Position(302, 1055), Direction.Zuid, new VehicleType[] { VehicleType.Voetganger }, "s16", Colors.Green);
        public Node EntryNode17 = new EntryNode(new Position(525, 1055), Direction.Zuid, new VehicleType[] { VehicleType.Voetganger }, "s17", Colors.Green);
        public Node EntryNode18 = new EntryNode(new Position(1318, 0), Direction.Noord, new VehicleType[] { VehicleType.Voetganger }, "s18", Colors.Green);
        public Node EntryNode19 = new EntryNode(new Position(2015, 230), Direction.Oost, new VehicleType[] { VehicleType.Voetganger }, "s19", Colors.Green);
        public Node EntryNode20 = new EntryNode(new Position(2015, 490), Direction.Oost, new VehicleType[] { VehicleType.Voetganger }, "s20", Colors.Green);

        //Intersection Nodes
        public Node NodeA1 = new Node(new Position(343, 354), "A1");
        public Node NodeA2 = new Node(new Position(325, 336), "A2");
        public Node NodeB1 = new Node(new Position(389, 318), "B1");
        public Node NodeB2 = new Node(new Position(407, 300), "B2");
        public Node NodeC1 = new Node(new Position(343, 436), "C1");
        public Node NodeC2 = new Node(new Position(325, 454), "C2");
        public Node NodeD1 = new Node(new Position(425, 400), "D1");
        public Node NodeD2 = new Node(new Position(443, 418), "D2");
        public Node NodeE1 = new Node(new Position(1200, 318), "E1");
        public Node NodeE2 = new Node(new Position(1182, 300), "E2");
        public Node NodeF1 = new Node(new Position(1282, 282), "F1");
        public Node NodeF2 = new Node(new Position(1300, 264), "F2");
        public Node NodeH1 = new Node(new Position(1282, 364), "H1");
        public Node NodeH2 = new Node(new Position(1300, 382), "H2");
        public Node NodeI = new Node(new Position(550, 418), "I");
        public Node NodeJ = new Node(new Position(620, 418), "J");
        public Node NodeK = new Node(new Position(1475, 418), "K");
        public Node NodeG1 = new Node(new Position(1236, 400), "G1");
        public Node NodeG2 = new Node(new Position(1218, 418), "G2");

        //ExitNodes
        public Node ExitNode1 = new ExitNode(new Position(1282, 0), Direction.Noord, new VehicleType[] { VehicleType.Auto, VehicleType.Bus }, "e1");
        public Node ExitNode2 = new ExitNode(new Position(1300, 0), Direction.Noord, new VehicleType[] { VehicleType.Auto, VehicleType.Bus }, "e2");
        public Node ExitNode3 = new ExitNode(new Position(1915, 400), Direction.Oost, new VehicleType[] { VehicleType.Auto, VehicleType.Bus }, "e3");
        public Node ExitNode4 = new ExitNode(new Position(1915, 418), Direction.Oost, new VehicleType[] { VehicleType.Auto, VehicleType.Bus }, "e4");
        public Node ExitNode5 = new ExitNode(new Position(343, 1055), Direction.Zuid, new VehicleType[] { VehicleType.Auto, VehicleType.Bus }, "e5");
        public Node ExitNode6 = new ExitNode(new Position(325, 1055), Direction.Zuid, new VehicleType[] { VehicleType.Auto, VehicleType.Bus }, "e6");
        public Node ExitNode7 = new ExitNode(new Position(0, 318), Direction.West, new VehicleType[] { VehicleType.Auto, VehicleType.Bus }, "e7");
        public Node ExitNode8 = new ExitNode(new Position(0, 300), Direction.West, new VehicleType[] { VehicleType.Auto, VehicleType.Bus }, "e8");
        public Node ExitNode9 = new ExitNode(new Position(0, 275), Direction.West, new VehicleType[] { VehicleType.Fiets }, "e9", Colors.Purple);
        public Node ExitNode10 = new ExitNode(new Position(405, 0), Direction.Noord, new VehicleType[] { VehicleType.Fiets }, "e10", Colors.Purple);
        public Node ExitNode11 = new ExitNode(new Position(312, 1055), Direction.Zuid, new VehicleType[] { VehicleType.Fiets }, "e11", Colors.Purple);
        public Node ExitNode12 = new ExitNode(new Position(1915, 475), Direction.Oost, new VehicleType[] { VehicleType.Fiets }, "e12", Colors.Purple);
        public Node ExitNode13 = new ExitNode(new Position(0, 261), Direction.West, new VehicleType[] { VehicleType.Voetganger }, "e13", Colors.Green);
        public Node ExitNode14 = new ExitNode(new Position(0, 505), Direction.West, new VehicleType[] { VehicleType.Voetganger }, "e14", Colors.Green);
        public Node ExitNode15 = new ExitNode(new Position(415, 0), Direction.Noord, new VehicleType[] { VehicleType.Voetganger }, "e15", Colors.Green);
        public Node ExitNode16 = new ExitNode(new Position(302, 1055), Direction.Zuid, new VehicleType[] { VehicleType.Voetganger }, "e16", Colors.Green);
        public Node ExitNode17 = new ExitNode(new Position(525, 1055), Direction.Zuid, new VehicleType[] { VehicleType.Voetganger }, "e17", Colors.Green);
        public Node ExitNode18 = new ExitNode(new Position(1318, 0), Direction.Noord, new VehicleType[] { VehicleType.Voetganger }, "e18", Colors.Green);
        public Node ExitNode19 = new ExitNode(new Position(2015, 230), Direction.Oost, new VehicleType[] { VehicleType.Voetganger }, "e19", Colors.Green);
        public Node ExitNode20 = new ExitNode(new Position(2015, 490), Direction.Oost, new VehicleType[] { VehicleType.Voetganger }, "e20", Colors.Green);

        //CustomNodes
        public Node Custom1 = new Node(new Position(1200, 70), "1");
        public Node Custom3 = new Node(new Position(1218, 70), "3");

        public Node Custom20 = new Node(new Position(1700, 300), "20");
        public Node Custom21 = new Node(new Position(1650, 282), "21");

        public Node Custom30 = new Node(new Position(920, 318), "30");
        public Node Custom31 = new Node(new Position(870, 336), "31");

        public Node Custom10 = new Node(new Position(1200, 318), "10");

        public Node Custom40 = new Node(new Position(870, 400), "40");
        public Node Custom41 = new Node(new Position(920, 382), "41");

        public Node Custom50 = new Node(new Position(25, 418), "50");
        public Node Custom51 = new Node(new Position(100, 436), "51");
        public Node Custom52 = new Node(new Position(50, 418), "52");
        public Node Custom53 = new Node(new Position(75, 400), "53");

        public Node Custom60 = new Node(new Position(425, 950), "60");
        public Node Custom61 = new Node(new Position(407, 900), "61");
        public Node Custom62 = new Node(new Position(389, 850), "62");
        public Node Custom63 = new Node(new Position(443, 950), "63");

        public Node Custom70 = new Node(new Position(510, 520), "70", new VehicleType[] { VehicleType.Auto, VehicleType.Bus, VehicleType.Fiets });
        public Node Custom71 = new Node(new Position(690, 475), "71", new VehicleType[] { VehicleType.Auto, VehicleType.Bus, VehicleType.Fiets });
        public Node Custom72 = new Node(new Position(1350, 475), "72", new VehicleType[] { VehicleType.Auto, VehicleType.Bus, VehicleType.Fiets });
        public Node Custom73 = new Node(new Position(1425, 475), "73", new VehicleType[] { VehicleType.Auto, VehicleType.Bus, VehicleType.Fiets });
        public Node Custom74 = new Node(new Position(510, 675), "74", new VehicleType[] { VehicleType.Auto, VehicleType.Bus, VehicleType.Fiets });

        //BusNodes
        public Node Bus1 = new BusNode(new Position(1236, 150), "b1");
        public Node Bus2 = new BusNode(new Position(461, 900), "b2");
        public Node Bus4 = new BusNode(new Position(1600, 264), "b4");

        //LaneSwitchers
        public LaneSwitcher LaneSwitcher1 = new LaneSwitcher(
            new LaneSwitchNode(true, new Position(425, 1045)),
            new LaneSwitchNode(true, new Position(443, 1045)),
            new LaneSwitchNode(false, new Position(425, 1000)),
            new LaneSwitchNode(false, new Position(443, 1000))
            );

        public LaneSwitcher LaneSwitcher2 = new LaneSwitcher(
            new LaneSwitchNode(true, new Position(645, 400)),
            new LaneSwitchNode(true, new Position(645, 418)),
            new LaneSwitchNode(false, new Position(690, 400)),
            new LaneSwitchNode(false, new Position(690, 418)));

        public LaneSwitcher LaneSwitcher3 = new LaneSwitcher(
            new LaneSwitchNode(true, new Position(1218, 0)),
            new LaneSwitchNode(true, new Position(1200, 0)),
            new LaneSwitchNode(false, new Position(1218, 45)),
            new LaneSwitchNode(false, new Position(1200, 45)));

        public LaneSwitcher LaneSwitcher4 = new LaneSwitcher(
            new LaneSwitchNode(true, new Position(1915, 318)),
            new LaneSwitchNode(true, new Position(1915, 300)),
            new LaneSwitchNode(false, new Position(1870, 318)),
            new LaneSwitchNode(false, new Position(1870, 300)));

        public LaneSwitcher LaneSwitcher5 = new LaneSwitcher(
            new LaneSwitchNode(true, new Position(1150, 318)),
            new LaneSwitchNode(true, new Position(1150, 300)),
            new LaneSwitchNode(false, new Position(1105, 318)),
            new LaneSwitchNode(false, new Position(1105, 300)));

        public LaneSwitcher LaneSwitcher6 = new LaneSwitcher(
            new LaneSwitchNode(true, new Position(510, 725), new VehicleType[] { VehicleType.Fiets }),
            new LaneSwitchNode(true, new Position(535, 675)),
            new LaneSwitchNode(false, new Position(510, 625)),
            new LaneSwitchNode(false, new Position(510, 625)));

        //------------------Cycling routes---------------------------------------------
        public Node Nodec1 = new BicycleNode(new Position(278, 545), "1");
        public Node Nodec2 = new BicycleNode(new Position(510, 225), "2");
        public Node Nodec3 = new BicycleNode(new Position(405, 155), "3");
        public Node Nodec4 = new BicycleNode(new Position(395, 155), "4");
        public Node Nodec5 = new BicycleNode(new Position(278, 230), "5");
        public Node Nodec6 = new BicycleNode(new Position(287, 520), "6");
        public Node Nodec7 = new BicycleNode(new Position(225, 495), "7");
        public Node Nodec8 = new BicycleNode(new Position(500, 510), "8");
        public Node Nodec9 = new BicycleNode(new Position(500, 225), "9");
        public Node Nodec10 = new BicycleNode(new Position(287, 230), "10");
        public Node Nodec11 = new BicycleNode(new Position(312, 650), "11");
        public Node Nodec12 = new BicycleNode(new Position(560, 500), "12");
        public Node Nodec14 = new BicycleNode(new Position(1150, 240), "14");
        public Node Nodec15 = new BicycleNode(new Position(1080, 275), "15");
        public Node Nodec16 = new BicycleNode(new Position(225, 275), "16");
        public Node Nodec17 = new BicycleNode(new Position(580, 275), "17");

        //------------------Pedestrian routes---------------------------------------------
        public Node Nodep1 = new PedestrianNode(new Position(225, 505), "1");
        public Node Nodep2 = new PedestrianNode(new Position(267, 505), "2");
        public Node Nodep3 = new PedestrianNode(new Position(267, 225), "3");
        public Node Nodep4 = new PedestrianNode(new Position(225, 261), "4");
        public Node Nodep5 = new PedestrianNode(new Position(386, 150), "5");
        public Node Nodep6 = new PedestrianNode(new Position(415, 150), "6");
        public Node Nodep7 = new PedestrianNode(new Position(489, 200), "7");
        public Node Nodep8 = new PedestrianNode(new Position(489, 505), "8");
        public Node Nodep9 = new PedestrianNode(new Position(267, 555), "9");
        public Node Nodep10 = new PedestrianNode(new Position(302, 650), "10");
        public Node Nodep11 = new PedestrianNode(new Position(525, 525), "11");
        public Node Nodep12 = new PedestrianNode(new Position(580, 265), "12");
        public Node Nodep13 = new PedestrianNode(new Position(1080, 265), "13");
        public Node Nodep14 = new PedestrianNode(new Position(1150, 230), "14");
        public Node Nodep15 = new PedestrianNode(new Position(1350, 230), "15");
        public Node Nodep16 = new PedestrianNode(new Position(1318, 200), "16");
        public Node Nodep17 = new PedestrianNode(new Position(1350, 490), "17");
        public Node Nodep18 = new PedestrianNode(new Position(690, 490), "18");

        //------------------Traffic lights---------------------------------------------
        public NotificationNode TrafficLight0EntryLeft = new NotificationNode(0, true, new Position(820, 318), null);
        public TrafficLightWaitNode TrafficLight0WaitLeft = new TrafficLightWaitNode(new Position(545, 318));
        public TrafficLight TrafficLight0Left = new TrafficLight(0, new Position(475, 318), null);
        public NotificationNode TrafficLight0ExitLeft = new NotificationNode(0, false, new Position(450, 318), null);

        public NotificationNode TrafficLight0EntryRight = new NotificationNode(0, true, new Position(820, 300), null);
        public TrafficLightWaitNode TrafficLight0WaitRight = new TrafficLightWaitNode(new Position(545, 300));
        public TrafficLight TrafficLight0Right = new TrafficLight(0, new Position(475, 300), null);
        public NotificationNode TrafficLight0ExitRight = new NotificationNode(0, false, new Position(450, 300), null);

        public NotificationNode TrafficLight1EntryLeft = new NotificationNode(1, true, new Position(820, 354), null);
        public TrafficLightWaitNode TrafficLight1WaitLeft = new TrafficLightWaitNode(new Position(545, 354));
        public TrafficLight TrafficLight1Left = new TrafficLight(1, new Position(475, 354), null);
        public NotificationNode TrafficLight1ExitLeft = new NotificationNode(1, false, new Position(450, 354), null);

        public NotificationNode TrafficLight1EntryRight = new NotificationNode(1, true, new Position(820, 336), null);
        public TrafficLightWaitNode TrafficLight1WaitRight = new TrafficLightWaitNode(new Position(545, 336));
        public TrafficLight TrafficLight1Right = new TrafficLight(1, new Position(475, 336), null);
        public NotificationNode TrafficLight1ExitRight = new NotificationNode(1, false, new Position(450, 336), null);

        public NotificationNode TrafficLight2EntryLeft = new NotificationNode(2, true, new Position(150, 436), null);
        public TrafficLightWaitNode TrafficLight2WaitLeft = new TrafficLightWaitNode(new Position(225, 436));
        public TrafficLight TrafficLight2Left = new TrafficLight(2, new Position(305, 436), null);
        public NotificationNode TrafficLight2ExitLeft = new NotificationNode(2, false, new Position(320, 436), null);

        public NotificationNode TrafficLight2EntryRight = new NotificationNode(2, true, new Position(150, 454), null);
        public TrafficLightWaitNode TrafficLight2WaitRight = new TrafficLightWaitNode(new Position(225, 454));
        public TrafficLight TrafficLight2Right = new TrafficLight(2, new Position(305, 454), null);
        public NotificationNode TrafficLight2ExitRight = new NotificationNode(2, false, new Position(320, 454), null);

        public NotificationNode TrafficLight3EntryLeft = new NotificationNode(3, true, new Position(150, 400), null);
        public TrafficLightWaitNode TrafficLight3WaitLeft = new TrafficLightWaitNode(new Position(225, 400));
        public TrafficLight TrafficLight3Left = new TrafficLight(3, new Position(305, 400), null);
        public NotificationNode TrafficLight3ExitLeft = new NotificationNode(3, false, new Position(320, 400), null);

        public NotificationNode TrafficLight3EntryRight = new NotificationNode(3, true, new Position(150, 418), null);
        public TrafficLightWaitNode TrafficLight3WaitRight = new TrafficLightWaitNode(new Position(225, 418));
        public TrafficLight TrafficLight3Right = new TrafficLight(3, new Position(305, 418), null);
        public NotificationNode TrafficLight3ExitRight = new NotificationNode(3, false, new Position(320, 418), null);

        public NotificationNode TrafficLight4EntryLeft = new NotificationNode(4, true, new Position(389, 750), null);
        public TrafficLightWaitNode TrafficLight4WaitLeft = new TrafficLightWaitNode(new Position(389, 560));
        public TrafficLight TrafficLight4Left = new TrafficLight(4, new Position(389, 475), null);
        public NotificationNode TrafficLight4ExitLeft = new NotificationNode(4, false, new Position(389, 450), null);

        public NotificationNode TrafficLight4EntryRight = new NotificationNode(4, true, new Position(407, 750), null);
        public TrafficLightWaitNode TrafficLight4WaitRight = new TrafficLightWaitNode(new Position(407, 560));
        public TrafficLight TrafficLight4Right = new TrafficLight(4, new Position(407, 475), null);
        public NotificationNode TrafficLight4ExitRight = new NotificationNode(4, false, new Position(407, 450), null);

        public NotificationNode TrafficLight5EntryLeft = new NotificationNode(5, true, new Position(425, 750), null);
        public TrafficLightWaitNode TrafficLight5WaitLeft = new TrafficLightWaitNode(new Position(425, 560));
        public TrafficLight TrafficLight5Left = new TrafficLight(5, new Position(425, 475), null);
        public NotificationNode TrafficLight5ExitLeft = new NotificationNode(5, false, new Position(425, 450), null);

        public NotificationNode TrafficLight5EntryRight = new NotificationNode(5, true, new Position(443, 750), null);
        public TrafficLightWaitNode TrafficLight5WaitRight = new TrafficLightWaitNode(new Position(443, 560));
        public TrafficLight TrafficLight5Right = new TrafficLight(5, new Position(443, 475), null);
        public NotificationNode TrafficLight5ExitRight = new NotificationNode(5, false, new Position(443, 450), null);

        public NotificationNode TrafficLight6Entry = new NotificationNode(6, true, new Position(461, 750), null, Colors.Gold);
        public TrafficLightWaitNode TrafficLight6Wait = new TrafficLightWaitNode(new Position(461, 560));
        public TrafficLight TrafficLight6 = new TrafficLight(6, new Position(461, 475), null, Colors.Gold);
        public NotificationNode TrafficLight6Exit = new NotificationNode(6, false, new Position(461, 450), null, Colors.Gold);

        public NotificationNode TrafficLight7EntryLeft = new NotificationNode(7, true, new Position(970, 364), null);
        public TrafficLightWaitNode TrafficLight7WaitLeft = new TrafficLightWaitNode(new Position(1150, 364));
        public TrafficLight TrafficLigh7Left = new TrafficLight(7, new Position(1200, 364), null);
        public NotificationNode TrafficLight7ExitLeft = new NotificationNode(7, false, new Position(1218, 364), null);

        public NotificationNode TrafficLight7EntryRight = new NotificationNode(7, true, new Position(970, 382), null);
        public TrafficLightWaitNode TrafficLight7WaitRight = new TrafficLightWaitNode(new Position(1150, 382));
        public TrafficLight TrafficLight7Right = new TrafficLight(7, new Position(1200, 382), null);
        public NotificationNode TrafficLight7ExitRight = new NotificationNode(7, false, new Position(1218, 382), null);

        public NotificationNode TrafficLight8EntryLeft = new NotificationNode(8, true, new Position(970, 400), null);
        public TrafficLightWaitNode TrafficLight8WaitLeft = new TrafficLightWaitNode(new Position(1150, 400));
        public TrafficLight TrafficLigh8Left = new TrafficLight(8, new Position(1200, 400), null);
        public NotificationNode TrafficLight8ExitLeft = new NotificationNode(8, false, new Position(1218, 400), null);

        public NotificationNode TrafficLight8EntryRight = new NotificationNode(8, true, new Position(970, 418), null);
        public TrafficLightWaitNode TrafficLight8WaitRight = new TrafficLightWaitNode(new Position(1150, 418));
        public TrafficLight TrafficLight8Right = new TrafficLight(8, new Position(1200, 418), null);
        public NotificationNode TrafficLight8ExitRight = new NotificationNode(8, false, new Position(1218, 418), null);

        public NotificationNode TrafficLight9EntryLeft = new NotificationNode(9, true, new Position(1600, 318), null);
        public TrafficLightWaitNode TrafficLight9WaitLeft = new TrafficLightWaitNode(new Position(1390, 318));
        public TrafficLight TrafficLight9Left = new TrafficLight(9, new Position(1325, 318), null);
        public NotificationNode TrafficLight9ExitLeft = new NotificationNode(9, false, new Position(1300, 318), null);

        public NotificationNode TrafficLight9EntryRight = new NotificationNode(9, true, new Position(1600, 300), null);
        public TrafficLightWaitNode TrafficLight9WaitRight = new TrafficLightWaitNode(new Position(1390, 300));
        public TrafficLight TrafficLight9Right = new TrafficLight(9, new Position(1325, 300), null);
        public NotificationNode TrafficLight9ExitRight = new NotificationNode(9, false, new Position(1300, 300), null);

        public NotificationNode TrafficLight10Entry = new NotificationNode(10, true, new Position(1600, 282), null);
        public TrafficLightWaitNode TrafficLight10Wait = new TrafficLightWaitNode(new Position(1390, 282));
        public TrafficLight TrafficLight10 = new TrafficLight(10, new Position(1325, 282), null);
        public NotificationNode TrafficLight10Exit = new NotificationNode(10, false, new Position(1300, 282), null);

        public NotificationNode TrafficLight11EntryLeft = new NotificationNode(11, true, new Position(1200, 150), null);
        public TrafficLightWaitNode TrafficLight11WaitLeft = new TrafficLightWaitNode(new Position(1200, 190));
        public TrafficLight TrafficLight11Left = new TrafficLight(11, new Position(1200, 255), null);
        public NotificationNode TrafficLight11ExitLeft = new NotificationNode(11, false, new Position(1200, 275), null);

        public NotificationNode TrafficLight11EntryRight = new NotificationNode(11, true, new Position(1182, 150), null);
        public TrafficLightWaitNode TrafficLight11WaitRight = new TrafficLightWaitNode(new Position(1182, 190));
        public TrafficLight TrafficLight11Right = new TrafficLight(11, new Position(1182, 255), null);
        public NotificationNode TrafficLight11ExitRight = new NotificationNode(11, false, new Position(1182, 275), null);

        public NotificationNode TrafficLight12Entry = new NotificationNode(12, true, new Position(1218, 150), null);
        public TrafficLightWaitNode TrafficLight12Wait = new TrafficLightWaitNode(new Position(1218, 190));
        public TrafficLight TrafficLight12 = new TrafficLight(12, new Position(1218, 255), null);
        public NotificationNode TrafficLight12Exit = new NotificationNode(12, false, new Position(1218, 275), null);

        public NotificationNode TrafficLight13Entry = new NotificationNode(13, true, new Position(1236, 170), null);
        public TrafficLightWaitNode TrafficLight13Wait = new TrafficLightWaitNode(new Position(1236, 190));
        public TrafficLight TrafficLight13 = new TrafficLight(13, new Position(1236, 255), null);
        public NotificationNode TrafficLight13Exit = new NotificationNode(13, false, new Position(1236, 275), null);

        public NotificationNode TrafficLight14Entry = new NotificationNode(14, true, new Position(1550, 264), null);
        public TrafficLightWaitNode TrafficLight14Wait = new TrafficLightWaitNode(new Position(1390, 264));
        public TrafficLight TrafficLight14 = new TrafficLight(14, new Position(1325, 264), null);
        public NotificationNode TrafficLight14Exit = new NotificationNode(14, false, new Position(1300, 264), null);

        //------------------Cycling Traffic lights---------------------------------------------
        public NotificationNode TrafficLight220EntryLeft = new NotificationNode(34, true, new Position(278, 265), new VehicleType[] { VehicleType.Fiets });
        public TrafficLightWaitNode TrafficLight220WaitLeft = new TrafficLightWaitNode(new Position(278, 275), "", new VehicleType[] { VehicleType.Fiets });
        public TrafficLight TrafficLight220Left = new TrafficLight(34, new Position(278, 280), new VehicleType[] { VehicleType.Fiets });
        public NotificationNode TrafficLight220ExitLeft = new NotificationNode(34, false, new Position(278, 290), new VehicleType[] { VehicleType.Fiets });

        public NotificationNode TrafficLight221EntryLeft = new NotificationNode(32, true, new Position(287, 510), new VehicleType[] { VehicleType.Fiets });
        public TrafficLightWaitNode TrafficLight221WaitLeft = new TrafficLightWaitNode(new Position(287, 480), "", new VehicleType[] { VehicleType.Fiets });
        public TrafficLight TrafficLight221Left = new TrafficLight(32, new Position(287, 472), new VehicleType[] { VehicleType.Fiets });
        public NotificationNode TrafficLight221ExitLeft = new NotificationNode(32, false, new Position(287, 454), new VehicleType[] { VehicleType.Fiets });

        public NotificationNode TrafficLight222EntryLeft = new NotificationNode(43, true, new Position(287, 520), new VehicleType[] { VehicleType.Fiets });
        public TrafficLightWaitNode TrafficLight222WaitLeft = new TrafficLightWaitNode(new Position(298, 520), "", new VehicleType[] { VehicleType.Fiets });
        public TrafficLight TrafficLight222Left = new TrafficLight(43, new Position(307, 520), new VehicleType[] { VehicleType.Fiets });
        public NotificationNode TrafficLight222ExitLeft = new NotificationNode(43, false, new Position(325, 520), new VehicleType[] { VehicleType.Fiets });

        public NotificationNode TrafficLight223EntryLeft = new NotificationNode(46, true, new Position(490, 510), new VehicleType[] { VehicleType.Fiets });
        public TrafficLightWaitNode TrafficLight223WaitLeft = new TrafficLightWaitNode(new Position(488, 510), "", new VehicleType[] { VehicleType.Fiets });
        public TrafficLight TrafficLight223Left = new TrafficLight(46, new Position(479, 510), new VehicleType[] { VehicleType.Fiets });
        public NotificationNode TrafficLight223ExitLeft = new NotificationNode(46, false, new Position(461, 510), new VehicleType[] { VehicleType.Fiets });

        public NotificationNode TrafficLight224EntryLeft = new NotificationNode(27, true, new Position(510, 450), new VehicleType[] { VehicleType.Fiets });
        public TrafficLightWaitNode TrafficLight224WaitLeft = new TrafficLightWaitNode(new Position(510, 445), "", new VehicleType[] { VehicleType.Fiets });
        public TrafficLight TrafficLight224Left = new TrafficLight(27, new Position(510, 436), new VehicleType[] { VehicleType.Fiets });
        public NotificationNode TrafficLight224ExitLeft = new NotificationNode(27, false, new Position(510, 418), new VehicleType[] { VehicleType.Fiets });

        public NotificationNode TrafficLight225EntryLeft = new NotificationNode(30, true, new Position(500, 265), new VehicleType[] { VehicleType.Fiets });
        public TrafficLightWaitNode TrafficLight225WaitLeft = new TrafficLightWaitNode(new Position(500, 275), "", new VehicleType[] { VehicleType.Fiets });
        public TrafficLight TrafficLight225Left = new TrafficLight(30, new Position(500, 280), new VehicleType[] { VehicleType.Fiets });
        public NotificationNode TrafficLight225ExitLeft = new NotificationNode(30, false, new Position(500, 290), new VehicleType[] { VehicleType.Fiets });

        public NotificationNode TrafficLight40EntryLeft = new NotificationNode(40, true, new Position(1550, 240), new VehicleType[] { VehicleType.Fiets });
        public TrafficLightWaitNode TrafficLight40WaitLeft = new TrafficLightWaitNode(new Position(1350, 240), "", new VehicleType[] { VehicleType.Fiets });
        public TrafficLight TrafficLight40Left = new TrafficLight(40, new Position(1325, 240), new VehicleType[] { VehicleType.Fiets });
        public NotificationNode TrafficLight40ExitLeft = new NotificationNode(40, false, new Position(1300, 240), new VehicleType[] { VehicleType.Fiets });

        //------------------Pedestrian  Traffic lights---------------------------------------------
        public NotificationNode TrafficLight38EntryLeft = new NotificationNode(38, true, new Position(267, 505), new VehicleType[] { VehicleType.Voetganger });
        public TrafficLightWaitNode TrafficLight38WaitLeft = new TrafficLightWaitNode(new Position(267, 480), "", new VehicleType[] { VehicleType.Voetganger });
        public TrafficLight TrafficLight38Left = new TrafficLight(38, new Position(267, 472), new VehicleType[] { VehicleType.Voetganger });
        public NotificationNode TrafficLight38ExitLeft = new NotificationNode(38, false, new Position(267, 454), new VehicleType[] { VehicleType.Voetganger });

        public NotificationNode TrafficLight36EntryLeft = new NotificationNode(36, true, new Position(267, 374), new VehicleType[] { VehicleType.Voetganger });
        public TrafficLightWaitNode TrafficLight36WaitLeft = new TrafficLightWaitNode(new Position(267, 344), "", new VehicleType[] { VehicleType.Voetganger });
        public TrafficLight TrafficLight36Left = new TrafficLight(36, new Position(267, 336), new VehicleType[] { VehicleType.Voetganger });
        public NotificationNode TrafficLight36ExitLeft = new NotificationNode(36, false, new Position(267, 318), new VehicleType[] { VehicleType.Voetganger });

        public NotificationNode TrafficLight35EntryLeft = new NotificationNode(35, true, new Position(267, 265), new VehicleType[] { VehicleType.Voetganger });
        public TrafficLightWaitNode TrafficLight35WaitLeft = new TrafficLightWaitNode(new Position(267, 275), "", new VehicleType[] { VehicleType.Voetganger });
        public TrafficLight TrafficLight35Left = new TrafficLight(35, new Position(267, 280), new VehicleType[] { VehicleType.Voetganger });
        public NotificationNode TrafficLight35ExitLeft = new NotificationNode(35, false, new Position(267, 290), new VehicleType[] { VehicleType.Voetganger });

        public NotificationNode TrafficLight37EntryLeft = new NotificationNode(37, true, new Position(267, 365), new VehicleType[] { VehicleType.Voetganger });
        public TrafficLightWaitNode TrafficLight37WaitLeft = new TrafficLightWaitNode(new Position(267, 375), "", new VehicleType[] { VehicleType.Voetganger });
        public TrafficLight TrafficLight37Left = new TrafficLight(37, new Position(267, 382), new VehicleType[] { VehicleType.Voetganger });
        public NotificationNode TrafficLight37ExitLeft = new NotificationNode(37, false, new Position(267, 400), new VehicleType[] { VehicleType.Voetganger });

        public NotificationNode TrafficLight48EntryLeft = new NotificationNode(48, true, new Position(489, 265), new VehicleType[] { VehicleType.Voetganger });
        public TrafficLightWaitNode TrafficLight48WaitLeft = new TrafficLightWaitNode(new Position(489, 275), "", new VehicleType[] { VehicleType.Voetganger });
        public TrafficLight TrafficLight48Left = new TrafficLight(48, new Position(489, 280), new VehicleType[] { VehicleType.Voetganger });
        public NotificationNode TrafficLight48ExitLeft = new NotificationNode(48, false, new Position(489, 290), new VehicleType[] { VehicleType.Voetganger });

        public NotificationNode TrafficLight25EntryLeft = new NotificationNode(25, true, new Position(489, 365), new VehicleType[] { VehicleType.Voetganger });
        public TrafficLightWaitNode TrafficLight25WaitLeft = new TrafficLightWaitNode(new Position(489, 375), "", new VehicleType[] { VehicleType.Voetganger });
        public TrafficLight TrafficLight25Left = new TrafficLight(25, new Position(489, 382), new VehicleType[] { VehicleType.Voetganger });
        public NotificationNode TrafficLight25ExitLeft = new NotificationNode(25, false, new Position(489, 400), new VehicleType[] { VehicleType.Voetganger });

        public NotificationNode TrafficLight26EntryLeft = new NotificationNode(26, true, new Position(489, 450), new VehicleType[] { VehicleType.Voetganger });
        public TrafficLightWaitNode TrafficLight26WaitLeft = new TrafficLightWaitNode(new Position(489, 445), "", new VehicleType[] { VehicleType.Voetganger });
        public TrafficLight TrafficLight26Left = new TrafficLight(26, new Position(489, 436), new VehicleType[] { VehicleType.Voetganger });
        public NotificationNode TrafficLight26ExitLeft = new NotificationNode(26, false, new Position(489, 418), new VehicleType[] { VehicleType.Voetganger });

        public NotificationNode TrafficLight49EntryLeft = new NotificationNode(49, true, new Position(489, 386), new VehicleType[] { VehicleType.Voetganger });
        public TrafficLightWaitNode TrafficLight49WaitLeft = new TrafficLightWaitNode(new Position(489, 381), "", new VehicleType[] { VehicleType.Voetganger });
        public TrafficLight TrafficLight49Left = new TrafficLight(49, new Position(489, 372), new VehicleType[] { VehicleType.Voetganger });
        public NotificationNode TrafficLight49ExitLeft = new NotificationNode(49, false, new Position(489, 354), new VehicleType[] { VehicleType.Voetganger });

        public NotificationNode TrafficLight50EntryLeft = new NotificationNode(50, true, new Position(490, 505), new VehicleType[] { VehicleType.Voetganger });
        public TrafficLightWaitNode TrafficLight50WaitLeft = new TrafficLightWaitNode(new Position(488, 505), "", new VehicleType[] { VehicleType.Voetganger });
        public TrafficLight TrafficLight50Left = new TrafficLight(50, new Position(479, 505), new VehicleType[] { VehicleType.Voetganger });
        public NotificationNode TrafficLight50ExitLeft = new NotificationNode(50, false, new Position(461, 505), new VehicleType[] { VehicleType.Voetganger });

        public NotificationNode TrafficLight15EntryLeft = new NotificationNode(15, true, new Position(372, 505), new VehicleType[] { VehicleType.Voetganger });
        public TrafficLightWaitNode TrafficLight15WaitLeft = new TrafficLightWaitNode(new Position(370, 505), "", new VehicleType[] { VehicleType.Voetganger });
        public TrafficLight TrafficLight15Left = new TrafficLight(15, new Position(361, 505), new VehicleType[] { VehicleType.Voetganger });
        public NotificationNode TrafficLight15ExitLeft = new NotificationNode(15, false, new Position(343, 505), new VehicleType[] { VehicleType.Voetganger });

        public NotificationNode TrafficLight47EntryLeft = new NotificationNode(47, true, new Position(287, 505), new VehicleType[] { VehicleType.Voetganger });
        public TrafficLightWaitNode TrafficLight47WaitLeft = new TrafficLightWaitNode(new Position(298, 505), "", new VehicleType[] { VehicleType.Voetganger });
        public TrafficLight TrafficLight47Left = new TrafficLight(47, new Position(307, 505), new VehicleType[] { VehicleType.Voetganger });
        public NotificationNode TrafficLight47ExitLeft = new NotificationNode(47, false, new Position(325, 505), new VehicleType[] { VehicleType.Voetganger });

        public NotificationNode TrafficLight16EntryLeft = new NotificationNode(16, true, new Position(351, 505), new VehicleType[] { VehicleType.Voetganger });
        public TrafficLightWaitNode TrafficLight16WaitLeft = new TrafficLightWaitNode(new Position(362, 505), "", new VehicleType[] { VehicleType.Voetganger });
        public TrafficLight TrafficLight16Left = new TrafficLight(16, new Position(371, 505), new VehicleType[] { VehicleType.Voetganger });
        public NotificationNode TrafficLight16ExitLeft = new NotificationNode(16, false, new Position(389, 505), new VehicleType[] { VehicleType.Voetganger });

        public NotificationNode TrafficLight23EntryLeft = new NotificationNode(23, true, new Position(1150, 230), new VehicleType[] { VehicleType.Voetganger });
        public TrafficLightWaitNode TrafficLight23WaitLeft = new TrafficLightWaitNode(new Position(1153, 230), "", new VehicleType[] { VehicleType.Voetganger });
        public TrafficLight TrafficLight23Left = new TrafficLight(23, new Position(1164, 230), new VehicleType[] { VehicleType.Voetganger });
        public NotificationNode TrafficLight23ExitLeft = new NotificationNode(23, false, new Position(1182, 230), new VehicleType[] { VehicleType.Voetganger });

        public NotificationNode TrafficLight21EntryLeft = new NotificationNode(21, true, new Position(1242, 230), new VehicleType[] { VehicleType.Voetganger });
        public TrafficLightWaitNode TrafficLight21WaitLeft = new TrafficLightWaitNode(new Position(1253, 230), "", new VehicleType[] { VehicleType.Voetganger });
        public TrafficLight TrafficLight21Left = new TrafficLight(21, new Position(1264, 230), new VehicleType[] { VehicleType.Voetganger });
        public NotificationNode TrafficLight21ExitLeft = new NotificationNode(21, false, new Position(1282, 230), new VehicleType[] { VehicleType.Voetganger });

        public NotificationNode TrafficLight24EntryLeft = new NotificationNode(24, true, new Position(1276, 230), new VehicleType[] { VehicleType.Voetganger });
        public TrafficLightWaitNode TrafficLight24WaitLeft = new TrafficLightWaitNode(new Position(1265, 230), "", new VehicleType[] { VehicleType.Voetganger });
        public TrafficLight TrafficLight24Left = new TrafficLight(24, new Position(1254, 230), new VehicleType[] { VehicleType.Voetganger });
        public NotificationNode TrafficLight24ExitLeft = new NotificationNode(24, false, new Position(1236, 230), new VehicleType[] { VehicleType.Voetganger });

        public NotificationNode TrafficLight22EntryLeft = new NotificationNode(22, true, new Position(1340, 230), new VehicleType[] { VehicleType.Voetganger });
        public TrafficLightWaitNode TrafficLight22WaitLeft = new TrafficLightWaitNode(new Position(1329, 230), "", new VehicleType[] { VehicleType.Voetganger });
        public TrafficLight TrafficLight22Left = new TrafficLight(22, new Position(1318, 230), new VehicleType[] { VehicleType.Voetganger });
        public NotificationNode TrafficLight22ExitLeft = new NotificationNode(22, false, new Position(1300, 230), new VehicleType[] { VehicleType.Voetganger });

        public NotificationNode TrafficLight17EntryLeft = new NotificationNode(17, true, new Position(1350, 232), new VehicleType[] { VehicleType.Voetganger });
        public TrafficLightWaitNode TrafficLight17WaitLeft = new TrafficLightWaitNode(new Position(1350, 235), "", new VehicleType[] { VehicleType.Voetganger });
        public TrafficLight TrafficLight17Left = new TrafficLight(17, new Position(1350, 246), new VehicleType[] { VehicleType.Voetganger });
        public NotificationNode TrafficLight17ExitLeft = new NotificationNode(17, false, new Position(1350, 264), new VehicleType[] { VehicleType.Voetganger });

        public NotificationNode TrafficLight19EntryLeft = new NotificationNode(19, true, new Position(1350, 360), new VehicleType[] { VehicleType.Voetganger });
        public TrafficLightWaitNode TrafficLight19WaitLeft = new TrafficLightWaitNode(new Position(1350, 371), "", new VehicleType[] { VehicleType.Voetganger });
        public TrafficLight TrafficLight19Left = new TrafficLight(19, new Position(1350, 382), new VehicleType[] { VehicleType.Voetganger });
        public NotificationNode TrafficLight19ExitLeft = new NotificationNode(19, false, new Position(1350, 400), new VehicleType[] { VehicleType.Voetganger });

        public NotificationNode TrafficLight20EntryLeft = new NotificationNode(20, true, new Position(1350, 458), new VehicleType[] { VehicleType.Voetganger });
        public TrafficLightWaitNode TrafficLight20WaitLeft = new TrafficLightWaitNode(new Position(1350, 447), "", new VehicleType[] { VehicleType.Voetganger });
        public TrafficLight TrafficLight20Left = new TrafficLight(20, new Position(1350, 436), new VehicleType[] { VehicleType.Voetganger });
        public NotificationNode TrafficLight20ExitLeft = new NotificationNode(20, false, new Position(1350, 418), new VehicleType[] { VehicleType.Voetganger });

        public NotificationNode TrafficLight18EntryLeft = new NotificationNode(18, true, new Position(1350, 358), new VehicleType[] { VehicleType.Voetganger });
        public TrafficLightWaitNode TrafficLight18WaitLeft = new TrafficLightWaitNode(new Position(1350, 347), "", new VehicleType[] { VehicleType.Voetganger });
        public TrafficLight TrafficLight18Left = new TrafficLight(18, new Position(1350, 336), new VehicleType[] { VehicleType.Voetganger });
        public NotificationNode TrafficLight18ExitLeft = new NotificationNode(18, false, new Position(1350, 318), new VehicleType[] { VehicleType.Voetganger });

        public Nodes()
        {

        }
    }
}
