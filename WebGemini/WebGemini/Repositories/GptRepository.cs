using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebGemini.Interfaces;
using WebGemini.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace WebGemini.Repositories
{
    public class GptRepository : IChatbotService
    {
        public async Task<string> GetChatbotResponse(string prompt)
        {
            // Aquí pondrías el consumo de API de GPT
            return $"[GPT FAKE RESPONSE]: {prompt}";
        }
    }

}
