using RobotBLL.Abstraction;
using RobotBLL.Implementation.CargoModels;
using RobotBLL.Implementation.FieldModels;
using RobotBLL.Implementation.Models;
using RobotBLL.Implementation.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotBLL.Implementation.Services
{
    public class GameService: IGameService
    {
        Random random = new Random();
        private Field CreateField(int x, int y)
        {
            Field field = new Field(x, y);
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    field.Cells[i, j] = new Cell();
                }
            }
            return field;
        }

        private void PlaceCargo(Cargo cargo, Cell cell)
        {
            cell.Cargo = cargo;
            //TODO: change cell state 
            cell.CurrentState = Enums.CellState.Cargo;
        }

        private void PlaceAllCargos(List<Cargo> cargos, List<Cargo> toxicCargos, int x, int y, Field field)
        {
            foreach (Cargo cargo in cargos)
            {
                int rx = random.Next(x);
                int ry = random.Next(y);
                if (field.Cells[rx, ry].CurrentState != Enums.CellState.Cargo) 
                    PlaceCargo(cargo, field.Cells[rx, ry]);
            }
            foreach (Cargo cargo in toxicCargos)
            {
                int rx = random.Next(x);
                int ry = random.Next(y);
                if (field.Cells[rx, ry].CurrentState != Enums.CellState.Cargo || 
                    field.Cells[rx, ry].CurrentState != Enums.CellState.RobotCargo)
                    PlaceCargo(cargo, field.Cells[rx, ry]);
            }
        }

        private List<Cargo> CreateCargos(int cargoAmount, double maxPrice, double maxWeight, bool isDecoding)
        {
            List<Cargo> cargos = new List<Cargo>(cargoAmount);
            for (int i = 0; i<cargoAmount; i++)
            {
                cargos.Add(new Cargo(random.NextDouble() * maxPrice, random.NextDouble() * maxWeight, isDecoding));
            }
            return cargos;
        }

        private List<Cargo> CreateToxicCargos(int cargoAmount, double maxPrice, double maxWeight, bool isDecoding)
        {
            List<Cargo> cargos = CreateCargos(cargoAmount, maxPrice, maxWeight, isDecoding);
            cargos = cargos.Select(c => c = new ToxicCargo(c))
                           .ToList();
            return cargos;
        }

        public GameState CreateGameState(GameStateOptions options)
        {
            Field field = CreateField(options.x, options.y);
            field.Cells[0, 0].CurrentState = Enums.CellState.Robot;
            List<Cargo> cargos = CreateCargos(options.CargoAmount, options.MaxPrice, options.MaxWeight, options.IsDecoding);
            List<Cargo> toxicCargos = CreateToxicCargos(options.ToxicCargoAmount, options.MaxPrice, options.MaxWeight, options.IsDecoding);
            PlaceAllCargos(cargos, toxicCargos, options.x, options.y, field);
            field.PreviousState = CreatePreviousState(field);
            return new GameState(field, options.CargoAmount + options.ToxicCargoAmount);
        }

        private Cell[,] CreatePreviousState(Field field)
        {
            Cell[,] previousState = field.DeepClone(field.Cells);
            previousState[0, 0].CurrentState = Enums.CellState.Empty;
            return previousState;
        }
    }
}
