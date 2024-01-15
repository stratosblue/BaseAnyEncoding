using System.Text;
using SimpleBase;

namespace BaseAnyEncodingTest;

[TestClass]
public class Base16LowerCaseTests : FrequentlyUsedCharBaseTestBase
{
    #region Protected 属性

    protected override string CharacterSet { get; } = "0123456789abcdef";

    #endregion Protected 属性

    #region Protected 方法

    protected override Span<byte> StandardDecode(string source)
    {
        return Base16.LowerCase.Decode(source);
    }

    protected override string StandardEncode(string source)
    {
        return Base16.LowerCase.Encode(Encoding.UTF8.GetBytes(source));
    }

    #endregion Protected 方法
}

[TestClass]
public class Base16UpperCaseTests : FrequentlyUsedCharBaseTestBase
{
    #region Protected 属性

    protected override string CharacterSet { get; } = "0123456789ABCDEF";

    #endregion Protected 属性

    #region Protected 方法

    protected override Span<byte> StandardDecode(string source)
    {
        return Base16.UpperCase.Decode(source);
    }

    protected override string StandardEncode(string source)
    {
        return Base16.UpperCase.Encode(Encoding.UTF8.GetBytes(source));
    }

    #endregion Protected 方法
}

[TestClass]
public class Base16ModHexTests : FrequentlyUsedCharBaseTestBase
{
    #region Protected 属性

    protected override string CharacterSet { get; } = "cbdefghijklnrtuv";

    #endregion Protected 属性

    #region Protected 方法

    protected override Span<byte> StandardDecode(string source)
    {
        return Base16.ModHex.Decode(source);
    }

    protected override string StandardEncode(string source)
    {
        return Base16.ModHex.Encode(Encoding.UTF8.GetBytes(source));
    }

    #endregion Protected 方法
}
