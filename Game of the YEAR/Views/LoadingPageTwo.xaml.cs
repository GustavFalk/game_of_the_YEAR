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
    /// Interaction logic for LoadingPageTwo.xaml
    /// </summary>
    public partial class LoadingPageTwo : Page
    {
        public LoadingPageTwo()
        {
            InitializeComponent();
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
                Page page = new StartpagePage();
                ((MainWindow)System.Windows.Application.Current.MainWindow).Main.Content = page;
            }
            
        }
    }
}
