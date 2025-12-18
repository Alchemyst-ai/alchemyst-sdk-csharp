using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Alchemystai.Core;

namespace Alchemystai.Models.V1.Context.View;

[JsonConverter(typeof(JsonModelConverter<ViewRetrieveResponse, ViewRetrieveResponseFromRaw>))]
public sealed record class ViewRetrieveResponse : JsonModel
{
    /// <summary>
    /// List of context items
    /// </summary>
    public IReadOnlyList<JsonElement>? Context
    {
        get { return JsonModel.GetNullableClass<List<JsonElement>>(this.RawData, "context"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "context", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Context;
    }

    public ViewRetrieveResponse() { }

    public ViewRetrieveResponse(ViewRetrieveResponse viewRetrieveResponse)
        : base(viewRetrieveResponse) { }

    public ViewRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ViewRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewRetrieveResponseFromRaw : IFromRawJson<ViewRetrieveResponse>
{
    /// <inheritdoc/>
    public ViewRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ViewRetrieveResponse.FromRawUnchecked(rawData);
}
