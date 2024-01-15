using System.Buffers;

namespace BaseAnyEncodingTest;

[TestClass]
public class GenericTest
{
    #region Public 方法

    [TestMethod]
    public void ShouldThrowWithErrorBaseValue()
    {
        var data = Array.Empty<byte>();
        var data1 = Array.Empty<char>();

        Assert.ThrowsException<ArgumentOutOfRangeException>(() => BaseAnyEncoding.Encode(data, "".AsSpan()));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => BaseAnyEncoding.Encode(data, "1".AsSpan()));

        Assert.ThrowsException<ArgumentOutOfRangeException>(() => BaseAnyEncoding.Decode(data1, "".AsSpan()));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => BaseAnyEncoding.Decode(data1, "1".AsSpan()));

        Assert.ThrowsException<ArgumentOutOfRangeException>(() => BaseAnyEncoding.CreateEncoder(" ".AsSpan()));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => BaseAnyEncoding.CreateEncoder("1".AsSpan()));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => BaseAnyEncoding.CreateEncoder('1'));
    }

    [TestMethod]
    public void ShouldSuccessWithBoundaryBaseValue()
    {
        var data = Array.Empty<byte>();
        var data1 = Array.Empty<char>();

        BaseAnyEncoding.Encode(data, "12".AsSpan());

        BaseAnyEncoding.Decode(data1, "12".AsSpan());

        using var encoder = BaseAnyEncoding.CreateEncoder("12".AsSpan());
    }

    #endregion Public 方法
}
