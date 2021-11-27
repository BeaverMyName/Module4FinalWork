using Microsoft.EntityFrameworkCore;
using System;
using DBAccess.Models;
using DBAccess.Configurations;

namespace DBAccess
{
    public class MusicContext : DbContext
    {
        public MusicContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<ArtistSong> ArtistSongs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArtistConfiguration())
                .ApplyConfiguration(new GenreConfiguration())
                .ApplyConfiguration(new SongConfiguration())
                .ApplyConfiguration(new ArtistSongConfiguration());
        }
    }
}
