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
    /// Interaction logic for HighScorePage.xaml
    /// </summary>
    public partial class HighScorePage : Page
    {
        HighScoreViewModel highScore = new HighScoreViewModel();
        public HighScorePage()
        {
            InitializeComponent();
        }
    }
}
