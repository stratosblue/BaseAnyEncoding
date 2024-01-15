# BaseAnyEncoding

Data encoding library, capable of character set encoding (base16 base32 base58 base62, etc.), or any type of custom encoding. 数据编码库，可进行字符集编码（base16 base32 base58 base62等），或任意类型的自定义编码。

## Note
 - 由于使用通用编码代码，所以效率会低于特化编码代码;
 - 编码基础数据大小不能小于2;
 - 编码基础数据越大编码后的输出越小;
 - 使用 `BaseXX` 的字符集即可进行对应的编码，但：
     - `Base64` 不会填充末尾 `=`;
     - 与标准 `Base85` 不兼容;
     - 未测试所有 `BaseXX` 与其标准编码的结果兼容性;

## 快速开始

### 引用包
```xml
<ItemGroup>
  <PackageReference Include="BaseAnyEncoding" Version="1.0.0" />
</ItemGroup>
```

### 静态方法调用

 使用 `System.Buffers.BaseAnyEncoding.Encode` 进行编码，`System.Buffers.BaseAnyEncoding.Decode` 进行解码

 - 使用任意大小字符集(*)作为编码基础

    ```C#
    var charset = ""嗷呜！".AsSpan();
    var source = Encoding.UTF8.GetBytes("hello world");

    using var encodedData = System.Buffers.BaseAnyEncoding.Encode(source, charset);
    Console.WriteLine("EncodedData: " + encodedData.Span.ToString());

    using var decodedData = System.Buffers.BaseAnyEncoding.Decode(encodedData.Span, charset);
    Console.WriteLine("DecodedData: " + Encoding.UTF8.GetString(decodedData.Span));
    ```

    输出为:
    ```text
    EncodedData: ！嗷呜呜呜！呜嗷呜！呜！！！！嗷呜！呜嗷呜嗷呜呜！！！呜嗷！！呜嗷呜呜呜！呜呜嗷！嗷嗷呜嗷！！呜！！嗷！嗷 ！嗷
    DecodedData: hello world
    ```

### 实例方法调用
 使用 `System.Buffers.BaseAnyEncoding.CreateEncoder` 创建编码器，然后调用其实例方法，对于多次调用会有稍好的性能

 - 使用任意大小字符集(*)作为编码基础

    ```C#
    var charset = "咕噜".AsSpan();
    var source = Encoding.UTF8.GetBytes("hello world");

    var encoder = System.Buffers.BaseAnyEncoding.CreateEncoder(charset);

    using var encodedData = encoder.Encode(source);
    Console.WriteLine("EncodedData: " + encodedData.Span.ToString());

    using var decodedData = encoder.Decode(encodedData.Span);
    Console.WriteLine("DecodedData: " + Encoding.UTF8.GetString(decodedData.Span));
    ```

    输出为:
    ```text
    EncodedData: 咕噜噜咕噜咕咕咕咕噜噜咕咕噜咕噜咕噜噜咕噜噜咕咕咕噜噜咕噜噜咕咕咕噜噜咕噜噜噜噜咕咕噜咕咕咕咕咕咕噜噜噜咕 噜噜噜咕噜噜咕噜噜噜噜咕噜噜噜咕咕噜咕咕噜噜咕噜噜咕咕咕噜噜咕咕噜咕咕
    DecodedData: hello world
    ```

## 基于自定义类型进行编码

不限于基于 `char` 编码，可以基于任意类型(需要实现 `IEquatable<T>` 接口)进行编码，示例:

 - 基于字符串

    ```C#
    var charset = new[] { "富强", "民主", "文明", "和谐", "自由", "平等", "公正", "法治", "爱国", "敬业", "诚信", "友善" };
    var source = Encoding.UTF8.GetBytes("hello world");

    var encoder = System.Buffers.BaseAnyEncoding.CreateEncoder(charset);

    using var encodedData = encoder.Encode(source);
    Console.WriteLine("EncodedData: " + string.Join(", ", encodedData.Span.ToArray()));

    using var decodedData = encoder.Decode(encodedData.Span);
    Console.WriteLine("DecodedData: " + Encoding.UTF8.GetString(decodedData.Span));
    ```

    输出为:
    ```text
    EncodedData: 民主, 法治, 富强, 法治, 和谐, 友善, 公正, 友善, 和谐, 敬业, 平等, 公正, 爱国, 友善, 公正, 法治, 法治, 富强, 爱国, 友善, 和谐, 法治, 诚信, 友善, 富强
    DecodedData: hello world
    ```

 - 基于自定义类型

    ```C#
    record struct TestValue(int Id, string Value)
    {
        public override string ToString() => Id.ToString();
    }
    ```

    ```C#
    var charset = new TestValue[] { new(0, "今"), new(11, "天"), new(111, "星"), new(1111, "期"), new(11111, "几"), new(111111, "？") };
    var source = Encoding.UTF8.GetBytes("hello world");

    var encoder = System.Buffers.BaseAnyEncoding.CreateEncoder(charset);

    using var encodedData = encoder.Encode(source);
    Console.WriteLine("EncodedData: " + string.Join(", ", encodedData.Span.ToArray()));

    using var decodedData = encoder.Decode(encodedData.Span);
    Console.WriteLine("DecodedData: " + Encoding.UTF8.GetString(decodedData.Span));
    ```

    输出为:
    ```text
    EncodedData: 111, 1111, 111111, 0, 111111, 11, 11111, 1111, 11111, 11111, 1111, 0, 111111, 11, 111111, 11, 1111, 111111, 111, 1111, 11111, 1111, 11, 111111, 1111, 11, 111111, 111, 11, 11111, 1111, 11, 11111, 0
    DecodedData: hello world
    ```
