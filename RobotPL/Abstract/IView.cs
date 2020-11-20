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
        string userOption { get; set; }
        string moveParameter { get; set; }

        event View.Handler OnMove;
        event View.Handler OnPickCargo;
        event View.Handler OnMoveUndo;
        event View.Handler OnPickUndo;


        void DisplayStartMenu();
        void DisplayField(FieldModel fieldModel);
        void DisplayGameMenu();
        void DisplayEndResult(double totalPrice);
    }
}
