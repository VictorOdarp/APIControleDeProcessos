using APIControleDeProcessos.Data;
using APIControleDeProcessos.Interface;
using APIControleDeProcessos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.ComponentModel;

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

        public async Task<ServiceResponse<OrderModel>> GetOrderByNumber(int number)
        {
            ServiceResponse<OrderModel> serviceResponse = new ServiceResponse<OrderModel>();

            try
            {
                if (number == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Informar dados!";
                    serviceResponse.Success = false;
                }

                OrderModel order = await _context.OrderModels.FirstOrDefaultAsync(X => X.Number == number);

                if (order == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Nenhuma ordem encontrada";
                    serviceResponse.Success = false;
                }

                serviceResponse.Data = order;

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<OrderModel>> GetOrderByName(ProductModel product)
        {
            ServiceResponse<OrderModel> serviceResponse = new ServiceResponse<OrderModel>();

            try
            {
                if (product == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Informar dados!";
                    serviceResponse.Success = false;
                }

                OrderModel order = await _context.OrderModels.FirstOrDefaultAsync(X => X.Product == product);

                if (order == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Produto não encontrado!";
                    serviceResponse.Success = false;
                }

                serviceResponse.Data = order;

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;


        }

        public async Task<ServiceResponse<List<OrderModel>>> CreateOrder(OrderModel newOrder)
        {
            ServiceResponse<List<OrderModel>> serviceResponse = new ServiceResponse<List<OrderModel>>();

            try
            {

                if (newOrder == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Informar dados!";
                    serviceResponse.Success = false;
                }
                _context.Add(newOrder);
                _context.SaveChangesAsync();

                serviceResponse.Data = await _context.OrderModels.ToListAsync();

            }catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<OrderModel>>> UpdateOrder(OrderModel upOrder)
        {
            ServiceResponse<List<OrderModel>> serviceResponse = new ServiceResponse<List<OrderModel>>();

            try
            {
                if (upOrder == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Informar dados!";
                    serviceResponse.Success = false;
                }

                OrderModel order = await _context.OrderModels.AsNoTracking().FirstOrDefaultAsync(X => X.Number == upOrder.Number);

                if (order == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Nenhum dado encontrado!";
                    serviceResponse.Success = false;
                }

                _context.Update(upOrder);
                _context.SaveChangesAsync();

                serviceResponse.Data = await _context.OrderModels.ToListAsync();

            }catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<OrderModel>>> DeleteOrder(int number)
        {
            ServiceResponse<List<OrderModel>> serviceResponse = new ServiceResponse<List<OrderModel>>();

            try
            {
                if (number == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Informar dados!";
                    serviceResponse.Success = false;
                }

                OrderModel order = await _context.OrderModels.FirstOrDefaultAsync(X => X.Number == number);

                if (order == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Nenhum dado encontrado";
                    serviceResponse.Success = false;
                }

                _context.Remove(order);
                _context.SaveChangesAsync();

                serviceResponse.Data = await _context.OrderModels.ToListAsync();

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }
    }
}
