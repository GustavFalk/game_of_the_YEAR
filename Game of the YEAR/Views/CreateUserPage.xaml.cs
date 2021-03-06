﻿using Game_of_the_YEAR.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Game_of_the_YEAR.ViewModels.Base.Navigation;
namespace Game_of_the_YEAR.Views
{
    /// <summary>
    /// Interaction logic for CreateUserPage.xaml
    /// </summary>
    public partial class CreateUserPage : Page
    {
        #region Constructor
        public CreateUserPage()
        {
            InitializeComponent();
            CreateUserPageViewModel createUserPageViewModel = new CreateUserPageViewModel();
            DataContext = createUserPageViewModel;
        }
        #endregion
        #region Methods
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).MaxLength == (sender as TextBox).Text.Length)
            {
                var ue = e.OriginalSource as FrameworkElement;
                e.Handled = true;
                ue.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
        }
       

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                if ((sender as TextBox).Text.Length == 0)
                {
                    var ue = e.OriginalSource as FrameworkElement;
                    e.Handled = true;
                    ue.MoveFocus(new TraversalRequest(FocusNavigationDirection.Previous));
                    IInputElement focusedControl = Keyboard.FocusedElement;
                    (focusedControl as TextBox).Clear();
                }
            }
        }

        private void Button_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                var ue = e.OriginalSource as FrameworkElement;
                e.Handled = true;
                ue.MoveFocus(new TraversalRequest(FocusNavigationDirection.Previous));
                IInputElement focusedControl = Keyboard.FocusedElement;
                (focusedControl as TextBox).Clear();
            }
        }
        #endregion
    }
}
