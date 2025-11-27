using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Alchemystai.Core;

namespace Alchemystai.Models.V1.Context.Memory;

/// <summary>
/// This endpoint updates memory context data.
/// </summary>
public sealed record class MemoryUpdateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Array of updated content objects
    /// </summary>
    public IReadOnlyList<Content>? Contents
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("contents", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Content>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["contents"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The ID of the memory to update
    /// </summary>
    public string? MemoryID
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("memoryId", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["memoryId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public MemoryUpdateParams() { }

    public MemoryUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MemoryUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    public static MemoryUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/context/memory/update"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

[JsonConverter(typeof(ModelConverter<Content, ContentFromRaw>))]
public sealed record class Content : ModelBase
{
    public string? Content1
    {
        get
        {
            if (!this._rawData.TryGetValue("content", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Content1;
    }

    public Content() { }

    public Content(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Content(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Content FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContentFromRaw : IFromRaw<Content>
{
    public Content FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Content.FromRawUnchecked(rawData);
}
