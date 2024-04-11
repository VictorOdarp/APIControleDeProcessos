using APIControleDeProcessos.Interface;
using APIControleDeProcessos.Models;

namespace APIControleDeProcessos.Services
{
    public class OrderService : IOrderInterface
    {
        public Task<List<OrderModel>> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Task<OrderModel> GetOrderByNumber(int number)
        {
            throw new NotImplementedException();
        }

        public Task<OrderModel> GetOrderByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderModel>> CreateOrder(OrderModel newOrder)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderModel>> UpdateOrder(OrderModel upOrder)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderModel>> DeleteOrder(int number)
        {
            throw new NotImplementedException();
        }
    }
}
