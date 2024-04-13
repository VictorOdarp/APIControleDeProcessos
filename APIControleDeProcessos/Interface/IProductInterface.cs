using APIControleDeProcessos.Models;
using APIControleDeProcessos.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIControleDeProcessos.Interface
{
    public interface IProductInterface
    {
        Task<ServiceResponse<List<ProductModel>>> GetAllProducts();
        Task<ServiceResponse<ProductModel>> GetProductById(int id);
        Task<ServiceResponse<ProductModel>> GetProductByName(string name);
        Task<ServiceResponse<List<ProductModel>>> CreateProduct(ProductModel newProduct);
        Task<ServiceResponse<List<ProductModel>>> UpdateProduct(ProductModel updateProdut);
        Task<ServiceResponse<List<ProductModel>>> DeleteProduct(int id);

    }
}
