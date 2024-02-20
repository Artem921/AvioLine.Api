using AvioLine.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AvioLine.Controllers
{
	public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
            logger.LogInformation("Приложение запущенно");
        }

        public IActionResult Index()
        {
            return View(new TicketViewModel());
        }

        

        public IActionResult Privacy()
        {
            return View();
        }

      
    }
}