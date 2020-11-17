﻿using RobotBLL.Abstraction;
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

        public (int, int) GetRobotCoordinates()
        {
            for (int i = 0; i<gameState.GameField.x; i++)
            {
                for (int j=0; j<gameState.GameField.y; j++)
                {
                    if (gameState.GameField.Cells[i, j].CurrentState == Enums.CellState.Robot) 
                        return (i, j);
                }
            }
            return (0, 0);
        }

        public (int, int) GetFieldDimension()
        {
            return (gameState.GameField.x, gameState.GameField.y);
        }

        public void MoveUpdateField((int, int) newCoordinates)
        {
            (int, int) oldCoordinates = GetRobotCoordinates();
            for (int i = 0; i < gameState.GameField.x; i++)
            {
                for (int j = 0; j < gameState.GameField.y; j++)
                {
                    
                }
            }
        }
    }
}
