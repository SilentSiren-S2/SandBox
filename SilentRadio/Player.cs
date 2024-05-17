using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TagLib.Flac;
namespace SilentRadio
{
    public class Song
    {
        public string Title { get; set; }
        public string Path { get; set; }
        public string Artist { get; set; }
        public string Lyrics { get; set; }

//        public BitmapImage? AlbumPicture { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }

    class Player
    {
        private MediaPlayer _mediaPlayer;
        private Song _song;

        public Player()
        {
            _mediaPlayer = new MediaPlayer();
        }

        public Song LoadSong(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                _song = new Song();
                _song.Path = filePath;
                var file = TagLib.File.Create(filePath);
                _song.Title = file.Tag.Title;
                _song.Artist = file.Tag.FirstArtist;
                _song.Lyrics = file.Tag.Lyrics;
            }
            return _song;
        }

        public BitmapImage? LoadImage(string filePath) 
        {
            var file = TagLib.File.Create(filePath);
            if (file.Tag.Pictures.Length >= 1)
            {
                var picture = file.Tag.Pictures[0];
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = new MemoryStream(picture.Data.Data);
                bitmapImage.EndInit();
                BitmapImage? AlbumPicture = bitmapImage;
                return AlbumPicture;
            }
            else
                return null;
        }

        public void PlaySong()
        {
            if (System.IO.File.Exists(_song.Path))
            {
                _mediaPlayer.Open(new Uri(_song.Path));
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
            if (System.IO.File.Exists(filePath))
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
