using System.Text.Json;
using Alchemystai.Models.V1.Org.Context;

namespace Alchemystai.Tests.Models.V1.Org.Context;

public class ContextViewResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContextViewResponse
        {
            Contexts = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        JsonElement expectedContexts = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.NotNull(model.Contexts);
        Assert.True(JsonElement.DeepEquals(expectedContexts, model.Contexts.Value));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContextViewResponse
        {
            Contexts = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ContextViewResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContextViewResponse
        {
            Contexts = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ContextViewResponse>(json);
        Assert.NotNull(deserialized);

        JsonElement expectedContexts = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.NotNull(deserialized.Contexts);
        Assert.True(JsonElement.DeepEquals(expectedContexts, deserialized.Contexts.Value));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContextViewResponse
        {
            Contexts = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ContextViewResponse { };

        Assert.Null(model.Contexts);
        Assert.False(model.RawData.ContainsKey("contexts"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ContextViewResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ContextViewResponse
        {
            // Null should be interpreted as omitted for these properties
            Contexts = null,
        };

        Assert.Null(model.Contexts);
        Assert.False(model.RawData.ContainsKey("contexts"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ContextViewResponse
        {
            // Null should be interpreted as omitted for these properties
            Contexts = null,
        };

        model.Validate();
    }
}
