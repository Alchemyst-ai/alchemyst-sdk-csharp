using System.Collections.Generic;
using System.Text.Json;
using Alchemystai.Models.V1.Context.View;

namespace Alchemystai.Tests.Models.V1.Context.View;

public class ViewRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ViewRetrieveResponse
        {
            Context = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        List<JsonElement> expectedContext = [JsonSerializer.Deserialize<JsonElement>("{}")];

        Assert.NotNull(model.Context);
        Assert.Equal(expectedContext.Count, model.Context.Count);
        for (int i = 0; i < expectedContext.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedContext[i], model.Context[i]));
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ViewRetrieveResponse
        {
            Context = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ViewRetrieveResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ViewRetrieveResponse
        {
            Context = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ViewRetrieveResponse>(element);
        Assert.NotNull(deserialized);

        List<JsonElement> expectedContext = [JsonSerializer.Deserialize<JsonElement>("{}")];

        Assert.NotNull(deserialized.Context);
        Assert.Equal(expectedContext.Count, deserialized.Context.Count);
        for (int i = 0; i < expectedContext.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedContext[i], deserialized.Context[i]));
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ViewRetrieveResponse
        {
            Context = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ViewRetrieveResponse { };

        Assert.Null(model.Context);
        Assert.False(model.RawData.ContainsKey("context"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ViewRetrieveResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ViewRetrieveResponse
        {
            // Null should be interpreted as omitted for these properties
            Context = null,
        };

        Assert.Null(model.Context);
        Assert.False(model.RawData.ContainsKey("context"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ViewRetrieveResponse
        {
            // Null should be interpreted as omitted for these properties
            Context = null,
        };

        model.Validate();
    }
}
