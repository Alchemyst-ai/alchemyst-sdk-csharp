using System.Text.Json;
using Alchemystai.Models.V1.Context.Memory;

namespace Alchemystai.Tests.Models.V1.Context.Memory;

public class ContentModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContentModel { Content = "content" };

        string expectedContent = "content";

        Assert.Equal(expectedContent, model.Content);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContentModel { Content = "content" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ContentModel>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContentModel { Content = "content" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ContentModel>(json);
        Assert.NotNull(deserialized);

        string expectedContent = "content";

        Assert.Equal(expectedContent, deserialized.Content);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContentModel { Content = "content" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ContentModel { };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ContentModel { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ContentModel
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
        var model = new ContentModel
        {
            // Null should be interpreted as omitted for these properties
            Content = null,
        };

        model.Validate();
    }
}
