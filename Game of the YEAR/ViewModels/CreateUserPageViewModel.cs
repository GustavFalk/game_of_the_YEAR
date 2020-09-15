using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace Game_of_the_YEAR.ViewModels
{
    class CreateUserPageViewModel: Base.BaseViewModel

    {
        #region models
        public void GoToStartGamePage()
        {
            Page page = new Views.StartGamePage();
            ((MainWindow)System.Windows.Application.Current.MainWindow).Main.Content = page;
        }

        public void ValuesToUserID()
        {
            UserIdTxt = $"{Value1}{Value2}{Value3}";
        }
    
        #endregion


        public string EmailTxt { get; set; }
        public string UserIdTxt { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }


        public ICommand CreateUserBtn { get; set; }

        public CreateUserPageViewModel() 
        {
            CreateUserBtn = new RelayCommand(ValuesToUserID);
        }

       
    }
}
