using RobotBLL.Implementation.RobotModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Implementation.Factories
{
    class WorkerRobotCreator : RobotCreator
    {
        public override Robot CreateRobot(RobotModel model)
        {
            Robot robot = new WorkerRobot(model);
            robot.DecodingProbability = 10;
            robot.Carrying = 20;
            return robot;
        }
    }
}
