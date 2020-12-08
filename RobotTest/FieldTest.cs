using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using AutoFixture;
using RobotBLL.Implementation.FieldModels;
using RobotBLL.Implementation.Enums;

namespace RobotTests
{
    public class FieldTest
    {
        [Fact]
        public void DeepCloneTest()
        {
            //Arrange
            var fixture = new Fixture();
            var array = fixture.Create<Cell[,]>();
            foreach (Cell c in array) c.CurrentState = CellState.Cargo;
            var field = new Field(array.GetLength(0), array.GetLength(1));

            //Act
            var result = field.DeepClone(array);

            //Assert
            result.Should().BeEquivalentTo(array);
        }

        [Fact]
        public void IndexerOutOfRangeTest()
        {
            //Arrange
            var field = new Field(5, 5);

            //Act

            //Assert
            field.Invoking(f => f[(6, 6)]).Should().Throw<IndexOutOfRangeException>();
        }

        [Fact]
        public void IdexerGetCellTest()
        {
            //Arrange
            var coordinates = (0, 0);
            var fixture = new Fixture();
            var field = fixture.Create<Field>();

            //Act
            var result = field.GetCellCoordinates(field[coordinates], field.Cells);

            //Assert
            Assert.Equal(coordinates, result);
        }

        [Fact]
        public void GetCellCoordinatesTest()
        {
            //Arrange
            var fixture = new Fixture();
            var field = fixture.Create<Field>();

            //Act
            var cell = field[(0, 0)];
            var coordinates = field.GetCellCoordinates(cell, field.Cells);

            //Assert
            Assert.Equal((0, 0), coordinates);
        }

        [Fact]
        public void NoCellTest()
        {
            //Arrange
            var fixture = new Fixture();
            var field = fixture.Create<Field>();
            var cell = new Cell();

            //Act
            var coordinates = field.GetCellCoordinates(cell, field.Cells);

            //Assert
            Assert.Equal((-1, -1), coordinates);
        }
    }
}
