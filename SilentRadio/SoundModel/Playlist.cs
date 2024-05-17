using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SilentRadio.SoundModel
{
    public class Playlist
    {
        public string PlaylistName { get; set; }
        public string Description { get; set; }
        public List<Song> Songs { get; set; } = new List<Song>();
//        public BitmapImage? PlaylistImage { get; set; }
        public Playlist(string name)
        {
            PlaylistName = name;
        }
        public Playlist()
        {
            
        }
    }
}
