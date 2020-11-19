﻿using RobotPL.Abstract;
using RobotPL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotPL
{
    class View: IView
    {
        public GameStateModel gameStateModel { get; set; }
        public PlayerStateModel playerStateModel { get; set; }

        public void DisplayStartMenu()
        {
            Console.WriteLine("Start menu: ");
            Console.WriteLine("Input start game parameters: ");
            gameStateModel = GetGameStateParameters();
            playerStateModel = GetPlayerStateParameters();
        }

        public void DisplayField(FieldModel fieldModel)
        {
            int[,] field = fieldModel.Field;
            for (int i = 0; i < fieldModel.x; i++)
            {
                for (int j = 0; j < fieldModel.y; j++) Console.Write("{0,3} ", field[i, j]);
                Console.WriteLine();
            }
        }

        public GameStateModel GetGameStateParameters()
        {
            Console.WriteLine("Input game field x dimension: ");
            int x = StringToInt(Console.ReadLine());
            Console.WriteLine("Input game field y dimension: ");
            int y = StringToInt(Console.ReadLine());
            Console.WriteLine("Input cargo amount: ");
            int ca = StringToInt(Console.ReadLine());
            Console.WriteLine("Input toxic cargo amount: ");
            int tca = StringToInt(Console.ReadLine());
            Console.WriteLine("Input maximum cargo price: ");
            double mp = StringToDouble(Console.ReadLine());
            Console.WriteLine("Input maximum cargo weight: ");
            double mw = StringToDouble(Console.ReadLine());
            Console.WriteLine("Input 1 if cargos are decoding: ");
            bool id = StringToBool(Console.ReadLine());
            return new GameStateModel(x, y, ca, tca, mp, mw, id);
        }

        public PlayerStateModel GetPlayerStateParameters()
        {
            Console.WriteLine("Input robot number: ");
            int num = StringToInt(Console.ReadLine());
            Console.WriteLine("Input robot name: ");
            string name = Console.ReadLine();
            return new PlayerStateModel(num, name);
        }

        private bool StringToBool(string parameter)
        {
            if (parameter == "1") return true;
            else return false;
        }

        private int StringToInt(string parameter)
        {
            return Int32.Parse(parameter);
        }

        private double StringToDouble(string param)
        {
            return double.Parse(param);
        }
    }
}