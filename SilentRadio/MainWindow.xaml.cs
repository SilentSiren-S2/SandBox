using SilentRadio.SoundModel;
using System.IO;
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

namespace SilentRadio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Song> _songs;
        public MainWindow()
        {
            InitializeComponent(); 

            LoadSongs();

            ucPlayer.NextAction += Next;
            ucPlayer.PreviousAction += Previous;

        }
        private void LoadSongs()
        {
            _songs = new List<Song>();

            string folderPath = @"D:\music\";
            string[] filePaths = Directory.EnumerateFiles(folderPath, "*.mp3", SearchOption.AllDirectories).ToArray();


            foreach (string filePath in filePaths)
            {
                string fileName = System.IO.Path.GetFileNameWithoutExtension(filePath);
                _songs.Add(new Song { Title = fileName, Path = filePath });
            }

            Playlist defaultPL = new Playlist("Default_PlayList");
            defaultPL.Songs = _songs;
            List<Playlist> tmp = new List<Playlist>();
            tmp.Add(defaultPL);
            XmlUtils.SaveData(tmp, "defaultPL", XmlUtils.StorageLocation.ProjectBin);
        }

        private void SongListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (songListBox.SelectedItem != null)
            //{
            //    Song selectedSong = (Song)songListBox.SelectedItem;
            //    ucPlayer.Init(selectedSong);
            //}
        }

        private void PlayPauseButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Previous()
        {
            //if (songListBox.SelectedItem != null)
            //{
            //    if (songListBox.SelectedIndex != 0)
            //    {
            //        songListBox.SelectedItem = songListBox.Items[songListBox.SelectedIndex - 1];
            //    }
            //    else if (songListBox.SelectedIndex == 0)
            //    {
            //        songListBox.SelectedItem = songListBox.Items[songListBox.Items.Count - 1];
            //    }
            //}
        }
        private void Next()
        {
            //if (songListBox.SelectedItem != null)
            //{
            //    if (songListBox.SelectedIndex < songListBox.Items.Count - 1)
            //    {
            //        songListBox.SelectedItem = songListBox.Items[songListBox.SelectedIndex + 1];
            //    }
            //    else if (songListBox.SelectedIndex == songListBox.Items.Count - 1)
            //    {
            //        songListBox.SelectedItem = songListBox.Items[0];
            //    }
            //}
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void songListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}