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

        public string Rules { get; set; } =
            "Spelregler för Game Of the Year. I Game of the Year ska du på tid gissa på vilket år som söks med hjälp av ledtrådar. Du startar med 99999 poäng och men dessa kommer att kontinuerligt räkna ned så länge spelrundan pågår.Så desto längre tid du tar på dig att svara desto lägre blir din slutpoäng. För varje fel svar så kommer du dock att få ett poängavdrag på 1000 poäng.Så det gäller att både vara snabb men inte så snabb att du blir slarvig. Som hjälp på vägen så kommer du att utöver din första ledtråd för vilket år som gäller få ytterligare två ledtrådar som låses upp steg för steg allt eftersom att tiden går. Dina poäng kommer att sparas så om du gissar tillräckligt bra så kommer du att visas i topp 5 listan i slutet av spelet.Du kommer även att kunna se vilka spelare som har varit flitigast i spelet och har spelat flest rundor.";


        public RuleViewModel()
        {

        }

        public void GoToStartGamePage()
        {
            Page page = new Views.StartGamePage();
            ((MainWindow)System.Windows.Application.Current.MainWindow).Main.Content = page;
        }
    }
}
