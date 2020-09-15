using Game_of_the_YEAR.ViewModels;
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

namespace Game_of_the_YEAR.Views
{
    /// <summary>
    /// Interaction logic for RulePage.xaml
    /// </summary>
    public partial class RulePage : Page
    {
        public RulePage()
        {
            InitializeComponent();
            RuleViewModel ruleViewModel = new RuleViewModel();
            DataContext = ruleViewModel;
        }



        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.KeyDown += HandleKeyPress;
        }
        private void HandleKeyPress(object sender, RoutedEventArgs e)
        {
            if ((e as KeyEventArgs).Key == Key.Enter)
            {
                Page page = new StartGamePage();
                ((MainWindow)System.Windows.Application.Current.MainWindow).Main.Content = page;
            }
        }
    }
}
