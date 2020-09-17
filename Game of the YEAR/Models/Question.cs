using System;
using System.Collections.Generic;
using System.Text;
using static Game_of_the_YEAR.Repositories.DBRepo;

namespace Game_of_the_YEAR.Models
{
    public class Question
    {
        public int Year { get; set; }
        public List<string> Clues { get; set; }

        public Question(int year)
        {
            Year = year;
            Clues = GetClues(Year);
        }

    }
}
