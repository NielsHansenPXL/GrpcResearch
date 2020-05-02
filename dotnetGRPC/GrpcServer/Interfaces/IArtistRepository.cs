using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcServer.Models;

namespace GrpcServer.Interfaces
{
    public interface IArtistRepository
    {
        IList<Artist> GetAllArtists();

        void UpdateArtist(Artist existingArtist);
        void AddArtist(Artist newArtist);
    }
}