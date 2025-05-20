using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EdwinSaa_WorkshopConection_Gemini_ChatGPT_APIs_P2_P4.Interfaces;
using EdwinSaa_WorkshopConection_Gemini_ChatGPT_APIs_P2_P4.Models;

namespace EdwinSaa_WorkshopConection_Gemini_ChatGPT_APIs_P2_P4.Repositories
{
    public class OpenAlRepository : IChatbotService
    {
        public Task<string> GetChatbotResponse(string prompt)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveResponseInDataBase(string chatbotPrompt, string chatbotResponse)
        {
            throw new NotImplementedException();
        }
    }

}
