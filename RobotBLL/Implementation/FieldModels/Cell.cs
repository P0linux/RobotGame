using RobotBLL.Implementation.CargoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Implementation.FieldModels
{
    public class Cell
    {
        public Enums.CellState CurrentState { get; set; } = Enums.CellState.Empty;
        public Cargo Cargo { get; set; }
    }
}
