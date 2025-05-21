using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebGemini.Interfaces;
using WebGemini.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;


namespace EdwinSaa_WorkshopConection_Gemini_ChatGPT_APIs_P2_P4.Repositories
{
    public class GeminiRepository : IChatbotService
    {
        private readonly HttpClient _httpClient;
        private readonly string _systemContext = "You are a angry farmer. Always respond angry with a farmer cliche phrase. Do not  introduce yourself twice";// this line is the context an rules of our chatbot to determain his behaivour 
        private string geminiApiKey = "AIzaSyA56EjVz9H8q6FMntEnPZTLuAEPQ51N-Tk";//the API key is not shown for privacy purposes
        public GeminiRepository()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetChatbotResponse(string prompt)
        {
            // conbined prompt idea was suggested by copilot 
            string url = "https://generativelanguage.googleapis.com/v1beta/models/gemini-pro:generateContent?key=TU_API_KEY\r\n" + geminiApiKey;// url isn't shown for privacy purposes
            string combinedPrompt = $"{_systemContext}\n\nUser: {prompt}";// conbine user prompt and rules_context to change chatbot behaivour
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
                                text = combinedPrompt,

                            }
                        }
                    }
                }
            };

            string jsonRequest = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");//this content goes to the header

            var response = await _httpClient.PostAsync(url, content);//sent de url and the body content
            var answer = await response.Content.ReadAsStringAsync();
            // body answer string extract and shown 
            dynamic json = JsonConvert.DeserializeObject(answer);// convert the string to a json object
            string chatbotResponse = json?.candidates?[0]?.content?.parts?[0]?.text;// extract the text from the json object

            return chatbotResponse ?? "No response from chatbot.";
        }

        Task<bool> IChatbotService.SaveResponseInDataBase(string chatbotPrompt, string chatbotResponse)
        {
            throw new NotImplementedException();
        }
    }

}
