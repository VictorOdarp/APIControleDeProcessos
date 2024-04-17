using System.ComponentModel.DataAnnotations;

namespace APIControleDeProcessos.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; } 
        public string Description { get; set; }
    }
}
