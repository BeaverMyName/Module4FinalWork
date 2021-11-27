using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBAccess.Configurations
{
    public class ArtistSongConfiguration : IEntityTypeConfiguration<ArtistSong>
    {
        public void Configure(EntityTypeBuilder<ArtistSong> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Artist)
                .WithMany(x => x.ArtistSong)
                .HasForeignKey(x => x.ArtistId);

            builder.HasOne(x => x.Song)
                .WithMany(x => x.ArtistSong)
                .HasForeignKey(x => x.SongId);

            builder.HasData(new ArtistSong[]
            {
                new ArtistSong() { Id = 1, ArtistId = 1, SongId = 5 },
                new ArtistSong() { Id = 2, ArtistId = 2, SongId = 4 },
                new ArtistSong() { Id = 3, ArtistId = 3, SongId = 2 },
                new ArtistSong() { Id = 4, ArtistId = 4, SongId = 1 },
                new ArtistSong() { Id = 5, ArtistId = 5, SongId = 3 }
            });
        }
    }
}
