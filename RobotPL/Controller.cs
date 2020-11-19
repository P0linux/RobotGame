using RobotBLL.Abstraction;
using RobotPL.Abstract;
using RobotPL.Mappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotPL
{
    class Controller
    {
        IView view;
        IGameController gameController;
        FieldMapper mapper = new FieldMapper();

        public Controller(IView view, IGameController gameController)
        {
            this.view = view;
            this.gameController = gameController;
        }

        public void StartGame()
        {
            view.DisplayStartMenu();
            gameController.CreateGameState(view.gameStateModel.x, view.gameStateModel.y, view.gameStateModel.cargoAmount, view.gameStateModel.toxicCargoAmount,
                                           view.gameStateModel.MaxPrice, view.gameStateModel.MaxWeight, view.gameStateModel.IsDecoding);
            gameController.CreatePlayerState(view.playerStateModel.Number, view.playerStateModel.Name);
            var gameState = gameController.GetGameState();
            view.DisplayField(mapper.Map(gameState.GameField));
        }
    }
}
