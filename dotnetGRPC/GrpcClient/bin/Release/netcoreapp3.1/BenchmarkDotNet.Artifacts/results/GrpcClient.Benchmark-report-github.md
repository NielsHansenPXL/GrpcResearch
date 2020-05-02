``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.778 (1909/November2018Update/19H2)
Intel Core i7-6700K CPU 4.00GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.1.201
  [Host]     : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT
  DefaultJob : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT


```
|   Method | Amount |     Mean |   Error |  StdDev |     Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------- |------- |---------:|--------:|--------:|----------:|------:|------:|----------:|
| **GrpcTest** |    **100** | **109.6 ms** | **2.08 ms** | **5.66 ms** | **1000.0000** |     **-** |     **-** |   **7.06 MB** |
| **GrpcTest** |    **200** | **215.3 ms** | **4.26 ms** | **5.83 ms** | **3000.0000** |     **-** |     **-** |  **14.15 MB** |
