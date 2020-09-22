using Game_of_the_YEAR.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using static Game_of_the_YEAR.ViewModels.Base.Navigation;
using static Game_of_the_YEAR.Repositories.DBRepo;
using Npgsql;
using System.Linq.Expressions;


namespace Game_of_the_YEAR.ViewModels
{
    
      
    class ExistingUserPageViewModel: Base.BaseViewModel
    {
        public string EmailTxt { get; set; }
        public string NicknameTxt { get; set; }

        public ICommand LogInBtn { get; set; }
        public string ErrorLbl { get; set; }

        private bool CheckIfEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

                 
        public void GetPlayer()
        {
           if (CheckIfEmail(EmailTxt))
            {
                Player player = new Player();
                player.Email = EmailTxt;
                player.Nickname = NicknameTxt;
                
                try
                {                    
                    player=GetPlayerFromDB(player.Email);
                    if (player == null)
                    {
                        ErrorLbl = "E-postadressen verkar inte finnas. Pröva igen";
                    }
                    else
                    {
                        CurrentGame.CurrentPlayer = player;
                        GoToStartGamePage();
                    }
                }
                catch (PostgresException)
                {
                    ErrorLbl = "Fråga Philip vad som är fel";
                }
                     
           
            }
           else
            {
                ErrorLbl = "E-mail adressen du angett är inte gilitg.";
            }
          
        }

        public ExistingUserPageViewModel()
        {
            LogInBtn = new RelayCommand(GetPlayer);
        }
    }
}
