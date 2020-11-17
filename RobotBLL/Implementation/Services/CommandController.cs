using RobotBLL.Abstraction;
using RobotBLL.Implementation.Commands;
using RobotBLL.Implementation.RobotModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Implementation.Services
{
    
    public class CommandController: ICommandController
    {
        Command MoveCommand;
        Command PickCargoCommand;

        public void SetMoveCommand(IGameStateService gameService, IPlayerStateService playerService)
        {
            MoveCommand = new MoveCommand(gameService, playerService);
        }

        public void SetPickCommand()
        {
            PickCargoCommand = new PickCargoCommand();
        }

        public void Move(Enums.MoveParameter parameter)
        {
            MoveCommand.Execute(parameter);
        }

        public void MoveUndo()
        {
            MoveCommand.Undo();
        }

        public void PickCargo()
        {
            PickCargoCommand.Execute();
        }

        public void PickCargoUndo()
        {
            PickCargoCommand.Undo();
        }
    }
}
