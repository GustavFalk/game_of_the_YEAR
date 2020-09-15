using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

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
