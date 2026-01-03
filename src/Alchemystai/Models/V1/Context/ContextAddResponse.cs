using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Alchemystai.Core;

namespace Alchemystai.Models.V1.Context;

[JsonConverter(typeof(JsonModelConverter<ContextAddResponse, ContextAddResponseFromRaw>))]
public sealed record class ContextAddResponse : JsonModel
{
    public required string ContextID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "context_id"); }
        init { JsonModel.Set(this._rawData, "context_id", value); }
    }

    public required bool Success
    {
        get { return JsonModel.GetNotNullStruct<bool>(this.RawData, "success"); }
        init { JsonModel.Set(this._rawData, "success", value); }
    }

    public double? ProcessedDocuments
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "processed_documents"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "processed_documents", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ContextID;
        _ = this.Success;
        _ = this.ProcessedDocuments;
    }

    public ContextAddResponse() { }

    public ContextAddResponse(ContextAddResponse contextAddResponse)
        : base(contextAddResponse) { }

    public ContextAddResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContextAddResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContextAddResponseFromRaw.FromRawUnchecked"/>
    public static ContextAddResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContextAddResponseFromRaw : IFromRawJson<ContextAddResponse>
{
    /// <inheritdoc/>
    public ContextAddResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ContextAddResponse.FromRawUnchecked(rawData);
}
