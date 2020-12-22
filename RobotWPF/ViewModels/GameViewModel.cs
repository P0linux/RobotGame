using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RobotWPF.ViewModels
{
    public class GameViewModel: INotifyPropertyChanged
    {
        private IModel _model;
        public GameViewModel(IModel model)
        {
            _model = model;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int[,] field;

        public int[,] Field
        {
            get => _model.GetField();
            set => field = value;
        }

        public void UpdateField()
        {
            OnPropertyChanged("Field");
        }
    }
}
