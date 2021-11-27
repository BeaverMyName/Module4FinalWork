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
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();

            builder.HasData(new Artist[]
            {
                new Artist() { Id = 1, Name = "Paul McCartney", Phone = "+4382836323", Email = "PaulMcC@gmail.com", InstagramUrl = "www.instagram.com/paulmccartney", DateOfBirth = new DateTime(1942, 6, 18) },
                new Artist() { Id = 2, Name = "Till Lendemann", Phone = "+5843893993", Email = "TillLindemann@gmail.com", InstagramUrl = "www.instagram.com/till_lindemann_official", DateOfBirth = new DateTime(1963, 1, 4) },
                new Artist() { Id = 3, Name = "Lady Gaga", Phone = "+4347823742", Email = "LadyGaga@gmail.com", InstagramUrl = "www.instagram.com/ladygaga", DateOfBirth = new DateTime(1986, 3, 28) },
                new Artist() { Id = 4, Name = "Eminem", Phone = "+53457349587", Email = "Eminem@gmail.com", InstagramUrl = "www.instagram.com/eminem", DateOfBirth = new DateTime(1972, 10, 17) },
                new Artist() { Id = 5, Name = "Adele", Phone = "+42348789233", Email = "Adele@gmail.com", InstagramUrl = "www.instagram.com/adele", DateOfBirth = new DateTime(1988, 5, 5) }
            });
        }
    }
}
