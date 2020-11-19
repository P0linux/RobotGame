using RobotBLL.Abstraction;
using RobotBLL.Implementation.RobotModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Implementation.Commands
{
    class PickCargoCommand: Command
    {
        IGameStateService gameStateService;
        IPlayerStateService playerStateService;
        public PickCargoCommand(IGameStateService changeGameState, IPlayerStateService changePlayerState)
        {
            gameStateService = changeGameState;
            playerStateService = changePlayerState;
        }

        public override void Execute()
        {

        }

        public override void Undo()
        {
            playerStateService.RestoreState();
            gameStateService.UndoUpdateField();
        }
    }
}
