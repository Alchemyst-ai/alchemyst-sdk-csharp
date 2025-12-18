using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Alchemystai.Core;
using Alchemystai.Exceptions;

namespace Alchemystai.Models.V1.Context;

/// <summary>
/// This endpoint accepts context data and sends it to a context processor for further
/// handling. It returns a success or error response depending on the result from
/// the context processor.
/// </summary>
public sealed record class ContextAddParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Type of context being added
    /// </summary>
    public ApiEnum<string, ContextType>? ContextType
    {
        get
        {
            return JsonModel.GetNullableClass<ApiEnum<string, ContextType>>(
                this.RawBodyData,
                "context_type"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "context_type", value);
        }
    }

    /// <summary>
    /// Array of documents with content and additional metadata
    /// </summary>
    public IReadOnlyList<Document>? Documents
    {
        get { return JsonModel.GetNullableClass<List<Document>>(this.RawBodyData, "documents"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "documents", value);
        }
    }

    /// <summary>
    /// Additional metadata for the context
    /// </summary>
    public Metadata? Metadata
    {
        get { return JsonModel.GetNullableClass<Metadata>(this.RawBodyData, "metadata"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "metadata", value);
        }
    }

    /// <summary>
    /// Scope of the context
    /// </summary>
    public ApiEnum<string, Scope>? Scope
    {
        get
        {
            return JsonModel.GetNullableClass<ApiEnum<string, Scope>>(this.RawBodyData, "scope");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "scope", value);
        }
    }

    /// <summary>
    /// The source of the context data
    /// </summary>
    public string? Source
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "source"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "source", value);
        }
    }

    public ContextAddParams() { }

    public ContextAddParams(ContextAddParams contextAddParams)
        : base(contextAddParams)
    {
        this._rawBodyData = [.. contextAddParams._rawBodyData];
    }

    public ContextAddParams(
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
    ContextAddParams(
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
    public static ContextAddParams FromRawUnchecked(
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/context/add")
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

/// <summary>
/// Type of context being added
/// </summary>
[JsonConverter(typeof(ContextTypeConverter))]
public enum ContextType
{
    Resource,
    Conversation,
    Instruction,
}

sealed class ContextTypeConverter : JsonConverter<ContextType>
{
    public override ContextType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "resource" => ContextType.Resource,
            "conversation" => ContextType.Conversation,
            "instruction" => ContextType.Instruction,
            _ => (ContextType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContextType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ContextType.Resource => "resource",
                ContextType.Conversation => "conversation",
                ContextType.Instruction => "instruction",
                _ => throw new AlchemystAIInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Document, DocumentFromRaw>))]
public sealed record class Document : JsonModel
{
    /// <summary>
    /// The content of the document
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
    }

    public Document() { }

    public Document(Document document)
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

    /// <inheritdoc cref="DocumentFromRaw.FromRawUnchecked"/>
    public static Document FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DocumentFromRaw : IFromRawJson<Document>
{
    /// <inheritdoc/>
    public Document FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Document.FromRawUnchecked(rawData);
}

/// <summary>
/// Additional metadata for the context
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Metadata, MetadataFromRaw>))]
public sealed record class Metadata : JsonModel
{
    /// <summary>
    /// Name of the file
    /// </summary>
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

    /// <summary>
    /// Size of the file in bytes
    /// </summary>
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

    /// <summary>
    /// Type/MIME of the file
    /// </summary>
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

    /// <summary>
    /// Array of Group Name to which the file belongs to
    /// </summary>
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

    /// <summary>
    /// Last modified timestamp
    /// </summary>
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

    public Metadata(Metadata metadata)
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

    /// <inheritdoc cref="MetadataFromRaw.FromRawUnchecked"/>
    public static Metadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MetadataFromRaw : IFromRawJson<Metadata>
{
    /// <inheritdoc/>
    public Metadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Metadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Scope of the context
/// </summary>
[JsonConverter(typeof(ScopeConverter))]
public enum Scope
{
    Internal,
    External,
}

sealed class ScopeConverter : JsonConverter<Scope>
{
    public override Scope Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "internal" => Scope.Internal,
            "external" => Scope.External,
            _ => (Scope)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Scope value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Scope.Internal => "internal",
                Scope.External => "external",
                _ => throw new AlchemystAIInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
