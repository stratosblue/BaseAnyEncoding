using System.Buffers;
using System.Buffers.Text;
using System.Text;

namespace BaseAnyEncodingTest;

[TestClass]
public class Base64Test : FrequentlyUsedCharBaseTestBase
{
    #region Protected 属性

    protected override string CharacterSet { get; } = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

    #endregion Protected 属性

    #region Protected 方法

    protected override void CheckEncodeDataEqualsStandard(string standardEncoded, PooledData<char> encodedData, params string[] messages)
    {
        Assert.AreEqual(standardEncoded.TrimEnd('='), encodedData.Span.ToString(), "Data not equal \n{0}\n{1}\n{2}", standardEncoded, encodedData.Span.ToString(), string.Concat(messages));
    }

    protected override Span<byte> StandardDecode(string source)
    {
        var data = Encoding.UTF8.GetBytes(source);
        var buffer = new byte[Base64.GetMaxDecodedFromUtf8Length(data.Length)];
        Base64.DecodeFromUtf8(data, buffer, out var bytesConsumed, out var bytesWritten, true);
        return buffer.AsSpan(0, bytesWritten);
    }

    protected override string StandardEncode(string source)
    {
        var data = Encoding.UTF8.GetBytes(source);
        var buffer = new byte[Base64.GetMaxEncodedToUtf8Length(data.Length)];
        Base64.EncodeToUtf8(data, buffer, out var bytesConsumed, out var bytesWritten, true);
        return Encoding.UTF8.GetString(buffer.AsSpan(0, bytesWritten));
    }

    #endregion Protected 方法
}
