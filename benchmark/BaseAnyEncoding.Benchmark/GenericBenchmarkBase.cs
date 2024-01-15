using Base62;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace BaseAnyEncodingBenchmark;

[SimpleJob(RuntimeMoniker.Net472)]
[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net80)]
[MemoryDiagnoser]
public abstract class GenericBenchmarkBase
{
    #region Public 字段

    public const string DefaultBase62CharacterSet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

    #endregion Public 字段

    #region Public 属性

    public string EncodedValue { get; set; } = null!;

    [Params("hello world",
            "Base62 Convertor for .Net\r\n\r\nConvert between byte array and base62 string.\r\n\r\nSpecial thanks to Mengye Ren and his base62-csharp, and Daniel Destouche and his base62.",
            "What is .NET?\r\n\r\nOfficial Starting Page: https://dotnet.microsoft.com\r\n\r\n    How to use .NET (with VS, VS Code, command-line CLI)\r\n        Install official releases\r\n        Install daily builds\r\n        Documentation (Get Started, Tutorials, Porting from .NET Framework, API reference, ...)\r\n            Deploying apps\r\n        Supported OS versions\r\n    Roadmap\r\n    Releases\r\n\r\nHow can I contribute?\r\n\r\nWe welcome contributions! Many people all over the world have helped make this project better.\r\n\r\n    Contributing explains what kinds of contributions we welcome\r\n    Workflow Instructions explains how to build and test\r\n    Get Up and Running on .NET Core explains how to get nightly builds of the runtime and its libraries to test them in your own projects.\r\n")]
    public string Value { get; set; } = null!;

    #endregion Public 属性

    #region Public 方法

    [IterationSetup]
    public virtual void IterationSetup()
    {
        EncodedValue = Value.ToBase62();
    }

    #endregion Public 方法
}
