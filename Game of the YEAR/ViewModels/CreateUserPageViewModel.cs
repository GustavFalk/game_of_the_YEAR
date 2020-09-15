using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Game_of_the_YEAR.ViewModels
{
    public class CreateUserPageViewModel: Base.BaseViewModel

    {
        public string EmailTxt { get; set; }
        public int UserIdTxt { get; set; }

        public ICommand CreateUserBtn { get; set; }

        public CreateUserPageViewModel() 
        {

        }
    }
}
