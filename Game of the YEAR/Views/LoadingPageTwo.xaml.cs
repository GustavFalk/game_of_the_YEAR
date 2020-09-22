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
using Game_of_the_YEAR.ViewModels;

namespace Game_of_the_YEAR.Views
{
    /// <summary>
    /// Interaction logic for LoadingPageTwo.xaml
    /// </summary>
    public partial class LoadingPageTwo : Page
    {
        public LoadingPageTwo()
        {
            InitializeComponent();
            LoadingPageTwoViewModel loadingPageTwoViewModel = new LoadingPageTwoViewModel();
            DataContext = loadingPageTwoViewModel;
        }
       
    }
}
