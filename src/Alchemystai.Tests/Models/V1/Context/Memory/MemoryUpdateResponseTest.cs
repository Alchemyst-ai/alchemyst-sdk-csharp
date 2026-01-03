using System.Text.Json;
using Alchemystai.Models.V1.Context.Memory;

namespace Alchemystai.Tests.Models.V1.Context.Memory;

public class MemoryUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MemoryUpdateResponse
        {
            MemoryID = "support-thread-TCK-1234",
            Success = true,
            UpdatedEntries = 2,
        };

        string expectedMemoryID = "support-thread-TCK-1234";
        bool expectedSuccess = true;
        double expectedUpdatedEntries = 2;

        Assert.Equal(expectedMemoryID, model.MemoryID);
        Assert.Equal(expectedSuccess, model.Success);
        Assert.Equal(expectedUpdatedEntries, model.UpdatedEntries);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MemoryUpdateResponse
        {
            MemoryID = "support-thread-TCK-1234",
            Success = true,
            UpdatedEntries = 2,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MemoryUpdateResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MemoryUpdateResponse
        {
            MemoryID = "support-thread-TCK-1234",
            Success = true,
            UpdatedEntries = 2,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MemoryUpdateResponse>(element);
        Assert.NotNull(deserialized);

        string expectedMemoryID = "support-thread-TCK-1234";
        bool expectedSuccess = true;
        double expectedUpdatedEntries = 2;

        Assert.Equal(expectedMemoryID, deserialized.MemoryID);
        Assert.Equal(expectedSuccess, deserialized.Success);
        Assert.Equal(expectedUpdatedEntries, deserialized.UpdatedEntries);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MemoryUpdateResponse
        {
            MemoryID = "support-thread-TCK-1234",
            Success = true,
            UpdatedEntries = 2,
        };

        model.Validate();
    }
}
