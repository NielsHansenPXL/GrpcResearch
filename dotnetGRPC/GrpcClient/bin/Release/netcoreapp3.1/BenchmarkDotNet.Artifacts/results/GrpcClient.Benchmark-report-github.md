``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17134.1425 (1803/April2018Update/Redstone4)
Intel Core i5-8250U CPU 1.60GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.1.100
  [Host]     : .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT
  DefaultJob : .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT


```
|   Method | Amount |     Mean |    Error |   StdDev |     Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------- |------- |---------:|---------:|---------:|----------:|------:|------:|----------:|
| **GrpcTest** |    **100** | **347.5 ms** |  **3.81 ms** |  **3.38 ms** | **1000.0000** |     **-** |     **-** |   **6.53 MB** |
| **GrpcTest** |    **200** | **708.9 ms** | **13.86 ms** | **20.75 ms** | **4000.0000** |     **-** |     **-** |  **13.14 MB** |
