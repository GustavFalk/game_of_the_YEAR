using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using static Game_of_the_YEAR.ViewModels.Base.Navigation;

namespace Game_of_the_YEAR.ViewModels
{
    class StartPageViewModel : Base.BaseViewModel
    {
        #region Properties
        public ICommand NewPlayerBtn { get; set; }
        public ICommand ExistingPlayerBtn { get; set; }
        #endregion
        #region Constructor
        public StartPageViewModel()
        {
            NewPlayerBtn = new RelayCommand(GoToCreateUserPage);
            ExistingPlayerBtn = new RelayCommand(GoToExistingUserPage);
        }
        #endregion





    }

}
