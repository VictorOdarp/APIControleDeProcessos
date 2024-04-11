using APIControleDeProcessos.Interface;
using APIControleDeProcessos.Models;

namespace APIControleDeProcessos.Services
{
    public class ProductService : IProductInterface
    {

        public Task<List<ProductModel>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> GetProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductModel>> CreateProduct(ProductModel newProduct)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductModel>> UpdateProduct(ProductModel updateProdut)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductModel>> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

    }
}
