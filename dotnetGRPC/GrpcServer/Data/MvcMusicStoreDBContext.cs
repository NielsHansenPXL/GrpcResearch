using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcServer.Models;
using Microsoft.EntityFrameworkCore;

namespace GrpcServer.Data
{
    public class MvcMusicStoreDBContext : DbContext
    {
        public MvcMusicStoreDBContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Artist>().HasData(
                GetArtists()
            );
        }
        public DbSet<Artist> Artists { get; set; }
        private static List<Artist> GetArtists()
        {
            List<Artist> artists = new List<Artist>() {
                new Artist() {    // 1
                    Name = "Vince",
                    ArtistId = 1
                },
                new Artist() {    // 2
                    Name = "Niels",
                    ArtistId = 2
                }
            };
            return artists;
        }
    }
}

