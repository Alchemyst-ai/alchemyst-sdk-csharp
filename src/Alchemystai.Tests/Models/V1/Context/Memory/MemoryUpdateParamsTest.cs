using System.Text.Json;
using Alchemystai.Models.V1.Context.Memory;

namespace Alchemystai.Tests.Models.V1.Context.Memory;

public class ContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Content { Content1 = "content" };

        string expectedContent1 = "content";

        Assert.Equal(expectedContent1, model.Content1);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Content { Content1 = "content" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Content>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Content { Content1 = "content" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Content>(json);
        Assert.NotNull(deserialized);

        string expectedContent1 = "content";

        Assert.Equal(expectedContent1, deserialized.Content1);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Content { Content1 = "content" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Content { };

        Assert.Null(model.Content1);
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
            Content1 = null,
        };

        Assert.Null(model.Content1);
        Assert.False(model.RawData.ContainsKey("content"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Content
        {
            // Null should be interpreted as omitted for these properties
            Content1 = null,
        };

        model.Validate();
    }
}
