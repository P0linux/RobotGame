using RobotBLL.Implementation.Memento;
using RobotBLL.Implementation.RobotModels;
using RobotBLL.Implementation.Services;
using RobotBLL.Implementation.States;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RobotTest
{
    public class PlayerServiceTest
    {
        [Fact]
        public void CreatePlayerState_Test() 
        {
            //Arrange
            var history = new GameHistory();
            var robotModel = new RobotModel(1, "test");
            PlayerService service = new PlayerService();

            //Act
            var playerState = service.CreatePlayerState(robotModel, history);

            //Assert
            Assert.NotNull(playerState);
            //TODO
        }
    }
}
