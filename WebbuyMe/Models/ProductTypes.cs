using System.ComponentModel.DataAnnotations;

namespace WebbuyMe.Models
{
    public class ProductTypes
    {
        [Key]
        public int ProductTypesId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
