using Kris.Infrastructure.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Kris.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(ValidationConstants.MaxProductNameLength, MinimumLength = ValidationConstants.MinNameLength,
            ErrorMessage = "The name should be between {2} and {1} symbols!")]
        public required string Name { get; set; }

        [StringLength(ValidationConstants.MaxDescriptionLength,MinimumLength = ValidationConstants.MinDescLength,
            ErrorMessage = "The description should be between {2} and {1} symbols")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(ValidationConstants.MaxCategoryTypeLength, MinimumLength = ValidationConstants.MinCategoryLength,
            ErrorMessage = "The category should be between {2} and {1} symbols")]
        public required string Category { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(ValidationConstants.MaxPrice, ValidationConstants.MinPrice,ErrorMessage = "The price should be between {2} and {1}")]
        public required decimal Price { get; set; }

    }
}
