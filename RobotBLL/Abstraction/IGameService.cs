using RobotBLL.Implementation.Models;
using RobotBLL.Implementation.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Abstraction
{
    public interface IGameService
    {
        GameState CreateGameState(GameStateOptions options);
    }
}
