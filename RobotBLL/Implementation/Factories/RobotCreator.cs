using RobotBLL.Implementation.RobotModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Implementation.Factories
{
    public abstract class RobotCreator
    {
        public abstract Robot CreateRobot(RobotModel model);
    }
}
