﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly ArtistRepository rep;
        public ArtistService(ILogger<ArtistService> logger, MvcMusicStoreContext context)
        {
            _logger = logger;
            _context = context;
            rep = new ArtistRepository(context);
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

        public override async Task GetNewArtists(NewArtistsRequest request, IServerStreamWriter<ArtistModel> responseStream, ServerCallContext context)
        {
            IList<ArtistModel> artists = new List<ArtistModel>();
            foreach(Artist artist in rep.GetAllArtists())
            {
                var artistModel = new ArtistModel
                {
                    Name = artist.Name,
                    ArtistId = artist.ArtistId
                };
                artists.Add(artistModel);
            }

            foreach(var art in artists)
            {
                await responseStream.WriteAsync(art);
            }
        }
    }
}
