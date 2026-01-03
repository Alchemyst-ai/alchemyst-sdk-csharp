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
            Pagination = new()
            {
                HasNextPage = true,
                HasPrevPage = true,
                Limit = 0,
                Page = 0,
                Total = 0,
                TotalPages = 0,
            },
            Traces =
            [
                new()
                {
                    _ID = "_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Data = JsonSerializer.Deserialize<JsonElement>("{}"),
                    OrganizationID = "organizationId",
                    Type = "type",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserID = "userId",
                },
            ],
        };

        Pagination expectedPagination = new()
        {
            HasNextPage = true,
            HasPrevPage = true,
            Limit = 0,
            Page = 0,
            Total = 0,
            TotalPages = 0,
        };
        List<Trace> expectedTraces =
        [
            new()
            {
                _ID = "_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Data = JsonSerializer.Deserialize<JsonElement>("{}"),
                OrganizationID = "organizationId",
                Type = "type",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserID = "userId",
            },
        ];

        Assert.Equal(expectedPagination, model.Pagination);
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
            Pagination = new()
            {
                HasNextPage = true,
                HasPrevPage = true,
                Limit = 0,
                Page = 0,
                Total = 0,
                TotalPages = 0,
            },
            Traces =
            [
                new()
                {
                    _ID = "_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Data = JsonSerializer.Deserialize<JsonElement>("{}"),
                    OrganizationID = "organizationId",
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
            Pagination = new()
            {
                HasNextPage = true,
                HasPrevPage = true,
                Limit = 0,
                Page = 0,
                Total = 0,
                TotalPages = 0,
            },
            Traces =
            [
                new()
                {
                    _ID = "_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Data = JsonSerializer.Deserialize<JsonElement>("{}"),
                    OrganizationID = "organizationId",
                    Type = "type",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserID = "userId",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TraceListResponse>(element);
        Assert.NotNull(deserialized);

        Pagination expectedPagination = new()
        {
            HasNextPage = true,
            HasPrevPage = true,
            Limit = 0,
            Page = 0,
            Total = 0,
            TotalPages = 0,
        };
        List<Trace> expectedTraces =
        [
            new()
            {
                _ID = "_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Data = JsonSerializer.Deserialize<JsonElement>("{}"),
                OrganizationID = "organizationId",
                Type = "type",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserID = "userId",
            },
        ];

        Assert.Equal(expectedPagination, deserialized.Pagination);
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
            Pagination = new()
            {
                HasNextPage = true,
                HasPrevPage = true,
                Limit = 0,
                Page = 0,
                Total = 0,
                TotalPages = 0,
            },
            Traces =
            [
                new()
                {
                    _ID = "_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Data = JsonSerializer.Deserialize<JsonElement>("{}"),
                    OrganizationID = "organizationId",
                    Type = "type",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UserID = "userId",
                },
            ],
        };

        model.Validate();
    }
}

public class PaginationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Pagination
        {
            HasNextPage = true,
            HasPrevPage = true,
            Limit = 0,
            Page = 0,
            Total = 0,
            TotalPages = 0,
        };

        bool expectedHasNextPage = true;
        bool expectedHasPrevPage = true;
        long expectedLimit = 0;
        long expectedPage = 0;
        long expectedTotal = 0;
        long expectedTotalPages = 0;

        Assert.Equal(expectedHasNextPage, model.HasNextPage);
        Assert.Equal(expectedHasPrevPage, model.HasPrevPage);
        Assert.Equal(expectedLimit, model.Limit);
        Assert.Equal(expectedPage, model.Page);
        Assert.Equal(expectedTotal, model.Total);
        Assert.Equal(expectedTotalPages, model.TotalPages);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Pagination
        {
            HasNextPage = true,
            HasPrevPage = true,
            Limit = 0,
            Page = 0,
            Total = 0,
            TotalPages = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Pagination>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Pagination
        {
            HasNextPage = true,
            HasPrevPage = true,
            Limit = 0,
            Page = 0,
            Total = 0,
            TotalPages = 0,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Pagination>(element);
        Assert.NotNull(deserialized);

        bool expectedHasNextPage = true;
        bool expectedHasPrevPage = true;
        long expectedLimit = 0;
        long expectedPage = 0;
        long expectedTotal = 0;
        long expectedTotalPages = 0;

        Assert.Equal(expectedHasNextPage, deserialized.HasNextPage);
        Assert.Equal(expectedHasPrevPage, deserialized.HasPrevPage);
        Assert.Equal(expectedLimit, deserialized.Limit);
        Assert.Equal(expectedPage, deserialized.Page);
        Assert.Equal(expectedTotal, deserialized.Total);
        Assert.Equal(expectedTotalPages, deserialized.TotalPages);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Pagination
        {
            HasNextPage = true,
            HasPrevPage = true,
            Limit = 0,
            Page = 0,
            Total = 0,
            TotalPages = 0,
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
            OrganizationID = "organizationId",
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserID = "userId",
        };

        string expected_ID = "_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedData = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedOrganizationID = "organizationId";
        string expectedType = "type";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedUserID = "userId";

        Assert.Equal(expected_ID, model._ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.True(JsonElement.DeepEquals(expectedData, model.Data));
        Assert.Equal(expectedOrganizationID, model.OrganizationID);
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
            OrganizationID = "organizationId",
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
            OrganizationID = "organizationId",
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserID = "userId",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Trace>(element);
        Assert.NotNull(deserialized);

        string expected_ID = "_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedData = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedOrganizationID = "organizationId";
        string expectedType = "type";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedUserID = "userId";

        Assert.Equal(expected_ID, deserialized._ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.True(JsonElement.DeepEquals(expectedData, deserialized.Data));
        Assert.Equal(expectedOrganizationID, deserialized.OrganizationID);
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
            OrganizationID = "organizationId",
            Type = "type",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserID = "userId",
        };

        model.Validate();
    }
}
