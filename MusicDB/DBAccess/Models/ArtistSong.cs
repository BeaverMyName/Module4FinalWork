using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess.Models
{
    public class ArtistSong
    {
        public int Id { get; init; }
        public Artist Artist { get; init; }
        public int ArtistId { get; init; }
        public Song Song { get; init; }
        public int SongId { get; init; }
    }
}
