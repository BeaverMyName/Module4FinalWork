using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess.Models
{
    public class Genre
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public ICollection<Song> Songs { get; }
    }
}
