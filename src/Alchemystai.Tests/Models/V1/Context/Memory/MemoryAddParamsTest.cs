using System.Collections.Generic;
using System.Text.Json;
using Alchemystai.Models.V1.Context.Memory;

namespace Alchemystai.Tests.Models.V1.Context.Memory;

public class MemoryAddParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MemoryAddParams
        {
            Contents =
            [
                new() { Content = "Customer asked about pricing for the Scale plan." },
                new()
                {
                    Content = "Explained the Scale plan pricing and shared the pricing page link.",
                },
            ],
            MemoryID = "support-thread-TCK-1234",
        };

        List<MemoryAddParamsContent> expectedContents =
        [
            new() { Content = "Customer asked about pricing for the Scale plan." },
            new()
            {
                Content = "Explained the Scale plan pricing and shared the pricing page link.",
            },
        ];
        string expectedMemoryID = "support-thread-TCK-1234";

        Assert.NotNull(parameters.Contents);
        Assert.Equal(expectedContents.Count, parameters.Contents.Count);
        for (int i = 0; i < expectedContents.Count; i++)
        {
            Assert.Equal(expectedContents[i], parameters.Contents[i]);
        }
        Assert.Equal(expectedMemoryID, parameters.MemoryID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MemoryAddParams { };

        Assert.Null(parameters.Contents);
        Assert.False(parameters.RawBodyData.ContainsKey("contents"));
        Assert.Null(parameters.MemoryID);
        Assert.False(parameters.RawBodyData.ContainsKey("memoryId"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MemoryAddParams
        {
            // Null should be interpreted as omitted for these properties
            Contents = null,
            MemoryID = null,
        };

        Assert.Null(parameters.Contents);
        Assert.False(parameters.RawBodyData.ContainsKey("contents"));
        Assert.Null(parameters.MemoryID);
        Assert.False(parameters.RawBodyData.ContainsKey("memoryId"));
    }
}

public class MemoryAddParamsContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MemoryAddParamsContent { Content = "content" };

        string expectedContent = "content";

        Assert.Equal(expectedContent, model.Content);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MemoryAddParamsContent { Content = "content" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MemoryAddParamsContent>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MemoryAddParamsContent { Content = "content" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MemoryAddParamsContent>(element);
        Assert.NotNull(deserialized);

        string expectedContent = "content";

        Assert.Equal(expectedContent, deserialized.Content);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MemoryAddParamsContent { Content = "content" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MemoryAddParamsContent { };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MemoryAddParamsContent { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MemoryAddParamsContent
        {
            // Null should be interpreted as omitted for these properties
            Content = null,
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MemoryAddParamsContent
        {
            // Null should be interpreted as omitted for these properties
            Content = null,
        };

        model.Validate();
    }
}
