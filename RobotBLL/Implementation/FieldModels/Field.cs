using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Implementation.FieldModels
{
    public class Field
    {
        public int x { get; set; }
        public int y { get; set; }
        public Cell[,] Cells { get; set; }

        public Field(int x, int y)
        {
            Cells = new Cell[x, y];
            this.x = x;
            this.y = y;
        }
    }
}
