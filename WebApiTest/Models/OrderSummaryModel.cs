using System.Collections.Generic;

namespace WebApiTest.Models
{
    public class OrderSummaryModel
    {
        public int OrderID { get; set; }
        public int OrderingPersonID { get; set; }
        public OrderTotalsModel Totals { get; set; }
        public IEnumerable<int> OrderPersonIDs { get; set; }
    }
}
