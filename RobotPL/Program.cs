using System;
using RobotBLL.Abstraction;
using RobotBLL.Implementation;
using RobotBLL.Implementation.Services;

namespace RobotPL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GameController gameController = new GameController(new GameService(), new PlayerService(), new CommandController());
            gameController.CreatePlayerState(1, "Polina");
            gameController.CreateGameState(3, 3, 1, 0, 10, 10, false);
            gameController.Move(RobotBLL.Implementation.Enums.MoveParameter.Down);
            var state = gameController.GetGameState();
            Console.WriteLine(state);
        }
    }
}
