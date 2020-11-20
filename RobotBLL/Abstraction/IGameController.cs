using RobotBLL.Implementation.Enums;
using RobotBLL.Implementation.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Abstraction
{
    public interface IGameController
    {
        void CreateGameState(int x, int y, int cargoAmount, int toxicCargoAmount,
                                     double maxPrice, double maxWeight, bool isDecoding);
        void CreatePlayerState(int number, string name);
        GameState GetGameState();
        PlayerState GetPlayerState();
        void Move(MoveParameter moveParameter);
        void MoveUndo();
        void PickCargo();
        void PickUndo();
        bool CheckEndGame();
    }
}
