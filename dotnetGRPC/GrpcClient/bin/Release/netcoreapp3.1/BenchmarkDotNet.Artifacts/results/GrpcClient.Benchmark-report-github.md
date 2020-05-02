``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.778 (1909/November2018Update/19H2)
Intel Core i7-6700K CPU 4.00GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.1.201
  [Host]     : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT
  DefaultJob : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT


```
|   Method | Amount |     Mean |   Error |   StdDev |   Median |     Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------- |------- |---------:|--------:|---------:|---------:|----------:|------:|------:|----------:|
| **GrpcTest** |    **100** | **113.2 ms** | **2.36 ms** |  **6.47 ms** | **110.1 ms** | **1000.0000** |     **-** |     **-** |   **7.14 MB** |
| **GrpcTest** |    **400** | **447.9 ms** | **8.82 ms** | **12.08 ms** | **445.5 ms** | **7000.0000** |     **-** |     **-** |  **28.68 MB** |
