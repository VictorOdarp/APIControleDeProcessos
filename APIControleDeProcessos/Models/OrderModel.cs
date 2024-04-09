using System.ComponentModel.DataAnnotations;

namespace APIControleDeProcessos.Models
{
    public class OrderModel
    {
        public int Number { get; set; }
        public ProductModel Name { get; set; }
        public ProductModel Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now.ToLocalTime();

    }
}
