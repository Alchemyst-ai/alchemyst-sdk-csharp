using System.Text.Json;
using Alchemystai.Core;
using Alchemystai.Exceptions;
using Alchemystai.Models.V1.Context;

namespace Alchemystai.Tests.Models.V1.Context;

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
