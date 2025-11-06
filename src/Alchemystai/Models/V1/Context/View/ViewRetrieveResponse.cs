using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Alchemystai.Core;

namespace Alchemystai.Models.V1.Context.View;

[JsonConverter(typeof(ModelConverter<ViewRetrieveResponse>))]
public sealed record class ViewRetrieveResponse : ModelBase, IFromRaw<ViewRetrieveResponse>
{
    /// <summary>
    /// List of context items
    /// </summary>
    public List<JsonElement>? Context
    {
        get
        {
            if (!this._properties.TryGetValue("context", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["context"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Context;
    }

    public ViewRetrieveResponse() { }

    public ViewRetrieveResponse(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewRetrieveResponse(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ViewRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
