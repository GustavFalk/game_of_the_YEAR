﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Game_of_the_YEAR.ViewModels.Base
{
    public static class Navigation
    {
        #region View navigation
        public static void GoToLoadingPageOne()
        {
            Page page = new Views.LoadingPageOne();
            ((MainWindow)System.Windows.Application.Current.MainWindow).Main.Content = page;
        }
        public static void GoToLoadingPageTwo()
        {
            Page page = new Views.LoadingPageTwo();
            ((MainWindow)System.Windows.Application.Current.MainWindow).Main.Content = page;
        }

        public static async void GoToLoadingPageTwoWithDelay()
        {
            await Task.Delay(2000);
            Page page = new Views.LoadingPageTwo();
            ((MainWindow)System.Windows.Application.Current.MainWindow).Main.Content = page;
        }

        public static void GoToStartpagePage()
        {
            Page page = new Views.StartpagePage();
            ((MainWindow)System.Windows.Application.Current.MainWindow).Main.Content = page;
        }
        public static void GoToCreateUserPage()
        {
            Page page = new Views.CreateUserPage();
            ((MainWindow)System.Windows.Application.Current.MainWindow).Main.Content = page;
        }
        public static void GoToExistingUserPage()
        {
            Page page = new Views.ExistingUserPage();
            ((MainWindow)System.Windows.Application.Current.MainWindow).Main.Content = page;
        }
        public static void GoToStartGamePage()
        {
            Page page = new Views.StartGamePage();
            ((MainWindow)System.Windows.Application.Current.MainWindow).Main.Content = page;
        }
        public static void GoToRulePage()
        {
            Page page = new Views.RulePage();
            ((MainWindow)System.Windows.Application.Current.MainWindow).Main.Content = page;
        }
        public static void GoToStartGameCountdownPage()
        {
            Page page = new Views.StartGameCountdownPage();
            ((MainWindow)System.Windows.Application.Current.MainWindow).Main.Content = page;
        }
        public static void GoToGamePage()
        {
            Page page = new Views.GamePage();
            ((MainWindow)System.Windows.Application.Current.MainWindow).Main.Content = page;
        }
        public static void GoToCheckAnswerPage()
        {
            Page page = new Views.CheckAnswerPage();
            ((MainWindow)System.Windows.Application.Current.MainWindow).Main.Content = page;
        }
        public static void GoToHighScorePage()
        {
            Page page = new Views.HighScorePage();
            ((MainWindow)System.Windows.Application.Current.MainWindow).Main.Content = page;
        }
        #endregion
        #region Sound navigation

        public static void PlayMenuMusic()
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).menuMusic.Play();
        }
        public static async void PlayMenuMusicWithDelay()
        {
            await Task.Delay(2500);
            ((MainWindow)System.Windows.Application.Current.MainWindow).menuMusic.Play();
        }

        public static void PauseMenuMusic()
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).menuMusic.Pause();
        }
        public static void PlayCoinDrop()
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).coinDrop.Play();
        }

        public static void MuteMusic()
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).menuMusic.Volume=0; //menuMusic är gustavs spelare
            ((MainWindow)System.Windows.Application.Current.MainWindow).coinDrop.Volume=0;
        }

        #endregion
    }
}
