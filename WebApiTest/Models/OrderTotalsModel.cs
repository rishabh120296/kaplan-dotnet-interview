namespace WebApiTest.Models
{
    public class OrderTotalsModel
    {
        public decimal SubTotal { get; set; }

        public decimal Tax { get; set; }

        public decimal Shipping { get; set; }
    }
}
