using Moq;
using RobotBLL.Abstraction;
using RobotBLL.Implementation;
using RobotBLL.Implementation.Enums;
using RobotBLL.Implementation.Memento;
using RobotBLL.Implementation.Models;
using RobotBLL.Implementation.RobotModels;
using RobotBLL.Implementation.States;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RobotTests
{
    public class GameControllerTest
    {
        [Fact]
        public void CreateGameStateTest()
        {
            //Arrange
            var mock = new Mock<IGameService>();
            var gameController = new GameController(mock.Object, null, null);

            //Act
            var options = new GameStateOptions();
            gameController.CreateGameState(options);

            //Assert
            mock.Verify(g => g.CreateGameState(options));
        }

        [Fact]
        public void MoveTest()
        {
            //Arrange
            var mock = new Mock<ICommandController>();
            var gameController = new GameController(null, null, mock.Object);

            //Act
            var moveParameter = MoveParameter.Up;
            gameController.Move(moveParameter);

            //Assert
            mock.Verify(c => c.Move());
        }
    }
}
