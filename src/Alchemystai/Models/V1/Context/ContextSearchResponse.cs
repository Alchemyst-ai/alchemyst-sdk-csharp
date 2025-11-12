using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Alchemystai.Core;

namespace Alchemystai.Models.V1.Context;

[JsonConverter(typeof(ModelConverter<ContextSearchResponse>))]
public sealed record class ContextSearchResponse : ModelBase, IFromRaw<ContextSearchResponse>
{
    public List<ContextModel>? Contexts
    {
        get
        {
            if (!this._properties.TryGetValue("contexts", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ContextModel>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["contexts"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Contexts ?? [])
        {
            item.Validate();
        }
    }

    public ContextSearchResponse() { }

    public ContextSearchResponse(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContextSearchResponse(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ContextSearchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(ModelConverter<ContextModel>))]
public sealed record class ContextModel : ModelBase, IFromRaw<ContextModel>
{
    public string? Content
    {
        get
        {
            if (!this._properties.TryGetValue("content", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public DateTimeOffset? CreatedAt
    {
        get
        {
            if (!this._properties.TryGetValue("createdAt", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["createdAt"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<JsonElement?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public double? Score
    {
        get
        {
            if (!this._properties.TryGetValue("score", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["score"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            if (!this._properties.TryGetValue("updatedAt", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["updatedAt"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Content;
        _ = this.CreatedAt;
        _ = this.Metadata;
        _ = this.Score;
        _ = this.UpdatedAt;
    }

    public ContextModel() { }

    public ContextModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContextModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ContextModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
