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
/// This endpoint adds memory context data, fetching chat history if needed.
/// </summary>
public sealed record class MemoryAddParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Array of content objects with additional properties allowed
    /// </summary>
    public required IReadOnlyList<MemoryAddParamsContent> Contents
    {
        get
        {
            return JsonModel.GetNotNullClass<List<MemoryAddParamsContent>>(
                this.RawBodyData,
                "contents"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "contents", value); }
    }

    /// <summary>
    /// The ID of the memory
    /// </summary>
    public required string MemoryID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawBodyData, "memoryId"); }
        init { JsonModel.Set(this._rawBodyData, "memoryId", value); }
    }

    public MemoryAddParams() { }

    public MemoryAddParams(MemoryAddParams memoryAddParams)
        : base(memoryAddParams)
    {
        this._rawBodyData = [.. memoryAddParams._rawBodyData];
    }

    public MemoryAddParams(
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
    MemoryAddParams(
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

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static MemoryAddParams FromRawUnchecked(
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
            options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/context/memory/add"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData),
            Encoding.UTF8,
            "application/json"
        );
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

[JsonConverter(typeof(JsonModelConverter<MemoryAddParamsContent, MemoryAddParamsContentFromRaw>))]
public sealed record class MemoryAddParamsContent : JsonModel
{
    /// <summary>
    /// Unique message ID
    /// </summary>
    public string? ID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "id", value);
        }
    }

    /// <summary>
    /// The content of the memory message
    /// </summary>
    public string? Content
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "content"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "content", value);
        }
    }

    /// <summary>
    /// Creation timestamp
    /// </summary>
    public string? CreatedAt
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "createdAt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "createdAt", value);
        }
    }

    /// <summary>
    /// Additional metadata for the message
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Metadata
    {
        get
        {
            return JsonModel.GetNullableClass<Dictionary<string, JsonElement>>(
                this.RawData,
                "metadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "metadata", value);
        }
    }

    /// <summary>
    /// Role of the message sender (e.g., user, assistant)
    /// </summary>
    public string? Role
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "role"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "role", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Content;
        _ = this.CreatedAt;
        _ = this.Metadata;
        _ = this.Role;
    }

    public MemoryAddParamsContent() { }

    public MemoryAddParamsContent(MemoryAddParamsContent memoryAddParamsContent)
        : base(memoryAddParamsContent) { }

    public MemoryAddParamsContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MemoryAddParamsContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MemoryAddParamsContentFromRaw.FromRawUnchecked"/>
    public static MemoryAddParamsContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MemoryAddParamsContentFromRaw : IFromRawJson<MemoryAddParamsContent>
{
    /// <inheritdoc/>
    public MemoryAddParamsContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MemoryAddParamsContent.FromRawUnchecked(rawData);
}
