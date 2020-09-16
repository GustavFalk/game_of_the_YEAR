using System;
using System.Collections.Generic;
using System.Text;

namespace Game_of_the_YEAR.Models
{
    static class CurrentGame
    {
        static public int TotalPoints { get; set; } = 180000;
        static public IEnumerable<Question> QuestionsAnswered { get; set; }
        static public Player CurrentPlayer { get; set; }
        static public Question CurrentQuestion { get; set; }
        static public int UserAnswer { get; set; }
        static public int TimePoints { get; set; }
    }
}
