using System.Buffers;
using System.Text;

namespace BaseAnyEncodingTest;

[TestClass]
public abstract class FrequentlyUsedCharBaseTestBase
{
    #region Protected 属性

    protected abstract string CharacterSet { get; }

    #endregion Protected 属性

    #region Public 方法

    [TestMethod]
    [DataRow("hello world")]
    [DataRow("What is .NET?Official Starting Page: https://dotnet.microsoft.com    How to use .NET (with VS, VS Code, command-line CLI)        Install official releases        Install daily builds        Documentation (Get Started, Tutorials, Porting from .NET Framework, API reference, ...)            Deploying apps        Supported OS versions    Roadmap    ReleasesHow can I contribute?We welcome contributions! Many people all over the world have helped make this project better.    Contributing explains what kinds of contributions we welcome    Workflow Instructions explains how to build and test    Get Up and Running on .NET Core explains how to get nightly builds of the runtime and its libraries to test them in your own projects.")]
    [DataRow(".NET 是一个免费的跨平台开放源代码开发人员平台，用于生成多种类型的应用程序。 .NET 基于许多大规模应用在生产中使用的高性能运行时构建而来。云应用    云原生应用    .NET Aspire    控制台应用    云中的无服务器函数    Web 应用、Web API 和微服务跨平台客户端应用    桌面应用    游戏    移动应用Windows 应用    Windows 桌面应用        Windows 窗体        Windows WPF        通用 Windows 平台 (UWP)    Windows 服务其他应用类型    机器学习    物联网 (IoT)")]
    public virtual void ShouldCodecEqualsStandard(string source)
    {
        using var encoder = BaseAnyEncoding.CreateEncoder(CharacterSet.AsSpan());

        using var encodedData = encoder.Encode(Encoding.UTF8.GetBytes(source));
        using var decodedData = encoder.Decode(encodedData.Span);
        var standardEncoded = StandardEncode(source);
        var standardDecoded = StandardDecode(standardEncoded);

        CheckEncodeDataEqualsStandard(standardEncoded, encodedData);
        CheckDecodeDataSequenceEqualsStandard(standardDecoded, decodedData);
    }

    [TestMethod]
    [DataRow("hello world")]
    [DataRow("What is .NET?Official Starting Page: https://dotnet.microsoft.com    How to use .NET (with VS, VS Code, command-line CLI)        Install official releases        Install daily builds        Documentation (Get Started, Tutorials, Porting from .NET Framework, API reference, ...)            Deploying apps        Supported OS versions    Roadmap    ReleasesHow can I contribute?We welcome contributions! Many people all over the world have helped make this project better.    Contributing explains what kinds of contributions we welcome    Workflow Instructions explains how to build and test    Get Up and Running on .NET Core explains how to get nightly builds of the runtime and its libraries to test them in your own projects.")]
    [DataRow(".NET 是一个免费的跨平台开放源代码开发人员平台，用于生成多种类型的应用程序。 .NET 基于许多大规模应用在生产中使用的高性能运行时构建而来。云应用    云原生应用    .NET Aspire    控制台应用    云中的无服务器函数    Web 应用、Web API 和微服务跨平台客户端应用    桌面应用    游戏    移动应用Windows 应用    Windows 桌面应用        Windows 窗体        Windows WPF        通用 Windows 平台 (UWP)    Windows 服务其他应用类型    机器学习    物联网 (IoT)")]
    public virtual void ShouldCodecEqualsStandardStatic(string source)
    {
        using var encodedData = BaseAnyEncoding.Encode(Encoding.UTF8.GetBytes(source), CharacterSet.AsSpan());
        using var decodedData = BaseAnyEncoding.Decode(encodedData.Span, CharacterSet.AsSpan());
        var standardEncoded = StandardEncode(source);
        var standardDecoded = StandardDecode(standardEncoded);

        CheckEncodeDataEqualsStandard(standardEncoded, encodedData);
        CheckDecodeDataSequenceEqualsStandard(standardDecoded, decodedData);
    }

    [TestMethod]
    [DataRow("hello world")]
    [DataRow("What is .NET?Official Starting Page: https://dotnet.microsoft.com    How to use .NET (with VS, VS Code, command-line CLI)        Install official releases        Install daily builds        Documentation (Get Started, Tutorials, Porting from .NET Framework, API reference, ...)            Deploying apps        Supported OS versions    Roadmap    ReleasesHow can I contribute?We welcome contributions! Many people all over the world have helped make this project better.    Contributing explains what kinds of contributions we welcome    Workflow Instructions explains how to build and test    Get Up and Running on .NET Core explains how to get nightly builds of the runtime and its libraries to test them in your own projects.")]
    [DataRow(".NET 是一个免费的跨平台开放源代码开发人员平台，用于生成多种类型的应用程序。 .NET 基于许多大规模应用在生产中使用的高性能运行时构建而来。云应用    云原生应用    .NET Aspire    控制台应用    云中的无服务器函数    Web 应用、Web API 和微服务跨平台客户端应用    桌面应用    游戏    移动应用Windows 应用    Windows 桌面应用        Windows 窗体        Windows WPF        通用 Windows 平台 (UWP)    Windows 服务其他应用类型    机器学习    物联网 (IoT)")]
    public virtual void ShouldCodecSuccess(string source)
    {
        using var encoder = BaseAnyEncoding.CreateEncoder(CharacterSet.AsSpan());
        var encodedData = encoder.EncodeToString(Encoding.UTF8.GetBytes(source));
        using var decodedData = encoder.DecodeFromString(encodedData);

        Assert.AreEqual(source, Encoding.UTF8.GetString(decodedData.Span.ToArray()));
    }

    [TestMethod]
    [DataRow("hello world")]
    [DataRow("What is .NET?Official Starting Page: https://dotnet.microsoft.com    How to use .NET (with VS, VS Code, command-line CLI)        Install official releases        Install daily builds        Documentation (Get Started, Tutorials, Porting from .NET Framework, API reference, ...)            Deploying apps        Supported OS versions    Roadmap    ReleasesHow can I contribute?We welcome contributions! Many people all over the world have helped make this project better.    Contributing explains what kinds of contributions we welcome    Workflow Instructions explains how to build and test    Get Up and Running on .NET Core explains how to get nightly builds of the runtime and its libraries to test them in your own projects.")]
    [DataRow(".NET 是一个免费的跨平台开放源代码开发人员平台，用于生成多种类型的应用程序。 .NET 基于许多大规模应用在生产中使用的高性能运行时构建而来。云应用    云原生应用    .NET Aspire    控制台应用    云中的无服务器函数    Web 应用、Web API 和微服务跨平台客户端应用    桌面应用    游戏    移动应用Windows 应用    Windows 桌面应用        Windows 窗体        Windows WPF        通用 Windows 平台 (UWP)    Windows 服务其他应用类型    机器学习    物联网 (IoT)")]
    public virtual void ShouldCodecSuccessStatic(string source)
    {
        using var encodedData = BaseAnyEncoding.Encode(Encoding.UTF8.GetBytes(source), CharacterSet.AsSpan());
        using var decodedData = BaseAnyEncoding.Decode(encodedData.Span, CharacterSet.AsSpan());

        Assert.AreEqual(source, Encoding.UTF8.GetString(decodedData.Span.ToArray()));
    }

    [TestMethod]
    [DataRow(".NET 是一个免费的跨平台开放源代码开发人员平台，用于生成多种类型的应用程序。 .NET 基于许多大规模应用在生产中使用的高性能运行时构建而来。云应用    云原生应用    .NET Aspire    控制台应用    云中的无服务器函数    Web 应用、Web API 和微服务跨平台客户端应用    桌面应用    游戏    移动应用Windows 应用    Windows 桌面应用        Windows 窗体        Windows WPF        通用 Windows 平台 (UWP)    Windows 服务其他应用类型    机器学习    物联网 (IoT)")]
    public virtual void ShouldEqualsStandardWithRandomValue(string source)
    {
        var random = new Random();
        using var encoder = BaseAnyEncoding.CreateEncoder(CharacterSet.AsSpan());

        for (int length = 1; length < 512; length++)
        {
            var randomSource = new string(Enumerable.Range(0, length).Select(_ => source[random.Next(source.Length)]).ToArray());
            using var encodedData = encoder.Encode(Encoding.UTF8.GetBytes(randomSource));
            using var decodedData = encoder.Decode(encodedData.Span);
            var standardEncoded = StandardEncode(randomSource);
            var standardDecoded = StandardDecode(standardEncoded);

            CheckEncodeDataEqualsStandard(standardEncoded, encodedData, $"Fail at length [{length}]");
            CheckDecodeDataSequenceEqualsStandard(standardDecoded, decodedData, $"Fail at length [{length}]");
        }
    }

    [TestMethod]
    [DataRow(".NET 是一个免费的跨平台开放源代码开发人员平台，用于生成多种类型的应用程序。 .NET 基于许多大规模应用在生产中使用的高性能运行时构建而来。云应用    云原生应用    .NET Aspire    控制台应用    云中的无服务器函数    Web 应用、Web API 和微服务跨平台客户端应用    桌面应用    游戏    移动应用Windows 应用    Windows 桌面应用        Windows 窗体        Windows WPF        通用 Windows 平台 (UWP)    Windows 服务其他应用类型    机器学习    物联网 (IoT)")]
    public virtual void ShouldEqualsStandardWithRandomValueStatic(string source)
    {
        var random = new Random();
        for (int length = 1; length < 512; length++)
        {
            var randomSource = new string(Enumerable.Range(0, length).Select(_ => source[random.Next(source.Length)]).ToArray());
            using var encodedData = BaseAnyEncoding.Encode(Encoding.UTF8.GetBytes(randomSource), CharacterSet.AsSpan());
            using var decodedData = BaseAnyEncoding.Decode(encodedData.Span, CharacterSet.AsSpan());
            var standardEncoded = StandardEncode(randomSource);
            var standardDecoded = StandardDecode(standardEncoded);

            CheckEncodeDataEqualsStandard(standardEncoded, encodedData, $"Fail at length [{length}]");
            CheckDecodeDataSequenceEqualsStandard(standardDecoded, decodedData, $"Fail at length [{length}]");
        }
    }

    [TestMethod]
    [DataRow(1)]
    [DataRow(5)]
    [DataRow(1 << 1)]
    [DataRow(1 << 2)]
    [DataRow(1 << 3)]
    [DataRow(1 << 4)]
    [DataRow(1 << 5)]
    [DataRow(1 << 6)]
    [DataRow(1 << 7)]
    [DataRow(1 << 8)]
    [DataRow(1 << 9)]
    [DataRow(byte.MaxValue)]
    public virtual void ShouldSuccessWithBoundaryValues(int length)
    {
        var random = new Random();
        var data = new byte[length];
        random.NextBytes(data);

        using var encodedData = BaseAnyEncoding.Encode(data, CharacterSet.AsSpan());
        using var decodedData = BaseAnyEncoding.Decode(encodedData.Span, CharacterSet.AsSpan());

        CheckDecodeDataSequenceEqualsRaw(data, decodedData, $"Fail at length [{length}]");
    }

    [TestMethod]
    public virtual void ShouldSuccessWithRandomShortValues()
    {
        var random = new Random();

        for (int length = 0; length <= sizeof(ulong) * 2; length++)
        {
            var data = new byte[length];
            random.NextBytes(data);

            using var encodedData = BaseAnyEncoding.Encode(data, CharacterSet.AsSpan());
            using var decodedData = BaseAnyEncoding.Decode(encodedData.Span, CharacterSet.AsSpan());

            CheckDecodeDataSequenceEqualsRaw(data, decodedData, $"Fail at length [{length}]");
        }
    }

    [TestMethod]
    public virtual void ShouldSuccessWithShortZeroValues()
    {
        for (int length = 1; length <= sizeof(ulong) * 2; length++)
        {
            var data = new byte[length];
            Array.Fill(data, (byte)0);

            using var encodedData = BaseAnyEncoding.Encode(data, CharacterSet.AsSpan());
            using var decodedData = BaseAnyEncoding.Decode(encodedData.Span, CharacterSet.AsSpan());

            CheckDecodeDataSequenceEqualsRaw(data, decodedData, $"Fail at length [{length}]");
        }
    }

    #endregion Public 方法

    #region Protected 方法

    protected virtual void CheckDecodeDataSequenceEqualsRaw(byte[] rawData, PooledData<byte> decodedData, params string[] messages)
    {
        Assert.IsTrue(decodedData.Span.SequenceEqual(rawData), "Sequence not equal \n{0}\n{1}\n{2}", Display(rawData), Display(decodedData.Span), string.Concat(messages));
    }

    protected virtual void CheckDecodeDataSequenceEqualsStandard(ReadOnlySpan<byte> standardData, PooledData<byte> decodedData, params string[] messages)
    {
        Assert.IsTrue(decodedData.Span.SequenceEqual(standardData), "Sequence not equal \n{0}\n{1}\n{2}", Display(standardData), Display(decodedData.Span), string.Concat(messages));
    }

    protected virtual void CheckEncodeDataEqualsStandard(string standardEncoded, PooledData<char> encodedData, params string[] messages)
    {
        Assert.AreEqual(standardEncoded, encodedData.Span.ToString(), "Data not equal \n{0}\n{1}\n{2}", standardEncoded, encodedData.Span.ToString(), string.Concat(messages));
    }

    protected abstract Span<byte> StandardDecode(string source);

    protected abstract string StandardEncode(string source);

    #region static

    protected static string Display<T>(IEnumerable<T> items)
    {
        return string.Join(", ", items);
    }

    protected static string Display<T>(Span<T> items)
    {
        return string.Join(", ", items.ToArray());
    }

    protected static string Display<T>(ReadOnlySpan<T> items)
    {
        return string.Join(", ", items.ToArray());
    }

    #endregion static

    #endregion Protected 方法
}
