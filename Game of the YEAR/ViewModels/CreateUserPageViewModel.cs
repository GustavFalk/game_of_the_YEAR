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
using CredentialManagement;

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
            if (CheckIfLetters(NicknameTxt) && CheckIfEmail(EmailTxt))
            {

                String errorMessageEmail = "DIN E-POST ÄR REDAN REGISTRERAD";
                string titleEmail = "E-POST";
                Player player = new Player();
                player.Email = EmailTxt;
                player.Nickname = NicknameTxt;                              
                
                try
                {
                    player= AddPlayerToDB(player);
                    CurrentGame.CurrentPlayer = player;
                    GoToStartGamePage();                    
                }
                catch(PostgresException e)
                {
                    
                    if(e.ConstraintName == "email_unique")
                    {
                        DialogResult result = (DialogResult)MessageBox.Show(errorMessageEmail, titleEmail);
                       
                        //DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning); //ErrorLbl = "din mail är redan registrerad";
                    }
                    else if(e.ConstraintName == "nickname_unique")
                    {
                        MessageBox.Show("ANVÄNDARNAMNET ÄR REDAN TAGET"); // ErrorLbl = "användarnamnet är redan taget";
                    }
                    else 
                    {
                        MessageBox.Show($"KONTAKTA KUNDTJÄNST OCH UPPGE: {e}."); //ErrorLbl = "fråga Philip vad som är fel";
                    }
                   
                    
                }          


            }
            else
            {
                MessageBox.Show("SE ÖVER ATT DIN EPOSTADRESS ÄR KORREKT OCH ATT ANVÄNDARNAMNET BARA INNEHÅLLER BOKSTÄVER."); //ErrorLbl = "Se över om din mail är korrekt. Användarnamnet får bara vara i bokstäver.";
            }         

        }



        #endregion
        #region properties
        public string EmailTxt { get; set; }
        public string NicknameTxt { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }   
        public string ErrorLbl { get; set; }
        public ICommand CreateUserBtn { get; set; }
        public object MessageBoxIcon { get; private set; }

        #endregion

        public CreateUserPageViewModel() 
        {
            CreateUserBtn = new RelayCommand(AddPlayer);
        }

       
    }
}
