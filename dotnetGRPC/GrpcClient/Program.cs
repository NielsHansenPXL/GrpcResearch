using System;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcServer;
using GrpcServer.Protos;

namespace GrpcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmark>();
            Console.ReadKey();
        }
    }

}
