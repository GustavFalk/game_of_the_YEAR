using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

namespace Game_of_the_YEAR.Views.Drag_and_drop_objects
{
    /// <summary>
    /// Interaction logic for CoinCompartment.xaml
    /// </summary>
    public partial class CoinCompartment : UserControl
    {
        public CoinCompartment()
        {
            InitializeComponent();

        }
      

        protected override void OnDrop(DragEventArgs e)
        {
            base.OnDrop(e);

            PlayCoinDrop();
            GoToLoadingPageTwoWithDelay();
           
            e.Handled = true;
        }
    }
}
