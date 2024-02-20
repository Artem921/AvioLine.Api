using AvioLine.Domain.Entities;
using AvioLine.Domain.Models;
using AvioLine.Interfaces;
using Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AvioLine.Areas.Admin.Controllers
{
    [Area(Role.Admin)]
    [Authorize(Roles =Role.Admin)]
    public class HomeController : Controller
    {
        private readonly ITicketService ticketService;

        public HomeController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        public async Task< IActionResult> Index()
        {

            var ticketsDTO = await ticketService.GetAllAsync();

            var ticketsVM = Mapping.Mapper.Map<IEnumerable<TicketViewModel>>(ticketsDTO);

            return View(ticketsVM);
        }
    }
}
