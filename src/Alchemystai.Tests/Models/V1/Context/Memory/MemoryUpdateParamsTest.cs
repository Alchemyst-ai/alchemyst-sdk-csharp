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
                new()
                {
                    ID = "msg-1",
                    ContentValue = "Customer asked about pricing for the Scale plan.",
                    CreatedAt = "2025-01-10T12:34:56.000Z",
                    Metadata = new Dictionary<string, JsonElement>()
                    {
                        { "messageId", JsonSerializer.SerializeToElement("bar") },
                    },
                    Role = "user",
                },
                new()
                {
                    ID = "msg-2",
                    ContentValue = "Updated answer about the Scale plan pricing after discounts.",
                    CreatedAt = "2025-01-10T12:36:00.000Z",
                    Metadata = new Dictionary<string, JsonElement>()
                    {
                        { "messageId", JsonSerializer.SerializeToElement("bar") },
                    },
                    Role = "assistant",
                },
            ],
            MemoryID = "support-thread-TCK-1234",
        };

        List<Content> expectedContents =
        [
            new()
            {
                ID = "msg-1",
                ContentValue = "Customer asked about pricing for the Scale plan.",
                CreatedAt = "2025-01-10T12:34:56.000Z",
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "messageId", JsonSerializer.SerializeToElement("bar") },
                },
                Role = "user",
            },
            new()
            {
                ID = "msg-2",
                ContentValue = "Updated answer about the Scale plan pricing after discounts.",
                CreatedAt = "2025-01-10T12:36:00.000Z",
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "messageId", JsonSerializer.SerializeToElement("bar") },
                },
                Role = "assistant",
            },
        ];
        string expectedMemoryID = "support-thread-TCK-1234";

        Assert.Equal(expectedContents.Count, parameters.Contents.Count);
        for (int i = 0; i < expectedContents.Count; i++)
        {
            Assert.Equal(expectedContents[i], parameters.Contents[i]);
        }
        Assert.Equal(expectedMemoryID, parameters.MemoryID);
    }
}

public class ContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Content
        {
            ID = "id",
            ContentValue = "content",
            CreatedAt = "createdAt",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Role = "role",
        };

        string expectedID = "id";
        string expectedContentValue = "content";
        string expectedCreatedAt = "createdAt";
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedRole = "role";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedContentValue, model.ContentValue);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Metadata[item.Key]));
        }
        Assert.Equal(expectedRole, model.Role);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Content
        {
            ID = "id",
            ContentValue = "content",
            CreatedAt = "createdAt",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Role = "role",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Content>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Content
        {
            ID = "id",
            ContentValue = "content",
            CreatedAt = "createdAt",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Role = "role",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Content>(element);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedContentValue = "content";
        string expectedCreatedAt = "createdAt";
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedRole = "role";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedContentValue, deserialized.ContentValue);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Metadata[item.Key]));
        }
        Assert.Equal(expectedRole, deserialized.Role);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Content
        {
            ID = "id",
            ContentValue = "content",
            CreatedAt = "createdAt",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Role = "role",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Content { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.ContentValue);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Role);
        Assert.False(model.RawData.ContainsKey("role"));
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
            ID = null,
            ContentValue = null,
            CreatedAt = null,
            Metadata = null,
            Role = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.ContentValue);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Role);
        Assert.False(model.RawData.ContainsKey("role"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Content
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            ContentValue = null,
            CreatedAt = null,
            Metadata = null,
            Role = null,
        };

        model.Validate();
    }
}
