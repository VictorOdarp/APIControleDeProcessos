using APIControleDeProcessos.Models;

namespace APIControleDeProcessos.Interface
{
    public interface IOrderInterface
    {
        Task<List<OrderModel>> GetAllOrders();
        Task<OrderModel> GetOrderByNumber(int number);
        Task<List<OrderModel>> CreateOrder (OrderModel newOrder);
        Task<List<OrderModel>> UpdateOrder (OrderModel upOrder);
        Task<List<OrderModel>> DeleteOrder(int number);
     }
}
