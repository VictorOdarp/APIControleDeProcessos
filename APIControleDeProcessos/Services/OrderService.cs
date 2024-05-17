using APIControleDeProcessos.Data;
using APIControleDeProcessos.Interface;
using APIControleDeProcessos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Options;
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
                if (serviceResponse.Data == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Nenhum dado encontrado!";
                    serviceResponse.Success = false;
                }

                serviceResponse.Data = await _context.OrderModels.Include(P => P.Product).ToListAsync();
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

                OrderModel order = await _context.OrderModels.Include(P => P.Product).FirstOrDefaultAsync(X => X.Number == number);

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

        public async Task<ServiceResponse<OrderModel>> GetOrderByName(string product)
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

                OrderModel order = await _context.OrderModels.Include(P => P.Product).FirstOrDefaultAsync(X => X.Product.Name == product);

                if (order == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Nenhuma ordem com este produto não encontrado!";
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

        public async Task<ServiceResponse<List<OrderModel>>> CreateOrder(OrderModel Order)
        {
            ServiceResponse<List<OrderModel>> serviceResponse = new ServiceResponse<List<OrderModel>>();

            try
            {

                if (Order == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Informar dados!";
                    serviceResponse.Success = false;
                }

                ProductModel produtoExistente = await _context.ProductModels.FirstOrDefaultAsync(X => X.Id == Order.Product.Id);

                if (produtoExistente != null)
                {
                    var novaOrdem = new OrderModel
                    {
                        Product = produtoExistente
                    };

                    _context.Add(novaOrdem);
                    await _context.SaveChangesAsync();
                    serviceResponse.Message = "Ordem de produção criada com sucesso!";
                }
                else
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Produto não existente";
                    serviceResponse.Success = false;
                }

                serviceResponse.Data = await _context.OrderModels.Include(P => P.Product).ToListAsync();

            }
            catch (Exception ex)
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
                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.OrderModels.Include(P => P.Product).ToListAsync();

            }
            catch (Exception ex)
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
                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.OrderModels.Include(P => P.Product).ToListAsync();

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
