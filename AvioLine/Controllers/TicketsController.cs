using AvioLine.Domain.Models;
using AvioLine.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace AvioLine.Controllers
{

    [Authorize]
    public class TicketsController : Controller
    {
        private readonly ITicketService<TicketViewModel> ticketService;

        public TicketsController(ITicketService<TicketViewModel> ticketService)
        {
            this.ticketService = ticketService;
        }

        [HttpPost]
        public async Task <IActionResult> BuyTickets(TicketViewModel model)
        {
            if (ModelState.IsValid)
            {
                await ticketService.AddAsync(model);

                return RedirectToAction("Index", "Home");

            }
            return RedirectToAction("Index", "Home");
        }


   

    }
}
