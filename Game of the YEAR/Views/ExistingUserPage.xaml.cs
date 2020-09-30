using Game_of_the_YEAR.ViewModels;
using System.Windows.Controls;


namespace Game_of_the_YEAR.Views
{
    
    public partial class ExistingUserPage : Page
    {
        #region Constructor
        public ExistingUserPage()
        {
            InitializeComponent();
            ExistingUserPageViewModel existingUserPageViewModel = new ExistingUserPageViewModel();
            DataContext = existingUserPageViewModel;
        }
        #endregion
    }
}
