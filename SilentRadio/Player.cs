using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
namespace SilentRadio
{
    public class Song
    {
        public string Title { get; set; }
        public string Path 
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Title;
        }
    }

    class Player
    {
        private MediaPlayer _mediaPlayer;

        public Player()
        {
            _mediaPlayer = new MediaPlayer();
        }

        public void PlaySong(string filePath)
        {
            if (File.Exists(filePath))
            {
                _mediaPlayer.Open(new Uri(filePath));
                _mediaPlayer.Play();
            }
            else
            {
            }
        }

        public void Pause()
        {
            _mediaPlayer.Pause();
        }

        public void Resume()
        {
            _mediaPlayer.Play();
        }

        public void PlayPause()
        {
            if (true)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }

        public TimeSpan GetAudioDuration(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    var file = TagLib.File.Create(filePath);
                    return file.Properties.Duration;
                }
                catch (Exception ex)
                {
                    // Обробіть помилку (якщо потрібно)
                    Console.WriteLine($"Помилка при читанні тривалості аудіофайлу: {ex.Message}");
                }
            }
            return TimeSpan.Zero;
        }

        public double GetPosition()
        {
            var pos = _mediaPlayer.Position.TotalSeconds;
            return pos;
        }
    }
}
