using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public enum Direction { Noord, Oost, Zuid, West, Ventweg  }
    public enum VehicleType {  Auto, Fiets, Bus, Voetganger}
    public enum Lane {  Links, Rechts }
    public enum TrafficLightState {  Rood, Oranje, Groen }
    public enum VehicleState { Driving, Stopping };
}
