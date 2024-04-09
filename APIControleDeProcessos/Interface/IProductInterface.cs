using APIControleDeProcessos.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIControleDeProcessos.Interface
{
    public interface IProductInterface
    {
        Task<List<ProductModel>> GetAllProducts();
        Task<ProductModel> GetProductById(int id);
        Task<ProductModel> GetProductByName(string name);
        Task<List<ProductModel>> CreateProduct(ProductModel newProduct);
        Task<List<ProductModel>> UpdateProduct(ProductModel updateProdut);
        Task<List<ProductModel>> DeleteProduct(int id);

    }
}
