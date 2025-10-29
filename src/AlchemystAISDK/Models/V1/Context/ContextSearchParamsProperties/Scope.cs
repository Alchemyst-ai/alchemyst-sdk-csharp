using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using AlchemystAISDK.Exceptions;

namespace AlchemystAISDK.Models.V1.Context.ContextSearchParamsProperties;

/// <summary>
/// Search scope
/// </summary>
[JsonConverter(typeof(ScopeConverter))]
public enum Scope
{
    Internal,
    External,
}

sealed class ScopeConverter : JsonConverter<Scope>
{
    public override Scope Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "internal" => Scope.Internal,
            "external" => Scope.External,
            _ => (Scope)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Scope value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Scope.Internal => "internal",
                Scope.External => "external",
                _ => throw new AlchemystAIInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
