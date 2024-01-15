using System.Text;
using Base62;

namespace BaseAnyEncodingTest;

[TestClass]
public class Base62Test : FrequentlyUsedCharBaseTestBase
{
    #region Protected 属性

    protected override string CharacterSet { get; } = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

    #endregion Protected 属性

    #region Protected 方法

    protected override Span<byte> StandardDecode(string source)
    {
        return Encoding.UTF8.GetBytes(source.FromBase62<string>());
    }

    protected override string StandardEncode(string source)
    {
        return source.ToBase62();
    }

    #endregion Protected 方法
}
