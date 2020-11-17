using RobotBLL.Abstraction;
using RobotBLL.Implementation.RobotModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Implementation.Commands
{
    class MoveCommand: Command
    {
        IGameStateService gameState;
        IPlayerStateService playerState;
        public MoveCommand(IGameStateService changeGameState, IPlayerStateService changePlayerState)
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
