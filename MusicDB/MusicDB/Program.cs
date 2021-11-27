using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MusicDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var musicContextFactory = new MusicContextFactory();

            using var context = musicContextFactory.CreateDbContext(args);

            var query1 = context.Artists
                .Where(x => EF.Functions.DateDiffYear(x.DateOfBirth, DateTime.UtcNow) < 100)
                .Join(
                context.ArtistSongs,
                x => x.Id,
                y => y.ArtistId,
                (x, y) => new { ArtistName = x.Name, SongId = y.SongId })
                .Join(
                context.Songs.Include(x => x.Genre).Select(x => new { Id = x.Id, Title = x.Title, GenreTitle = x.Genre.Title }),
                x => x.SongId,
                y => y.Id,
                (x, y) => new { ArtistName = x.ArtistName, SongTitle = y.Title, GenreTitle = y.GenreTitle });

            var query2 = context.Songs.GroupBy(x => x.Genre.Title).Select(x => new { GenreTitle = x.Key, Count = x.Count() });

            var query3 = context.Songs.Where(x => EF.Functions.DateDiffDay(x.ReleaseDate, context.Artists.Max(x => x.DateOfBirth)) > 0);
        }
    }
}
