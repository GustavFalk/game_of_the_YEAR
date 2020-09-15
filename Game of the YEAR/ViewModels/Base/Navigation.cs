﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

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
        #endregion
    }
}