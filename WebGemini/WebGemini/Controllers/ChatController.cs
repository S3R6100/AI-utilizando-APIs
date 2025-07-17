using Microsoft.AspNetCore.Mvc;
using WebGemini.Factories;

namespace WebGemini.Controllers
{
    public class ChatController : Controller
    {
        private readonly ChatbotFactory _chatbotFactory;

        public ChatController(ChatbotFactory chatbotFactory)
        {
            _chatbotFactory = chatbotFactory;
        }

        public IActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> SendPrompt(string userPrompt, string mode)
        {
            var chatbotService = _chatbotFactory.GetChatbotService(mode);
            var response = await chatbotService.GetChatbotResponse(userPrompt);

            ViewBag.BotResponse = response;
            ViewBag.SelectedMode = mode;
            ViewBag.UserPrompt = userPrompt;

            return View("~/Views/Home/Index.cshtml");
        }
    }
}
