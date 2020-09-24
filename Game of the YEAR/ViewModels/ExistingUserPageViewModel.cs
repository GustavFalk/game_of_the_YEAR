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
using System.Windows;

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
            String errorMessageEmail = "E-POSTADRESSEN VERKAR INTE FINNAS. FÖRSÖK IGEN!";
            String titleEmail = "ANVÄNDARUPPGIFTER";
            String errorMessageSystem = "NÅGOT VERKAR HA GÅTT FEL. VÄNLIGEN KONTAKTA KUNDTJÄNST";
            String titleSystem = "SYSTEMFEL";
            String errorMessageBadInput = "E-POSTADRESSEN DU ANGETT ÄR INTE EN GILTIG E-POSTADRESS, FÖRSÖK IGEN!";
            String titleInput = "E-POST";

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
                        MessageBox.Show(errorMessageEmail, titleEmail, MessageBoxButton.OK, MessageBoxImage.Exclamation); 
                    }
                    else
                    {
                        CurrentGame.CurrentPlayer = player;
                        GoToStartGamePage();
                    }
                }
                catch (PostgresException)
                {
                    MessageBox.Show(errorMessageSystem, titleSystem, MessageBoxButton.OK, MessageBoxImage.Error); //Har inte testat denna då jag inte vet hur jag ska forcera fram ett sådant fel.
                }
                             
            }
           else
            {
                MessageBox.Show(errorMessageBadInput, titleInput, MessageBoxButton.OK, MessageBoxImage.Error);
            }
          
        }

        public ExistingUserPageViewModel()
        {
            LogInBtn = new RelayCommand(GetPlayer);
        }
    }
}
