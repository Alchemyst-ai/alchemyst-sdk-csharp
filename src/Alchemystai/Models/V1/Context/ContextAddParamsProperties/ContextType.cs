using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Alchemystai.Exceptions;

namespace Alchemystai.Models.V1.Context.ContextAddParamsProperties;

/// <summary>
/// Type of context being added
/// </summary>
[JsonConverter(typeof(ContextTypeConverter))]
public enum ContextType
{
    Resource,
    Conversation,
    Instruction,
}

sealed class ContextTypeConverter : JsonConverter<ContextType>
{
    public override ContextType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "resource" => ContextType.Resource,
            "conversation" => ContextType.Conversation,
            "instruction" => ContextType.Instruction,
            _ => (ContextType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContextType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ContextType.Resource => "resource",
                ContextType.Conversation => "conversation",
                ContextType.Instruction => "instruction",
                _ => throw new AlchemystAIInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
