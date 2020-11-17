using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Implementation.Memento
{
    public class RobotMemento
    {
        public int BatteryCharge { get; private set; }
        public RobotMemento(int battery)
        {
            BatteryCharge = battery;
        }
    }
}
