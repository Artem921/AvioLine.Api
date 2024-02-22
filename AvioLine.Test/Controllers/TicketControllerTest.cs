using AvioLine.Controllers;
using AvioLine.Domain.Models;
using AvioLine.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;
using Assert = Xunit.Assert;
namespace AvioLine.Test.Controllers
{
    [TestClass]
    public class TicketControllerTest
    {
        [TestMethod]
       
        public async Task BuyTickets_Add_Ticket_at_Database()
        {
            //Arrange
            var ticket = new Mock<TicketViewModel>();

            var ticketsServices_mock = new Mock<ITicketService<TicketViewModel>>();
            
            var controller = new TicketsController(ticketsServices_mock.Object);

            //Arg
            var result = await controller.BuyTickets(ticket.Object);

            //Assert
            var view_result = Assert.IsType<RedirectToActionResult>(result);





        }

        [TestMethod]

        public async Task BuyTickets_Result_ViewModel()
        {
            //Arrange
            var ticket = new TicketViewModel();
      
            var ticketsServices_mock = new Mock<ITicketService<TicketViewModel>>(MockBehavior.Strict);

            var controller = new TicketsController(ticketsServices_mock.Object);
            controller.ModelState.AddModelError("Name", "Required");

            //Arg
            var result = await controller.BuyTickets(ticket);

            //Assert

            var view_result = Assert.IsType<ViewResult>(result);
            Assert.Equal(ticket, view_result?.Model);
        }

    }
}
