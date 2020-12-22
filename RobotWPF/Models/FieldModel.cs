﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RobotWPF.Models
{
    public class FieldModel
    {
        public int[,] Field { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        public FieldModel(int[,] field, int x, int y)
        {
            Field = field;
            this.x = x;
            this.y = y;
        }
    }
}
