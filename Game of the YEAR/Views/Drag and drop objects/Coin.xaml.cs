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

namespace Game_of_the_YEAR.Views.Drag_and_drop_objects
{
    /// <summary>
    /// Interaction logic for Coin.xaml
    /// </summary>
    public partial class Coin : UserControl
    {
        public Coin()
        {
            InitializeComponent();
        }
        public Coin(Coin c)
        {
            InitializeComponent();          
            this.coinUI.Fill = c.coinUI.Fill;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                
                DataObject data = new DataObject();
                data.SetData(DataFormats.StringFormat, coinUI.Fill.ToString());                
                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }
    }
}
