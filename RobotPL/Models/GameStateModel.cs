using System;
using System.Collections.Generic;
using System.Text;

namespace RobotPL.Models
{
    class GameStateModel
    {
        public int x { get; set; } = 5;
        public int y { get; set; } = 5;
        public int cargoAmount { get; set; } = 3;
        public int toxicCargoAmount { get; set; } = 0;
        public double MaxPrice { get; set; } = 10;
        public double MaxWeight { get; set; } = 10;
        public bool IsDecoding { get; set; } = false;

        public GameStateModel(int x, int y, int ca, int tca, double mp, double mw, bool id)
        {
            this.x = x;
            this.y = y;
            cargoAmount = ca;
            toxicCargoAmount = tca;
            MaxPrice = mp;
            MaxWeight = mw;
            IsDecoding = id;
        }
    }
}
