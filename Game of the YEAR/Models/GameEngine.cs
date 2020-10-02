using System;
using System.Collections.Generic;
using System.Text;

namespace Game_of_the_YEAR.Models
{
    public static class GameEngine
    {
        #region Methods
        public static int CalculateDifference()
        {
            int differance = CurrentGame.UserAnswer - CurrentGame.Questions[CurrentGame.CurrentQuestion].Year;
            if (differance < 0)
            {
                differance =  CurrentGame.Questions[CurrentGame.CurrentQuestion].Year - CurrentGame.UserAnswer;
            }
            return differance;
        }
        public static int CalculateDeduction(int answerDifferance)
        {
            int deduction = answerDifferance * 2000;
            return deduction;
        }
        public static int CalculateQuestionPoints(int deduction)
        {
            int QuestionPoints = CurrentGame.TimePoints - deduction;
            if(QuestionPoints < 0)
            {
                return 0;
            }
            return QuestionPoints;
        }
        public static void CalculateTotalPoints(int questionPoints)
        {
            CurrentGame.TotalPoints += questionPoints; 
        }


        public static void ResetGame()
        {
            CurrentGame.TotalPoints = 0;
            CurrentGame.Questions = null;
            CurrentGame.CurrentQuestion = 0;
            CurrentGame.UserAnswer = 0;
            CurrentGame.TimePoints = 0;
        }
        #endregion
    }
}
