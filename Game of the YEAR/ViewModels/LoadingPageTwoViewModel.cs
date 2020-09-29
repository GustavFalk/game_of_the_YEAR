using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Game_of_the_YEAR.ViewModels.Base.Navigation;

namespace Game_of_the_YEAR.ViewModels
{
    class LoadingPageTwoViewModel : Base.BaseViewModel
    {
        #region Properties
        public string LoadingTxt { get; set; }
        #endregion
        #region Methods
        private async void Loading()
        {
            LoadingTxt = "LOADING.";
            await Task.Delay(1000);
            LoadingTxt = "LOADING..";
            await Task.Delay(1000);
            LoadingTxt = "LOADING...";
            await Task.Delay(1000);
            LoadingTxt = "LOADING.";
            await Task.Delay(1000);
            LoadingTxt = "LOADING..";
            await Task.Delay(1000);
            LoadingTxt = "LOADING...";
            await Task.Delay(1000);
            GoToStartpagePage();         
        }
        #endregion
        #region Construtror
        public LoadingPageTwoViewModel()
        {
            Loading();
        }
        #endregion
    }
}
