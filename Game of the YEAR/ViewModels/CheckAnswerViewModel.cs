using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static Game_of_the_YEAR.ViewModels.Base.Navigation;
using static Game_of_the_YEAR.Models.GameEngine;
using Game_of_the_YEAR.Models;
using static Game_of_the_YEAR.Repositories.DBRepo;
using static Game_of_the_YEAR.ViewModels.Base.Soundengine;

namespace Game_of_the_YEAR.ViewModels
{
    class CheckAnswerViewModel : Base.BaseViewModel
    {
        #region Number Properties

        public int UserAnswer { get; set; } 
        public int CorrectAnswer { get; set; } 
        public int DifferanceAnswers { get; set; }
        public int Deduction { get; set; } 
        public int TimePoints { get; set; }
        public int PointsGained { get; set; }
        public int TotalPoints { get; set; } 

        #endregion

        #region Visibility Properties

        public Visibility VisibilityFirstView { get; set; } = Visibility.Visible;
        public Visibility VisibilitySecondView { get; set; } = Visibility.Hidden;
        public Visibility VisibilityUserAnswer { get; set; } = Visibility.Hidden;
        public Visibility VisibilityCorrectAnswer { get; set; } = Visibility.Hidden;
        public Visibility VisibilityTimePoints { get; set; } = Visibility.Hidden;
        public Visibility VisibilityDifferance { get; set; } = Visibility.Hidden;
        public Visibility VisibilityDeduction { get; set; } = Visibility.Hidden;
        public Visibility VisibilityPointsGained { get; set; } = Visibility.Hidden;
        public Visibility VisibilityTotalPoints { get; set; } = Visibility.Hidden;
        public Visibility VisibilityNextQuestion { get; set; } = Visibility.Hidden;

        public ImageSource BackgroundImage { get; set; }

        #endregion

        #region ICommand Properties

        public ICommand NextQuestionCommand { get; set; }

        #endregion

        #region Constructor

        public CheckAnswerViewModel()
        {
            AssignPropertyValues();
            NextQuestionCommand = new RelayCommand(NextQuestion);
            ShowOrder();
        }

        #endregion

        #region Methods/Tasks

        public async void ShowOrder()
        {
            MediaPlayerLoad(sounds.bipbopsound);
            await Task.Delay(1000);
            MediaPlayerPlay();
            VisibilityUserAnswer = Visibility.Visible;
            await Task.Delay(300);
            await FlashLightning(); 
            VisibilityCorrectAnswer = Visibility.Visible;
            await Task.Delay(1500);
            VisibilityFirstView = Visibility.Hidden;
            VisibilitySecondView = Visibility.Visible;
            MediaPlayerLoad(sounds.bipbopsound);
            await Task.Delay(500);
            MediaPlayerPlay();
            VisibilityTimePoints = Visibility.Visible;
            await Task.Delay(300);
            MediaPlayerPlayFromZero();
            VisibilityDifferance = Visibility.Visible;
            await Task.Delay(300);
            MediaPlayerPlayFromZero();
            VisibilityDeduction = Visibility.Visible;
            await Task.Delay(300);
            MediaPlayerPlayFromZero();
            VisibilityPointsGained = Visibility.Visible;
            await Task.Delay(300);
            MediaPlayerPlayFromZero();
            VisibilityTotalPoints = Visibility.Visible;
            VisibilityNextQuestion = Visibility.Visible;
            await Task.Delay(400);
            ConvertToTotalPoints();

        }

        public async Task FlashLightning()
        {
            MediaPlayerLoad(sounds.lightning);
            MediaPlayerPlay();
            for (int i = 0; i < 3; i++)
            {
                BackgroundImage = new BitmapImage(new Uri(@".\Assets\Images\BackgroundBlixt_Test_Black.png", UriKind.Relative));
                await Task.Delay(100);
                BackgroundImage = new BitmapImage(new Uri(@".\Assets\Images\BackgroundBlixt_Test_white.png", UriKind.Relative));
                await Task.Delay(100);
                BackgroundImage = null;
                await Task.Delay(100);
            }
            SetBackgroundToAnswerDifferance();

        }
        public void SetBackgroundToAnswerDifferance()
        {
            if (DifferanceAnswers == 0)
            {
                BackgroundImage = new BitmapImage(new Uri(@".\Assets\Images\BackgroundBlixt_Test_Green.png", UriKind.Relative));
            }
            else
            {
                BackgroundImage = new BitmapImage(new Uri(@".\Assets\Images\BackgroundBlixt_Test_Red.png", UriKind.Relative));
            }
        }

        public async void ConvertToTotalPoints()
        {
            MediaPlayerLoad(sounds.pointcoundown);
            MediaPlayerPlay();
            await CountTotalPointsPositive();
            MediaPlayerPause();
        }
        public async Task CountTotalPointsPositive()
        {
            while (PointsGained > 0)
            {
                if (PointsGained > 1133)
                {
                    PointsGained -= 333;
                    TotalPoints += 333;
                    await Task.Delay(1);
                }
                else if (PointsGained > 133)
                {
                    PointsGained -= 133;
                    TotalPoints += 133;
                    await Task.Delay(1);
                }
                else
                {
                    PointsGained--;
                    TotalPoints++;
                    await Task.Delay(1);
                }
            }
        }

        public void AssignPropertyValues()
        {
            UserAnswer = CurrentGame.UserAnswer;
            CorrectAnswer = CurrentGame.Questions[CurrentGame.CurrentQuestion].Year;
            DifferanceAnswers = CheckAnswerDifferance();
            Deduction = CalculateDeduction(DifferanceAnswers);
            TimePoints = CurrentGame.TimePoints;
            PointsGained = CalculateQuestionPoints(Deduction);
            TotalPoints = CurrentGame.TotalPoints;
            CalculateTotalPoints(PointsGained);
            CurrentGame.CurrentQuestion++;
        }
        public void CheckIfLastQuestion()
        {
            if (CurrentGame.Questions.Count > CurrentGame.CurrentQuestion)
            {
                GoToGamePage();
            }
            else
            {
                AddGameRoundToDB();
                GoToHighScorePage();
            }
        }
        public void NextQuestion()
        {
            MediaPlayerPause();
            CheckIfLastQuestion();
        }
       


        #endregion

    }
}
