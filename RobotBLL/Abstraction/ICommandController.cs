using RobotBLL.Implementation.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Abstraction
{
    interface ICommandController
    {
        void SetMoveCommand(IGameStateService gameService, IPlayerStateService playerService);
        void SetPickCommand();
        void Move(MoveParameter parameter);
        void MoveUndo();
        void PickCargo();
        void PickCargoUndo();
    }
}
