using RobotBLL.Abstraction;
using RobotBLL.Implementation.Commands;
using RobotBLL.Implementation.RobotModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Implementation.Services
{
    class CommandController
    {
        Command MoveCommand;
        Command PickCargoCommand;

        public void SetMoveCommand()
        {
            MoveCommand = new MoveCommand();
        }

        public void SetPickCommand()
        {
            PickCargoCommand = new PickCargoCommand();
        }

        public void Move()
        {
            MoveCommand.Execute();
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
