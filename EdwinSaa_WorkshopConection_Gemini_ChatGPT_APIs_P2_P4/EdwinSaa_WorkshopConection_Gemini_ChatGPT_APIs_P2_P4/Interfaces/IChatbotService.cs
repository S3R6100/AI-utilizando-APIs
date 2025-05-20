using System;
using System.Globalization;
using System.Threading.Tasks;

namespace EdwinSaa_WorkshopConection_Gemini_ChatGPT_APIs_P2_P4.Interfaces
{
    public interface IChatbotService
    {
        public Task<string> GetChatbotResponse (string prompt);
        public Task<Boolean> SaveResponseInDataBase(string chatbotPrompt, string chatbotResponse);
    }
}
