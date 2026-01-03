using System.Text.Json;
using Alchemystai.Models.V1.Context;

namespace Alchemystai.Tests.Models.V1.Context;

public class ContextAddResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContextAddResponse
        {
            ContextID = "ctx_01HXYZABC",
            Success = true,
            ProcessedDocuments = 2,
        };

        string expectedContextID = "ctx_01HXYZABC";
        bool expectedSuccess = true;
        double expectedProcessedDocuments = 2;

        Assert.Equal(expectedContextID, model.ContextID);
        Assert.Equal(expectedSuccess, model.Success);
        Assert.Equal(expectedProcessedDocuments, model.ProcessedDocuments);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContextAddResponse
        {
            ContextID = "ctx_01HXYZABC",
            Success = true,
            ProcessedDocuments = 2,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ContextAddResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContextAddResponse
        {
            ContextID = "ctx_01HXYZABC",
            Success = true,
            ProcessedDocuments = 2,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ContextAddResponse>(element);
        Assert.NotNull(deserialized);

        string expectedContextID = "ctx_01HXYZABC";
        bool expectedSuccess = true;
        double expectedProcessedDocuments = 2;

        Assert.Equal(expectedContextID, deserialized.ContextID);
        Assert.Equal(expectedSuccess, deserialized.Success);
        Assert.Equal(expectedProcessedDocuments, deserialized.ProcessedDocuments);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContextAddResponse
        {
            ContextID = "ctx_01HXYZABC",
            Success = true,
            ProcessedDocuments = 2,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ContextAddResponse { ContextID = "ctx_01HXYZABC", Success = true };

        Assert.Null(model.ProcessedDocuments);
        Assert.False(model.RawData.ContainsKey("processed_documents"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ContextAddResponse { ContextID = "ctx_01HXYZABC", Success = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ContextAddResponse
        {
            ContextID = "ctx_01HXYZABC",
            Success = true,

            // Null should be interpreted as omitted for these properties
            ProcessedDocuments = null,
        };

        Assert.Null(model.ProcessedDocuments);
        Assert.False(model.RawData.ContainsKey("processed_documents"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ContextAddResponse
        {
            ContextID = "ctx_01HXYZABC",
            Success = true,

            // Null should be interpreted as omitted for these properties
            ProcessedDocuments = null,
        };

        model.Validate();
    }
}
