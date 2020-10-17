using System.ComponentModel.DataAnnotations;

namespace WebbuyMe.Models
{
    public class SpecialTags
    {
        [Key]
        public int SpecialTagsId { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
