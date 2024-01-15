using System.Buffers;
using System.Text;
using Base62;
using BenchmarkDotNet.Attributes;

namespace BaseAnyEncodingBenchmark;

public class Base62DecodeBenchmark : GenericBenchmarkBase
{
    #region Private 字段

    private IBaseAnyEncoder<char> _encoder = null!;

    #endregion Private 字段

    #region Public 方法

    [Benchmark(Baseline = true)]
    public void Base62NetDecode()
    {
        _ = EncodedValue.FromBase62<string>();
    }

    [Benchmark]
    public void BaseAnyEncodingDecode()
    {
        using var data = _encoder.DecodeFromString(EncodedValue);
#if NET6_0_OR_GREATER
        Encoding.UTF8.GetString(data.Span);
#else
        Encoding.UTF8.GetString(data.Span.ToArray());
#endif
    }

    [Benchmark]
    public void BaseAnyEncodingStaticDecode()
    {
        using var data = BaseAnyEncoding.Decode(EncodedValue.AsSpan(), DefaultBase62CharacterSet.AsSpan());
        _ = data.Span.ToString();
    }

    #endregion Public 方法

    public override void IterationSetup()
    {
        base.IterationSetup();
        _encoder = BaseAnyEncoding.CreateEncoder(DefaultBase62CharacterSet.AsSpan());
    }
}
