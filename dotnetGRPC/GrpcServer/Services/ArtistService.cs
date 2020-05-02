using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcServer.Models;
using GrpcServer.Protos;
using Microsoft.Extensions.Logging;


namespace GrpcServer.Services
{
    public class ArtistService : RemoteArtist.RemoteArtistBase
    {
        private readonly ILogger<ArtistService> _logger;
        private readonly MvcMusicStoreContext _context;

        public ArtistService(ILogger<ArtistService> logger, MvcMusicStoreContext context)
        {
            _logger = logger;
            _context = context;
        }

        public override Task<ArtistModel> GetArtistInfo(ArtistLookUpModel request, ServerCallContext context)
        {
            ArtistModel output = new ArtistModel();
            var artist = _context.Artist.Find(request.ArtistId);
            _logger.LogInformation("Sending Artist response");
            if (artist != null)
            {
                output.ArtistId = artist.ArtistId;
                output.Name = artist.Name;
            }

            return Task.FromResult(output);
        }

        public override async Task GetNewArtists(NewArtistsRequest request,
            IServerStreamWriter<ArtistModel> responseStream, ServerCallContext context)
        {
            IList<ArtistModel> artists = new List<ArtistModel>();
            foreach (Artist artist in _context.Artist.ToList())
            {
                var artistModel = new ArtistModel
                {
                    Name = artist.Name,
                    ArtistId = artist.ArtistId
                };
                artists.Add(artistModel);
            }

            foreach (var art in artists)
            {
                await responseStream.WriteAsync(art);
            }
        }

        public override Task<NewArtistsRequest> InsertArtists
        (ArtistModel requestData,
            ServerCallContext context)
        {
            _context.Artist.Add(new Artist()
            {
                Name = requestData.Name
            });
            _context.SaveChanges();
            return Task.FromResult(new NewArtistsRequest());
        }

        public override Task<NewArtistsRequest>
            DeleteArtists(ArtistLookUpModel requestData,
                ServerCallContext context)
        {
            var data = _context.Artist.Find(requestData.ArtistId);
            _context.Artist.Remove(new Artist()
            {
                ArtistId = data.ArtistId,
                Name = data.Name,
            });
            _context.SaveChanges();
            return Task.FromResult(new NewArtistsRequest());
        }

        public override Task<NewArtistsRequest>
            UpdateArtists(ArtistModel requestData,
                ServerCallContext context)
        {
            _context.Artist.Update(new Artist()
            {
                Name = requestData.Name,
            });
            _context.SaveChanges();
            return Task.FromResult(new NewArtistsRequest());
        }
    }
}