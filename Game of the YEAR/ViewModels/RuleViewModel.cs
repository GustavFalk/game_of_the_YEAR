using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using static Game_of_the_YEAR.ViewModels.Base.Navigation;

namespace Game_of_the_YEAR.ViewModels
{
    class RuleViewModel : Base.BaseViewModel
    {
        #region Properties
        public ICommand OkBtn { get; set; }
       

        public string Rules { get; set; } =
            "Spelet är uppdelat i tio frågeomgångar. \r\n \r\n Du startar med 99999 poäng i varje frågarunda som snabbt räknar ned. \r\n \r\n Ju snabbare du svarar desto högre poäng. \r\n \r\n Men för varje år du svarar fel så får du poängavdrag på 1000 poäng. \r\n \r\n När tiden går får du ytterligare chans till två ledtrådar om du väntar för länge.";

        #endregion
        #region Constructor
        public RuleViewModel()
        {
            OkBtn = new RelayCommand(GoToStartGamePage); 
        }

      
        #endregion
    }
}
