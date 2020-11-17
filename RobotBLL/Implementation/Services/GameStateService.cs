using RobotBLL.Abstraction;
using RobotBLL.Implementation.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Implementation.Services
{
    class GameStateService: IGameStateService
    {
        GameState gameState;

        public GameStateService(GameState state)
        {
            gameState = state;
        }

        public void ReduceCargoAmount()
        {
            gameState.CargoAmount--;
        }

        public void IncreaseCargoAmount()
        {
            gameState.CargoAmount++;
        }

        public void IncreaseTotalPrice(float price)
        {
            gameState.TotalCurrentPrice += price;
        }
    }
}
