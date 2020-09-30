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
    
    public partial class RulePage : Page
    {
        #region Constructor
        public RulePage()
        {
            InitializeComponent();
            RuleViewModel ruleViewModel = new RuleViewModel();
            DataContext = ruleViewModel;
        }
        #endregion


    }
}
