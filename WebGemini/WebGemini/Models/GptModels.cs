using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebGemini.Models
{
    public class GptRequest
    {
        [JsonPropertyName("model")]
        public string Model { get; set; } = "gpt-3.5-turbo";

        [JsonPropertyName("messages")]
        public List<GptMessage>? Messages { get; set; }
    }

    public class GptMessage
    {
        [JsonPropertyName("role")]
        public string? Role { get; set; }

        [JsonPropertyName("content")]
        public string? Content { get; set; }
    }

    public class GptResponse
    {
        [JsonPropertyName("choices")]
        public List<GptChoice>? Choices { get; set; }
    }

    public class GptChoice
    {
        [JsonPropertyName("message")]
        public GptMessage? Message { get; set; }
    }
}
