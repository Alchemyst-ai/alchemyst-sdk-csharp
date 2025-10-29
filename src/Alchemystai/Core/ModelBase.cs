using System.Collections.Generic;
using System.Text.Json;
using Alchemystai.Models.V1.Context.ContextAddParamsProperties;
using ContextSearchParamsProperties = Alchemystai.Models.V1.Context.ContextSearchParamsProperties;

namespace Alchemystai.Core;

public abstract record class ModelBase
{
    public Dictionary<string, JsonElement> Properties { get; set; } = [];

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, ContextType>(),
            new ApiEnumConverter<string, Scope>(),
            new ApiEnumConverter<string, ContextSearchParamsProperties::Scope>(),
        },
    };

    static readonly JsonSerializerOptions _toStringSerializerOptions = new(SerializerOptions)
    {
        WriteIndented = true,
    };

    public sealed override string? ToString()
    {
        return JsonSerializer.Serialize(this.Properties, _toStringSerializerOptions);
    }

    public abstract void Validate();
}

interface IFromRaw<T>
{
    static abstract T FromRawUnchecked(Dictionary<string, JsonElement> properties);
}
