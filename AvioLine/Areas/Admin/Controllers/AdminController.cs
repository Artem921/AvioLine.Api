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
    public class AdminController : Controller
    {
        private readonly ITicketService<TicketViewModel> ticketService;

        public AdminController(ITicketService<TicketViewModel> ticketService)
        {
            this.ticketService = ticketService;
        }

        public async Task< IActionResult> Index()
        {

            var tickets = await ticketService.GetAllAsync();

            return View(tickets);
        }


    }
}
