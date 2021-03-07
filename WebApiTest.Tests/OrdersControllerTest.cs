using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApiTest.Services;
using WebApiTest.Web.Controllers;

namespace WebApiTest.Tests
{
    [TestClass]
    public class OrdersControllerTest
    {
        private Mock<IOrderItemsService> orderItemsService;
        private Mock<ILogger<OrdersController>> logger;

        [TestInitialize]
        public void Setup()
        {
            this.orderItemsService = new Mock<IOrderItemsService>();
            this.logger = new Mock<ILogger<OrdersController>>();
        }

        [TestMethod]
        public void Test_Get()
        {
            orderItemsService.Setup(x => x.Get(It.IsAny<int>()));

            var controller = new OrdersController(orderItemsService.Object, logger.Object);
            var result = controller.Get(1000);
            var notFoundResult = result as NotFoundResult;

            Assert.AreEqual(404, notFoundResult.StatusCode);
        }
    }
}
