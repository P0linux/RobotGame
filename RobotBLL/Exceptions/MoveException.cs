using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Exceptions
{
    class MoveException: Exception
    {
        public MoveException(string message)
            :base()
        {

        }

        public MoveException(string message, Exception ex)
            :base()
        {

        }
    }
}
