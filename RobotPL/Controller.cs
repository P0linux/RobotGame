using RobotBLL.Abstraction;
using RobotPL.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotPL
{
    class Controller
    {
        IView view;
        IGameController gameController;

        public Controller(IView view, IGameController gameController)
        {
            this.view = view;
            this.gameController = gameController;
        }


    }
}
