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
    public required IReadOnlyList<ViewRetrieveResponseContext> Contexts
    {
        get
        {
            return JsonModel.GetNotNullClass<List<ViewRetrieveResponseContext>>(
                this.RawData,
                "contexts"
            );
        }
        init { JsonModel.Set(this._rawData, "contexts", value); }
    }

    public required bool Success
    {
        get { return JsonModel.GetNotNullStruct<bool>(this.RawData, "success"); }
        init { JsonModel.Set(this._rawData, "success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Contexts)
        {
            item.Validate();
        }
        _ = this.Success;
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

[JsonConverter(
    typeof(JsonModelConverter<ViewRetrieveResponseContext, ViewRetrieveResponseContextFromRaw>)
)]
public sealed record class ViewRetrieveResponseContext : JsonModel
{
    /// <summary>
    /// The content of the context item
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
    /// Additional metadata for the context
    /// </summary>
    public global::Alchemystai.Models.V1.Context.View.Metadata? Metadata
    {
        get
        {
            return JsonModel.GetNullableClass<global::Alchemystai.Models.V1.Context.View.Metadata>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        this.Metadata?.Validate();
    }

    public ViewRetrieveResponseContext() { }

    public ViewRetrieveResponseContext(ViewRetrieveResponseContext viewRetrieveResponseContext)
        : base(viewRetrieveResponseContext) { }

    public ViewRetrieveResponseContext(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewRetrieveResponseContext(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewRetrieveResponseContextFromRaw.FromRawUnchecked"/>
    public static ViewRetrieveResponseContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewRetrieveResponseContextFromRaw : IFromRawJson<ViewRetrieveResponseContext>
{
    /// <inheritdoc/>
    public ViewRetrieveResponseContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ViewRetrieveResponseContext.FromRawUnchecked(rawData);
}

/// <summary>
/// Additional metadata for the context
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        global::Alchemystai.Models.V1.Context.View.Metadata,
        global::Alchemystai.Models.V1.Context.View.MetadataFromRaw
    >)
)]
public sealed record class Metadata : JsonModel
{
    public string? FileName
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "fileName"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "fileName", value);
        }
    }

    public double? FileSize
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "fileSize"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "fileSize", value);
        }
    }

    public string? FileType
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "fileType"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "fileType", value);
        }
    }

    public IReadOnlyList<string>? GroupName
    {
        get { return JsonModel.GetNullableClass<List<string>>(this.RawData, "groupName"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "groupName", value);
        }
    }

    public string? LastModified
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "lastModified"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "lastModified", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileName;
        _ = this.FileSize;
        _ = this.FileType;
        _ = this.GroupName;
        _ = this.LastModified;
    }

    public Metadata() { }

    public Metadata(global::Alchemystai.Models.V1.Context.View.Metadata metadata)
        : base(metadata) { }

    public Metadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Metadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Alchemystai.Models.V1.Context.View.MetadataFromRaw.FromRawUnchecked"/>
    public static global::Alchemystai.Models.V1.Context.View.Metadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MetadataFromRaw : IFromRawJson<global::Alchemystai.Models.V1.Context.View.Metadata>
{
    /// <inheritdoc/>
    public global::Alchemystai.Models.V1.Context.View.Metadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Alchemystai.Models.V1.Context.View.Metadata.FromRawUnchecked(rawData);
}
