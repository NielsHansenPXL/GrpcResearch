using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcClient
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(100, 200)]
        public int Amount;
        public readonly GRPCClient grpcClient = new GRPCClient();

        [Benchmark]
        public async Task GrpcTest()
        {
            for (int i = 0; i < Amount; i++)
            {
                await grpcClient.StreamResultAsync();
            }
        }
    }
}
