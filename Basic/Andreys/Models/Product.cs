namespace Andreys.Models
{
    using Enums;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public CategoryEnums Category { get; set; }

        [Required]
        public GenderEnums Gender { get; set; }
    }
}
