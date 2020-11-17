using RobotBLL.Abstraction;
using RobotBLL.Implementation.RobotModels;
using RobotBLL.Implementation.Services;
using RobotBLL.Implementation.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Implementation
{
    public class GameController
    {
        GameState gameState;
        PlayerState playerState;
        IGameService gameService;
        IPlayerService playerService;
        ICommandController commandController;
        IGameStateService gameStateService;
        IPlayerStateService playerStateService;


        public GameController(IGameService gameSevice, IPlayerService playerService, ICommandController commandController)
        {
            this.gameService = gameSevice;
            this.playerService = playerService;
            this.commandController = commandController;
            InitializeServices();
            InitializeCommands();
        }

        private void InitializeServices()
        {
            gameStateService = new GameStateService(gameState);
            playerStateService = new PlayerStateService(playerState);
        }

        private void InitializeCommands()
        {    
            commandController.SetMoveCommand(gameStateService, playerStateService);
            commandController.SetPickCommand();
        }

        public void CreateGameState(int x, int y, int cargoAmount, int toxicCargoAmount, 
                                     double maxPrice, double maxWeight, bool isDecoding)
        {
            gameState = gameService.CreateGameState(x, y, cargoAmount, toxicCargoAmount, maxPrice, maxWeight, isDecoding);
        }

        public void CreatePlayerState(int number, string name)
        {
            RobotModel robotModel = new RobotModel(number, name);
            playerState = playerService.CreatePlayerState(robotModel);
        }

        public GameState GetGameState()
        {
            return gameState;
        }

        public PlayerState GetPlayerState()
        {
            return playerState;
        }

        public void Move(Enums.MoveParameter moveParameter)
        {
            commandController.Move(moveParameter);
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
