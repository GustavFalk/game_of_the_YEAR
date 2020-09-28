using System;
using System.Collections.Generic;
using System.Text;

namespace Game_of_the_YEAR.ViewModels.Base
{
    public static class Soundengine
    {
        public enum sounds { _321go, bipbopsound, coindrop, gamemusic, lightning, menumusic, pointcoundown }

        #region Mediaplayer commands
        public static void MediaPlayerPlay()
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).mediaPlayer.Play();
        }

        public static void MediaPlayerPause()
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).mediaPlayer.Pause();
        }

        public static void MediaPlayerLoad(sounds sound)
        {

            switch (sound)
            {
                case sounds._321go:
                    ((MainWindow)System.Windows.Application.Current.MainWindow).mediaPlayer.Open(new Uri($@".\Assets\Sound\321go.mp3", UriKind.Relative));
                    break;
                case sounds.bipbopsound:
                    ((MainWindow)System.Windows.Application.Current.MainWindow).mediaPlayer.Open(new Uri($@".\Assets\Sound\bipbopsound.wav", UriKind.Relative));
                    break;
                case sounds.coindrop:
                    ((MainWindow)System.Windows.Application.Current.MainWindow).mediaPlayer.Open(new Uri($@".\Assets\Sound\coindrop.wav", UriKind.Relative));
                    break;
                case sounds.gamemusic:
                    ((MainWindow)System.Windows.Application.Current.MainWindow).mediaPlayer.Open(new Uri($@".\Assets\Sound\gamemusic.wav", UriKind.Relative));
                    break;
                case sounds.lightning:
                    ((MainWindow)System.Windows.Application.Current.MainWindow).mediaPlayer.Open(new Uri($@".\Assets\Sound\lightning.mp3", UriKind.Relative));
                    break;
                case sounds.menumusic:
                    ((MainWindow)System.Windows.Application.Current.MainWindow).mediaPlayer.Open(new Uri($@".\Assets\Sound\menumusic.wav", UriKind.Relative));
                    break;
                case sounds.pointcoundown:
                    ((MainWindow)System.Windows.Application.Current.MainWindow).mediaPlayer.Open(new Uri($@".\Assets\Sound\pointcountdown.wav", UriKind.Relative));
                    break;
            }



            }

            public static void MediaPlayerPlayFromZero()
        {

            ((MainWindow)System.Windows.Application.Current.MainWindow).mediaPlayer.Position = TimeSpan.Zero;
            MediaPlayerPlay();
        }

        public static void MediaPlayerVolume(double volume)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).mediaPlayer.Volume = volume;
        }

        public static void MediaPlayerLoop()
        {

        }
        #endregion
    }
}
