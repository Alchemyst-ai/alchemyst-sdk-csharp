using System;
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
            Trace = new()
            {
                _ID = "trace_123",
                CreatedAt = DateTimeOffset.Parse("2025-01-10T12:35:10.000Z"),
                Data = new()
                {
                    FileName = "support_thread_TCK-1234.txt",
                    Query = "What did the customer ask about pricing for the Scale plan?",
                    Source = "support-inbox",
                },
                OrganizationID = "org_123",
                Type = "context.search",
                UpdatedAt = DateTimeOffset.Parse("2025-01-10T12:35:10.000Z"),
                UserID = "user_123",
            },
        };

        TraceDeleteResponseTrace expectedTrace = new()
        {
            _ID = "trace_123",
            CreatedAt = DateTimeOffset.Parse("2025-01-10T12:35:10.000Z"),
            Data = new()
            {
                FileName = "support_thread_TCK-1234.txt",
                Query = "What did the customer ask about pricing for the Scale plan?",
                Source = "support-inbox",
            },
            OrganizationID = "org_123",
            Type = "context.search",
            UpdatedAt = DateTimeOffset.Parse("2025-01-10T12:35:10.000Z"),
            UserID = "user_123",
        };

        Assert.Equal(expectedTrace, model.Trace);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TraceDeleteResponse
        {
            Trace = new()
            {
                _ID = "trace_123",
                CreatedAt = DateTimeOffset.Parse("2025-01-10T12:35:10.000Z"),
                Data = new()
                {
                    FileName = "support_thread_TCK-1234.txt",
                    Query = "What did the customer ask about pricing for the Scale plan?",
                    Source = "support-inbox",
                },
                OrganizationID = "org_123",
                Type = "context.search",
                UpdatedAt = DateTimeOffset.Parse("2025-01-10T12:35:10.000Z"),
                UserID = "user_123",
            },
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
            Trace = new()
            {
                _ID = "trace_123",
                CreatedAt = DateTimeOffset.Parse("2025-01-10T12:35:10.000Z"),
                Data = new()
                {
                    FileName = "support_thread_TCK-1234.txt",
                    Query = "What did the customer ask about pricing for the Scale plan?",
                    Source = "support-inbox",
                },
                OrganizationID = "org_123",
                Type = "context.search",
                UpdatedAt = DateTimeOffset.Parse("2025-01-10T12:35:10.000Z"),
                UserID = "user_123",
            },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TraceDeleteResponse>(element);
        Assert.NotNull(deserialized);

        TraceDeleteResponseTrace expectedTrace = new()
        {
            _ID = "trace_123",
            CreatedAt = DateTimeOffset.Parse("2025-01-10T12:35:10.000Z"),
            Data = new()
            {
                FileName = "support_thread_TCK-1234.txt",
                Query = "What did the customer ask about pricing for the Scale plan?",
                Source = "support-inbox",
            },
            OrganizationID = "org_123",
            Type = "context.search",
            UpdatedAt = DateTimeOffset.Parse("2025-01-10T12:35:10.000Z"),
            UserID = "user_123",
        };

        Assert.Equal(expectedTrace, deserialized.Trace);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TraceDeleteResponse
        {
            Trace = new()
            {
                _ID = "trace_123",
                CreatedAt = DateTimeOffset.Parse("2025-01-10T12:35:10.000Z"),
                Data = new()
                {
                    FileName = "support_thread_TCK-1234.txt",
                    Query = "What did the customer ask about pricing for the Scale plan?",
                    Source = "support-inbox",
                },
                OrganizationID = "org_123",
                Type = "context.search",
                UpdatedAt = DateTimeOffset.Parse("2025-01-10T12:35:10.000Z"),
                UserID = "user_123",
            },
        };

        model.Validate();
    }
}

public class TraceDeleteResponseTraceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TraceDeleteResponseTrace
        {
            _ID = "trace_123",
            CreatedAt = DateTimeOffset.Parse("2025-01-10T12:35:10.000Z"),
            Data = new()
            {
                FileName = "support_thread_TCK-1234.txt",
                Query = "What did the customer ask about pricing for the Scale plan?",
                Source = "support-inbox",
            },
            OrganizationID = "org_123",
            Type = "context.search",
            UpdatedAt = DateTimeOffset.Parse("2025-01-10T12:35:10.000Z"),
            UserID = "user_123",
        };

        string expected_ID = "trace_123";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-10T12:35:10.000Z");
        Data expectedData = new()
        {
            FileName = "support_thread_TCK-1234.txt",
            Query = "What did the customer ask about pricing for the Scale plan?",
            Source = "support-inbox",
        };
        string expectedOrganizationID = "org_123";
        string expectedType = "context.search";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2025-01-10T12:35:10.000Z");
        string expectedUserID = "user_123";

        Assert.Equal(expected_ID, model._ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedOrganizationID, model.OrganizationID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUserID, model.UserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TraceDeleteResponseTrace
        {
            _ID = "trace_123",
            CreatedAt = DateTimeOffset.Parse("2025-01-10T12:35:10.000Z"),
            Data = new()
            {
                FileName = "support_thread_TCK-1234.txt",
                Query = "What did the customer ask about pricing for the Scale plan?",
                Source = "support-inbox",
            },
            OrganizationID = "org_123",
            Type = "context.search",
            UpdatedAt = DateTimeOffset.Parse("2025-01-10T12:35:10.000Z"),
            UserID = "user_123",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TraceDeleteResponseTrace>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TraceDeleteResponseTrace
        {
            _ID = "trace_123",
            CreatedAt = DateTimeOffset.Parse("2025-01-10T12:35:10.000Z"),
            Data = new()
            {
                FileName = "support_thread_TCK-1234.txt",
                Query = "What did the customer ask about pricing for the Scale plan?",
                Source = "support-inbox",
            },
            OrganizationID = "org_123",
            Type = "context.search",
            UpdatedAt = DateTimeOffset.Parse("2025-01-10T12:35:10.000Z"),
            UserID = "user_123",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TraceDeleteResponseTrace>(element);
        Assert.NotNull(deserialized);

        string expected_ID = "trace_123";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-10T12:35:10.000Z");
        Data expectedData = new()
        {
            FileName = "support_thread_TCK-1234.txt",
            Query = "What did the customer ask about pricing for the Scale plan?",
            Source = "support-inbox",
        };
        string expectedOrganizationID = "org_123";
        string expectedType = "context.search";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2025-01-10T12:35:10.000Z");
        string expectedUserID = "user_123";

        Assert.Equal(expected_ID, deserialized._ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedOrganizationID, deserialized.OrganizationID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUserID, deserialized.UserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TraceDeleteResponseTrace
        {
            _ID = "trace_123",
            CreatedAt = DateTimeOffset.Parse("2025-01-10T12:35:10.000Z"),
            Data = new()
            {
                FileName = "support_thread_TCK-1234.txt",
                Query = "What did the customer ask about pricing for the Scale plan?",
                Source = "support-inbox",
            },
            OrganizationID = "org_123",
            Type = "context.search",
            UpdatedAt = DateTimeOffset.Parse("2025-01-10T12:35:10.000Z"),
            UserID = "user_123",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TraceDeleteResponseTrace { };

        Assert.Null(model._ID);
        Assert.False(model.RawData.ContainsKey("_id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.OrganizationID);
        Assert.False(model.RawData.ContainsKey("organizationId"));
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
        var model = new TraceDeleteResponseTrace { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TraceDeleteResponseTrace
        {
            // Null should be interpreted as omitted for these properties
            _ID = null,
            CreatedAt = null,
            Data = null,
            OrganizationID = null,
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
        Assert.Null(model.OrganizationID);
        Assert.False(model.RawData.ContainsKey("organizationId"));
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
        var model = new TraceDeleteResponseTrace
        {
            // Null should be interpreted as omitted for these properties
            _ID = null,
            CreatedAt = null,
            Data = null,
            OrganizationID = null,
            Type = null,
            UpdatedAt = null,
            UserID = null,
        };

        model.Validate();
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            FileName = "support_thread_TCK-1234.txt",
            Query = "What did the customer ask about pricing for the Scale plan?",
            Source = "support-inbox",
        };

        string expectedFileName = "support_thread_TCK-1234.txt";
        string expectedQuery = "What did the customer ask about pricing for the Scale plan?";
        string expectedSource = "support-inbox";

        Assert.Equal(expectedFileName, model.FileName);
        Assert.Equal(expectedQuery, model.Query);
        Assert.Equal(expectedSource, model.Source);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            FileName = "support_thread_TCK-1234.txt",
            Query = "What did the customer ask about pricing for the Scale plan?",
            Source = "support-inbox",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Data>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data
        {
            FileName = "support_thread_TCK-1234.txt",
            Query = "What did the customer ask about pricing for the Scale plan?",
            Source = "support-inbox",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Data>(element);
        Assert.NotNull(deserialized);

        string expectedFileName = "support_thread_TCK-1234.txt";
        string expectedQuery = "What did the customer ask about pricing for the Scale plan?";
        string expectedSource = "support-inbox";

        Assert.Equal(expectedFileName, deserialized.FileName);
        Assert.Equal(expectedQuery, deserialized.Query);
        Assert.Equal(expectedSource, deserialized.Source);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            FileName = "support_thread_TCK-1234.txt",
            Query = "What did the customer ask about pricing for the Scale plan?",
            Source = "support-inbox",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data { };

        Assert.Null(model.FileName);
        Assert.False(model.RawData.ContainsKey("fileName"));
        Assert.Null(model.Query);
        Assert.False(model.RawData.ContainsKey("query"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Data { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Data
        {
            // Null should be interpreted as omitted for these properties
            FileName = null,
            Query = null,
            Source = null,
        };

        Assert.Null(model.FileName);
        Assert.False(model.RawData.ContainsKey("fileName"));
        Assert.Null(model.Query);
        Assert.False(model.RawData.ContainsKey("query"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            // Null should be interpreted as omitted for these properties
            FileName = null,
            Query = null,
            Source = null,
        };

        model.Validate();
    }
}
