using System.Text.Json;
using Alchemystai.Models.V1.Context.Memory;

namespace Alchemystai.Tests.Models.V1.Context.Memory;

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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Content>(json);
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
