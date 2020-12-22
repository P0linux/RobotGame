using RobotBLL.Implementation.Models;
using RobotWPF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotWPF.Mappers
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
