using RobotBLL.Abstraction;
using RobotBLL.Exceptions;
using RobotBLL.Implementation.RobotModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Implementation.Commands
{
    class MoveCommand: Command
    {
        int moveCharge = 10;
        IGameStateService gameState;
        IPlayerStateService playerState;
        public MoveCommand(IGameStateService changeGameState, IPlayerStateService changePlayerState)
        {
            gameState = changeGameState;
            playerState = changePlayerState;
        }

        public void Execute(Enums.MoveParameter parameter)
        {
            (int, int) newCoordinates = CheckParameter(parameter);
            playerState.reduceBatteryCharge(moveCharge);
            playerState.SaveState();
            gameState.MoveUpdateField(newCoordinates);
        }

        public void Undo()
        {

        }

        private (int, int) CheckParameter(Enums.MoveParameter param)
        {
            (int, int) coordinates = gameState.GetRobotCoordinates();
            switch (param)
            {
                case Enums.MoveParameter.Up:
                    return CanMoveUp(coordinates);
                case Enums.MoveParameter.Down:
                    return CanMoveDown(coordinates);
                case Enums.MoveParameter.Left:
                    return CanMoveLeft(coordinates);
                case Enums.MoveParameter.Right:
                    return CanMoveRight(coordinates);
                default:
                    return (0, 0);
            }
        }

        private (int, int) CanMoveUp((int, int) coordinates)
        {
            if (coordinates.Item1 == 0) throw new MoveException("Can not move up");
            return (coordinates.Item1 - 1, coordinates.Item2);
        }

        private (int, int) CanMoveDown((int, int) coordinates)
        {
            (int, int) dimension = gameState.GetFieldDimension();
            if (coordinates.Item2 == dimension.Item1 - 1) throw new MoveException("Can not move down");
            return (coordinates.Item1 + 1, coordinates.Item2);
        }

        private (int, int) CanMoveLeft((int, int) coordinates)
        {
            if (coordinates.Item2 == 0) throw new MoveException("can not move Left");
            return (coordinates.Item1, coordinates.Item2 - 1);
        }

        private (int, int) CanMoveRight((int, int) coordinates)
        {
            (int, int) dimension = gameState.GetFieldDimension();
            if (coordinates.Item2 == dimension.Item2 - 1) throw new MoveException("Can not move down");
            return (coordinates.Item1, coordinates.Item2 + 1);
        }
    }
}
