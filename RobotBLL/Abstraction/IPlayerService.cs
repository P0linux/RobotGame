using RobotBLL.Implementation.RobotModels;
using RobotBLL.Implementation.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Abstraction
{
    interface IPlayerService
    {
        PlayerState CreatePlayerState(RobotModel model);
    }
}
