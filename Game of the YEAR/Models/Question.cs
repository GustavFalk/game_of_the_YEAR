using System;
using System.Collections.Generic;
using System.Text;

namespace Game_of_the_YEAR.Models
{
    public class Question
    {
        public int Year { get; set; }
        public IEnumerable<string> Clues { get; set; }

    }
}
