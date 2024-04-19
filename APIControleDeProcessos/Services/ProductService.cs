using APIControleDeProcessos.Data;
using APIControleDeProcessos.Interface;
using APIControleDeProcessos.Models;
using Microsoft.EntityFrameworkCore;

namespace APIControleDeProcessos.Services
{
    public class ProductService : IProductInterface
    {
        private readonly APIControleDeProcessosDBContext _context;

        public ProductService(APIControleDeProcessosDBContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<ProductModel>>> GetAllProducts()
        {
            ServiceResponse<List<ProductModel>> serviceResponse = new ServiceResponse<List<ProductModel>>();

            try
            {
               
                serviceResponse.Data = await _context.ProductModels.ToListAsync();
                serviceResponse.Message = "Os dados acima foram encontrados!";

                if (serviceResponse.Data.Count == 0)
                {
                    serviceResponse.Message = "Nenhum dado encontrado!";
                }


            }catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;

            
        }

        public async Task<ServiceResponse<ProductModel>> GetProductById(int id)
        {
            ServiceResponse<ProductModel> serviceResponse = new ServiceResponse<ProductModel>();

            try
            {
                if (id == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Informar dados!";
                    serviceResponse.Success = false;
                }

                ProductModel product = await _context.ProductModels.FirstOrDefaultAsync(X => X.Id == id);

                if(product == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Nenhum dado encontrado!";
                    serviceResponse.Success = false;
                }

                serviceResponse.Data = product;

            }catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<ProductModel>> GetProductByName(string name)
        {
            ServiceResponse<ProductModel> serviceResponse = new ServiceResponse<ProductModel>();

            try
            {
                if (name == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Informar dados!";
                    serviceResponse.Success = false;
                }

                ProductModel product = await _context.ProductModels.FirstOrDefaultAsync(X => X.Name == name);

                if (product == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Nenhum dado encontrado!";
                    serviceResponse.Success = false;
                }

                serviceResponse.Data = product;

            }catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ProductModel>>> CreateProduct(ProductModel newProduct)
        {
            ServiceResponse<List<ProductModel>> serviceResponse = new ServiceResponse<List<ProductModel>>();

            try
            {
                if (newProduct == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Informar dados";
                    serviceResponse.Success = false;
                }

                _context.Add(newProduct);
                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.ProductModels.ToListAsync();

            }catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ProductModel>>> UpdateProduct(ProductModel updateProdut)
        {
            ServiceResponse<List<ProductModel>> serviceResponse = new ServiceResponse<List<ProductModel>>();

            try
            {
                if (updateProdut == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Informar dados";
                    serviceResponse.Success = false;
                }

                ProductModel product = await _context.ProductModels.AsNoTracking().FirstOrDefaultAsync(X => X.Id == updateProdut.Id);

                if (product == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Nenhum dado encontrado!";
                    serviceResponse.Success = false;
                }

                _context.Update(updateProdut);
                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.ProductModels.ToListAsync();

            }catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ProductModel>>> DeleteProduct(int id)
        {
            ServiceResponse<List<ProductModel>> serviceResponse = new ServiceResponse<List<ProductModel>>();

            try
            {
                if (id == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Informar dados!";
                    serviceResponse.Success = false;
                }

                ProductModel product = await _context.ProductModels.FirstOrDefaultAsync(X => X.Id == id);

                if (product == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Nenhum dado encontrado!";
                    serviceResponse.Success = false;
                }

                _context.Remove(product);
                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.ProductModels.ToListAsync();
                serviceResponse.Message = "O Produto " + product.Id + " foi deletado!";
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
