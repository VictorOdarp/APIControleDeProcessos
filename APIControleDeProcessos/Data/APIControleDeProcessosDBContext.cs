using APIControleDeProcessos.Models;
using Microsoft.EntityFrameworkCore;

namespace APIControleDeProcessos.Data
{
    public class APIControleDeProcessosDBContext : DbContext
    {
        public APIControleDeProcessosDBContext(DbContextOptions<APIControleDeProcessosDBContext> options) : base(options)
        {

        }

        public DbSet<OrderModel> OrderModels { get; set; }
        public DbSet<ProductModel> ProductModels { get; set; }

    }
}
