using Microsoft.AspNetCore.Mvc;
using Portifolio.Models;
using System.Text;
using System.Text.Json;

namespace Portifolio.Controllers;

public class IaController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _config;

    public IaController(IHttpClientFactory httpClientFactory, IConfiguration config)
    {
        _httpClientFactory = httpClientFactory;
        _config = config;
    }

    public IActionResult Index() => View();

    [HttpPost]
    public async Task<IActionResult> Chat([FromBody] ChatRequest body)
    {
        if (string.IsNullOrWhiteSpace(body?.Message))
            return BadRequest(new { error = "Mensagem vazia" });

        var groqApiKey = _config["GROQ_API_KEY"];
        if (string.IsNullOrEmpty(groqApiKey))
            return StatusCode(500, new { error = "GROQ_API_KEY não configurada." });

        var groqPayload = new
        {
            model = "llama-3.1-8b-instant",
            messages = new[]
            {
                new { role = "system", content = "Você é uma inteligência artificial geral, capaz de ajudar em qualquer assunto." },
                new { role = "user",   content = body.Message }
            },
            temperature = 0.7
        };

        var json = new StringContent(
            JsonSerializer.Serialize(groqPayload),
            Encoding.UTF8,
            "application/json"
        );

        try
        {
            var client = _httpClientFactory.CreateClient("groq");
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", groqApiKey);

            var response  = await client.PostAsync("openai/v1/chat/completions", json);
            var rawBody   = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"GROQ RESPONSE: {rawBody}");

            var groqData = JsonSerializer.Deserialize<GroqResponse>(rawBody,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (groqData?.Choices is null || groqData.Choices.Length == 0)
                return StatusCode(500, new { error = "Erro ao gerar resposta da IA." });

            return Ok(new { reply = groqData.Choices[0].Message.Content });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex);
            return StatusCode(500, new { error = "Erro interno do servidor." });
        }
    }
}