using Grpc.Core;
using Grpc.Net.Client;
using GrpcServer.Protos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrpcClient
{
    public class GRPCClient
    {
        private readonly GrpcChannel channel;
        private readonly RemoteArtist.RemoteArtistClient client;

        public GRPCClient()
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            channel = GrpcChannel.ForAddress("http://localhost:5000");
            client = new RemoteArtist.RemoteArtistClient(channel);
        }
        public async Task<List<ArtistModel>> StreamResultAsync()
        {
            List<ArtistModel> artistModels = new List<ArtistModel>();
            using (var call = client.GetNewArtists(new NewArtistsRequest()))
            {
                while (await call.ResponseStream.MoveNext())
                {
                    var currentArtist = call.ResponseStream.Current;
                    artistModels.Add(currentArtist);
                }
            };
            return artistModels;
        }
    }
}
