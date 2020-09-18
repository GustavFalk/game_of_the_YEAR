using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using static Game_of_the_YEAR.Repositories.DBRepo;



namespace Game_of_the_YEAR
{
    public class MainWindowViewModel 
    {
        public int AmountOutput { get; set; }

        public ICommand ButtonCommand { get; set; }

        public MainWindowViewModel()
        {
            ButtonCommand = new RelayCommand(Amount);
        }

        public void Amount()
        {
            //AmountOutput = GetAmountOfYears();
        }

    }
}
