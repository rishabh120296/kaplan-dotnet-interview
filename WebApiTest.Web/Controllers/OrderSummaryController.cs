using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using WebApiTest.Models;
using WebApiTest.Services;

namespace WebApiTest.Web.Controllers
{
    [ApiController]
    [Route( "[controller]" )]
    public class OrderSummaryController : ControllerBase
    {
        public OrderSummaryController( IOrderSummaryService orderSummaryService, ILogger<OrderSummaryController> logger )
        {
            _orderSummaryService = orderSummaryService;
            _logger = logger;
        }

        private readonly ILogger<OrderSummaryController> _logger;
        private readonly IOrderSummaryService _orderSummaryService;

        [Route("{orderID:int}")]
        [HttpGet]
        public Task<OrderSummaryModel> Get( int orderID )
        {
            return _orderSummaryService.GetAsync( orderID );
        }
    }
}
