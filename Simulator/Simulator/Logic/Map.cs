using Simulator.Dijkstra;
using Simulator.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Simulator.UserControls
{
    public class Map : Canvas
    {
        //Static instance
        public static Map Instance { get; private set; }


        public List<Node> EntryPoints { get; private set; }
        public Nodes nodes { get; private set; }


        public Map()
            : base()
        {
            //SetMap instance
            Instance = this;

            //Initialize Node List
            this.EntryPoints = new List<Node>();

            this.nodes = new Nodes();
            //Create nodes to their end points
            this.CreateNodes();

            //Draw Figures on canvas
            this.Draw();

            //Open test window
            if (Config.DisplayDebugWindow)
            {
                TestControls TestControlWindow = new TestControls();
                TestControlWindow.Show();
            }

            VehicleHandler.Instance.StartVehicleHandler();


            //ProcessCommands
            NetworkCommandHandler.Instance.Start();
        }

        private void CreateNodes()
        {
            this.AddStartNodes();
            this.BuildRoads();
            this.BuildBycycleRoutes();
            this.BuildPedestrianRoutes();
        }

        public void Draw()
        {
            if (!Config.DisplayNodes)
            {
                Rectangle BackGround = new Rectangle();
                BackGround.Width = 1920;
                BackGround.Height = 1080;
                BackGround.Fill = new SolidColorBrush(Colors.LimeGreen);

                this.Children.Add(BackGround);
            }

            foreach (Node n in this.EntryPoints)
            {
                n.Draw();
            }
        }

        public void AddStartNodes()
        {
            EntryPoints.Add(this.nodes.EntryNode1);
            EntryPoints.Add(this.nodes.EntryNode2);
            EntryPoints.Add(this.nodes.EntryNode3);
            EntryPoints.Add(this.nodes.EntryNode4);
            EntryPoints.Add(this.nodes.EntryNode5);
            EntryPoints.Add(this.nodes.EntryNode6);
            EntryPoints.Add(this.nodes.EntryNode7);
            EntryPoints.Add(this.nodes.EntryNode8);
            EntryPoints.Add(this.nodes.EntryNode9);
            EntryPoints.Add(this.nodes.EntryNode10);
            EntryPoints.Add(this.nodes.EntryNode11);
            EntryPoints.Add(this.nodes.EntryNode12);
            EntryPoints.Add(this.nodes.EntryNode13);
            EntryPoints.Add(this.nodes.EntryNode14);
            EntryPoints.Add(this.nodes.EntryNode15);
            EntryPoints.Add(this.nodes.EntryNode16);
            EntryPoints.Add(this.nodes.EntryNode17);
            EntryPoints.Add(this.nodes.EntryNode18);
            EntryPoints.Add(this.nodes.EntryNode19);
            EntryPoints.Add(this.nodes.EntryNode20);
        }

        private void BuildRoads()
        {
            //south
            this.nodes.EntryNode6.AddNode(this.nodes.LaneSwitcher1.EntryNodeLeft);
            this.nodes.LaneSwitcher1.ExitNodeLeft.AddNode(this.nodes.Custom60);
            this.nodes.Custom60.AddNode(this.nodes.Custom61);
            this.nodes.Custom61.AddNode(this.nodes.Custom62);

            //Trafflight4r
            this.nodes.Custom61.AddNode(this.nodes.TrafficLight4EntryRight);
            this.nodes.TrafficLight4EntryRight.AddNode(this.nodes.TrafficLight4WaitRight);
            this.nodes.TrafficLight4WaitRight.AddNode(this.nodes.TrafficLight4Right);
            this.nodes.TrafficLight4Right.AddNode(this.nodes.TrafficLight4ExitRight);
            this.nodes.TrafficLight4ExitRight.AddNode(this.nodes.NodeB2);

            //TrafficLight4l
            this.nodes.Custom62.AddNode(this.nodes.TrafficLight4EntryLeft);
            this.nodes.TrafficLight4EntryLeft.AddNode(this.nodes.TrafficLight4WaitLeft);
            this.nodes.TrafficLight4WaitLeft.AddNode(this.nodes.TrafficLight4Left);
            this.nodes.TrafficLight4Left.AddNode(this.nodes.TrafficLight4ExitLeft);
            this.nodes.TrafficLight4ExitLeft.AddNode(this.nodes.NodeB1);

            this.nodes.NodeB1.AddNode(this.nodes.ExitNode7);
            this.nodes.NodeB2.AddNode(this.nodes.ExitNode8);

            //TrafficLight5l
            this.nodes.Custom60.AddNode(this.nodes.TrafficLight5EntryLeft);
            this.nodes.TrafficLight5EntryLeft.AddNode(this.nodes.TrafficLight5WaitLeft);
            this.nodes.TrafficLight5WaitLeft.AddNode(this.nodes.TrafficLight5Left);
            this.nodes.TrafficLight5Left.AddNode(this.nodes.TrafficLight5ExitLeft);
            this.nodes.TrafficLight5ExitLeft.AddNode(this.nodes.NodeD1);

            this.nodes.EntryNode5.AddNode(this.nodes.LaneSwitcher1.EntryNodeRight);
            this.nodes.LaneSwitcher1.ExitNodeRight.AddNode(this.nodes.Custom63);

            //TrafficLight5r
            this.nodes.Custom63.AddNode(this.nodes.TrafficLight5EntryRight);
            this.nodes.TrafficLight5EntryRight.AddNode(this.nodes.TrafficLight5WaitRight);
            this.nodes.TrafficLight5WaitRight.AddNode(this.nodes.TrafficLight5Right);
            this.nodes.TrafficLight5Right.AddNode(this.nodes.TrafficLight5ExitRight);
            this.nodes.TrafficLight5ExitRight.AddNode(this.nodes.NodeD2);

            this.nodes.Custom63.AddNode(this.nodes.Bus2);

            //TrafficLight 6 
            this.nodes.Bus2.AddNode(this.nodes.TrafficLight6Entry);
            this.nodes.TrafficLight6Entry.AddNode(this.nodes.TrafficLight6Wait);
            this.nodes.TrafficLight6Wait.AddNode(this.nodes.TrafficLight6);
            this.nodes.TrafficLight6.AddNode(this.nodes.TrafficLight6Exit);
            this.nodes.TrafficLight6Exit.AddNode(this.nodes.NodeD2);

            //west
            this.nodes.EntryNode7.AddNode(this.nodes.Custom50);
            this.nodes.Custom50.AddNode(this.nodes.Custom52);
            this.nodes.Custom52.AddNode(this.nodes.Custom51);
            this.nodes.Custom50.AddNode(this.nodes.Custom53);
            this.nodes.Custom52.AddNode(this.nodes.TrafficLight3EntryRight);
            this.nodes.TrafficLight3EntryRight.AddNode(this.nodes.TrafficLight3WaitRight);
            this.nodes.TrafficLight3WaitRight.AddNode(this.nodes.TrafficLight3Right);
            this.nodes.TrafficLight3Right.AddNode(this.nodes.TrafficLight3ExitRight);
            this.nodes.TrafficLight3ExitRight.AddNode(this.nodes.NodeD2);
            this.nodes.Custom51.AddNode(this.nodes.TrafficLight2EntryLeft);
            this.nodes.TrafficLight2EntryLeft.AddNode(this.nodes.TrafficLight2WaitLeft);
            this.nodes.TrafficLight2WaitLeft.AddNode(this.nodes.TrafficLight2Left);
            this.nodes.TrafficLight2Left.AddNode(this.nodes.TrafficLight2ExitLeft);
            this.nodes.TrafficLight2ExitLeft.AddNode(this.nodes.NodeC1);
            this.nodes.Custom51.AddNode(this.nodes.TrafficLight2EntryRight);
            this.nodes.TrafficLight2EntryRight.AddNode(this.nodes.TrafficLight2WaitRight);
            this.nodes.TrafficLight2WaitRight.AddNode(this.nodes.TrafficLight2Right);
            this.nodes.TrafficLight2Right.AddNode(this.nodes.TrafficLight2ExitRight);
            this.nodes.TrafficLight2ExitRight.AddNode(this.nodes.NodeC2);
            this.nodes.NodeC1.AddNode(this.nodes.ExitNode5);
            this.nodes.NodeC2.AddNode(this.nodes.ExitNode6);
            this.nodes.Custom53.AddNode(this.nodes.TrafficLight3EntryLeft);
            this.nodes.TrafficLight3EntryLeft.AddNode(this.nodes.TrafficLight3WaitLeft);
            this.nodes.TrafficLight3WaitLeft.AddNode(this.nodes.TrafficLight3Left);
            this.nodes.TrafficLight3Left.AddNode(this.nodes.TrafficLight3ExitLeft);
            this.nodes.TrafficLight3ExitLeft.AddNode(this.nodes.NodeD1);
            this.nodes.NodeD2.AddNode(this.nodes.NodeI);
            this.nodes.NodeI.AddNode(this.nodes.NodeJ);
            this.nodes.NodeJ.AddNode(this.nodes.LaneSwitcher2.EntryNodeRight);
            this.nodes.LaneSwitcher2.ExitNodeRight.AddNode(this.nodes.TrafficLight8EntryRight);
            this.nodes.TrafficLight8EntryRight.AddNode(this.nodes.TrafficLight8WaitRight);
            this.nodes.TrafficLight8WaitRight.AddNode(this.nodes.TrafficLight8Right);
            this.nodes.TrafficLight8Right.AddNode(this.nodes.TrafficLight8ExitRight);
            this.nodes.TrafficLight8ExitRight.AddNode(this.nodes.NodeG2);
            this.nodes.NodeD1.AddNode(this.nodes.LaneSwitcher2.EntryNodeLeft);
            this.nodes.LaneSwitcher2.ExitNodeLeft.AddNode(this.nodes.Custom40);
            this.nodes.Custom40.AddNode(this.nodes.Custom41);
            this.nodes.Custom40.AddNode(this.nodes.TrafficLight8EntryLeft);
            this.nodes.TrafficLight8EntryLeft.AddNode(this.nodes.TrafficLight8WaitLeft);
            this.nodes.TrafficLight8WaitLeft.AddNode(this.nodes.TrafficLigh8Left);
            this.nodes.TrafficLigh8Left.AddNode(this.nodes.TrafficLight8ExitLeft);
            this.nodes.TrafficLight8ExitLeft.AddNode(this.nodes.NodeG1);
            this.nodes.Custom41.AddNode(this.nodes.TrafficLight7EntryRight);
            this.nodes.TrafficLight7EntryRight.AddNode(this.nodes.TrafficLight7WaitRight);
            this.nodes.TrafficLight7WaitRight.AddNode(this.nodes.TrafficLight7Right);
            this.nodes.TrafficLight7Right.AddNode(this.nodes.TrafficLight7ExitRight);
            this.nodes.TrafficLight7ExitRight.AddNode(this.nodes.NodeH2);
            this.nodes.Custom41.AddNode(this.nodes.TrafficLight7EntryLeft);
            this.nodes.TrafficLight7EntryLeft.AddNode(this.nodes.TrafficLight7WaitLeft);
            this.nodes.TrafficLight7WaitLeft.AddNode(this.nodes.TrafficLigh7Left);
            this.nodes.TrafficLigh7Left.AddNode(this.nodes.TrafficLight7ExitLeft);
            this.nodes.TrafficLight7ExitLeft.AddNode(this.nodes.NodeH1);
            this.nodes.NodeG1.AddNode(this.nodes.ExitNode3);
            this.nodes.NodeG2.AddNode(this.nodes.NodeK);
            this.nodes.NodeK.AddNode(this.nodes.ExitNode4);
            this.nodes.NodeH1.AddNode(this.nodes.NodeF1);
            this.nodes.NodeH2.AddNode(this.nodes.NodeF2);

            //east
            this.nodes.EntryNode3.AddNode(this.nodes.LaneSwitcher4.EntryNodeRight);
            this.nodes.LaneSwitcher4.ExitNodeRight.AddNode(this.nodes.Custom20);
            this.nodes.Custom20.AddNode(this.nodes.Custom21);
            this.nodes.Custom21.AddNode(this.nodes.Bus4);
            this.nodes.Custom21.AddNode(this.nodes.TrafficLight10Entry);
            this.nodes.TrafficLight10Entry.AddNode(this.nodes.TrafficLight10Wait);
            this.nodes.TrafficLight10Wait.AddNode(this.nodes.TrafficLight10);
            this.nodes.TrafficLight10.AddNode(this.nodes.TrafficLight10Exit);
            this.nodes.TrafficLight10Exit.AddNode(this.nodes.NodeF1);
            this.nodes.Bus4.AddNode(this.nodes.TrafficLight14Entry);
            this.nodes.TrafficLight14Entry.AddNode(this.nodes.TrafficLight14Wait);
            this.nodes.TrafficLight14Wait.AddNode(this.nodes.TrafficLight14);
            this.nodes.TrafficLight14.AddNode(this.nodes.TrafficLight14Exit);
            this.nodes.TrafficLight14Exit.AddNode(this.nodes.NodeF2);
            this.nodes.NodeF1.AddNode(this.nodes.ExitNode1);
            this.nodes.NodeF2.AddNode(this.nodes.ExitNode2);
            this.nodes.EntryNode4.AddNode(this.nodes.LaneSwitcher4.EntryNodeLeft);
            this.nodes.LaneSwitcher4.ExitNodeLeft.AddNode(this.nodes.TrafficLight9EntryLeft);
            this.nodes.TrafficLight9EntryLeft.AddNode(this.nodes.TrafficLight9WaitLeft);
            this.nodes.TrafficLight9WaitLeft.AddNode(this.nodes.TrafficLight9Left);
            this.nodes.TrafficLight9Left.AddNode(this.nodes.TrafficLight9ExitLeft);
            this.nodes.TrafficLight9ExitLeft.AddNode(this.nodes.NodeE1);
            this.nodes.Custom20.AddNode(this.nodes.TrafficLight9EntryRight);
            this.nodes.TrafficLight9EntryRight.AddNode(this.nodes.TrafficLight9WaitRight);
            this.nodes.TrafficLight9WaitRight.AddNode(this.nodes.TrafficLight9Right);
            this.nodes.TrafficLight9Right.AddNode(this.nodes.TrafficLight9ExitRight);
            this.nodes.TrafficLight9ExitRight.AddNode(this.nodes.NodeE2);

            //North
            this.nodes.EntryNode1.AddNode(this.nodes.LaneSwitcher3.EntryNodeRight);
            this.nodes.LaneSwitcher3.ExitNodeRight.AddNode(this.nodes.Custom1);
            this.nodes.Custom1.AddNode(this.nodes.TrafficLight11EntryRight);
            this.nodes.TrafficLight11EntryRight.AddNode(this.nodes.TrafficLight11WaitRight);
            this.nodes.TrafficLight11WaitRight.AddNode(this.nodes.TrafficLight11Right);
            this.nodes.TrafficLight11Right.AddNode(this.nodes.TrafficLight11ExitRight);
            this.nodes.TrafficLight11ExitRight.AddNode(this.nodes.NodeE2);
            this.nodes.Custom1.AddNode(this.nodes.TrafficLight11EntryLeft);
            this.nodes.TrafficLight11EntryLeft.AddNode(this.nodes.TrafficLight11WaitLeft);
            this.nodes.TrafficLight11WaitLeft.AddNode(this.nodes.TrafficLight11Left);
            this.nodes.TrafficLight11Left.AddNode(this.nodes.TrafficLight11ExitLeft);
            this.nodes.TrafficLight11ExitLeft.AddNode(this.nodes.NodeE1);

            this.nodes.EntryNode2.AddNode(this.nodes.LaneSwitcher3.EntryNodeLeft);
            this.nodes.LaneSwitcher3.ExitNodeLeft.AddNode(this.nodes.Custom3);
            this.nodes.Custom3.AddNode(this.nodes.TrafficLight12Entry);
            this.nodes.TrafficLight12Entry.AddNode(this.nodes.TrafficLight12Wait);
            this.nodes.TrafficLight12Wait.AddNode(this.nodes.TrafficLight12);
            this.nodes.TrafficLight12.AddNode(this.nodes.TrafficLight12Exit);
            this.nodes.TrafficLight12Exit.AddNode(this.nodes.NodeG2);
            this.nodes.Custom3.AddNode(this.nodes.Bus1);
            this.nodes.Bus1.AddNode(this.nodes.TrafficLight13Entry);
            this.nodes.TrafficLight13Entry.AddNode(this.nodes.TrafficLight13Wait);
            this.nodes.TrafficLight13Wait.AddNode(this.nodes.TrafficLight13);
            this.nodes.TrafficLight13.AddNode(this.nodes.TrafficLight13Exit);
            this.nodes.TrafficLight13Exit.AddNode(this.nodes.NodeG1);
            this.nodes.NodeE2.AddNode(this.nodes.LaneSwitcher5.EntryNodeRight);
            this.nodes.LaneSwitcher5.ExitNodeRight.AddNode(this.nodes.TrafficLight0EntryRight);
            this.nodes.TrafficLight0EntryRight.AddNode(this.nodes.TrafficLight0WaitRight);
            this.nodes.TrafficLight0WaitRight.AddNode(this.nodes.TrafficLight0Right);
            this.nodes.TrafficLight0Right.AddNode(this.nodes.TrafficLight0ExitRight);
            this.nodes.TrafficLight0ExitRight.AddNode(this.nodes.NodeB2);

            this.nodes.NodeE1.AddNode(this.nodes.LaneSwitcher5.EntryNodeLeft);
            this.nodes.LaneSwitcher5.ExitNodeLeft.AddNode(this.nodes.Custom30);
            this.nodes.Custom30.AddNode(this.nodes.Custom31);
            this.nodes.Custom30.AddNode(this.nodes.TrafficLight0EntryLeft);
            this.nodes.TrafficLight0EntryLeft.AddNode(this.nodes.TrafficLight0WaitLeft);
            this.nodes.TrafficLight0WaitLeft.AddNode(this.nodes.TrafficLight0Left);
            this.nodes.TrafficLight0Left.AddNode(this.nodes.TrafficLight0ExitLeft);
            this.nodes.TrafficLight0ExitLeft.AddNode(this.nodes.NodeB1);
            this.nodes.Custom31.AddNode(this.nodes.TrafficLight1EntryRight);
            this.nodes.TrafficLight1EntryRight.AddNode(this.nodes.TrafficLight1WaitRight);
            this.nodes.TrafficLight1WaitRight.AddNode(this.nodes.TrafficLight1Right);
            this.nodes.TrafficLight1Right.AddNode(this.nodes.TrafficLight1ExitRight);
            this.nodes.TrafficLight1ExitRight.AddNode(this.nodes.NodeA2);
            this.nodes.Custom31.AddNode(this.nodes.TrafficLight1EntryLeft);
            this.nodes.TrafficLight1EntryLeft.AddNode(this.nodes.TrafficLight1WaitLeft);
            this.nodes.TrafficLight1WaitLeft.AddNode(this.nodes.TrafficLight1Left);
            this.nodes.TrafficLight1Left.AddNode(this.nodes.TrafficLight1ExitLeft);
            this.nodes.TrafficLight1ExitLeft.AddNode(this.nodes.NodeA1);
            this.nodes.NodeA1.AddNode(this.nodes.NodeC1);
            this.nodes.NodeA2.AddNode(this.nodes.NodeC2);

            //Ventweg
            this.nodes.EntryNode8.AddNode(this.nodes.LaneSwitcher6.EntryNodeRight);
            this.nodes.LaneSwitcher6.ExitNodeLeft.AddNode(this.nodes.Custom70);
          //  this.nodes.Custom74.AddNode(this.nodes.Custom70);
            this.nodes.Custom70.AddNode(this.nodes.NodeI);
            this.nodes.NodeJ.AddNode(this.nodes.Custom71);
            this.nodes.Custom71.AddNode(this.nodes.Custom72);
            this.nodes.Custom72.AddNode(this.nodes.Custom73);
            this.nodes.Custom73.AddNode(this.nodes.NodeK);
        }

        private void BuildBycycleRoutes()
        {
            this.nodes.EntryNode11.AddNode(this.nodes.TrafficLight40EntryLeft);
            this.nodes.TrafficLight40EntryLeft.AddNode(this.nodes.TrafficLight40WaitLeft);
            this.nodes.TrafficLight40WaitLeft.AddNode(this.nodes.TrafficLight40Left);
            this.nodes.TrafficLight40Left.AddNode(this.nodes.TrafficLight40ExitLeft);
            this.nodes.EntryNode10.AddNode(this.nodes.Nodec4);
            this.nodes.EntryNode9.AddNode(this.nodes.Nodec7);
            this.nodes.Nodec7.AddNode(this.nodes.Nodec1);
            this.nodes.Nodec1.AddNode(this.nodes.Nodec6);
            this.nodes.Nodec1.AddNode(this.nodes.Nodec11);
            this.nodes.Custom70.AddNode(this.nodes.TrafficLight224EntryLeft);
            this.nodes.TrafficLight224EntryLeft.AddNode(this.nodes.TrafficLight224WaitLeft);
            this.nodes.TrafficLight224WaitLeft.AddNode(this.nodes.TrafficLight224Left);
            this.nodes.TrafficLight224Left.AddNode(this.nodes.TrafficLight224ExitLeft);
            this.nodes.TrafficLight224ExitLeft.AddNode(this.nodes.Nodec2);
            this.nodes.Custom70.AddNode(this.nodes.Nodec8);
            this.nodes.Custom70.AddNode(this.nodes.Nodec12);
            this.nodes.Custom71.AddNode(this.nodes.Nodec8);
            this.nodes.Nodec2.AddNode(this.nodes.Nodec3);
            this.nodes.Nodec3.AddNode(this.nodes.Nodec4);
            this.nodes.Nodec3.AddNode(this.nodes.ExitNode10);
            this.nodes.Nodec4.AddNode(this.nodes.Nodec5);
            this.nodes.Nodec4.AddNode(this.nodes.Nodec9);
            this.nodes.Nodec5.AddNode(this.nodes.TrafficLight220EntryLeft);
            this.nodes.TrafficLight220EntryLeft.AddNode(this.nodes.TrafficLight220WaitLeft);
            this.nodes.TrafficLight220WaitLeft.AddNode(this.nodes.TrafficLight220Left);
            this.nodes.TrafficLight220Left.AddNode(this.nodes.TrafficLight220ExitLeft);
            this.nodes.TrafficLight220ExitLeft.AddNode(this.nodes.Nodec1);
            this.nodes.Nodec5.AddNode(this.nodes.Nodec16);
            this.nodes.Nodec16.AddNode(this.nodes.ExitNode9);
            this.nodes.Nodec6.AddNode(this.nodes.TrafficLight221EntryLeft);
            this.nodes.TrafficLight221EntryLeft.AddNode(this.nodes.TrafficLight221WaitLeft);
            this.nodes.TrafficLight221WaitLeft.AddNode(this.nodes.TrafficLight221Left);
            this.nodes.TrafficLight221Left.AddNode(this.nodes.TrafficLight221ExitLeft);
            this.nodes.TrafficLight221ExitLeft.AddNode(this.nodes.Nodec10);
            this.nodes.Nodec6.AddNode(this.nodes.TrafficLight222EntryLeft);
            this.nodes.TrafficLight222EntryLeft.AddNode(this.nodes.TrafficLight222WaitLeft);
            this.nodes.TrafficLight222WaitLeft.AddNode(this.nodes.TrafficLight222Left);
            this.nodes.TrafficLight222Left.AddNode(this.nodes.TrafficLight222ExitLeft);
            this.nodes.TrafficLight222ExitLeft.AddNode(this.nodes.Custom70);
            this.nodes.Nodec8.AddNode(this.nodes.TrafficLight223EntryLeft);
            this.nodes.TrafficLight223EntryLeft.AddNode(this.nodes.TrafficLight223WaitLeft);
            this.nodes.TrafficLight223WaitLeft.AddNode(this.nodes.TrafficLight223Left);
            this.nodes.TrafficLight223Left.AddNode(this.nodes.TrafficLight223ExitLeft);
            this.nodes.TrafficLight223ExitLeft.AddNode(this.nodes.TrafficLight221EntryLeft);
            this.nodes.Nodec8.AddNode(this.nodes.Custom70);
            this.nodes.Nodec9.AddNode(this.nodes.TrafficLight225EntryLeft);
            this.nodes.TrafficLight225EntryLeft.AddNode(this.nodes.TrafficLight225WaitLeft);
            this.nodes.TrafficLight225WaitLeft.AddNode(this.nodes.TrafficLight225Left);
            this.nodes.TrafficLight225Left.AddNode(this.nodes.TrafficLight225ExitLeft);
            this.nodes.TrafficLight225ExitLeft.AddNode(this.nodes.Nodec8);
            this.nodes.Nodec10.AddNode(this.nodes.Nodec3);
            this.nodes.Nodec11.AddNode(this.nodes.ExitNode11);
            this.nodes.Nodec12.AddNode(this.nodes.Custom71);
            this.nodes.TrafficLight40ExitLeft.AddNode(this.nodes.Nodec14);
            this.nodes.Nodec14.AddNode(this.nodes.Nodec15);
            this.nodes.Nodec15.AddNode(this.nodes.Nodec17);
            this.nodes.Nodec17.AddNode(this.nodes.Nodec2);
            this.nodes.Custom73.AddNode(this.nodes.ExitNode12);
            this.nodes.EntryNode12.AddNode(this.nodes.LaneSwitcher6.EntryNodeLeft);
        }

        private void BuildPedestrianRoutes()
        {
            nodes.EntryNode13.AddNode(nodes.Nodep1);
            nodes.Nodep1.AddNode(nodes.Nodep2);
            nodes.Nodep2.AddNode(nodes.TrafficLight38EntryLeft);
            nodes.TrafficLight38EntryLeft.AddNode(nodes.TrafficLight38WaitLeft);
            nodes.TrafficLight38WaitLeft.AddNode(nodes.TrafficLight38Left);
            nodes.TrafficLight38Left.AddNode(nodes.TrafficLight38ExitLeft);
            nodes.TrafficLight38ExitLeft.AddNode(nodes.TrafficLight36EntryLeft);
            nodes.TrafficLight36EntryLeft.AddNode(nodes.TrafficLight36WaitLeft);
            nodes.TrafficLight36WaitLeft.AddNode(nodes.TrafficLight36Left);
            nodes.TrafficLight36Left.AddNode(nodes.TrafficLight36ExitLeft);
            nodes.TrafficLight36ExitLeft.AddNode(nodes.Nodep3);
            nodes.Nodep3.AddNode(nodes.Nodep4);
            nodes.Nodep4.AddNode(nodes.ExitNode13);

            nodes.EntryNode14.AddNode(nodes.Nodep4);
            nodes.Nodep4.AddNode(nodes.Nodep3);
            nodes.Nodep3.AddNode(nodes.TrafficLight35EntryLeft);
            nodes.TrafficLight35EntryLeft.AddNode(nodes.TrafficLight35WaitLeft);
            nodes.TrafficLight35WaitLeft.AddNode(nodes.TrafficLight35Left);
            nodes.TrafficLight35Left.AddNode(nodes.TrafficLight35ExitLeft);
            nodes.TrafficLight36ExitLeft.AddNode(nodes.TrafficLight37EntryLeft);
            nodes.TrafficLight37EntryLeft.AddNode(nodes.TrafficLight37WaitLeft);
            nodes.TrafficLight37WaitLeft.AddNode(nodes.TrafficLight37Left);
            nodes.TrafficLight37Left.AddNode(nodes.TrafficLight37ExitLeft);
            nodes.TrafficLight37ExitLeft.AddNode(nodes.Nodep2);
            nodes.Nodep2.AddNode(nodes.Nodep1);
            nodes.Nodep1.AddNode(nodes.ExitNode14);

            nodes.Nodep3.AddNode(nodes.Nodep5);
            nodes.Nodep5.AddNode(nodes.Nodep3);
            nodes.Nodep5.AddNode(nodes.Nodep6);
            nodes.Nodep6.AddNode(nodes.Nodep5);
            nodes.EntryNode15.AddNode(nodes.Nodep6);
            nodes.Nodep6.AddNode(nodes.ExitNode15);
            nodes.Nodep6.AddNode(nodes.Nodep7);
            nodes.Nodep7.AddNode(nodes.Nodep6);

            nodes.Nodep7.AddNode(nodes.TrafficLight48EntryLeft);
            nodes.TrafficLight48EntryLeft.AddNode(nodes.TrafficLight48WaitLeft);
            nodes.TrafficLight48WaitLeft.AddNode(nodes.TrafficLight48Left);
            nodes.TrafficLight48Left.AddNode(nodes.TrafficLight48ExitLeft);
            nodes.TrafficLight48ExitLeft.AddNode(nodes.TrafficLight25EntryLeft);
            nodes.TrafficLight25EntryLeft.AddNode(nodes.TrafficLight25WaitLeft);
            nodes.TrafficLight25WaitLeft.AddNode(nodes.TrafficLight25Left);
            nodes.TrafficLight25Left.AddNode(nodes.TrafficLight25ExitLeft);
            nodes.TrafficLight25ExitLeft.AddNode(nodes.Nodep8);
            nodes.Nodep8.AddNode(nodes.TrafficLight26EntryLeft);
            nodes.TrafficLight26EntryLeft.AddNode(nodes.TrafficLight26WaitLeft);
            nodes.TrafficLight26WaitLeft.AddNode(nodes.TrafficLight26Left);
            nodes.TrafficLight26Left.AddNode(nodes.TrafficLight26ExitLeft);
            nodes.TrafficLight26ExitLeft.AddNode(nodes.TrafficLight49EntryLeft);
            nodes.TrafficLight49EntryLeft.AddNode(nodes.TrafficLight49WaitLeft);
            nodes.TrafficLight49WaitLeft.AddNode(nodes.TrafficLight49Left);
            nodes.TrafficLight49Left.AddNode(nodes.TrafficLight49ExitLeft);
            nodes.TrafficLight49ExitLeft.AddNode(nodes.Nodep7);


            nodes.Nodep8.AddNode(nodes.TrafficLight50EntryLeft);
            nodes.TrafficLight50EntryLeft.AddNode(nodes.TrafficLight50WaitLeft);
            nodes.TrafficLight50WaitLeft.AddNode(nodes.TrafficLight50Left);
            nodes.TrafficLight50Left.AddNode(nodes.TrafficLight50ExitLeft);
            nodes.TrafficLight50ExitLeft.AddNode(nodes.TrafficLight15EntryLeft);
            nodes.TrafficLight15EntryLeft.AddNode(nodes.TrafficLight15WaitLeft);
            nodes.TrafficLight15WaitLeft.AddNode(nodes.TrafficLight15Left);
            nodes.TrafficLight15Left.AddNode(nodes.TrafficLight15ExitLeft);
            nodes.TrafficLight15ExitLeft.AddNode(nodes.Nodep2);

            nodes.Nodep2.AddNode(nodes.TrafficLight47EntryLeft);
            nodes.TrafficLight47EntryLeft.AddNode(nodes.TrafficLight47WaitLeft);
            nodes.TrafficLight47WaitLeft.AddNode(nodes.TrafficLight47Left);
            nodes.TrafficLight47Left.AddNode(nodes.TrafficLight47ExitLeft);
            nodes.TrafficLight47ExitLeft.AddNode(nodes.TrafficLight16EntryLeft);
            nodes.TrafficLight16EntryLeft.AddNode(nodes.TrafficLight16WaitLeft);
            nodes.TrafficLight16WaitLeft.AddNode(nodes.TrafficLight16Left);
            nodes.TrafficLight16Left.AddNode(nodes.TrafficLight16ExitLeft);
            nodes.TrafficLight16ExitLeft.AddNode(nodes.Nodep8);

            nodes.Nodep1.AddNode(nodes.Nodep9);
            nodes.Nodep2.AddNode(nodes.Nodep9);
            nodes.Nodep9.AddNode(nodes.Nodep1);
            nodes.Nodep9.AddNode(nodes.Nodep2);
            nodes.Nodep9.AddNode(nodes.Nodep10);
            nodes.Nodep10.AddNode(nodes.Nodep9);
            nodes.Nodep10.AddNode(nodes.ExitNode16);
            nodes.EntryNode16.AddNode(nodes.Nodep10);

            nodes.Nodep8.AddNode(nodes.Nodep11);
            nodes.Nodep11.AddNode(nodes.Nodep8);
            nodes.Nodep11.AddNode(nodes.ExitNode17);
            nodes.EntryNode17.AddNode(nodes.Nodep11);

            nodes.Nodep7.AddNode(nodes.Nodep12);
            nodes.Nodep12.AddNode(nodes.Nodep7);
            nodes.Nodep12.AddNode(nodes.Nodep13);
            nodes.Nodep13.AddNode(nodes.Nodep12);

            nodes.Nodep13.AddNode(nodes.Nodep14);
            nodes.Nodep14.AddNode(nodes.Nodep13);

            nodes.Nodep14.AddNode(nodes.TrafficLight23EntryLeft);
            nodes.TrafficLight23EntryLeft.AddNode(nodes.TrafficLight23WaitLeft);
            nodes.TrafficLight23WaitLeft.AddNode(nodes.TrafficLight23Left);
            nodes.TrafficLight23Left.AddNode(nodes.TrafficLight23ExitLeft);
            nodes.TrafficLight23ExitLeft.AddNode(nodes.TrafficLight21EntryLeft);
            nodes.TrafficLight21EntryLeft.AddNode(nodes.TrafficLight21WaitLeft);
            nodes.TrafficLight21WaitLeft.AddNode(nodes.TrafficLight21Left);
            nodes.TrafficLight21Left.AddNode(nodes.TrafficLight21ExitLeft);
            nodes.TrafficLight21ExitLeft.AddNode(nodes.Nodep15);

            nodes.Nodep15.AddNode(nodes.TrafficLight22EntryLeft);
            nodes.TrafficLight22EntryLeft.AddNode(nodes.TrafficLight22WaitLeft);
            nodes.TrafficLight22WaitLeft.AddNode(nodes.TrafficLight22Left);
            nodes.TrafficLight22Left.AddNode(nodes.TrafficLight22ExitLeft);
            nodes.TrafficLight22ExitLeft.AddNode(nodes.TrafficLight24EntryLeft);
            nodes.TrafficLight24EntryLeft.AddNode(nodes.TrafficLight24WaitLeft);
            nodes.TrafficLight24WaitLeft.AddNode(nodes.TrafficLight24Left);
            nodes.TrafficLight24Left.AddNode(nodes.TrafficLight24ExitLeft);
            nodes.TrafficLight24ExitLeft.AddNode(nodes.Nodep14);

            nodes.Nodep15.AddNode(nodes.Nodep16);
            nodes.Nodep16.AddNode(nodes.Nodep15);
            nodes.Nodep16.AddNode(nodes.ExitNode18);
            nodes.EntryNode18.AddNode(nodes.Nodep16);

            nodes.EntryNode19.AddNode(nodes.Nodep15);
            nodes.Nodep15.AddNode(nodes.ExitNode19);

            nodes.Nodep15.AddNode(nodes.TrafficLight17EntryLeft);
            nodes.TrafficLight17EntryLeft.AddNode(nodes.TrafficLight17WaitLeft);
            nodes.TrafficLight17WaitLeft.AddNode(nodes.TrafficLight17Left);
            nodes.TrafficLight17Left.AddNode(nodes.TrafficLight17ExitLeft);
            nodes.TrafficLight17ExitLeft.AddNode(nodes.TrafficLight19EntryLeft);
            nodes.TrafficLight19EntryLeft.AddNode(nodes.TrafficLight19WaitLeft);
            nodes.TrafficLight19WaitLeft.AddNode(nodes.TrafficLight19Left);
            nodes.TrafficLight19Left.AddNode(nodes.TrafficLight19ExitLeft);
            nodes.TrafficLight19ExitLeft.AddNode(nodes.Nodep17);

            nodes.Nodep17.AddNode(nodes.TrafficLight20EntryLeft);
            nodes.TrafficLight20EntryLeft.AddNode(nodes.TrafficLight20WaitLeft);
            nodes.TrafficLight20WaitLeft.AddNode(nodes.TrafficLight20Left);
            nodes.TrafficLight20Left.AddNode(nodes.TrafficLight20ExitLeft);
            nodes.TrafficLight20ExitLeft.AddNode(nodes.TrafficLight18EntryLeft);
            nodes.TrafficLight18EntryLeft.AddNode(nodes.TrafficLight18WaitLeft);
            nodes.TrafficLight18WaitLeft.AddNode(nodes.TrafficLight18Left);
            nodes.TrafficLight18Left.AddNode(nodes.TrafficLight18ExitLeft);
            nodes.TrafficLight18ExitLeft.AddNode(nodes.Nodep15);

            nodes.Nodep17.AddNode(nodes.Nodep18);
            nodes.Nodep18.AddNode(nodes.Nodep17);
            nodes.Nodep18.AddNode(nodes.Nodep11);
            nodes.Nodep11.AddNode(nodes.Nodep18);

            nodes.EntryNode20.AddNode(nodes.Nodep17);
            nodes.Nodep17.AddNode(nodes.ExitNode20);
        }
    }
}


