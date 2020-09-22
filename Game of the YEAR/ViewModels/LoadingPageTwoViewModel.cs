using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Game_of_the_YEAR.ViewModels.Base.Navigation;

namespace Game_of_the_YEAR.ViewModels
{
    class LoadingPageTwoViewModel : Base.BaseViewModel
    {
        public string LoadingText { get; set; }

        private async void Loading()
        {
            LoadingText = "LOADING.";
            await Task.Delay(1000);
            LoadingText = "LOADING..";
            await Task.Delay(1000);
            LoadingText = "LOADING...";
            await Task.Delay(1000);
            LoadingText = "LOADING.";
            await Task.Delay(1000);
            LoadingText = "LOADING..";
            await Task.Delay(1000);
            LoadingText = "LOADING...";
            await Task.Delay(1000);
            GoToStartpagePage();         
        }
        public LoadingPageTwoViewModel()
        {
            Loading();
        }
    }
}
