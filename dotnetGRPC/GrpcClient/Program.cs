using System;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcServer;
using GrpcServer.Models;
using GrpcServer.Protos;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // BenchmarkRunner.Run<Benchmark>();
            // Console.ReadKey();

            {
                AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
                var channel = GrpcChannel.ForAddress("https://localhost:8083");
                var artistClient = new RemoteArtist.RemoteArtistClient(channel);

                var artistInput = new ArtistLookUpModel() { ArtistId = 22 };
                var artistReply = await artistClient.GetArtistInfoAsync(artistInput);
                Console.WriteLine($"{artistReply.Name}");

                Console.WriteLine();

                //Create
                var newArtist = new ArtistModel()
                {
                    Name = "Deadmau5"
                };
                var response1 = await artistClient.InsertArtistsAsync(newArtist);

                Console.WriteLine($"{newArtist.Name} added succesfully");

                Console.WriteLine();

                //Update

                var modifiedArtist = await artistClient.GetArtistInfoAsync(new ArtistLookUpModel()
                {
                    ArtistId = 278
                });


                modifiedArtist.Name = "Donna Summer";

                var response2 = await artistClient.UpdateArtistsAsync(modifiedArtist);

                Console.WriteLine($"{modifiedArtist.Name} with Id {modifiedArtist.ArtistId} modified succesfully");

                Console.WriteLine();


                //Read
                using (var call = artistClient.GetNewArtists(new NewArtistsRequest()))
                {
                    while (await call.ResponseStream.MoveNext())
                    {
                        var currentArtist = call.ResponseStream.Current;
                        Console.WriteLine($"{currentArtist.Name}");
                    }
                }
                Console.ReadLine();

                Console.WriteLine();

                //Delete


            }
        }
    }
}