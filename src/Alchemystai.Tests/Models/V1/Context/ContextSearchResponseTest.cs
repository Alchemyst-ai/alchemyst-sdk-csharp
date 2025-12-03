using System;
using System.Collections.Generic;
using System.Text.Json;
using Alchemystai.Models.V1.Context;

namespace Alchemystai.Tests.Models.V1.Context;

public class ContextSearchResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContextSearchResponse
        {
            Contexts =
            [
                new()
                {
                    Content = "content",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Score = 0.001,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        List<ContextModel> expectedContexts =
        [
            new()
            {
                Content = "content",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                Score = 0.001,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.Equal(expectedContexts.Count, model.Contexts.Count);
        for (int i = 0; i < expectedContexts.Count; i++)
        {
            Assert.Equal(expectedContexts[i], model.Contexts[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContextSearchResponse
        {
            Contexts =
            [
                new()
                {
                    Content = "content",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Score = 0.001,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ContextSearchResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContextSearchResponse
        {
            Contexts =
            [
                new()
                {
                    Content = "content",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Score = 0.001,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ContextSearchResponse>(json);
        Assert.NotNull(deserialized);

        List<ContextModel> expectedContexts =
        [
            new()
            {
                Content = "content",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                Score = 0.001,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.Equal(expectedContexts.Count, deserialized.Contexts.Count);
        for (int i = 0; i < expectedContexts.Count; i++)
        {
            Assert.Equal(expectedContexts[i], deserialized.Contexts[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContextSearchResponse
        {
            Contexts =
            [
                new()
                {
                    Content = "content",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Score = 0.001,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ContextSearchResponse { };

        Assert.Null(model.Contexts);
        Assert.False(model.RawData.ContainsKey("contexts"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ContextSearchResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ContextSearchResponse
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
        var model = new ContextSearchResponse
        {
            // Null should be interpreted as omitted for these properties
            Contexts = null,
        };

        model.Validate();
    }
}

public class ContextModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContextModel
        {
            Content = "content",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Score = 0.001,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedContent = "content";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        double expectedScore = 0.001;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.True(
            model.Metadata.HasValue
                && JsonElement.DeepEquals(expectedMetadata, model.Metadata.Value)
        );
        Assert.Equal(expectedScore, model.Score);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContextModel
        {
            Content = "content",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Score = 0.001,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ContextModel>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContextModel
        {
            Content = "content",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Score = 0.001,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ContextModel>(json);
        Assert.NotNull(deserialized);

        string expectedContent = "content";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        double expectedScore = 0.001;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.True(
            deserialized.Metadata.HasValue
                && JsonElement.DeepEquals(expectedMetadata, deserialized.Metadata.Value)
        );
        Assert.Equal(expectedScore, deserialized.Score);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContextModel
        {
            Content = "content",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Score = 0.001,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ContextModel { };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ContextModel { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ContextModel
        {
            // Null should be interpreted as omitted for these properties
            Content = null,
            CreatedAt = null,
            Metadata = null,
            Score = null,
            UpdatedAt = null,
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ContextModel
        {
            // Null should be interpreted as omitted for these properties
            Content = null,
            CreatedAt = null,
            Metadata = null,
            Score = null,
            UpdatedAt = null,
        };

        model.Validate();
    }
}
