using RobotBLL.Abstraction;
using RobotBLL.Implementation.Commands;
using RobotBLL.Implementation.Enums;
using RobotBLL.Implementation.Memento;
using RobotBLL.Implementation.RobotModels;
using RobotBLL.Implementation.Services;
using RobotBLL.Implementation.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Implementation
{
    public class GameController: IGameController
    {
        GameState gameState;
        PlayerState playerState;
        IGameService gameService;
        IPlayerService playerService;
        ICommandController commandController;
        IGameStateService gameStateService;
        IPlayerStateService playerStateService;
        GameHistory gameHistory;


        public GameController(IGameService gameSevice, IPlayerService playerService, ICommandController commandController)
        {
            this.gameService = gameSevice;
            this.playerService = playerService;
            this.commandController = commandController;
            CreateGameHistory();
        }

        private void CreateGameHistory()
        {
            gameHistory = new GameHistory();
        }

        public void CreateGameState(int x, int y, int cargoAmount, int toxicCargoAmount, 
                                     double maxPrice, double maxWeight, bool isDecoding)
        {
            gameState = gameService.CreateGameState(x, y, cargoAmount, toxicCargoAmount, maxPrice, maxWeight, isDecoding);
            gameStateService = new GameStateService(gameState);
        }

        public void CreatePlayerState(int number, string name)
        {
            RobotModel robotModel = new RobotModel(number, name);
            playerState = playerService.CreatePlayerState(robotModel, gameHistory);
            playerStateService = new PlayerStateService(playerState);
        }

        public GameState GetGameState()
        {
            return gameState;
        }

        public PlayerState GetPlayerState()
        {
            return playerState;
        }

        private void SetMoveCommand(MoveParameter parameter)
        {
            Command moveCommand = new MoveCommand(gameStateService, playerStateService, parameter);
            commandController.SetMoveCommand(moveCommand);
        }

        private void SetPickCommand()
        {
            Command pickCommand = new PickCargoCommand();
            commandController.SetPickCommand(pickCommand);
        }

        public void Move(MoveParameter moveParameter)
        {
            SetMoveCommand(moveParameter);
            commandController.Move();
        }

        public void MoveUndo()
        {
            commandController.MoveUndo();
        }

        public void PickCargo()
        {
            commandController.PickCargo();
        }

        public void PickUndo()
        {
            commandController.PickCargoUndo();
        }
    }
}
