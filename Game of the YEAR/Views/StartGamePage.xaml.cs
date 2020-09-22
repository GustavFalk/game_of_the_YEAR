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
using static Game_of_the_YEAR.ViewModels.Base.Navigation;

namespace Game_of_the_YEAR.Views
{
    /// <summary>
    /// Interaction logic for StartGamePage.xaml
    /// </summary>
    public partial class StartGamePage : Page
    {
        public StartGamePage()
        {
            InitializeComponent();
            StartGameViewModel startGameViewModel = new StartGameViewModel();
            DataContext = startGameViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GoToLoadingPageOne(); 
        }
    }
}
