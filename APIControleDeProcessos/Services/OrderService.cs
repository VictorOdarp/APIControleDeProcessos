using APIControleDeProcessos.Data;
using APIControleDeProcessos.Interface;
using APIControleDeProcessos.Models;
using Microsoft.EntityFrameworkCore;

namespace APIControleDeProcessos.Services
{
    public class OrderService : IOrderInterface
    {

        private readonly APIControleDeProcessosDBContext _context;

        public OrderService(APIControleDeProcessosDBContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<OrderModel>>> GetAllOrders()
        {
            ServiceResponse<List<OrderModel>> serviceResponse = new ServiceResponse<List<OrderModel>>();

            try
            {
                if (serviceResponse.Data.Count == 0)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Nenhum dado encontrado!";
                    serviceResponse.Success = false;
                }

                serviceResponse.Data = await _context.OrderModels.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public Task<ServiceResponse<OrderModel>> GetOrderByNumber(int number)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<OrderModel>> GetOrderByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<OrderModel>>> CreateOrder(OrderModel newOrder)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<OrderModel>>> UpdateOrder(OrderModel upOrder)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<OrderModel>>> DeleteOrder(int number)
        {
            throw new NotImplementedException();
        }
    }
}
