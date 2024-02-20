using AvioLine.Domain.DTO;
using AvioLine.Domain.Models;
using AvioLine.Interfaces;
using Mappers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace AvioLine.Controllers
{
 
    [Authorize]
    public class TicketsController : Controller
    {
        private readonly ITicketService ticketService;

        public TicketsController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        [HttpPost]
        public async Task <IActionResult> BuyTickets(TicketViewModel model)
        {
            var ticket= Mapping.Mapper.Map<TicketDTO>(model);

            ticket.UserId = User.Identity.GetUserId();

            await ticketService.AddAsync(ticket);

            return RedirectToAction("Index", "Home");
        }


   

    }
}
