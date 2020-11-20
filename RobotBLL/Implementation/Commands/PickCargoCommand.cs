using RobotBLL.Abstraction;
using RobotBLL.Exceptions;
using RobotBLL.Implementation.CargoModels;
using RobotBLL.Implementation.Enums;
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
        int pickCharge = 10;
        public PickCargoCommand(IGameStateService changeGameState, IPlayerStateService changePlayerState)
        {
            gameStateService = changeGameState;
            playerStateService = changePlayerState;
        }

        public override void Execute()
        {
            var robotCoordinates = gameStateService.GetRobotCoordinates();
            var cargo = CheckCargo(robotCoordinates);
            gameStateService.IncreaseTotalPrice(cargo.Price);
            playerStateService.reduceBatteryCharge(pickCharge);
            gameStateService.PickCargoUpdateField(robotCoordinates);
        }

        public override void Undo()
        {
            playerStateService.RestoreState();
            gameStateService.UndoUpdateField();
        }

        private Cargo CheckCargo((int, int) robotCoordinates)
        {
            int x = robotCoordinates.Item1;
            int y = robotCoordinates.Item2;
            var cell = gameStateService.GetCell(robotCoordinates);
            if (cell.CurrentState == CellState.RobotCargo) return cell.Cargo;
            else throw new PickCargoException("No cargo in the cell");
        }
    }
}
