using System.Text;
using SimpleBase;

namespace BaseAnyEncodingTest;

[TestClass]
public class Base32Bech32Test : FrequentlyUsedCharBaseTestBase
{
    #region Protected 属性

    protected override string CharacterSet { get; } = "qpzry9x8gf2tvdw0s3jn54khce6mua7l";

    #endregion Protected 属性

    #region Protected 方法

    protected override Span<byte> StandardDecode(string source)
    {
        return Base32.Bech32.Decode(source);
    }

    protected override string StandardEncode(string source)
    {
        return Base32.Bech32.Encode(Encoding.UTF8.GetBytes(source));
    }

    #endregion Protected 方法
}

[TestClass]
public class Base32FileCoinTest : FrequentlyUsedCharBaseTestBase
{
    #region Protected 属性

    protected override string CharacterSet { get; } = "abcdefghijklmnopqrstuvwxyz234567";

    #endregion Protected 属性

    #region Protected 方法

    protected override Span<byte> StandardDecode(string source)
    {
        return Base32.FileCoin.Decode(source);
    }

    protected override string StandardEncode(string source)
    {
        return Base32.FileCoin.Encode(Encoding.UTF8.GetBytes(source));
    }

    #endregion Protected 方法
}

[TestClass]
public class Base32Rfc4648Test : FrequentlyUsedCharBaseTestBase
{
    #region Protected 属性

    protected override string CharacterSet { get; } = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";

    #endregion Protected 属性

    #region Protected 方法

    protected override Span<byte> StandardDecode(string source)
    {
        return Base32.Rfc4648.Decode(source);
    }

    protected override string StandardEncode(string source)
    {
        return Base32.Rfc4648.Encode(Encoding.UTF8.GetBytes(source));
    }

    #endregion Protected 方法
}
