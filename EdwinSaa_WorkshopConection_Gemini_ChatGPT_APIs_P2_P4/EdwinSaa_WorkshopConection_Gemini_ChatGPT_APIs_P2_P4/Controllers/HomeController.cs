using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using EdwinSaa_WorkshopConection_Gemini_ChatGPT_APIs_P2_P4.Models;
using EdwinSaa_WorkshopConection_Gemini_ChatGPT_APIs_P2_P4.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EdwinSaa_WorkshopConection_Gemini_ChatGPT_APIs_P2_P4.Controllers
{
    public class HomeController : Controller
    {
        private Interfaces.IChatbotService _chatbotService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            GeminiRepository repo = new GeminiRepository();
            string response = await repo.GetChatbotResponse(" Give me a poem about a dog");
            ViewBag.chatbotanswer = response;
            return View();
        }

        public ActionResult Privacy()
        {
           
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
