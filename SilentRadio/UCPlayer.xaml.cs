using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Threading;

namespace SilentRadio
{
    /// <summary>
    /// Interaction logic for UCPlayer.xaml
    /// </summary>
    public partial class UCPlayer : UserControl
    {
        private Player _player;
        private bool _playing;
        private DispatcherTimer _timer; // Об'єкт таймера
        private TimeSpan _duration;
        private TimeSpan _elapsedTime = TimeSpan.Zero; // Пройдений час
        public event Action NextAction;
        public event Action PreviousAction;
        public UCPlayer()
        {
            InitializeComponent();

            _player = new Player();
        }

        public void Init(Song song)
        {
            song = _player.LoadSong(song.Path);
            songTitle.Text = song.Title;
            artistName.Text = song.Artist;
            if (song.AlbumPicture != null)
                albumImage.Source = song.AlbumPicture;
            _duration = _player.GetAudioDuration(song.Path);
            _player.PlaySong();
            _playing = true;

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                // додаєм секунду
                _elapsedTime += TimeSpan.FromSeconds(1);
                double currentPosition = _player.GetPosition(); 

                progressBar.Value = (currentPosition / _duration.TotalSeconds) * 100;
                if (currentPosition >= _duration.TotalSeconds-1)
                {
                    Random rnd= new Random();
                    var x = rnd.Next(0, 1);
                    if (x == 0)
                    {
                        NextAction?.Invoke();
                    }
                    else
                    {
                        PreviousAction?.Invoke();
                        NextAction?.Invoke();
                    }
                }
            }
            catch { }
        }

        private void playPauseButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (_playing)
            {
                var temp = _player.GetPosition();
                _player.Pause();
                _playing = false;
                _timer.Stop();
            }
            else
            {
                _player.Resume();
                _playing = true;
                _timer.Start();
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            NextAction?.Invoke();
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            PreviousAction?.Invoke();
        }
    }
}
