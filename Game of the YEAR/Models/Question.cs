using System;
using System.Collections.Generic;
using System.Text;
using static Game_of_the_YEAR.Repositories.DBRepo;

namespace Game_of_the_YEAR.Models
{
    public class Question
    {
        #region Properties
        public int Year { get; set; }
        public List<string> Clues { get; set; }
        #endregion
        #region Constructor
        public Question(int year)
        {
            Year = year;
            Clues = GetClues(Year);
        }
        #endregion
    }
}
