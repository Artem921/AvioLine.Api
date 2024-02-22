using AvioLine.Areas.Admin.Controllers;
using AvioLine.Domain.DTO;
using AvioLine.Domain.Models;
using AvioLine.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Assert = Xunit.Assert;
namespace AvioLine.Test.Controllers
{
    [TestClass]
    public class AdminControllerTest
    {
        [TestMethod]

        public async Task  Index_GetAll_Tickets()
        {
            //Arrange

            var ticketsServices_mock=new Mock<ITicketService<TicketViewModel>>();

            ticketsServices_mock.Setup(p => p.GetAllAsync().Result).Returns(new List<TicketViewModel>());

            var controller = new AdminController(ticketsServices_mock.Object);

            //Arg
            var result = await controller.Index();

            //Assert

            var view_result=Assert.IsType<ViewResult>(result);

        }
    }
}
