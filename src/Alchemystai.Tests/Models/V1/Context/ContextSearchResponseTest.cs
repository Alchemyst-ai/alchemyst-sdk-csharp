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
        Assert.True(JsonElement.DeepEquals(expectedMetadata, model.Metadata));
        Assert.Equal(expectedScore, model.Score);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }
}
