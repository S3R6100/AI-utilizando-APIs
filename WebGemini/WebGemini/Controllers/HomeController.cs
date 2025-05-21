using Microsoft.AspNetCore.Mvc;
using WebGemini.Interfaces;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IChatbotService _chatbotService;

    public HomeController(ILogger<HomeController> logger, IChatbotService chatbotService)
    {
        _logger = logger;
        _chatbotService = chatbotService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(string userPrompt)
    {
        var response = await _chatbotService.GetChatbotResponse(userPrompt);
        ViewBag.UserPrompt = userPrompt;
        ViewBag.BotResponse = response;
        return View();
    }
}
