using Moq;
using RobotBLL.Abstraction;
using RobotBLL.Exceptions;
using RobotBLL.Implementation.Commands;
using RobotBLL.Implementation.FieldModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RobotTests
{
    public class PickCargoCommandTest
    {
        [Fact]
        public void NoCargoInCellTest()
        {
            //Arrange
            var mock = new Mock<IGameStateService>();
            var robotCoordinates = (0, 0);
            mock.Setup(s => s.GetRobotCoordinates()).Returns(robotCoordinates);
            mock.Setup(s => s.GetCell(robotCoordinates)).Returns(new Cell());
            var pickCommand = new PickCargoCommand(mock.Object, null);

            //Act

            //Assert
            Assert.Throws<PickCargoException>(() => pickCommand.Execute());
        }
    }
}
