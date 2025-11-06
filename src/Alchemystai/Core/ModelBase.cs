using System.Collections.Generic;
using System.Text.Json;
using Alchemystai.Models.V1.Context;

namespace Alchemystai.Core;

public abstract record class ModelBase
{
    private protected FreezableDictionary<string, JsonElement> _properties = [];

    public IReadOnlyDictionary<string, JsonElement> Properties
    {
        get { return this._properties.Freeze(); }
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, ContextType>(),
            new ApiEnumConverter<string, Scope>(),
            new ApiEnumConverter<string, ScopeModel>(),
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
    static abstract T FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties);
}
