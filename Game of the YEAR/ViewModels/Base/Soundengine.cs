using System;
using System.Collections.Generic;
using System.Text;

namespace Game_of_the_YEAR.ViewModels.Base
{
    public static class Soundengine
    {
        #region Mediaplayer commands
        public static void MediaplayerPlay()
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).mediaPlayer.Play();
        }

        public static void PauseMediaPlayerMusic()
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).mediaPlayer.Pause();
        }

        public static void LoadNewSound(string soundname)
        {
            string soundstring = $@".\Assets\Sound\{soundname}";
            ((MainWindow)System.Windows.Application.Current.MainWindow).mediaPlayer.Open(new Uri(soundstring, UriKind.Relative));
        }

        public static void PlaySoundFromZero()
        {

            ((MainWindow)System.Windows.Application.Current.MainWindow).mediaPlayer.Position = TimeSpan.Zero;
            MediaplayerPlay();
        }

        #endregion
    }
}
