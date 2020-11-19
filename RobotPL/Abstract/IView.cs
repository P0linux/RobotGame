using RobotPL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotPL.Abstract
{
    interface IView
    {
        GameStateModel gameStateModel { get; set; }
        PlayerStateModel playerStateModel { get; set; }

        void DisplayStartMenu();
        void DisplayField(FieldModel fieldModel);
    }
}
