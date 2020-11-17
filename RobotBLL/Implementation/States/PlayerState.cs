using RobotBLL.Implementation.RobotModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Implementation.States
{
    public class PlayerState
    {
        public Robot GameRobot { get; set; }

        public PlayerState(Robot robot)
        {
            GameRobot = robot;
        }
    }
}
