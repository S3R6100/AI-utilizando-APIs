using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EdwinSaa_WorkshopConection_Gemini_ChatGPT_APIs_P2_P4.Interfaces;
using EdwinSaa_WorkshopConection_Gemini_ChatGPT_APIs_P2_P4.Models;
using Newtonsoft.Json;

namespace EdwinSaa_WorkshopConection_Gemini_ChatGPT_APIs_P2_P4.Repositories
{
    public class GeminiRepository : IChatbotService
    {
        private HttpClient _httpClient;
        private string geminiApiKey = "";
        public GeminiRepository()   
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetChatbotResponse(string prompt)
        {
            string url = ""+geminiApiKey;
            GeminiRequest request = new GeminiRequest
            {
                contents = new List<GeminiContent>
                {
                    new GeminiContent
                    {
                        parts = new List<GeminiPart>

                        {
                            new GeminiPart
                            {
                                text = prompt,

                            }
                        }
                    }
                }
            };

            string jsonRequest = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonRequest, Encoding.UTF8,"application/json");//this content goes to the header

            var response = await _httpClient.PostAsync(url, content);//sent de url and the body content
            var answer = await response.Content.ReadAsStringAsync();

            return answer;

        }

        Task<bool> IChatbotService.SaveResponseInDataBase(string chatbotPrompt, string chatbotResponse)
        {
            throw new NotImplementedException();
        }
    }
 
}
