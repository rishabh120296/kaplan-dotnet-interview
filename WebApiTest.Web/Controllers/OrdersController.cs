using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using WebApiTest.Models;
using WebApiTest.Services;

namespace WebApiTest.Web.Controllers
{
    [ApiController]
    [Route( "[controller]" )]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderItemsService _orderItemsService;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController( IOrderItemsService orderItemsService, ILogger<OrdersController> logger )
        {
            _logger = logger;
            _orderItemsService = orderItemsService;
        }

        /// <summary>
        ///     Get the items on the order
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        [Route("{orderID:int}")]
        [HttpGet]
        public OrderItemsModel Get( int orderID )
        {
            return _orderItemsService.Get( orderID );
        }

        /// <summary>
        ///     Adds an item to an order, LineNumber must be zero or unspecified
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="item">The Order Item</param>
        /// <returns></returns>
        [Route("{orderID:int}")]
        [HttpPost]
        public Task<short> Post( int orderID, OrderItemModel item )
        {
            try
            {
                return _orderItemsService.AddAsync( orderID, item );
            }
            catch ( ValidationException ve )
            {
                throw new BadHttpRequestException( ve.Message );
            }
        }
    }
}
