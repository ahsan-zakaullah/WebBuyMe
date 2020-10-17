namespace WebbuyMe.Data
{
    public class ProductTypes
    {
        [Key]
        public int ProductTypesId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
