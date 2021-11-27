using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MusicDB
{
    public class MusicContextFactory : IDesignTimeDbContextFactory<MusicContext>
    {
        public MusicContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var optionsBuilder = new DbContextOptionsBuilder();

            var connectionString = configuration.GetConnectionString("Music");

            optionsBuilder.UseSqlServer(connectionString);

            return new MusicContext(optionsBuilder.Options);
        }
    }
}
