using System.Buffers;
using System.Text;

[assembly: Parallelize(Scope = ExecutionScope.MethodLevel)]
namespace BaseAnyEncodingTest;

[TestClass]
public class GenericTest
{
    #region Public 方法

    [TestMethod]
    [DataRow("hello world")]
    [DataRow("What is .NET?Official Starting Page: https://dotnet.microsoft.com    How to use .NET (with VS, VS Code, command-line CLI)        Install official releases        Install daily builds        Documentation (Get Started, Tutorials, Porting from .NET Framework, API reference, ...)            Deploying apps        Supported OS versions    Roadmap    ReleasesHow can I contribute?We welcome contributions! Many people all over the world have helped make this project better.    Contributing explains what kinds of contributions we welcome    Workflow Instructions explains how to build and test    Get Up and Running on .NET Core explains how to get nightly builds of the runtime and its libraries to test them in your own projects.")]
    [DataRow(".NET 是一个免费的跨平台开放源代码开发人员平台，用于生成多种类型的应用程序。 .NET 基于许多大规模应用在生产中使用的高性能运行时构建而来。云应用    云原生应用    .NET Aspire    控制台应用    云中的无服务器函数    Web 应用、Web API 和微服务跨平台客户端应用    桌面应用    游戏    移动应用Windows 应用    Windows 桌面应用        Windows 窗体        Windows WPF        通用 Windows 平台 (UWP)    Windows 服务其他应用类型    机器学习    物联网 (IoT)")]
    public void ShouldStringUtilityMethodsWorkSuccess(string source)
    {
        var charset = "12".AsSpan();
        using var encoder = BaseAnyEncoding.CreateEncoder(charset);

        using var rawEncodedData = encoder.Encode(Encoding.UTF8.GetBytes(source));
        using var rawDecodedData = encoder.Decode(rawEncodedData.Span);

        var rawEncodedString = rawEncodedData.Span.ToString();
        var rawDecodedString = Encoding.UTF8.GetString(rawDecodedData.Span);

        Console.WriteLine($"rawEncodedString: {rawEncodedString}\nrawDecodedString: {rawDecodedString}");

        Assert.AreEqual(source, rawDecodedString);

        #region Instance

        Assert.AreEqual(rawEncodedString, encoder.EncodeToString(source));
        Assert.AreEqual(rawEncodedString, encoder.EncodeToString(Encoding.UTF8.GetBytes(source)));

        Assert.AreEqual(rawDecodedString, encoder.DecodeFromString(rawEncodedString).ToDisplayString(Encoding.UTF8));
        Assert.AreEqual(rawDecodedString, encoder.DecodeToString(rawEncodedString));

        #endregion Instance

        #region Static

        Assert.AreEqual(rawEncodedString, BaseAnyEncoding.EncodeToString(source, charset));
        Assert.AreEqual(rawEncodedString, BaseAnyEncoding.EncodeToString(Encoding.UTF8.GetBytes(source), charset));

        Assert.AreEqual(rawDecodedString, BaseAnyEncoding.DecodeToString(rawEncodedString, charset));

        #endregion Static

        Assert.AreEqual(string.Join(", ", rawDecodedData.Span.ToArray().Select(m => m.ToString())), rawDecodedData.ToDisplayString(", "));
        Assert.AreEqual(string.Join(", ", rawDecodedData.Span.ToArray().Select(m => (m * 2).ToString())), rawDecodedData.ToDisplayString(", ", m => (m * 2).ToString()));

        Assert.AreEqual(string.Concat(rawDecodedData.Span.ToArray().Select(m => m.ToString())), rawDecodedData.ToDisplayString(separator: null));
        Assert.AreEqual(string.Concat(rawDecodedData.Span.ToArray().Select(m => (m * 2).ToString())), rawDecodedData.ToDisplayString(separator: null, m => (m * 2).ToString()));
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

    [TestMethod]
    public void ShouldThrowWithErrorBaseValue()
    {
        var data = Array.Empty<byte>();
        var data1 = Array.Empty<char>();

        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => BaseAnyEncoding.Encode(data, "".AsSpan()));
        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => BaseAnyEncoding.Encode(data, "1".AsSpan()));

        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => BaseAnyEncoding.Decode(data1, "".AsSpan()));
        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => BaseAnyEncoding.Decode(data1, "1".AsSpan()));

        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => BaseAnyEncoding.CreateEncoder(" ".AsSpan()));
        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => BaseAnyEncoding.CreateEncoder("1".AsSpan()));
        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => BaseAnyEncoding.CreateEncoder('1'));
    }

    #endregion Public 方法
}
