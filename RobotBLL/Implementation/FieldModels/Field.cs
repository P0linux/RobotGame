﻿using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Implementation.FieldModels
{
    public class Field: IEnumerable<Cell>
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

        public Field DeepClone()
        {
            Cell[,] newcells = new Cell[x, y];
            for (int i = 0; i < this.Cells.GetLength(0); i++)
            {
                for (int j = 0; j < this.Cells.GetLength(1); j++)
                {
                    newcells[i, j] = (Cell)this.Cells[i, j].Clone();
                }
            }
            var newfield = new Field(this.x, this.y) { Cells = newcells};
            return newfield;
        }

        public (int, int) GetCellCoordinates(Cell cell, Cell[,] cells)
        {
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    if (cells[i, j].Equals(cell)) return (i, j);
                }
            }
            return (-1, -1);
        }

        public Cell this[(int, int) point]
        {
            get => Cells[point.Item1, point.Item2];
            set => Cells[point.Item1, point.Item2] = value;
        }


        public IEnumerator<Cell> GetEnumerator()
        {
            foreach (Cell c in Cells) yield return c;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
