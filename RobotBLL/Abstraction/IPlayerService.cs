using RobotBLL.Implementation.Memento;
using RobotBLL.Implementation.RobotModels;
using RobotBLL.Implementation.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Abstraction
{
    public interface IPlayerService
    {
        PlayerState CreatePlayerState(RobotModel model, GameHistory history);
    }
}
