using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Alchemystai.Core;

namespace Alchemystai.Models.V1.Context.Memory;

[JsonConverter(typeof(JsonModelConverter<MemoryAddResponse, MemoryAddResponseFromRaw>))]
public sealed record class MemoryAddResponse : JsonModel
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

    public MemoryAddResponse() { }

    public MemoryAddResponse(MemoryAddResponse memoryAddResponse)
        : base(memoryAddResponse) { }

    public MemoryAddResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MemoryAddResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MemoryAddResponseFromRaw.FromRawUnchecked"/>
    public static MemoryAddResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MemoryAddResponseFromRaw : IFromRawJson<MemoryAddResponse>
{
    /// <inheritdoc/>
    public MemoryAddResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MemoryAddResponse.FromRawUnchecked(rawData);
}
