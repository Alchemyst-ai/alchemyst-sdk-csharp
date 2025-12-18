using System.Text.Json;
using Alchemystai.Models.V1.Context.Traces;

namespace Alchemystai.Tests.Models.V1.Context.Traces;

public class TraceDeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TraceDeleteResponse
        {
            Trace = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        JsonElement expectedTrace = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.NotNull(model.Trace);
        Assert.True(JsonElement.DeepEquals(expectedTrace, model.Trace.Value));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TraceDeleteResponse
        {
            Trace = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TraceDeleteResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TraceDeleteResponse
        {
            Trace = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TraceDeleteResponse>(element);
        Assert.NotNull(deserialized);

        JsonElement expectedTrace = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.NotNull(deserialized.Trace);
        Assert.True(JsonElement.DeepEquals(expectedTrace, deserialized.Trace.Value));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TraceDeleteResponse
        {
            Trace = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TraceDeleteResponse { };

        Assert.Null(model.Trace);
        Assert.False(model.RawData.ContainsKey("trace"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TraceDeleteResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TraceDeleteResponse
        {
            // Null should be interpreted as omitted for these properties
            Trace = null,
        };

        Assert.Null(model.Trace);
        Assert.False(model.RawData.ContainsKey("trace"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TraceDeleteResponse
        {
            // Null should be interpreted as omitted for these properties
            Trace = null,
        };

        model.Validate();
    }
}
