using RobotBLL.Abstraction;
using RobotBLL.Implementation.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotBLL.Implementation.Services
{
    public class PlayerStateService: IPlayerStateService
    {
        PlayerState playerState;

        public PlayerStateService(PlayerState playerState)
        {
            this.playerState = playerState;
        }

        public void reduceBatteryCharge(int percents)
        {
            playerState.GameRobot.BatteryCharge -= percents;
        }

        public int GetBatteryCharge()
        {
            return playerState.GameRobot.BatteryCharge;
        }

        public void SaveState()
        {
            playerState.GameRobot.SaveState();
        }

        public void RestoreState()
        {
            playerState.GameRobot.RestoreState();
        }
    }
}
