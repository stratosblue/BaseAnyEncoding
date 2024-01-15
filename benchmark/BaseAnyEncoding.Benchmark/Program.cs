using BaseAnyEncodingBenchmark;
using BenchmarkDotNet.Running;

var arg = args.Length > 0 ? args[0] : "";

switch (arg.ToLowerInvariant())
{
    case "decode":
        BenchmarkRunner.Run<Base62DecodeBenchmark>();
        break;

    case "encode":
    default:
        BenchmarkRunner.Run<Base62EncodeBenchmark>();
        break;
}
