﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Navigation;
using RobotWPF.Models;

namespace RobotWPF
{
    class ViewModel: INotifyPropertyChanged
    {
        private IModel _model;
        public ViewModel(IModel model)
        {
            _model = model;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string robotName;
        public string RobotName { get; set; }

        private RelayCommand startCommand;

        public RelayCommand StartCommand
        {
            get { return startCommand ?? new RelayCommand(obj => StartGame()); }
        }

        private void StartGame()
        {
            var playerModel = new PlayerStateModel(robotName);
            _model.StartGame(new GameStateModel(), playerModel);
        }
    }
}
