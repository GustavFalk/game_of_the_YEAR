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
    /// Interaction logic for ExistingUserPage.xaml
    /// </summary>
    public partial class ExistingUserPage : Page
    {
        public ExistingUserPage()
        {
            InitializeComponent();
            ExistingUserPageViewModel existingUserPageViewModel = new ExistingUserPageViewModel();
            DataContext = existingUserPageViewModel;
        }
    }
}
