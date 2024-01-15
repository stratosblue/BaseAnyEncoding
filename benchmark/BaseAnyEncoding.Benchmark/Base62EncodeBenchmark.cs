using System.Buffers;
using System.Text;
using Base62;
using BenchmarkDotNet.Attributes;

namespace BaseAnyEncodingBenchmark;

public class Base62EncodeBenchmark : GenericBenchmarkBase
{
    #region Private 字段

    private IBaseAnyEncoder<char> _encoder = null!;

    #endregion Private 字段

    #region Public 方法

    [Benchmark(Baseline = true)]
    public void Base62NetEncode()
    {
        _ = Value.ToBase62();
    }

    [Benchmark]
    public void BaseAnyEncodingEncode()
    {
        _ = _encoder.EncodeToString(Encoding.UTF8.GetBytes(Value));
    }

    [Benchmark]
    public void BaseAnyEncodingStaticEncode()
    {
        using var data = BaseAnyEncoding.Encode(Encoding.UTF8.GetBytes(Value), DefaultBase62CharacterSet.AsSpan());
        _ = data.Span.ToString();
    }

    public override void IterationSetup()
    {
        base.IterationSetup();
        _encoder = BaseAnyEncoding.CreateEncoder(DefaultBase62CharacterSet.AsSpan());
    }

    #endregion Public 方法
}
