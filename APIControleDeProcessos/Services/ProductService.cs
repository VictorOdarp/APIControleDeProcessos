using APIControleDeProcessos.Data;
using APIControleDeProcessos.Interface;
using APIControleDeProcessos.Models;

namespace APIControleDeProcessos.Services
{
    public class ProductService : IProductInterface
    {
        private readonly APIControleDeProcessosDBContext _context;

        public ProductService(APIControleDeProcessosDBContext context)
        {
            _context = context;
        }

        public Task<ServiceResponse<List<ProductModel>>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<ProductModel>> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<ProductModel>> GetProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<ProductModel>>> CreateProduct(ProductModel newProduct)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<ProductModel>>> UpdateProduct(ProductModel updateProdut)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<ProductModel>>> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

    }
}
