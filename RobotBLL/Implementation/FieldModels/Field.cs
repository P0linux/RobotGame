using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Implementation.FieldModels
{
    public class Field
    {
        public int x { get; set; }
        public int y { get; set; }
        public Cell[,] Cells { get; set; }
        public Cell[,] PreviousState { get; set; }

        public Field(int x, int y)
        {
            Cells = new Cell[x, y];
            this.x = x;
            this.y = y;
        }

        public Cell[,] DeepClone(Cell[,] cells)
        {
            Cell[,] newcells = new Cell[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    newcells[i, j] = (Cell)cells[i, j].Clone();
                }
            }
            return newcells;
        }
    }
}
