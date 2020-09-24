using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
        ImageSource BackgroundImage { get; set; } = new BitmapImage(new Uri(@".\Assets\Images\goldpile.gif", UriKind.Relative));
        public Coin()
        {
            InitializeComponent();
            this.Background = new ImageBrush(BackgroundImage);
        }
        
        private class DraggableCoin : Adorner
        {
            
            Rect coinSize;
            Brush coinImage;
            public Point CenterOfCoin;

            public ImageSource CoinImage { get; set; } = new BitmapImage(new Uri(@".\Assets\Images\8bitCoin.png", UriKind.Relative));

            public DraggableCoin(Coin dragedCoin): base(dragedCoin)
            {
                coinSize = new Rect(dragedCoin.RenderSize);
                this.IsHitTestVisible = false;
                coinImage = new ImageBrush(CoinImage);
                //coinImage = dragedCoin.Background.Clone();
                CenterOfCoin = new Point(-coinSize.Width / 2, -coinSize.Height / 2);
            }
            protected override void OnRender(DrawingContext drawingContext)
            {
                drawingContext.DrawRectangle(coinImage, null, coinSize);
            }
        }
        private struct PInPoint
        {
            public int X;
            public int Y;
            public PInPoint(int x, int y)
            {
                X = x;
                Y = y;
            }
            public PInPoint(double x, double y)
            {
                X = (int)x;
                Y = (int)y;
            }
            public Point GetPoint(double xOffset = 0, double yOffset = 0)
            {
                return new Point(X + xOffset, Y + yOffset);
            }
            public Point GetPoint(Point offset)
            {
                return new Point(X + offset.X, Y + offset.Y);
            }
        }

        [DllImport("user32.dll")]
        static extern void GetCursorPos(ref PInPoint p);

        private DraggableCoin myCoin;
        private PInPoint pointRef = new PInPoint();


        private void UserControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var obj = new DataObject(this.Background);
                var adLayer = AdornerLayer.GetAdornerLayer(this);
                myCoin = new DraggableCoin(this);
                adLayer.Add(myCoin);
                DragDrop.DoDragDrop(this, obj, DragDropEffects.Copy);
                adLayer.Remove(myCoin);
            }
        }

        private void UserControl_PreviewGiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            GetCursorPos(ref pointRef);
            Point relPos = this.PointFromScreen(pointRef.GetPoint(myCoin.CenterOfCoin));
            myCoin.Arrange(new Rect(relPos, myCoin.DesiredSize));
        }
    }
}
