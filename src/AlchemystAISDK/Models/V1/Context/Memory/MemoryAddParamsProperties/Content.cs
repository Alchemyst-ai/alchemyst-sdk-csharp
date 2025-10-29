using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using AlchemystAISDK.Core;

namespace AlchemystAISDK.Models.V1.Context.Memory.MemoryAddParamsProperties;

[JsonConverter(typeof(ModelConverter<Content>))]
public sealed record class Content : ModelBase, IFromRaw<Content>
{
    public string? Content1
    {
        get
        {
            if (!this.Properties.TryGetValue("content", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Content1;
    }

    public Content() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Content(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Content FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
