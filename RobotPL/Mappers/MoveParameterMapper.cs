using RobotBLL.Implementation.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotPL.Mappers
{
    class MoveParameterMapper
    {
        public MoveParameter Map(string moveParameter)
        {
            switch (moveParameter)
            {
                case "1":
                    return MoveParameter.Up;
                case "2":
                    return MoveParameter.Down;
                case "3":
                    return MoveParameter.Left;
                case "4":
                    return MoveParameter.Right;
                default:
                    return MoveParameter.Up;
            }
        }
    }
}
