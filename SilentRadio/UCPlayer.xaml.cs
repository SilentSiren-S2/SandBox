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
        public UCPlayer()
        {
            InitializeComponent();

            _player = new Player();
        }

        public void Init(Song song)
        {
            songTitle.Text = $"Now Playing: {song.Title}";
            _duration = _player.GetAudioDuration(song.Path);
            _player.PlaySong(song.Path);
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

                progressBar.Value = (_elapsedTime.TotalSeconds / _duration.TotalSeconds) * 100;
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
    }
}
