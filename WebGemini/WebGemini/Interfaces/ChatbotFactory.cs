using EdwinSaa_WorkshopConection_Gemini_ChatGPT_APIs_P2_P4.Repositories;
using WebGemini.Repositories;

namespace WebGemini.Interfaces
{
    public class ChatbotFactory
    {
        private readonly GeminiRepository _gemini;
        private readonly GptRepository _gpt;

        public ChatbotFactory(GeminiRepository gemini, GptRepository gpt)
        {
            _gemini = gemini;
            _gpt = gpt;
        }

        public IChatbotService GetChatbotService(string mode)
        {
            return mode.ToLower() switch
            {
                "gemini" => _gemini,
                "gpt" => _gpt,
                _ => _gemini
            };
        }
    }

}
