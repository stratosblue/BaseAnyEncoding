using System.Buffers;
using System.Text;

namespace BaseAnyEncodingTest;

[TestClass]
public class CustomBaseTypeTest
{
    #region Private 字段

    private readonly BaseItem[] _baseItems = [new(1, "Name1"), new(2, "Name2"), new(3, "Name3")];

    private readonly BaseItem[] _baseItemsBit = [new(4, "Name4"), new(5, "Name5"), new(6, "Name6"), new(7, "Name7")];

    #endregion Private 字段

    #region Public 方法

    [TestMethod]
    [DataRow("hello world")]
    [DataRow("What is .NET?Official Starting Page: https://dotnet.microsoft.com    How to use .NET (with VS, VS Code, command-line CLI)        Install official releases        Install daily builds        Documentation (Get Started, Tutorials, Porting from .NET Framework, API reference, ...)            Deploying apps        Supported OS versions    Roadmap    ReleasesHow can I contribute?We welcome contributions! Many people all over the world have helped make this project better.    Contributing explains what kinds of contributions we welcome    Workflow Instructions explains how to build and test    Get Up and Running on .NET Core explains how to get nightly builds of the runtime and its libraries to test them in your own projects.")]
    [DataRow(".NET 是一个免费的跨平台开放源代码开发人员平台，用于生成多种类型的应用程序。 .NET 基于许多大规模应用在生产中使用的高性能运行时构建而来。云应用    云原生应用    .NET Aspire    控制台应用    云中的无服务器函数    Web 应用、Web API 和微服务跨平台客户端应用    桌面应用    游戏    移动应用Windows 应用    Windows 桌面应用        Windows 窗体        Windows WPF        通用 Windows 平台 (UWP)    Windows 服务其他应用类型    机器学习    物联网 (IoT)")]
    public void ShouldSuccessCodec(string source)
    {
        using var encoder1 = BaseAnyEncoding.CreateEncoder(_baseItems);
        using var encoder2 = BaseAnyEncoding.CreateEncoder(_baseItemsBit);

        using var encodedData1 = encoder1.Encode(Encoding.UTF8.GetBytes(source));

        Console.WriteLine($"encodedData1：{string.Join(", ", encodedData1.Span.ToArray())}");
        using var decodedData1 = encoder1.Decode(encodedData1.Span);

        Assert.AreEqual(source, Encoding.UTF8.GetString(decodedData1.Span));

        using var encodedData2 = encoder2.Encode(Encoding.UTF8.GetBytes(source));

        Console.WriteLine($"encodedData2：{string.Join(", ", encodedData2.Span.ToArray())}");
        using var decodedData2 = encoder2.Decode(encodedData2.Span);

        Assert.AreEqual(source, Encoding.UTF8.GetString(decodedData2.Span));
    }

    [TestMethod]
    [DataRow("hello world")]
    [DataRow("What is .NET?Official Starting Page: https://dotnet.microsoft.com    How to use .NET (with VS, VS Code, command-line CLI)        Install official releases        Install daily builds        Documentation (Get Started, Tutorials, Porting from .NET Framework, API reference, ...)            Deploying apps        Supported OS versions    Roadmap    ReleasesHow can I contribute?We welcome contributions! Many people all over the world have helped make this project better.    Contributing explains what kinds of contributions we welcome    Workflow Instructions explains how to build and test    Get Up and Running on .NET Core explains how to get nightly builds of the runtime and its libraries to test them in your own projects.")]
    [DataRow(".NET 是一个免费的跨平台开放源代码开发人员平台，用于生成多种类型的应用程序。 .NET 基于许多大规模应用在生产中使用的高性能运行时构建而来。云应用    云原生应用    .NET Aspire    控制台应用    云中的无服务器函数    Web 应用、Web API 和微服务跨平台客户端应用    桌面应用    游戏    移动应用Windows 应用    Windows 桌面应用        Windows 窗体        Windows WPF        通用 Windows 平台 (UWP)    Windows 服务其他应用类型    机器学习    物联网 (IoT)")]
    public void ShouldSuccessCodecStatic(string source)
    {
        using var encodedData1 = BaseAnyEncoding.Encode<BaseItem>(Encoding.UTF8.GetBytes(source), _baseItems);

        Console.WriteLine($"encodedData1：{string.Join(", ", encodedData1.Span.ToArray())}");
        using var decodedData1 = BaseAnyEncoding.Decode<BaseItem>(encodedData1.Span, _baseItems);

        Assert.AreEqual(source, Encoding.UTF8.GetString(decodedData1.Span));

        using var encodedData2 = BaseAnyEncoding.Encode<BaseItem>(Encoding.UTF8.GetBytes(source), _baseItemsBit);

        Console.WriteLine($"encodedData2：{string.Join(", ", encodedData2.Span.ToArray())}");
        using var decodedData2 = BaseAnyEncoding.Decode<BaseItem>(encodedData2.Span, _baseItemsBit);

        Assert.AreEqual(source, Encoding.UTF8.GetString(decodedData2.Span));
    }

    #endregion Public 方法

    #region Public 结构体

    public struct BaseItem(int Id, string Name) : IEquatable<BaseItem>
    {
        #region Public 属性

        public int Id { get; } = Id;

        public string Name { get; } = Name;

        #endregion Public 属性

        #region Public 方法

        public bool Equals(BaseItem other)
        {
            return Id == other.Id
                   && Name.Equals(other.Name);
        }

        public override bool Equals(object obj)
        {
            return obj is BaseItem && Equals((BaseItem)obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return $"[{Id} - {Name}]";
        }

        #endregion Public 方法
    }

    #endregion Public 结构体
}
