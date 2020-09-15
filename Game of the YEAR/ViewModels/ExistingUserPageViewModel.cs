using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using static Game_of_the_YEAR.ViewModels.Base.Navigation;

namespace Game_of_the_YEAR.ViewModels
{
    class ExistingUserPageViewModel
    {
        public string EmailTxt { get; set; }

        public ICommand LogInBtn { get; set; }

        public ExistingUserPageViewModel()
        {

        }
    }
}
