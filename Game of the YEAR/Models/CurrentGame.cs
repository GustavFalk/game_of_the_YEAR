using System;
using System.Collections.Generic;
using System.Text;

namespace Game_of_the_YEAR.Models
{
    class CurrentGame
    {
        public int Points { get; set; }
        public IEnumerable<Question> QuestionsAnswered { get; set; }
        public Player CurrentPlayer { get; set; }
    }
}
