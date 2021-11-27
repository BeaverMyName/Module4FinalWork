using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess.Models
{
    public class Artist
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public DateTime DateOfBirth { get; init; }
        [Phone]
        public string Phone { get; init; }
        [EmailAddress]
        public string Email { get; init; }
        [Url]
        public string InstagramUrl { get; init; }

        public ICollection<ArtistSong> ArtistSong { get; }

        public Artist()
        {
            ArtistSong = new List<ArtistSong>();
        }
    }
}
