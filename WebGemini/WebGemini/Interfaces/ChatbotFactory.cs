using WebGemini.Repositories;
using WebGemini.Interfaces;
using WebGemini.Repositories;

namespace WebGemini.Factories
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
                "gpt" => _gpt,
                "gemini" => _gemini,
                _ => _gemini
            };
        }
    }
}
