using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace Game_of_the_YEAR.ViewModels
{
    class RuleViewModel : Base.BaseViewModel
    {
        public ICommand OkBtn { get; set; }
        public ICommand GoBackCommand { get; set; }

        public string Rules { get; set; } =
            "Spelet är uppdelat i tio frågeomgångar. \r\n \r\n Du startar med 99999 poäng i varje frågarunda som snabbt räknar ned. \r\n Ju snabbare du svarar desto högre poäng. \r\n Men för varje år du svarar fel så får du poängavdrag på 1000 poäng. \r\n \r\n När tiden går får du ytterligare chans till två ledtrådar om du väntar för länge.";


        public RuleViewModel()
        {
            GoBackCommand = new RelayCommand(GoToStartGamePage); 
        }

        public void GoToStartGamePage()
        {
            Page page = new Views.StartGamePage();
            ((MainWindow)System.Windows.Application.Current.MainWindow).Main.Content = page;
        }
    }
}
