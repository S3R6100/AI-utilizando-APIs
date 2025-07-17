using Microsoft.AspNetCore.Mvc;
using WebGemini.Factories;
using WebGemini.Interfaces;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ChatbotFactory _chatbotFactory;

    public HomeController(ILogger<HomeController> logger, ChatbotFactory chatbotFactory)
    {
        _logger = logger;
        _chatbotFactory = chatbotFactory;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(string userPrompt, string mode)
    {
        var chatbotService = _chatbotFactory.GetChatbotService(mode ?? "gemini");
        var response = await chatbotService.GetChatbotResponse(userPrompt);
        ViewBag.UserPrompt = userPrompt;
        ViewBag.BotResponse = response;
        ViewBag.SelectedMode = mode;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
