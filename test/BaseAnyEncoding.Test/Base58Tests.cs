using System.Text;
using SimpleBase;

namespace BaseAnyEncodingTest;

[TestClass]
public class Base58BitcoinTests : FrequentlyUsedCharBaseTestBase
{
    #region Protected 属性

    protected override string CharacterSet { get; } = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";

    #endregion Protected 属性

    #region Protected 方法

    protected override Span<byte> StandardDecode(string source)
    {
        return Base58.Bitcoin.Decode(source);
    }

    protected override string StandardEncode(string source)
    {
        return Base58.Bitcoin.Encode(Encoding.UTF8.GetBytes(source));
    }

    #endregion Protected 方法
}

[TestClass]
public class Base58FlickrTests : FrequentlyUsedCharBaseTestBase
{
    #region Protected 属性

    protected override string CharacterSet { get; } = "123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ";

    #endregion Protected 属性

    #region Protected 方法

    protected override Span<byte> StandardDecode(string source)
    {
        return Base58.Flickr.Decode(source);
    }

    protected override string StandardEncode(string source)
    {
        return Base58.Flickr.Encode(Encoding.UTF8.GetBytes(source));
    }

    #endregion Protected 方法
}

[TestClass]
public class Base58RippleTests : FrequentlyUsedCharBaseTestBase
{
    #region Protected 属性

    protected override string CharacterSet { get; } = "rpshnaf39wBUDNEGHJKLM4PQRST7VWXYZ2bcdeCg65jkm8oFqi1tuvAxyz";

    #endregion Protected 属性

    #region Protected 方法

    protected override Span<byte> StandardDecode(string source)
    {
        return Base58.Ripple.Decode(source);
    }

    protected override string StandardEncode(string source)
    {
        return Base58.Ripple.Encode(Encoding.UTF8.GetBytes(source));
    }

    #endregion Protected 方法
}
