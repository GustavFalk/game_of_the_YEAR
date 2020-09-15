using System;
using System.Collections.Generic;
using System.Text;

namespace Game_of_the_YEAR.Models
{
    public class Question
    {
        public string Year { get; set; }
        public IEnumerable<string> Clues { get; set; }

    }
}
