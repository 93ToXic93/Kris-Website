using Kris.Infrastructure.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Kris.Models
{
    public class ProductModel
    {
        //public ProductModel()
        //{
        //}

        //[SetsRequiredMembers]
        //public ProductModel(string name, string category, decimal price)
        //{
        //    Name = name;
        //    Category = category;
        //    Price = price;
        //}

        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(ValidationConstants.MaxProductNameLength, MinimumLength = ValidationConstants.MinNameLength,
            ErrorMessage = "The name should be between {2} and {1} symbols!")]
        public  string Name { get; set; }

        [StringLength(ValidationConstants.MaxDescriptionLength,MinimumLength = ValidationConstants.MinDescLength,
            ErrorMessage = "The description should be between {2} and {1} symbols")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(ValidationConstants.MaxCategoryTypeLength, MinimumLength = ValidationConstants.MinCategoryLength,
            ErrorMessage = "The category should be between {2} and {1} symbols")]
        public string Category { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(ValidationConstants.MinPrice, ValidationConstants.MaxPrice,ErrorMessage = "The price should be between {2} and {1}")]
        public decimal Price { get; set; }

    }
}
