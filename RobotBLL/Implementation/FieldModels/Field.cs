using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Implementation.FieldModels
{
    class Field
    {
        public Cell[,] Cells { get; set; }

        public Field(int x, int y)
        {
            Cells = new Cell[x, y];
        }
    }
}
