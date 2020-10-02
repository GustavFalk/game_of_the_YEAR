using Game_of_the_YEAR.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using static Game_of_the_YEAR.ViewModels.Base.Navigation;
using static Game_of_the_YEAR.Repositories.DBRepo;
using Npgsql;
using System.Windows;



namespace Game_of_the_YEAR.ViewModels
{
    class CreateUserPageViewModel: Base.BaseViewModel
    {  
        #region Properties
        public string EmailTxt { get; set; }
        public string NicknameTxt { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }   
        public string ErrorLbl { get; set; }
        public ICommand CreateUserBtn { get; set; }
        public object MessageBoxIcon { get; private set; }
        public ICommand GoBackBtn { get; set; }

        #endregion
        #region Methods

        private bool CheckIfLetters(string text)
        {
            foreach (char c in text)
            {
                if (!Char.IsLetter(c))
                {
                    return false;

                }
            }

            return true;

        }
        private bool CheckIfEmail(string text)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(text);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void ValuesToUserID()
        {
            NicknameTxt = Value1 + Value2 + Value3;

        }

        public void AddPlayer()
        {
            ValuesToUserID();
            String errorMessageEmail = "DIN E-POST ÄR REDAN REGISTRERAD.";
            String titleEmail = "E-POST";
            String errorMessageUser = "ANVÄNDARNAMNET ÄR REDAN TAGET.";
            String titleUser = "ANVÄNDARE";
            String errorMessageSystem = "KONTAKTA KUNDTJÄNST OCH UPPGE:";
            String titleSystem = "SYSTEMFEL";
            String errorMessageBadInput = "SE ÖVER ATT DIN E-POSTADRESS ÄR KORREKT OCH ATT ANVÄNDARNAMNET BARA INNEHÅLLER BOKSTÄVER.";
            String titleInput = "ANVÄNDARUPPGIFTER";

            if (CheckIfLetters(NicknameTxt) && CheckIfEmail(EmailTxt))
            {
                Player player = new Player();
                player.Email = EmailTxt;
                player.Nickname = NicknameTxt;

                try
                {
                    player = AddPlayerToDB(player);
                    CurrentGame.CurrentPlayer = player;
                    GoToStartGamePage();
                }
                catch (PostgresException e)
                {

                    if (e.ConstraintName == "email_unique")
                    {
                        MessageBox.Show(errorMessageEmail, titleEmail, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                    else if (e.ConstraintName == "nickname_unique")
                    {
                        MessageBox.Show(errorMessageUser, titleUser, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show(errorMessageSystem + $"{e}", titleSystem, MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show(errorMessageBadInput, titleInput, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }



        #endregion
        #region Contstructor
        public CreateUserPageViewModel() 
        {
            CreateUserBtn = new RelayCommand(AddPlayer);
            GoBackBtn = new RelayCommand(GoToStartpagePage);
        }
        #endregion
    }
}
