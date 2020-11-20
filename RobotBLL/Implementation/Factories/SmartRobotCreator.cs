using RobotBLL.Implementation.RobotModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Implementation.Factories
{
    class SmartRobotCreator : RobotCreator
    {
        public override Robot CreateRobot(RobotModel model)
        {
            Robot robot = new WorkerRobot(model);
            robot.DecodingProbability = 100;
            robot.Carrying = 10;
            return robot;
        }
    }
}
