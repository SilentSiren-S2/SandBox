using SilentRadio.SoundModel;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace SilentRadio.SoundGUI
{
    /// <summary>
    /// Interaction logic for UCPlaylist.xaml
    /// </summary>
    public partial class UCPlaylist : UserControl
    {
        public Playlist _playlist;

        public UCPlaylist()
        {
            InitializeComponent();
        }

        public UCPlaylist(Playlist pl) : this()
        {
            _playlist = pl;
        }

        private void LoadSongs()
        {
            

            string folderPath = @"D:\music\";
            string[] filePaths = Directory.EnumerateFiles(folderPath, "*.mp3", SearchOption.AllDirectories).ToArray();


            foreach (string filePath in filePaths)
            {
                string fileName = System.IO.Path.GetFileNameWithoutExtension(filePath);
                _playlist.Songs.Add(new Song { Title = fileName, Path = filePath });
            }
        }

        private void SongListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (songListBox.SelectedItem != null)
            {
                Song selectedSong = (Song)songListBox.SelectedItem;
                //ucPlayer.Init(selectedSong);
            }
        }
    }
}
