using System;
using System.Collections.Generic;
using System.Text.Json;
using Alchemystai.Models.V1.Context.Traces;

namespace Alchemystai.Tests.Models.V1.Context.Traces;

public class TraceListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TraceListResponse
        {
            Traces =
            [
                new()
                {
                    _ID = "_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Data = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Type = "type",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserID = "userId",
                },
            ],
        };

        List<Trace> expectedTraces =
        [
            new()
            {
                _ID = "_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Data = JsonSerializer.Deserialize<JsonElement>("{}"),
                Type = "type",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserID = "userId",
            },
        ];

        Assert.Equal(expectedTraces.Count, model.Traces.Count);
        for (int i = 0; i < expectedTraces.Count; i++)
        {
            Assert.Equal(expectedTraces[i], model.Traces[i]);
        }
    }
}

public class TraceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Trace
        {
            _ID = "_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserID = "userId",
        };

        string expected_ID = "_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedData = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedType = "type";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedUserID = "userId";

        Assert.Equal(expected_ID, model._ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.True(model.Data.HasValue && JsonElement.DeepEquals(expectedData, model.Data.Value));
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUserID, model.UserID);
    }
}
