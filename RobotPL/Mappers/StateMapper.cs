﻿using RobotBLL.Implementation.Models;
using RobotPL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotPL.Mappers
{
    class StateMapper
    {
        public GameStateOptions Map(GameStateModel gameStateModel)
        {
            return new GameStateOptions
            {
                x = gameStateModel.x,
                y = gameStateModel.y,
                CargoAmount = gameStateModel.cargoAmount,
                ToxicCargoAmount = gameStateModel.toxicCargoAmount,
                MaxPrice = gameStateModel.MaxPrice,
                MaxWeight = gameStateModel.MaxWeight,
                IsDecoding = gameStateModel.IsDecoding
            };
        }
    }
}
