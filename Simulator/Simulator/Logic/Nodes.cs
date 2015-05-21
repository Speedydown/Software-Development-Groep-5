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
        public Node EntryNode2 = new EntryNode(new Position(1225, -100), Direction.Noord, new VehicleType[] { VehicleType.Auto, VehicleType.Bus }, "s2");
        public Node EntryNode3 = new EntryNode(new Position(2015, 300), Direction.Oost, new VehicleType[] { VehicleType.Auto, VehicleType.Bus }, "s3");
        public Node EntryNode4 = new EntryNode(new Position(2015, 325), Direction.Oost, new VehicleType[] { VehicleType.Auto, VehicleType.Bus }, "s4");
        public Node EntryNode5 = new EntryNode(new Position(450, 1055), Direction.Zuid, new VehicleType[] { VehicleType.Auto, VehicleType.Bus }, "s5");
        public Node EntryNode6 = new EntryNode(new Position(425, 1055), Direction.Zuid, new VehicleType[] { VehicleType.Auto, VehicleType.Bus }, "s6");
        public Node EntryNode7 = new EntryNode(new Position(0, 425), Direction.West, new VehicleType[] { VehicleType.Auto, VehicleType.Bus }, "s7");
        public Node EntryNode8 = new EntryNode(new Position(500, 1055), Direction.Ventweg, new VehicleType[] { VehicleType.Auto, VehicleType.Bus, VehicleType.Fiets }, "s8");
        public Node EntryNode9 = new EntryNode(new Position(0, 495), Direction.West, new VehicleType[] { VehicleType.Fiets }, "s9", Colors.Purple);
        public Node EntryNode10 = new EntryNode(new Position(395, 0), Direction.Noord, new VehicleType[] { VehicleType.Fiets }, "s10", Colors.Purple);
        public Node EntryNode11 = new EntryNode(new Position(1915, 225), Direction.Oost, new VehicleType[] { VehicleType.Fiets }, "s11", Colors.Purple);


        //Intersection Nodes
        public Node NodeA1 = new Node(new Position(350, 375), "A1");
        public Node NodeA2 = new Node(new Position(325, 350), "A2");
        public Node NodeB1 = new Node(new Position(375, 325), "B1");
        public Node NodeB2 = new Node(new Position(400, 300), "B2");
        public Node NodeC1 = new Node(new Position(350, 450), "C1");
        public Node NodeC2 = new Node(new Position(325, 475), "C2");
        public Node NodeD1 = new Node(new Position(425, 400), "D1");
        public Node NodeD2 = new Node(new Position(450, 425), "D2");
        public Node NodeE1 = new Node(new Position(1200, 325), "E1");
        public Node NodeE2 = new Node(new Position(1175, 300), "E2");
        public Node NodeF1 = new Node(new Position(1275, 275), "F1");
        public Node NodeF2 = new Node(new Position(1300, 250), "F2");
        public Node NodeH1 = new Node(new Position(1275, 350), "H1");
        public Node NodeH2 = new Node(new Position(1300, 375), "H2");
        public Node NodeI = new Node(new Position(550, 425), "I");
        public Node NodeJ = new Node(new Position(620, 425), "J");
        public Node NodeK = new Node(new Position(1475, 425), "K");
        public Node NodeG1 = new Node(new Position(1250, 400), "G1");
        public Node NodeG2 = new Node(new Position(1225, 425), "G2");

        //ExitNodes
        public Node ExitNode1 = new ExitNode(new Position(1275, 0), Direction.Noord, new VehicleType[] { VehicleType.Auto, VehicleType.Bus }, "e1");
        public Node ExitNode2 = new ExitNode(new Position(1300, 0), Direction.Noord, new VehicleType[] { VehicleType.Auto, VehicleType.Bus }, "e2");
        public Node ExitNode3 = new ExitNode(new Position(1915, 400), Direction.Oost, new VehicleType[] { VehicleType.Auto, VehicleType.Bus }, "e3");
        public Node ExitNode4 = new ExitNode(new Position(1915, 425), Direction.Oost, new VehicleType[] { VehicleType.Auto, VehicleType.Bus }, "e4");
        public Node ExitNode5 = new ExitNode(new Position(350, 1055), Direction.Zuid, new VehicleType[] { VehicleType.Auto, VehicleType.Bus }, "e5");
        public Node ExitNode6 = new ExitNode(new Position(325, 1055), Direction.Zuid, new VehicleType[] { VehicleType.Auto, VehicleType.Bus }, "e6");
        public Node ExitNode7 = new ExitNode(new Position(0, 325), Direction.West, new VehicleType[] { VehicleType.Auto, VehicleType.Bus }, "e7");
        public Node ExitNode8 = new ExitNode(new Position(0, 300), Direction.West, new VehicleType[] { VehicleType.Auto, VehicleType.Bus }, "e8");
        public Node ExitNode9 = new ExitNode(new Position(0, 275), Direction.West, new VehicleType[] { VehicleType.Fiets }, "e9", Colors.Purple);
        public Node ExitNode10 = new ExitNode(new Position(405, 0), Direction.Noord, new VehicleType[] { VehicleType.Fiets }, "e10", Colors.Purple);
        public Node ExitNode11 = new ExitNode(new Position(312, 1055), Direction.Zuid, new VehicleType[] { VehicleType.Fiets }, "e11", Colors.Purple);
        public Node ExitNode12 = new ExitNode(new Position(1915, 475), Direction.Oost, new VehicleType[] { VehicleType.Fiets }, "e12", Colors.Purple);

        //CustomNodes
        public Node Custom1 = new Node(new Position(1200, 70), "1");
        public Node Custom3 = new Node(new Position(1225, 70), "3");

        public Node Custom20 = new Node(new Position(1700, 300), "20");
        public Node Custom21 = new Node(new Position(1650, 275), "21");

        public Node Custom30 = new Node(new Position(920, 325), "30");
        public Node Custom31 = new Node(new Position(870, 350), "31");

        public Node Custom10 = new Node(new Position(1200, 318), "10");

        public Node Custom40 = new Node(new Position(870, 400), "40");
        public Node Custom41 = new Node(new Position(920, 375), "41");

        public Node Custom50 = new Node(new Position(25, 425), "50");
        public Node Custom51 = new Node(new Position(100, 450), "51");
        public Node Custom52 = new Node(new Position(50, 425), "52");
        public Node Custom53 = new Node(new Position(75, 400), "53");

        public Node Custom60 = new Node(new Position(425, 950), "60");
        public Node Custom61 = new Node(new Position(400, 900), "61");
        public Node Custom62 = new Node(new Position(375, 850), "62");
        public Node Custom63 = new Node(new Position(450, 950), "63");

        public Node Custom70 = new Node(new Position(510, 520), "70", new VehicleType[] { VehicleType.Auto, VehicleType.Bus, VehicleType.Fiets });
        public Node Custom71 = new Node(new Position(690, 475), "71", new VehicleType[] { VehicleType.Auto, VehicleType.Bus, VehicleType.Fiets });
        public Node Custom72 = new Node(new Position(1350, 475), "72", new VehicleType[] { VehicleType.Auto, VehicleType.Bus, VehicleType.Fiets });
        public Node Custom73 = new Node(new Position(1425, 475), "73", new VehicleType[] { VehicleType.Auto, VehicleType.Bus, VehicleType.Fiets });

        //BusNodes
        public Node Bus1 = new BusNode(new Position(1250, 150), "b1");
        public Node Bus2 = new BusNode(new Position(475, 900), "b2");
        public Node Bus4 = new BusNode(new Position(1600, 250), "b4");

        //LaneSwitchers
        public LaneSwitcher LaneSwitcher1 = new LaneSwitcher(
            new LaneSwitchNode(true, new Position(425, 1045)),
            new LaneSwitchNode(true, new Position(450, 1045)),
            new LaneSwitchNode(false, new Position(425, 1000)),
            new LaneSwitchNode(false, new Position(450, 1000))
            );

        public LaneSwitcher LaneSwitcher2 = new LaneSwitcher(
            new LaneSwitchNode(true, new Position(645, 400)),
            new LaneSwitchNode(true, new Position(645, 425)),
            new LaneSwitchNode(false, new Position(690, 400)),
            new LaneSwitchNode(false, new Position(690, 425)));

        public LaneSwitcher LaneSwitcher3 = new LaneSwitcher(
            new LaneSwitchNode(true, new Position(1225, 0)),
            new LaneSwitchNode(true, new Position(1200, 0)),
            new LaneSwitchNode(false, new Position(1225, 45)),
            new LaneSwitchNode(false, new Position(1200, 45)));

        public LaneSwitcher LaneSwitcher4 = new LaneSwitcher(
            new LaneSwitchNode(true, new Position(1915, 325)),
            new LaneSwitchNode(true, new Position(1915, 300)),
            new LaneSwitchNode(false, new Position(1870, 325)),
            new LaneSwitchNode(false, new Position(1870, 300)));

        public LaneSwitcher LaneSwitcher5 = new LaneSwitcher(
            new LaneSwitchNode(true, new Position(1150, 325)),
            new LaneSwitchNode(true, new Position(1150, 300)),
            new LaneSwitchNode(false, new Position(1105, 325)),
            new LaneSwitchNode(false, new Position(1105, 300)));

        //------------------Cycling routes---------------------------------------------
        public Node Nodec1 = new BicycleNode(new Position(295, 545), "1");
        public Node Nodec2 = new BicycleNode(new Position(510, 225), "2");
        public Node Nodec3 = new BicycleNode(new Position(405, 155), "3");
        public Node Nodec4 = new BicycleNode(new Position(395, 155), "4");
        public Node Nodec5 = new BicycleNode(new Position(295, 225), "5");
        public Node Nodec6 = new BicycleNode(new Position(300, 520), "6");
        public Node Nodec7 = new BicycleNode(new Position(225, 495), "7");
        public Node Nodec8 = new BicycleNode(new Position(500, 510), "8");
        public Node Nodec9 = new BicycleNode(new Position(500, 225), "9");
        public Node Nodec10 = new BicycleNode(new Position(305, 225), "10");
        public Node Nodec11 = new BicycleNode(new Position(312, 650), "11");
        public Node Nodec12 = new BicycleNode(new Position(560, 500), "12");
        public Node Nodec13 = new BicycleNode(new Position(1350, 225), "13");
        public Node Nodec14 = new BicycleNode(new Position(1150, 225), "14");
        public Node Nodec15 = new BicycleNode(new Position(1080, 275), "15");
        public Node Nodec16 = new BicycleNode(new Position(225, 275), "16");


        //------------------Traffic lights---------------------------------------------
        public NotificationNode TrafficLight0EntryLeft = new NotificationNode(0, true, new Position(820, 325), null);
        public TrafficLightWaitNode TrafficLight0WaitLeft = new TrafficLightWaitNode(new Position(525, 325));
        public TrafficLight TrafficLight0Left = new TrafficLight(0, new Position(475, 325), null);
        public NotificationNode TrafficLight0ExitLeft = new NotificationNode(0, false, new Position(450, 325), null);

        public NotificationNode TrafficLight0EntryRight = new NotificationNode(0, true, new Position(820, 300), null);
        public TrafficLightWaitNode TrafficLight0WaitRight = new TrafficLightWaitNode(new Position(525, 300));
        public TrafficLight TrafficLight0Right = new TrafficLight(0, new Position(475, 300), null);
        public NotificationNode TrafficLight0ExitRight = new NotificationNode(0, false, new Position(450, 300), null);

        public NotificationNode TrafficLight1EntryLeft = new NotificationNode(1, true, new Position(820, 375), null);
        public TrafficLightWaitNode TrafficLight1WaitLeft = new TrafficLightWaitNode(new Position(525, 375));
        public TrafficLight TrafficLight1Left = new TrafficLight(1, new Position(475, 375), null);
        public NotificationNode TrafficLight1ExitLeft = new NotificationNode(1, false, new Position(450, 375), null);

        public NotificationNode TrafficLight1EntryRight = new NotificationNode(1, true, new Position(820, 350), null);
        public TrafficLightWaitNode TrafficLight1WaitRight = new TrafficLightWaitNode(new Position(525, 350));
        public TrafficLight TrafficLight1Right = new TrafficLight(1, new Position(475, 350), null);
        public NotificationNode TrafficLight1ExitRight = new NotificationNode(1, false, new Position(450, 350), null);

        public NotificationNode TrafficLight2EntryLeft = new NotificationNode(2, true, new Position(150, 450), null);
        public TrafficLightWaitNode TrafficLight2WaitLeft = new TrafficLightWaitNode(new Position(255, 450));
        public TrafficLight TrafficLight2Left = new TrafficLight(2, new Position(280, 450), null);
        public NotificationNode TrafficLight2ExitLeft = new NotificationNode(2, false, new Position(305, 450), null);

        public NotificationNode TrafficLight2EntryRight = new NotificationNode(2, true, new Position(150, 475), null);
        public TrafficLightWaitNode TrafficLight2WaitRight = new TrafficLightWaitNode(new Position(255, 475));
        public TrafficLight TrafficLight2Right = new TrafficLight(2, new Position(280, 475), null);
        public NotificationNode TrafficLight2ExitRight = new NotificationNode(2, false, new Position(305, 475), null);

        public NotificationNode TrafficLight3EntryLeft = new NotificationNode(3, true, new Position(150, 400), null);
        public TrafficLightWaitNode TrafficLight3WaitLeft = new TrafficLightWaitNode(new Position(255, 400));
        public TrafficLight TrafficLight3Left = new TrafficLight(3, new Position(280, 400), null);
        public NotificationNode TrafficLight3ExitLeft = new NotificationNode(3, false, new Position(305, 400), null);

        public NotificationNode TrafficLight3EntryRight = new NotificationNode(3, true, new Position(150, 425), null);
        public TrafficLightWaitNode TrafficLight3WaitRight = new TrafficLightWaitNode(new Position(255, 425));
        public TrafficLight TrafficLight3Right = new TrafficLight(3, new Position(280, 425), null);
        public NotificationNode TrafficLight3ExitRight = new NotificationNode(3, false, new Position(305, 425), null);

        public NotificationNode TrafficLight4EntryLeft = new NotificationNode(4, true, new Position(375, 750), null);
        public TrafficLightWaitNode TrafficLight4WaitLeft = new TrafficLightWaitNode(new Position(375, 540));
        public TrafficLight TrafficLight4Left = new TrafficLight(4, new Position(375, 475), null);
        public NotificationNode TrafficLight4ExitLeft = new NotificationNode(4, false, new Position(375, 450), null);

        public NotificationNode TrafficLight4EntryRight = new NotificationNode(4, true, new Position(400, 750), null);
        public TrafficLightWaitNode TrafficLight4WaitRight = new TrafficLightWaitNode(new Position(400, 540));
        public TrafficLight TrafficLight4Right = new TrafficLight(4, new Position(400, 475), null);
        public NotificationNode TrafficLight4ExitRight = new NotificationNode(4, false, new Position(400, 450), null);

        public NotificationNode TrafficLight5EntryLeft = new NotificationNode(5, true, new Position(425, 750), null);
        public TrafficLightWaitNode TrafficLight5WaitLeft = new TrafficLightWaitNode(new Position(425, 540));
        public TrafficLight TrafficLight5Left = new TrafficLight(5, new Position(425, 475), null);
        public NotificationNode TrafficLight5ExitLeft = new NotificationNode(5, false, new Position(425, 450), null);

        public NotificationNode TrafficLight5EntryRight = new NotificationNode(5, true, new Position(450, 750), null);
        public TrafficLightWaitNode TrafficLight5WaitRight = new TrafficLightWaitNode(new Position(450, 540));
        public TrafficLight TrafficLight5Right = new TrafficLight(5, new Position(450, 475), null);
        public NotificationNode TrafficLight5ExitRight = new NotificationNode(5, false, new Position(450, 450), null);

        public NotificationNode TrafficLight6Entry = new NotificationNode(6, true, new Position(475, 750), null, Colors.Gold);
        public TrafficLightWaitNode TrafficLight6Wait = new TrafficLightWaitNode(new Position(475, 540));
        public TrafficLight TrafficLight6 = new TrafficLight(6, new Position(475, 475), null, Colors.Gold);
        public NotificationNode TrafficLight6Exit = new NotificationNode(6, false, new Position(465, 450), null, Colors.Gold);

        public NotificationNode TrafficLight7EntryLeft = new NotificationNode(7, true, new Position(970, 350), null);
        public TrafficLightWaitNode TrafficLight7WaitLeft = new TrafficLightWaitNode(new Position(1150, 350));
        public TrafficLight TrafficLigh7Left = new TrafficLight(7, new Position(1175, 350), null);
        public NotificationNode TrafficLight7ExitLeft = new NotificationNode(7, false, new Position(1200, 350), null);

        public NotificationNode TrafficLight7EntryRight = new NotificationNode(7, true, new Position(970, 375), null);
        public TrafficLightWaitNode TrafficLight7WaitRight = new TrafficLightWaitNode(new Position(1150, 375));
        public TrafficLight TrafficLight7Right = new TrafficLight(7, new Position(1175, 375), null);
        public NotificationNode TrafficLight7ExitRight = new NotificationNode(7, false, new Position(1200, 375), null);

        public NotificationNode TrafficLight8EntryLeft = new NotificationNode(8, true, new Position(970, 400), null);
        public TrafficLightWaitNode TrafficLight8WaitLeft = new TrafficLightWaitNode(new Position(1150, 400));
        public TrafficLight TrafficLigh8Left = new TrafficLight(8, new Position(1175, 400), null);
        public NotificationNode TrafficLight8ExitLeft = new NotificationNode(8, false, new Position(1200, 400), null);

        public NotificationNode TrafficLight8EntryRight = new NotificationNode(8, true, new Position(970, 425), null);
        public TrafficLightWaitNode TrafficLight8WaitRight = new TrafficLightWaitNode(new Position(1150, 425));
        public TrafficLight TrafficLight8Right = new TrafficLight(8, new Position(1175, 425), null);
        public NotificationNode TrafficLight8ExitRight = new NotificationNode(8, false, new Position(1200, 425), null);

        public NotificationNode TrafficLight9EntryLeft = new NotificationNode(9, true, new Position(1600, 325), null);
        public TrafficLightWaitNode TrafficLight9WaitLeft = new TrafficLightWaitNode(new Position(1350, 325));
        public TrafficLight TrafficLight9Left = new TrafficLight(9, new Position(1325, 325), null);
        public NotificationNode TrafficLight9ExitLeft = new NotificationNode(9, false, new Position(1300, 325), null);

        public NotificationNode TrafficLight9EntryRight = new NotificationNode(9, true, new Position(1600, 300), null);
        public TrafficLightWaitNode TrafficLight9WaitRight = new TrafficLightWaitNode(new Position(1350, 300));
        public TrafficLight TrafficLight9Right = new TrafficLight(9, new Position(1325, 300), null);
        public NotificationNode TrafficLight9ExitRight = new NotificationNode(9, false, new Position(1300, 300), null);

        public NotificationNode TrafficLight10Entry = new NotificationNode(10, true, new Position(1600, 275), null);
        public TrafficLightWaitNode TrafficLight10Wait = new TrafficLightWaitNode(new Position(1350, 275));
        public TrafficLight TrafficLight10 = new TrafficLight(10, new Position(1325, 275), null);
        public NotificationNode TrafficLight10Exit = new NotificationNode(10, false, new Position(1300, 275), null);

        public NotificationNode TrafficLight11EntryLeft = new NotificationNode(11, true, new Position(1200, 150), null);
        public TrafficLightWaitNode TrafficLight11WaitLeft = new TrafficLightWaitNode(new Position(1200, 225));
        public TrafficLight TrafficLight11Left = new TrafficLight(11, new Position(1200, 250), null);
        public NotificationNode TrafficLight11ExitLeft = new NotificationNode(11, false, new Position(1200, 275), null);

        public NotificationNode TrafficLight11EntryRight = new NotificationNode(11, true, new Position(1175, 150), null);
        public TrafficLightWaitNode TrafficLight11WaitRight = new TrafficLightWaitNode(new Position(1175, 225));
        public TrafficLight TrafficLight11Right = new TrafficLight(11, new Position(1175, 250), null);
        public NotificationNode TrafficLight11ExitRight = new NotificationNode(11, false, new Position(1175, 275), null);

        public NotificationNode TrafficLight12Entry = new NotificationNode(12, true, new Position(1225, 150), null);
        public TrafficLightWaitNode TrafficLight12Wait = new TrafficLightWaitNode(new Position(1225, 225));
        public TrafficLight TrafficLight12 = new TrafficLight(12, new Position(1225, 250), null);
        public NotificationNode TrafficLight12Exit = new NotificationNode(12, false, new Position(1225, 275), null);

        public NotificationNode TrafficLight13Entry = new NotificationNode(13, true, new Position(1250, 200), null);
        public TrafficLightWaitNode TrafficLight13Wait = new TrafficLightWaitNode(new Position(1250, 225));
        public TrafficLight TrafficLight13 = new TrafficLight(13, new Position(1250, 250), null);
        public NotificationNode TrafficLight13Exit = new NotificationNode(13, false, new Position(1250, 275), null);

        public NotificationNode TrafficLight14Entry = new NotificationNode(14, true, new Position(1550, 250), null);
        public TrafficLightWaitNode TrafficLight14Wait = new TrafficLightWaitNode(new Position(1350, 250));
        public TrafficLight TrafficLight14 = new TrafficLight(14, new Position(1325, 250), null);
        public NotificationNode TrafficLight14Exit = new NotificationNode(14, false, new Position(1300, 250), null);

        //------------------Cycling Traffic lights---------------------------------------------
        public NotificationNode TrafficLight220EntryLeft = new NotificationNode(220, true, new Position(295, 235), new VehicleType[] { VehicleType.Fiets });
        public TrafficLightWaitNode TrafficLight220WaitLeft = new TrafficLightWaitNode(new Position(295, 250), "", new VehicleType[] { VehicleType.Fiets });
        public TrafficLight TrafficLight220Left = new TrafficLight(220, new Position(295, 280), new VehicleType[] { VehicleType.Fiets });
        public NotificationNode TrafficLight220ExitLeft = new NotificationNode(220, false, new Position(295, 300), new VehicleType[] { VehicleType.Fiets });

        public NotificationNode TrafficLight221EntryLeft = new NotificationNode(221, true, new Position(305, 510), new VehicleType[] { VehicleType.Fiets });
        public TrafficLightWaitNode TrafficLight221WaitLeft = new TrafficLightWaitNode(new Position(305, 500), "", new VehicleType[] { VehicleType.Fiets });
        public TrafficLight TrafficLight221Left = new TrafficLight(221, new Position(305, 490), new VehicleType[] { VehicleType.Fiets });
        public NotificationNode TrafficLight221ExitLeft = new NotificationNode(221, false, new Position(305, 480), new VehicleType[] { VehicleType.Fiets });

        public NotificationNode TrafficLight222EntryLeft = new NotificationNode(222, true, new Position(310, 520), new VehicleType[] { VehicleType.Fiets });
        public TrafficLightWaitNode TrafficLight222WaitLeft = new TrafficLightWaitNode(new Position(310, 520), "", new VehicleType[] { VehicleType.Fiets });
        public TrafficLight TrafficLight222Left = new TrafficLight(222, new Position(315, 520), new VehicleType[] { VehicleType.Fiets });
        public NotificationNode TrafficLight222ExitLeft = new NotificationNode(222, false, new Position(315, 520), new VehicleType[] { VehicleType.Fiets });

        public NotificationNode TrafficLight223EntryLeft = new NotificationNode(223, true, new Position(490, 510), new VehicleType[] { VehicleType.Fiets });
        public TrafficLightWaitNode TrafficLight223WaitLeft = new TrafficLightWaitNode(new Position(488, 510), "", new VehicleType[] { VehicleType.Fiets });
        public TrafficLight TrafficLight223Left = new TrafficLight(223, new Position(486, 510), new VehicleType[] { VehicleType.Fiets });
        public NotificationNode TrafficLight223ExitLeft = new NotificationNode(223, false, new Position(484, 510), new VehicleType[] { VehicleType.Fiets });

        public NotificationNode TrafficLight224EntryLeft = new NotificationNode(224, true, new Position(510, 440), new VehicleType[] { VehicleType.Fiets });
        public TrafficLightWaitNode TrafficLight224WaitLeft = new TrafficLightWaitNode(new Position(510, 440), "", new VehicleType[] { VehicleType.Fiets });
        public TrafficLight TrafficLight224Left = new TrafficLight(224, new Position(510, 435), new VehicleType[] { VehicleType.Fiets });
        public NotificationNode TrafficLight224ExitLeft = new NotificationNode(224, false, new Position(510, 425), new VehicleType[] { VehicleType.Fiets });

        public NotificationNode TrafficLight225EntryLeft = new NotificationNode(225, true, new Position(500, 275), new VehicleType[] { VehicleType.Fiets });
        public TrafficLightWaitNode TrafficLight225WaitLeft = new TrafficLightWaitNode(new Position(500, 285), "", new VehicleType[] { VehicleType.Fiets });
        public TrafficLight TrafficLight225Left = new TrafficLight(225, new Position(500, 290), new VehicleType[] { VehicleType.Fiets });
        public NotificationNode TrafficLight225ExitLeft = new NotificationNode(225, false, new Position(500, 300), new VehicleType[] { VehicleType.Fiets });

        public Nodes()
        {

        }
    }
}
