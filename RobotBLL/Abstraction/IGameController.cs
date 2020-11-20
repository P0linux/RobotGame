using RobotBLL.Implementation.Enums;
using RobotBLL.Implementation.Models;
using RobotBLL.Implementation.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Abstraction
{
    public interface IGameController
    {
        void CreateGameState(GameStateOptions options);
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
