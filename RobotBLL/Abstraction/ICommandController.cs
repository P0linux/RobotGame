using RobotBLL.Implementation.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Abstraction
{
    public interface ICommandController
    {
        void SetMoveCommand(Command command);
        void SetPickCommand(Command command);
        void Move();
        void MoveUndo();
        void PickCargo();
        void PickCargoUndo();
    }
}
