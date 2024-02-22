using AvioLine.Domain.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AvioLine.Controllers
{
	public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new TicketViewModel{ UserId=User.Identity.GetUserId()});
        }

        

        public IActionResult Privacy()
        {
            return View();
        }

      
    }
}