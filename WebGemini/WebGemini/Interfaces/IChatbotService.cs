using System;
using System.Globalization;
using System.Threading.Tasks;

namespace WebGemini.Interfaces
{
    public interface IChatbotService
    {
        public Task<string> GetChatbotResponse(string prompt);
        public Task<Boolean> SaveResponseInDataBase(string chatbotPrompt, string chatbotResponse);
    }
}
