using RobotBLL.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using RobotWPF.Mappers;
using RobotWPF.Models;

namespace RobotWPF
{
    class Model: IModel
    {
        IGameController _controller;
        StateMapper _stateMapper = new StateMapper();
        FieldMapper _fieldMapper = new FieldMapper();
        
        public Model(IGameController controller)
        {
            _controller = controller;
        }

        public void StartGame(GameStateModel gameModel, PlayerStateModel playerModel)
        {
            CreateStates(gameModel, playerModel);
        }

        private void CreateStates(GameStateModel gameModel, PlayerStateModel playerModel)
        {
            var gameState = _stateMapper.Map(gameModel);
            _controller.CreateGameState(gameState);
            _controller.CreatePlayerState(playerModel.Number, playerModel.Name);
            var state = _controller.GetGameState();
        }

        public int[,] GetField()
        {
            var gameState = _controller.GetGameState();
            if (gameState is null) return new int[0,0];
            var fieldModel = _fieldMapper.Map(_controller.GetGameState().GameField);
            return fieldModel.Field;
        }
    }
}
