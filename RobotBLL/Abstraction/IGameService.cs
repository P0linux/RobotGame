using RobotBLL.Implementation.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Abstraction
{
    public interface IGameService
    {
        GameState CreateGameState(int x, int y, int cargoAmount, int toxicCargoAmount, double maxPrice,
                                         double maxWeight, bool isDecoding);
    }
}
