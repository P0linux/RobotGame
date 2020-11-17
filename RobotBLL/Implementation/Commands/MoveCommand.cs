using RobotBLL.Abstraction;
using RobotBLL.Implementation.RobotModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Implementation.Commands
{
    class MoveCommand: Command
    {
        IChangeGameStateService gameState;
        IChangePlayerStateService playerState;
        public MoveCommand(IChangeGameStateService changeGameState, IChangePlayerStateService changePlayerState)
        {
            gameState = changeGameState;
            playerState = changePlayerState;
        }

        public void Execute()
        {

        }

        public void Undo()
        {

        }
    }
}
