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

        Assert.NotNull(model.Traces);
        Assert.Equal(expectedTraces.Count, model.Traces.Count);
        for (int i = 0; i < expectedTraces.Count; i++)
        {
            Assert.Equal(expectedTraces[i], model.Traces[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TraceListResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TraceListResponse>(json);
        Assert.NotNull(deserialized);

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

        Assert.NotNull(deserialized.Traces);
        Assert.Equal(expectedTraces.Count, deserialized.Traces.Count);
        for (int i = 0; i < expectedTraces.Count; i++)
        {
            Assert.Equal(expectedTraces[i], deserialized.Traces[i]);
        }
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TraceListResponse { };

        Assert.Null(model.Traces);
        Assert.False(model.RawData.ContainsKey("traces"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TraceListResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TraceListResponse
        {
            // Null should be interpreted as omitted for these properties
            Traces = null,
        };

        Assert.Null(model.Traces);
        Assert.False(model.RawData.ContainsKey("traces"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TraceListResponse
        {
            // Null should be interpreted as omitted for these properties
            Traces = null,
        };

        model.Validate();
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
        Assert.NotNull(model.Data);
        Assert.True(JsonElement.DeepEquals(expectedData, model.Data.Value));
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUserID, model.UserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Trace>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Trace>(json);
        Assert.NotNull(deserialized);

        string expected_ID = "_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedData = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedType = "type";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedUserID = "userId";

        Assert.Equal(expected_ID, deserialized._ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.NotNull(deserialized.Data);
        Assert.True(JsonElement.DeepEquals(expectedData, deserialized.Data.Value));
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUserID, deserialized.UserID);
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Trace { };

        Assert.Null(model._ID);
        Assert.False(model.RawData.ContainsKey("_id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
        Assert.Null(model.UserID);
        Assert.False(model.RawData.ContainsKey("userId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Trace { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Trace
        {
            // Null should be interpreted as omitted for these properties
            _ID = null,
            CreatedAt = null,
            Data = null,
            Type = null,
            UpdatedAt = null,
            UserID = null,
        };

        Assert.Null(model._ID);
        Assert.False(model.RawData.ContainsKey("_id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
        Assert.Null(model.UserID);
        Assert.False(model.RawData.ContainsKey("userId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Trace
        {
            // Null should be interpreted as omitted for these properties
            _ID = null,
            CreatedAt = null,
            Data = null,
            Type = null,
            UpdatedAt = null,
            UserID = null,
        };

        model.Validate();
    }
}
