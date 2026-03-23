using System.Text.Json.Serialization;

namespace Portifolio.Models;

public record ChatRequest(
    [property: JsonPropertyName("message")] string Message
);

public record GroqResponse(
    [property: JsonPropertyName("choices")] GroqChoice[] Choices
);

public record GroqChoice(
    [property: JsonPropertyName("message")] GroqMessage Message
);

public record GroqMessage(
    [property: JsonPropertyName("content")] string Content
);