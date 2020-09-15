using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace Game_of_the_YEAR.ViewModels
{
    class StartPageViewModel : Base.BaseViewModel
    {
        public ICommand NewPlayerBtn { get; set; }
        public ICommand ExistingPlayerBtn { get; set; }

        public StartPageViewModel()
        {

        }

        public void GoToCreateUserPage()
        {
            Page page = new Views.CreateUserPage();
            ((MainWindow)System.Windows.Application.Current.MainWindow).Main.Content = page;
        }

        public void GoToExistingUserPage()
        {
            Page page = new Views.ExistingUserPage();
            ((MainWindow)System.Windows.Application.Current.MainWindow).Main.Content = page;
        }
            

    }

    

    
       

       

        public CreateUserPageViewModel()
        {

        }
    }
}
