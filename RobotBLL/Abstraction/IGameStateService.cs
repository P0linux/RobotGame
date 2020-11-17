﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Abstraction
{
    public interface IGameStateService
    {
        void ReduceCargoAmount();
        void IncreaseCargoAmount();
        void IncreaseTotalPrice(float price);
        (int, int) GetRobotCoordinates();
        (int, int) GetFieldDimension();
        void MoveUpdateField((int, int) newCoordinates);

    }
}
