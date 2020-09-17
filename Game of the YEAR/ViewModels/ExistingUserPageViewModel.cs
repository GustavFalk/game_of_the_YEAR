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
using static Game_of_the_YEAR.Models.CurrentGame;

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
                    CurrentGame.CurrentPlayer
                    GoToStartGamePage();
                }
                catch (PostgresException e)
                {
                    //visa felmeddelande
                }
                     
           
            }
          
        }

        public ExistingUserPageViewModel()
        {
            LogInBtn = new RelayCommand(GetPlayer);
        }
    }
}
