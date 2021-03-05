using System.Threading.Tasks;
using WebApiTest.Models;

namespace WebApiTest.Services
{
    public interface IOrderSummaryService
    {
        Task<OrderSummaryModel> GetAsync(int orderID);
    }
}