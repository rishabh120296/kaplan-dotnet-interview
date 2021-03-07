﻿using System.Threading.Tasks;

using WebApiTest.Models;

namespace WebApiTest.Services
{
    public interface IOrderItemsService
    {
        Task<short> AddAsync(int orderID, OrderItemModel item);
        OrderItemsModel Get(int orderID);
        int Delete(int orderID, int lineNumber);
    }
}
