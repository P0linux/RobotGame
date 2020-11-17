using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Implementation.CargoModels
{
    class Cargo
    {
        public double Price { get; set; }
        public double Weight { get; set; }
        public bool IsDecoding { get; set; }
       

        public Cargo(double price, double weight, bool isDecoding)
        {
            Price = price;
            Weight = weight;
            IsDecoding = isDecoding;
        }
    }
}
