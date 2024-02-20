using AvioLine.Domain.DTO;
using AvioLine.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AvioLine.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/tickets")]
    [ApiController]
    public class TicketController : ControllerBase, ITicketService
    {
        private readonly ITicketService ticketService;

        public TicketController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }


        [HttpGet]
        public async Task<IEnumerable<TicketDTO>> GetAllAsync() => await ticketService.GetAllAsync();


        [HttpGet("{id}")]
        public async Task<TicketDTO> GetByIdAsync(string id) => await ticketService.GetByIdAsync(id);

        [Route("Add")]
        [HttpPost]
        public async Task AddAsync(TicketDTO ticket) => await ticketService.AddAsync(ticket);


        [HttpDelete("{id}")]
        public async Task DeleteAsync(string id) => await ticketService.DeleteAsync(id);




    }
}
