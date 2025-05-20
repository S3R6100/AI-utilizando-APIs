using System.Collections.Generic;

namespace EdwinSaa_WorkshopConection_Gemini_ChatGPT_APIs_P2_P4.Models
{
    public class GeminiRequest
    {
        public List<GeminiContent> contents { get; set; }
    }
    public class GeminiContent
    {
        public List<GeminiPart> parts { get; set; }
    }
    public class GeminiPart
    {
        public string text { get; set; }
    }

}
