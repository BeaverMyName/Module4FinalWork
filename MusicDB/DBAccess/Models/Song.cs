using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess.Models
{
    public class Song
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public int Duration { get; init; }
        public DateTime ReleaseDate { get; init; }
        public Genre Genre { get; init; }
        public int GenreId { get; init; }

        public ICollection<ArtistSong> ArtistSong { get; }

        public Song()
        {
            ArtistSong = new List<ArtistSong>();
        }
    }
}
