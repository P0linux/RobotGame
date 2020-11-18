using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Abstraction
{
    public abstract class Command
    {
        public abstract void Execute();

        public abstract void Undo();
    }
}
