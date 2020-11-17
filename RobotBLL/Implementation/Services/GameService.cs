using RobotBLL.Abstraction;
using RobotBLL.Implementation.CargoModels;
using RobotBLL.Implementation.FieldModels;
using RobotBLL.Implementation.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotBLL.Implementation.Services
{
    class GameService: IGameService
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
            cell.CurrentState = Cell.CellState.Cargo;
        }

        private void PlaceAllCargos(List<Cargo> cargos, List<Cargo> toxicCargos, int x, int y, Field field)
        {
            foreach (Cargo cargo in cargos)
            {
                int rx = random.Next(x);
                int ry = random.Next(y);
                if (field.Cells[rx, ry].CurrentState != Cell.CellState.Cargo) 
                    PlaceCargo(cargo, field.Cells[rx, ry]);
            }
            foreach (Cargo cargo in toxicCargos)
            {
                int rx = random.Next(x);
                int ry = random.Next(y);
                if (field.Cells[rx, ry].CurrentState != Cell.CellState.Cargo)
                    PlaceCargo(cargo, field.Cells[rx, ry]);
            }
        }

        private List<Cargo> CreateCargos(int cargoAmount, double maxPrice, double maxWeight, bool isDecoding)
        {
            List<Cargo> cargos = new List<Cargo>(cargoAmount);
            cargos = cargos.Select(c => c = new Cargo(random.NextDouble() * maxPrice, random.NextDouble() * maxWeight, isDecoding))
                           .ToList();
            return cargos;
        }

        private List<Cargo> CreateToxicCargos(int cargoAmount, double maxPrice, double maxWeight, bool isDecoding)
        {
            List<Cargo> cargos = CreateCargos(cargoAmount, maxPrice, maxWeight, isDecoding);
            cargos = cargos.Select(c => c = new ToxicCargo(c))
                           .ToList();
            return cargos;
        }

        public GameState CreateGameState(int x, int y, int cargoAmount, int toxicCargoAmount, double maxPrice, 
                                         double maxWeight, bool isDecoding)
        {
            Field field = CreateField(x, y);
            field.Cells[0, 0].CurrentState = Cell.CellState.Robot;
            List<Cargo> cargos = CreateCargos(cargoAmount, maxPrice, maxWeight, isDecoding);
            List<Cargo> toxicCargos = CreateToxicCargos(toxicCargoAmount, maxPrice, maxWeight, isDecoding);
            PlaceAllCargos(cargos, toxicCargos, x, y, field);
            return new GameState(field, cargoAmount + toxicCargoAmount);
        }
    }
}
