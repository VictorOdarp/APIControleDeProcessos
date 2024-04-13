using APIControleDeProcessos.Models;
using APIControleDeProcessos.Services;

namespace APIControleDeProcessos.Interface
{
    public interface IOrderInterface
    {
        Task<ServiceResponse<List<OrderModel>>> GetAllOrders();
        Task<ServiceResponse<OrderModel>> GetOrderByNumber(int number);
        Task<ServiceResponse<OrderModel>> GetOrderByName (string name); 
        Task<ServiceResponse<List<OrderModel>>> CreateOrder (OrderModel newOrder);
        Task<ServiceResponse<List<OrderModel>>> UpdateOrder (OrderModel upOrder);
        Task<ServiceResponse<List<OrderModel>>> DeleteOrder(int number);
     }
}
