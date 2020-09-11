using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Game_of_the_YEAR.ViewModels.Base
{
    class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
