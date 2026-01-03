using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Alchemystai.Core;

namespace Alchemystai.Models.V1.Context.Memory;

[JsonConverter(typeof(JsonModelConverter<MemoryUpdateResponse, MemoryUpdateResponseFromRaw>))]
public sealed record class MemoryUpdateResponse : JsonModel
{
    public required string MemoryID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "memory_id"); }
        init { JsonModel.Set(this._rawData, "memory_id", value); }
    }

    public required bool Success
    {
        get { return JsonModel.GetNotNullStruct<bool>(this.RawData, "success"); }
        init { JsonModel.Set(this._rawData, "success", value); }
    }

    public required double UpdatedEntries
    {
        get { return JsonModel.GetNotNullStruct<double>(this.RawData, "updated_entries"); }
        init { JsonModel.Set(this._rawData, "updated_entries", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MemoryID;
        _ = this.Success;
        _ = this.UpdatedEntries;
    }

    public MemoryUpdateResponse() { }

    public MemoryUpdateResponse(MemoryUpdateResponse memoryUpdateResponse)
        : base(memoryUpdateResponse) { }

    public MemoryUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MemoryUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MemoryUpdateResponseFromRaw.FromRawUnchecked"/>
    public static MemoryUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MemoryUpdateResponseFromRaw : IFromRawJson<MemoryUpdateResponse>
{
    /// <inheritdoc/>
    public MemoryUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MemoryUpdateResponse.FromRawUnchecked(rawData);
}
