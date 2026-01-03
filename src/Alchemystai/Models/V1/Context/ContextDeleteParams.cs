using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Alchemystai.Core;

namespace Alchemystai.Models.V1.Context;

/// <summary>
/// This endpoint deletes context data based on the provided parameters. It returns
/// a success or error response depending on the result from the context processor.
/// </summary>
public sealed record class ContextDeleteParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Organization ID
    /// </summary>
    public required string OrganizationID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawBodyData, "organization_id"); }
        init { JsonModel.Set(this._rawBodyData, "organization_id", value); }
    }

    /// <summary>
    /// Source identifier for the context
    /// </summary>
    public required string Source
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawBodyData, "source"); }
        init { JsonModel.Set(this._rawBodyData, "source", value); }
    }

    /// <summary>
    /// Flag to delete by document
    /// </summary>
    public bool? ByDoc
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawBodyData, "by_doc"); }
        init { JsonModel.Set(this._rawBodyData, "by_doc", value); }
    }

    /// <summary>
    /// Flag to delete by ID
    /// </summary>
    public bool? ByID
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawBodyData, "by_id"); }
        init { JsonModel.Set(this._rawBodyData, "by_id", value); }
    }

    /// <summary>
    /// Optional user ID
    /// </summary>
    [Obsolete("deprecated")]
    public string? UserID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "user_id"); }
        init { JsonModel.Set(this._rawBodyData, "user_id", value); }
    }

    public ContextDeleteParams() { }

    public ContextDeleteParams(ContextDeleteParams contextDeleteParams)
        : base(contextDeleteParams)
    {
        this._rawBodyData = [.. contextDeleteParams._rawBodyData];
    }

    public ContextDeleteParams(
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
    ContextDeleteParams(
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
    public static ContextDeleteParams FromRawUnchecked(
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/context/delete")
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
