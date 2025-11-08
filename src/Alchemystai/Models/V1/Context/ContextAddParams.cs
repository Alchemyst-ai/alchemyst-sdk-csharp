using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Alchemystai.Core;
using Alchemystai.Exceptions;
using System = System;

namespace Alchemystai.Models.V1.Context;

/// <summary>
/// This endpoint accepts context data and sends it to a context processor for further
/// handling. It returns a success or error response depending on the result from
/// the context processor.
/// </summary>
public sealed record class ContextAddParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _bodyProperties = [];
    public IReadOnlyDictionary<string, JsonElement> BodyProperties
    {
        get { return this._bodyProperties.Freeze(); }
    }

    /// <summary>
    /// Type of context being added
    /// </summary>
    public ApiEnum<string, ContextType>? ContextType
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("context_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, ContextType>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._bodyProperties["context_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Array of documents with content and additional metadata
    /// </summary>
    public List<Document>? Documents
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("documents", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Document>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._bodyProperties["documents"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Additional metadata for the context
    /// </summary>
    public Metadata? Metadata
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Metadata?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._bodyProperties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Scope of the context
    /// </summary>
    public ApiEnum<string, Scope>? Scope
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("scope", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Scope>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._bodyProperties["scope"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The source of the context data
    /// </summary>
    public string? Source
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("source", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._bodyProperties["source"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ContextAddParams() { }

    public ContextAddParams(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContextAddParams(
        FrozenDictionary<string, JsonElement> headerProperties,
        FrozenDictionary<string, JsonElement> queryProperties,
        FrozenDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }
#pragma warning restore CS8618

    public static ContextAddParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(headerProperties),
            FrozenDictionary.ToFrozenDictionary(queryProperties),
            FrozenDictionary.ToFrozenDictionary(bodyProperties)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/context/add"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.HeaderProperties)
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
        System::Type typeToConvert,
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

[JsonConverter(typeof(ModelConverter<Document>))]
public sealed record class Document : ModelBase, IFromRaw<Document>
{
    /// <summary>
    /// The content of the document
    /// </summary>
    public string? Content
    {
        get
        {
            if (!this._properties.TryGetValue("content", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Content;
    }

    public Document() { }

    public Document(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Document(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Document FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Additional metadata for the context
/// </summary>
[JsonConverter(typeof(ModelConverter<Metadata>))]
public sealed record class Metadata : ModelBase, IFromRaw<Metadata>
{
    /// <summary>
    /// Name of the file
    /// </summary>
    public string? FileName
    {
        get
        {
            if (!this._properties.TryGetValue("fileName", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["fileName"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Size of the file in bytes
    /// </summary>
    public double? FileSize
    {
        get
        {
            if (!this._properties.TryGetValue("fileSize", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["fileSize"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Type/MIME of the file
    /// </summary>
    public string? FileType
    {
        get
        {
            if (!this._properties.TryGetValue("fileType", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["fileType"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Array of Group Name to which the file belongs to
    /// </summary>
    public List<string>? GroupName
    {
        get
        {
            if (!this._properties.TryGetValue("groupName", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["groupName"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Last modified timestamp
    /// </summary>
    public string? LastModified
    {
        get
        {
            if (!this._properties.TryGetValue("lastModified", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["lastModified"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.FileName;
        _ = this.FileSize;
        _ = this.FileType;
        _ = this.GroupName;
        _ = this.LastModified;
    }

    public Metadata() { }

    public Metadata(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Metadata(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Metadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
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
        System::Type typeToConvert,
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
