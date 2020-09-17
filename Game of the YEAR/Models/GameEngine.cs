using System;
using System.Collections.Generic;
using System.Text;

namespace Game_of_the_YEAR.Models
{
    public static class GameEngine
    {
        public static int CheckAnswerDifferance()
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
            int deduction = answerDifferance * 1000;
            return deduction;
        }
        public static int CalculateQuestionPoints(int deduction)
        {
            int QuestionPoints = CurrentGame.TimePoints - deduction;
            return QuestionPoints;
        }
        public static void CalculateTotalPoints(int questionPoints)
        {
            CurrentGame.TotalPoints += questionPoints; 
        }
        public static void CalculateTotalPoints()
        {
            CurrentGame.TotalPoints += (CurrentGame.TimePoints - (CheckAnswerDifferance() * 1000));
        }

    }
}
