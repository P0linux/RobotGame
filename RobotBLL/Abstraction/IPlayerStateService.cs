using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Abstraction
{
    public interface IPlayerStateService
    {
        void reduceBatteryCharge(int percents);
        int GetBatteryCharge();
        void SaveState();
        void RestoreState();
        int GetDecodingProbability();
    }
}
