using System;
using System.Collections.Generic;
using System.Text;

namespace RobotWPF.Models
{
    public class PlayerStateModel
    {
        public int Number { get; set; } = 1;
        public string Name { get; set; }

        public PlayerStateModel(string name)
        {
            Name = name;
        }
    }
}
