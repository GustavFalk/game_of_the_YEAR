using System;
using System.Collections.Generic;
using System.Text;

namespace Game_of_the_YEAR.ViewModels.Base
{
    public static class Soundengine
    {
        #region Mediaplayer commands
        public static void MediaPlayerPlay()
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).mediaPlayer.Play();
        }

        public static void MediaPlayerPause()
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).mediaPlayer.Pause();
        }

        public static void MediaPlayerLoad(string soundname)
        {
            string soundstring = $@".\Assets\Sound\{soundname}";
            ((MainWindow)System.Windows.Application.Current.MainWindow).mediaPlayer.Open(new Uri(soundstring, UriKind.Relative));
        }

        public static void MediaPlayerPlayFromZero()
        {

            ((MainWindow)System.Windows.Application.Current.MainWindow).mediaPlayer.Position = TimeSpan.Zero;
            MediaPlayerPlay();
        }

        #endregion
    }
}
