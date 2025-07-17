using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WebGemini.Interfaces;
using WebGemini.Models;

namespace WebGemini.Repositories
{
    public class GptRepository : IChatbotService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _url = "https://api.openai.com/v1/chat/completions";

        public GptRepository(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["OpenAI:ApiKey"];
        }

        public async Task<string> GetChatbotResponse(string prompt)
        {
            var request = new GptRequest
            {
                Model = "gpt-3.5-turbo",
                Messages = new List<GptMessage>
                {
                    new GptMessage
                    {
                        Role = "system",
                        Content = "Eres un asistente amigable que responde en español."
                    },
                    new GptMessage
                    {
                        Role = "user",
                        Content = prompt
                    }
                }
            };

            var json = JsonSerializer.Serialize(request);
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, _url)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            httpRequest.Headers.Add("Authorization", $"Bearer {_apiKey}");

            var response = await _httpClient.SendAsync(httpRequest);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var responseData = JsonSerializer.Deserialize<GptResponse>(responseString);

            return responseData?.Choices?[0]?.Message?.Content ?? "Sin respuesta de GPT.";
        }

        public Task<bool> SaveResponseInDataBase(string chatbotPrompt, string chatbotResponse)
        {
            throw new System.NotImplementedException();
        }
    }
}
