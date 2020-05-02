using System;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcServer;
using GrpcServer.Protos;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            var channel = GrpcChannel.ForAddress("https://localhost:8081");
            var artistClient = new RemoteArtist.RemoteArtistClient(channel);

            var artistInput = new ArtistLookUpModel() { ArtistId = 22 };
            var artistReply = await artistClient.GetArtistInfoAsync(artistInput);
            Console.WriteLine($"{artistReply.Name}");

            using (var call = artistClient.GetNewArtists(new NewArtistsRequest()))
            {
                while (await call.ResponseStream.MoveNext())
                {
                    var currentArtist = call.ResponseStream.Current;
                    Console.WriteLine($"{currentArtist.Name}");
                }
            }
            Console.ReadLine();
        }
    }
}
