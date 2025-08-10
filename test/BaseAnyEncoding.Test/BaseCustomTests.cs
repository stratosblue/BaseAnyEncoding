namespace BaseAnyEncodingTest;

[TestClass]
public class BaseCustomTests : FrequentlyUsedCharBaseTestBase
{
    #region Protected 属性

    protected override string CharacterSet { get; } = "0123456789abcdefghijklmnopqrstuvwxyz";

    #endregion Protected 属性

    #region Public 方法

    public override void ShouldCodecEqualsStandard(string source)
    {
    }

    public override void ShouldCodecEqualsStandardStatic(string source)
    {
    }

    public override void ShouldEqualsStandardWithRandomValue(string source)
    {
    }

    public override void ShouldEqualsStandardWithRandomValueStatic(string source)
    {
    }

    #endregion Public 方法

    #region Protected 方法

    protected override Span<byte> StandardDecode(string source)
    {
        throw new NotImplementedException();
    }

    protected override string StandardEncode(string source)
    {
        throw new NotImplementedException();
    }

    #endregion Protected 方法
}
