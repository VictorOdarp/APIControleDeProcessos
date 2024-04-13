using APIControleDeProcessos.Enum;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace APIControleDeProcessos.Models
{
    public class OrderModel
    {
        [Key]
        public int Number { get; set; }
        public ProductModel Product { get; set; }
        public ProcessEnum Process { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now.ToLocalTime();

    }
}
