using Game_of_the_YEAR.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using static Game_of_the_YEAR.ViewModels.Base.Navigation;

namespace Game_of_the_YEAR.ViewModels
{
    class CreateUserPageViewModel: Base.BaseViewModel

    {
        #region models
      
        private bool CheckIfLetters(string text)
        {
            foreach(char c in text)
            {
                if (!Char.IsLetter(c))
                {
                    return false;

                }
            }

            return true;     
        
        }
        public void ValuesToUserID()
        {
            UserIdTxt = Value1 + Value2 + Value2;

        }

        public void AddPlayer()
        {
            ValuesToUserID();           
            if (CheckIfLetters(UserIdTxt))
            {
                Player player = new Player();
                player.Email = EmailTxt;
                player.Nickname = UserIdTxt;
                //metod för att amta in i DB
            }
            else
            {
                /*u får bara ha bokstäver*/
            }
         

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
            CreateUserBtn = new RelayCommand(AddPlayer);
        }

       
    }
}
