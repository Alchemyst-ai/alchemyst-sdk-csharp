using System.Text.Json;
using Alchemystai.Core;
using Alchemystai.Exceptions;
using Alchemystai.Models.V1.Context;

namespace Alchemystai.Tests.Models.V1.Context;

public class ContextSearchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ContextSearchParams
        {
            MinimumSimilarityThreshold = 0.5,
            Query = "What did the customer ask about pricing for the Scale plan?",
            SimilarityThreshold = 0.8,
            Metadata = ContextSearchParamsMetadata.True,
            Mode = Mode.Fast,
            MetadataValue = JsonSerializer.Deserialize<JsonElement>("{}"),
            Scope = ContextSearchParamsScope.Internal,
            UserID = "user123",
        };

        double expectedMinimumSimilarityThreshold = 0.5;
        string expectedQuery = "What did the customer ask about pricing for the Scale plan?";
        double expectedSimilarityThreshold = 0.8;
        ApiEnum<string, ContextSearchParamsMetadata> expectedMetadata =
            ContextSearchParamsMetadata.True;
        ApiEnum<string, Mode> expectedMode = Mode.Fast;
        JsonElement expectedMetadataValue = JsonSerializer.Deserialize<JsonElement>("{}");
        ApiEnum<string, ContextSearchParamsScope> expectedScope = ContextSearchParamsScope.Internal;
        string expectedUserID = "user123";

        Assert.Equal(expectedMinimumSimilarityThreshold, parameters.MinimumSimilarityThreshold);
        Assert.Equal(expectedQuery, parameters.Query);
        Assert.Equal(expectedSimilarityThreshold, parameters.SimilarityThreshold);
        Assert.Equal(expectedMetadata, parameters.Metadata);
        Assert.Equal(expectedMode, parameters.Mode);
        Assert.NotNull(parameters.MetadataValue);
        Assert.True(JsonElement.DeepEquals(expectedMetadataValue, parameters.MetadataValue.Value));
        Assert.Equal(expectedScope, parameters.Scope);
        Assert.Equal(expectedUserID, parameters.UserID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ContextSearchParams
        {
            MinimumSimilarityThreshold = 0.5,
            Query = "What did the customer ask about pricing for the Scale plan?",
            SimilarityThreshold = 0.8,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawQueryData.ContainsKey("metadata"));
        Assert.Null(parameters.Mode);
        Assert.False(parameters.RawQueryData.ContainsKey("mode"));
        Assert.Null(parameters.MetadataValue);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Scope);
        Assert.False(parameters.RawBodyData.ContainsKey("scope"));
        Assert.Null(parameters.UserID);
        Assert.False(parameters.RawBodyData.ContainsKey("user_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ContextSearchParams
        {
            MinimumSimilarityThreshold = 0.5,
            Query = "What did the customer ask about pricing for the Scale plan?",
            SimilarityThreshold = 0.8,

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            Mode = null,
            MetadataValue = null,
            Scope = null,
            UserID = null,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawQueryData.ContainsKey("metadata"));
        Assert.Null(parameters.Mode);
        Assert.False(parameters.RawQueryData.ContainsKey("mode"));
        Assert.Null(parameters.MetadataValue);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Scope);
        Assert.False(parameters.RawBodyData.ContainsKey("scope"));
        Assert.Null(parameters.UserID);
        Assert.False(parameters.RawBodyData.ContainsKey("user_id"));
    }
}

public class ContextSearchParamsMetadataTest : TestBase
{
    [Theory]
    [InlineData(ContextSearchParamsMetadata.True)]
    [InlineData(ContextSearchParamsMetadata.False)]
    public void Validation_Works(ContextSearchParamsMetadata rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContextSearchParamsMetadata> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ContextSearchParamsMetadata>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AlchemystAIInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ContextSearchParamsMetadata.True)]
    [InlineData(ContextSearchParamsMetadata.False)]
    public void SerializationRoundtrip_Works(ContextSearchParamsMetadata rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContextSearchParamsMetadata> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ContextSearchParamsMetadata>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ContextSearchParamsMetadata>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ContextSearchParamsMetadata>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ModeTest : TestBase
{
    [Theory]
    [InlineData(Mode.Fast)]
    [InlineData(Mode.Standard)]
    public void Validation_Works(Mode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Mode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AlchemystAIInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Mode.Fast)]
    [InlineData(Mode.Standard)]
    public void SerializationRoundtrip_Works(Mode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Mode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ContextSearchParamsScopeTest : TestBase
{
    [Theory]
    [InlineData(ContextSearchParamsScope.Internal)]
    [InlineData(ContextSearchParamsScope.External)]
    public void Validation_Works(ContextSearchParamsScope rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContextSearchParamsScope> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ContextSearchParamsScope>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AlchemystAIInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ContextSearchParamsScope.Internal)]
    [InlineData(ContextSearchParamsScope.External)]
    public void SerializationRoundtrip_Works(ContextSearchParamsScope rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContextSearchParamsScope> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ContextSearchParamsScope>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ContextSearchParamsScope>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ContextSearchParamsScope>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
