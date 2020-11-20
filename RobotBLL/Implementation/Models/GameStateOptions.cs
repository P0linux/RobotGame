using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Implementation.Models
{
    public class GameStateOptions
    {
        public int x { get; set; }
        public int y { get; set; }
        public int CargoAmount { get; set; }
        public int ToxicCargoAmount { get; set; }
        public double MaxPrice { get; set; }
        public double MaxWeight { get; set; }
        public bool IsDecoding { get; set; }
    }
}
