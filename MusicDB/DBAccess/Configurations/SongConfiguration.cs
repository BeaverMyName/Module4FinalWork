using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBAccess.Configurations
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();

            builder.HasOne(x => x.Genre)
                .WithMany(x => x.Songs)
                .HasForeignKey(x => x.GenreId);

            builder.HasData(new Song[]
            {
                new Song() { Id = 1, Title = "Lose Yourself", GenreId = 1, Duration = 323, ReleaseDate = new DateTime(2002, 10, 28) },
                new Song() { Id = 2, Title = "Bad Romance", GenreId = 3, Duration = 308, ReleaseDate = new DateTime(2009, 11, 24) },
                new Song() { Id = 3, Title = "Hello", GenreId = 3, Duration = 366, ReleaseDate = new DateTime(2015, 10, 23) },
                new Song() { Id = 4, Title = "Du Hast", GenreId = 2, Duration = 235, ReleaseDate = new DateTime (1997, 7, 19) },
                new Song() { Id = 5, Title = "Eleanor Rigby", GenreId = 2, Duration = 131, ReleaseDate = new DateTime (1966, 8, 5) }
            });
        }
    }
}
