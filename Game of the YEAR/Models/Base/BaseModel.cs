﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Game_of_the_YEAR.Models.Base
{
    #region Constructor
    class BaseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
    #endregion
}
