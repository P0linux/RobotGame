using RobotBLL.Implementation.CargoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Implementation.FieldModels
{
    class Cell
    {
        public Enums.CellState PreviousState { get; set; } = Enums.CellState.Empty;
        public Enums.CellState CurrentState { get; set; } = Enums.CellState.Empty;
        public Cargo Cargo { get; set; }
    }
}
