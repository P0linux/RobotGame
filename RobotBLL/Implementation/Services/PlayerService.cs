using RobotBLL.Implementation.Factories;
using RobotBLL.Implementation.RobotModels;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using RobotBLL.Abstraction;
using RobotBLL.Implementation.States;

namespace RobotBLL.Implementation.Services
{
    class PlayerService: IPlayerService
    {
        public Dictionary<string, double> ChoiceProbability { get; set; } = new Dictionary<string, double>
        {
            {"WorkerRobot", 0.5 },
            {"CyborgRobot", 0.3 },
            {"SmartRobot", 0.2 }
        };
        private Robot CreateRobot(RobotModel model, RobotCreator creator)
        {
            return creator.CreateRobot(model);
        }

        private Robot ChooseRobot(RobotModel model)
        {
            RobotCreator creator = null;
            double sum = 0;
            Random random = new Random();
            double randomNumber = random.NextDouble();
            foreach (KeyValuePair<string, double> probability in ChoiceProbability)
            {
                if (randomNumber <= (sum = sum + probability.Value))
                {
                    creator = ChooseCreator(probability.Key);
                    break;
                }
            }
            return CreateRobot(model, creator);
        }

        public PlayerState CreatePlayerState(RobotModel model)
        {
            return new PlayerState(ChooseRobot(model));
        }
        private RobotCreator ChooseCreator(string creator)
        {
            switch (creator)
            {
                case "WorkerRobot":
                    return new WorkerRobotCreator();
                case "CyborgRobot":
                    return new CyborgRobotCreator();
                case "SmartRobot":
                    return new SmartRobotCreator();
                default:
                    return null;
            }
        }
    }
}
