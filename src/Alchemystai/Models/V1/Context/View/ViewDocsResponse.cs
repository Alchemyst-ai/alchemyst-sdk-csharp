using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Alchemystai.Core;

namespace Alchemystai.Models.V1.Context.View;

[JsonConverter(typeof(JsonModelConverter<ViewDocsResponse, ViewDocsResponseFromRaw>))]
public sealed record class ViewDocsResponse : JsonModel
{
    public required IReadOnlyList<global::Alchemystai.Models.V1.Context.View.Document> Documents
    {
        get
        {
            return JsonModel.GetNotNullClass<
                List<global::Alchemystai.Models.V1.Context.View.Document>
            >(this.RawData, "documents");
        }
        init { JsonModel.Set(this._rawData, "documents", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Documents)
        {
            item.Validate();
        }
    }

    public ViewDocsResponse() { }

    public ViewDocsResponse(ViewDocsResponse viewDocsResponse)
        : base(viewDocsResponse) { }

    public ViewDocsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewDocsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewDocsResponseFromRaw.FromRawUnchecked"/>
    public static ViewDocsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ViewDocsResponse(List<global::Alchemystai.Models.V1.Context.View.Document> documents)
        : this()
    {
        this.Documents = documents;
    }
}

class ViewDocsResponseFromRaw : IFromRawJson<ViewDocsResponse>
{
    /// <inheritdoc/>
    public ViewDocsResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ViewDocsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        global::Alchemystai.Models.V1.Context.View.Document,
        global::Alchemystai.Models.V1.Context.View.DocumentFromRaw
    >)
)]
public sealed record class Document : JsonModel
{
    /// <summary>
    /// Name of the file
    /// </summary>
    public required string FileName
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "fileName"); }
        init { JsonModel.Set(this._rawData, "fileName", value); }
    }

    /// <summary>
    /// Size of the file in bytes
    /// </summary>
    public required double FileSize
    {
        get { return JsonModel.GetNotNullStruct<double>(this.RawData, "fileSize"); }
        init { JsonModel.Set(this._rawData, "fileSize", value); }
    }

    /// <summary>
    /// Type/MIME of the file
    /// </summary>
    public required string FileType
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "fileType"); }
        init { JsonModel.Set(this._rawData, "fileType", value); }
    }

    /// <summary>
    /// Array of group names to which the file belongs
    /// </summary>
    public required IReadOnlyList<string> GroupName
    {
        get { return JsonModel.GetNotNullClass<List<string>>(this.RawData, "groupName"); }
        init { JsonModel.Set(this._rawData, "groupName", value); }
    }

    /// <summary>
    /// Last modified timestamp (ISO format)
    /// </summary>
    public required string LastModified
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "lastModified"); }
        init { JsonModel.Set(this._rawData, "lastModified", value); }
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

    public Document() { }

    public Document(global::Alchemystai.Models.V1.Context.View.Document document)
        : base(document) { }

    public Document(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Document(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Alchemystai.Models.V1.Context.View.DocumentFromRaw.FromRawUnchecked"/>
    public static global::Alchemystai.Models.V1.Context.View.Document FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DocumentFromRaw : IFromRawJson<global::Alchemystai.Models.V1.Context.View.Document>
{
    /// <inheritdoc/>
    public global::Alchemystai.Models.V1.Context.View.Document FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Alchemystai.Models.V1.Context.View.Document.FromRawUnchecked(rawData);
}
