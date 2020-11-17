using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Abstraction
{
    public abstract class Command
    {
        public void Execute(Implementation.Enums.MoveParameter parameter) { }
        public void Execute() { }

        public void Undo() { }
    }
}
