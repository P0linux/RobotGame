using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Navigation;
using RobotWPF.Models;

namespace RobotWPF.ViewModels
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

        public string RobotName { get; set; }

        private RelayCommand startCommand;

        public RelayCommand StartCommand
        {
            get { return startCommand ?? (new RelayCommand(obj => StartGame())); }
        }

        private void StartGame()
        {
            var playerModel = new PlayerStateModel(RobotName);
            _model.StartGame(new GameStateModel(), playerModel);
            UpdateField();
        }

        private int[,] field;

        public int[,] Field
        {
            get => _model.GetField();
            set => field = value;
        }

        private void UpdateField()
        {
            OnPropertyChanged("Field");
        }
    }
}
