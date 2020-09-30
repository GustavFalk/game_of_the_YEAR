using System;
using System.Collections.Generic;
using System.Text;

namespace Game_of_the_YEAR.Models
{
    static class CurrentGame
    {
        #region Properties
        static public int TotalPoints { get; set; } = 0;
        static public List<Question> Questions { get; set; }
        static public Player CurrentPlayer { get; set; }
        static public int CurrentQuestion { get; set; }
        static public int UserAnswer { get; set; }
        static public int TimePoints { get; set; }
        #endregion
    }
}
