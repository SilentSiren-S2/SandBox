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

            songListBox.ItemsSource = _songs;

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
        }

        private void SongListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (songListBox.SelectedItem != null)
            {
                Song selectedSong = (Song)songListBox.SelectedItem;
                ucPlayer.Init(selectedSong);
            }
        }

        private void PlayPauseButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void songListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}