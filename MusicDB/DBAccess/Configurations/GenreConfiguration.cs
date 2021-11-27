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
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();

            builder.HasData(new Genre[]
            {
                new Genre() { Id = 1, Title = "Rap" },
                new Genre() { Id = 2, Title = "Rock" },
                new Genre() { Id = 3, Title = "Pop" },
                new Genre() { Id = 4, Title = "Hip hop" },
                new Genre() { Id = 5, Title = "Electronic" }
            });
        }
    }
}
