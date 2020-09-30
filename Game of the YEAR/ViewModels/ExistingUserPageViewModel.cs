using Game_of_the_YEAR.Models;
using System;
using System.Windows.Input;
using static Game_of_the_YEAR.ViewModels.Base.Navigation;
using static Game_of_the_YEAR.Repositories.DBRepo;
using Npgsql;
using System.Windows;

namespace Game_of_the_YEAR.ViewModels
{
       
    class ExistingUserPageViewModel: Base.BaseViewModel
    {
        #region Properties
        public string EmailTxt { get; set; }
        public string NicknameTxt { get; set; }

        public ICommand LogInBtn { get; set; }
        public ICommand ReturnBtn { get; set; }
        #endregion
        #region Methods
        private bool CheckIfValidEmail(string email)
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
                 
        public void GetPlayerFromDb()
        {
            String errorMessageEmail = "E-POSTADRESSEN VERKAR INTE FINNAS. FÖRSÖK IGEN!";
            String titleEmail = "ANVÄNDARUPPGIFTER";
            String errorMessageSystem = "NÅGOT VERKAR HA GÅTT FEL. VÄNLIGEN KONTAKTA KUNDTJÄNST";
            String titleSystem = "SYSTEMFEL";
            String errorMessageBadInput = "E-POSTADRESSEN DU ANGETT ÄR INTE EN GILTIG E-POSTADRESS, FÖRSÖK IGEN!";
            String titleInput = "E-POST";

            if (CheckIfValidEmail(EmailTxt))
            {
                Player player = new Player();
                player.Email = EmailTxt;
                player.Nickname = NicknameTxt;
                
                try
                {                    
                    player=GetPlayer(player.Email);
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
                    MessageBox.Show(errorMessageSystem, titleSystem, MessageBoxButton.OK, MessageBoxImage.Error); 
                }
                             
            }
           else
            {
                MessageBox.Show(errorMessageBadInput, titleInput, MessageBoxButton.OK, MessageBoxImage.Error);
            }
          
        }

        #endregion
        #region Constructor
        public ExistingUserPageViewModel()
        {
            LogInBtn = new RelayCommand(GetPlayerFromDb);
            ReturnBtn = new RelayCommand(GoToStartpagePage);
        }
        #endregion
    }

}
