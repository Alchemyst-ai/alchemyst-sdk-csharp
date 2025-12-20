using System.Collections.Generic;
using System.Text.Json;
using Alchemystai.Models.V1.Context.Memory;

namespace Alchemystai.Tests.Models.V1.Context.Memory;

public class MemoryUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MemoryUpdateParams
        {
            Contents =
            [
                new() { ContentValue = "Customer asked about pricing for the Scale plan." },
                new()
                {
                    ContentValue = "Updated answer about the Scale plan pricing after discounts.",
                },
            ],
            MemoryID = "support-thread-TCK-1234",
        };

        List<Content> expectedContents =
        [
            new() { ContentValue = "Customer asked about pricing for the Scale plan." },
            new() { ContentValue = "Updated answer about the Scale plan pricing after discounts." },
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
        var parameters = new MemoryUpdateParams { };

        Assert.Null(parameters.Contents);
        Assert.False(parameters.RawBodyData.ContainsKey("contents"));
        Assert.Null(parameters.MemoryID);
        Assert.False(parameters.RawBodyData.ContainsKey("memoryId"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MemoryUpdateParams
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

public class ContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Content { ContentValue = "content" };

        string expectedContentValue = "content";

        Assert.Equal(expectedContentValue, model.ContentValue);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Content { ContentValue = "content" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Content>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Content { ContentValue = "content" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Content>(element);
        Assert.NotNull(deserialized);

        string expectedContentValue = "content";

        Assert.Equal(expectedContentValue, deserialized.ContentValue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Content { ContentValue = "content" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Content { };

        Assert.Null(model.ContentValue);
        Assert.False(model.RawData.ContainsKey("content"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Content { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Content
        {
            // Null should be interpreted as omitted for these properties
            ContentValue = null,
        };

        Assert.Null(model.ContentValue);
        Assert.False(model.RawData.ContainsKey("content"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Content
        {
            // Null should be interpreted as omitted for these properties
            ContentValue = null,
        };

        model.Validate();
    }
}
