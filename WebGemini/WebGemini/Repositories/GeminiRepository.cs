using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WebGemini.Interfaces;
using WebGemini.Models;

namespace WebGemini.Repositories
{
    public class GeminiRepository : IChatbotService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _url = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent";

        private readonly string _systemContext = "You are a friendly assistant. Always respond politely and helpfully. You can speak Spanish.";

        public GeminiRepository(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["Gemini:ApiKey"];
        }

        public async Task<string> GetChatbotResponse(string prompt)
        {
            var fullPrompt = $"{_systemContext}\n\nUser: {prompt}";

            var request = new GeminiRequest
            {
                Contents = new List<GeminiContent>
                {
                    new GeminiContent
                    {
                        Parts = new List<GeminiPart>
                        {
                            new GeminiPart { Text = fullPrompt }
                        }
                    }
                }
            };

            var json = JsonSerializer.Serialize(request);
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, _url)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            httpRequest.Headers.Add("X-goog-api-key", _apiKey);

            var response = await _httpClient.SendAsync(httpRequest);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<GeminiResponse>(jsonResponse);

            return data?.Candidates?[0]?.Content?.Parts?[0]?.Text ?? "No response from Gemini.";
        }

        public Task<bool> SaveResponseInDataBase(string chatbotPrompt, string chatbotResponse)
        {
            throw new System.NotImplementedException();
        }
    }
}
