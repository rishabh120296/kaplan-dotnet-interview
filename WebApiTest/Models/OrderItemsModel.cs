using System.Collections.Generic;

namespace WebApiTest.Models
{
    public class OrderItemsModel
    {
        public int OrderID { get; set; }
        public IEnumerable<OrderItemModel> Items { get; set; }
    }
}
