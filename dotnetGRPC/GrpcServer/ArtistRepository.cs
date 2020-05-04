using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcServer.Interfaces;
using MvcMusicStore_library.Models;

namespace GrpcServer
{
    public class ArtistRepository : IArtistRepository
    {
        private MvcMusicStoreContext _context;
        private IList<Artist> artists;

        public ArtistRepository(MvcMusicStoreContext context)
        {
            artists = context.Artist.ToList();
            this._context = context;
        }


        public IList<Artist> GetAllArtists()
        {
            return artists;
        }

        public void UpdateArtist(Artist existingArtist)
        {
            throw new NotImplementedException();
        }

        public void AddArtist(Artist newArtist)
        {
            throw new NotImplementedException();
        }
    }
}