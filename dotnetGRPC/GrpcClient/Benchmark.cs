using BenchmarkApp;
using BenchmarkDotNet.Attributes;
using System.Threading.Tasks;

namespace GrpcClient
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(100, 200, 300)] public int Amount;
        public GRPCClient grpcClient = new GRPCClient();
        public RESTClient restClient = new RESTClient();

        [Benchmark]
        public async Task GrpcStreamBenchmark()
        {
            for (int i = 0; i < Amount; i++)
            {
                await grpcClient.StreamResultAsync();
            }
        }
    }
}