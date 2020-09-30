using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Game_of_the_YEAR
{
    public class RelayCommand : ICommand
    {
        #region Properties
        public event EventHandler CanExecuteChanged;
        private Action action;
        #endregion
        #region Methods
        public RelayCommand(Action action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action();
        }
        #endregion
    }
}
