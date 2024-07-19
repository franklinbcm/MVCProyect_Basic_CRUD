using System.ComponentModel.DataAnnotations;

namespace MVCProyect_UCSD.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0.01, 5000000.00)]
        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
}
