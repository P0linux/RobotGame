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
        
        public Model(IGameController controller)
        {
            _controller = controller;
        }

        public void StartGame(GameStateModel gameModel, PlayerStateModel playerModel)
        {
            CreateStates(gameModel, playerModel);
            
        }

        public void CreateStates(GameStateModel gameModel, PlayerStateModel playerModel)
        {
            var gameState = _stateMapper.Map(gameModel);
            _controller.CreateGameState(gameState);
            _controller.CreatePlayerState(playerModel.Number, playerModel.Name);
        }
    }
}
