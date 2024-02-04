using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Kris.Infrastructure.Validation;

namespace Kris.Infrastructure.Data.Models
{
    [Comment("Products for the Menu")]
    public class Product
    {
        [Key]
        [Comment("Product identificator")]
        public int Id { get; set; }

        [Required]
        [Comment("Product's Name")]
        [MaxLength(ValidationConstants.MaxProductNameLength)]
        public required string Name { get; set; }

        [Comment("Product Description")]
        [MaxLength(ValidationConstants.MaxDescriptionLength)]
        public string? Description { get; set; }

        [Required]
        [Comment("Product category type")]
        [MaxLength(ValidationConstants.MaxCategoryTypeLength)]
        public required string Category { get; set; }

        [Required]
        [Comment("Product price")]
        [Range(ValidationConstants.MaxPrice,ValidationConstants.MinPrice)]
        public required decimal Price { get; set; }

    }
}
