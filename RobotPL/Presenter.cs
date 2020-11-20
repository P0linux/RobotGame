using RobotBLL.Abstraction;
using RobotPL.Abstract;
using RobotPL.Mappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotPL
{
    class Presenter
    {
        IView view;
        IGameController gameController;
        FieldMapper mapper = new FieldMapper();
        MoveParameterMapper moveMapper = new MoveParameterMapper();

        public Presenter(IView view, IGameController gameController)
        {
            this.view = view;
            this.gameController = gameController;
            view.OnMove += Move;
            view.OnMoveUndo += MoveUndo;
            view.OnPickCargo += PickCargo;
            view.OnPickUndo += PickUndo;
        }

        public void StartGame()
        {
            view.DisplayStartMenu();
            CreateStates();
            var gameState = gameController.GetGameState();
            view.DisplayField(mapper.Map(gameState.GameField));
            view.DisplayGameMenu();
        }

        private void CreateStates()
        {
            gameController.CreateGameState(view.gameStateModel.x, view.gameStateModel.y, view.gameStateModel.cargoAmount, view.gameStateModel.toxicCargoAmount,
                                           view.gameStateModel.MaxPrice, view.gameStateModel.MaxWeight, view.gameStateModel.IsDecoding);
            gameController.CreatePlayerState(view.playerStateModel.Number, view.playerStateModel.Name);
        }

        private void Move()
        {
            var moveParameter = moveMapper.Map(view.moveParameter);
            gameController.Move(moveParameter);
            CheckEndGame();
        }

        private void MoveUndo()
        {
            gameController.MoveUndo();
            CheckEndGame();
        }

        private void PickCargo()
        {
            gameController.PickCargo();
            CheckEndGame();
        }

        private void PickUndo()
        {
            gameController.PickUndo();
            CheckEndGame();
        }

        private void CheckEndGame()
        {
            var totalPrice = gameController.GetGameState().TotalCurrentPrice;
            if (gameController.CheckEndGame()) view.DisplayEndResult(totalPrice);
            else
            {
                var gameState = gameController.GetGameState();
                view.DisplayField(mapper.Map(gameState.GameField));
                view.DisplayGameMenu();
            }
        }
    }
}
