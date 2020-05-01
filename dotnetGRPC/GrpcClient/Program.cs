using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcServer;
using GrpcServer.Protos;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var artistClient = new RemoteArtist.RemoteArtistClient(channel);
            var artistInput = new ArtistLookUpModel() { ArtistId = 22 };
            var artistReply = await artistClient.GetArtistInfoAsync(artistInput);
            Console.WriteLine($"{artistReply.Name}");
        }
    }
}
