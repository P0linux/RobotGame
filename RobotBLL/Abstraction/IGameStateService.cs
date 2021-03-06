﻿using RobotBLL.Implementation.CargoModels;
using RobotBLL.Implementation.FieldModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Abstraction
{
    public interface IGameStateService
    {
        void ReduceCargoAmount();
        void IncreaseCargoAmount();
        void IncreaseTotalPrice(double price);
        (int, int) GetRobotCoordinates();
        (int, int) GetFieldDimension();
        void MoveUpdateField((int, int) newCoordinates);
        void PickCargoUpdateField((int, int) coordinates);
        void UndoUpdateField();
        void CheckEndGame(int robotCharge);
        Cell GetCell((int, int) cellCoordinates);
        Cargo GetCurrentCellCargo();
    }
}
