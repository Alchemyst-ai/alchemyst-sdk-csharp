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
/// Deletes context data based on provided parameters
/// </summary>
public sealed record class ContextDeleteParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Flag to delete by document
    /// </summary>
    public bool? ByDoc
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "by_doc"); }
        init { ModelBase.Set(this._rawBodyData, "by_doc", value); }
    }

    /// <summary>
    /// Flag to delete by ID
    /// </summary>
    public bool? ByID
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "by_id"); }
        init { ModelBase.Set(this._rawBodyData, "by_id", value); }
    }

    /// <summary>
    /// Optional organization ID
    /// </summary>
    public string? OrganizationID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "organization_id"); }
        init { ModelBase.Set(this._rawBodyData, "organization_id", value); }
    }

    /// <summary>
    /// Source identifier for the context
    /// </summary>
    public string? Source
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "source"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "source", value);
        }
    }

    /// <summary>
    /// Optional user ID
    /// </summary>
    [Obsolete("deprecated")]
    public string? UserID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "user_id"); }
        init { ModelBase.Set(this._rawBodyData, "user_id", value); }
    }

    public ContextDeleteParams() { }

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

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
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
