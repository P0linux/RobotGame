using RobotBLL.Abstraction;
using RobotBLL.Implementation.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Implementation.Services
{
    class ChangeGameStateService: IChangeGameStateService
    {
        GameState gameState;

        public ChangeGameStateService(GameState state)
        {
            gameState = state;
        }


    }
}
