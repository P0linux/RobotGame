using RobotBLL.Implementation.CargoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Implementation.FieldModels
{
    class Cell
    {
        public enum CellState
        {
            Empty,
            Robot,
            Cargo,
            RobotCargo
        }

        public CellState PreviousState { get; set; } = CellState.Empty;
        public CellState CurrentState { get; set; } = CellState.Empty;
        public Cargo Cargo { get; set; }
    }
}
