﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Implementation.CargoModels
{
    class ToxicCargo: CargoDecorator
    {
        public int ToxicImpact { get; set; }
        public ToxicCargo(Cargo cargo)
            :base(cargo.Price, cargo.Weight, cargo.IsDecoding, cargo)
        {

        }
    }
}
