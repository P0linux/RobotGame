using System;
using System.Collections.Generic;
using System.Text;
using RobotWPF.Models;

namespace RobotWPF
{
    public interface IModel
    {
        void StartGame(GameStateModel gameModel, PlayerStateModel playerModel);
        int[,] GetField();
    }
}
