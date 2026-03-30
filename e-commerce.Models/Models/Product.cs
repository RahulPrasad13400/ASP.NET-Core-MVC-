
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace e_commerce.Models.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required]
        public string ISBN { get; set; } = string.Empty;
        [Required]
        public string Author { get; set; } = string.Empty;
        [Required]
        [Display(Name = "List Price")]
        [Range(1, 10000, ErrorMessage = "List Price must be between 1 and 10000")]
        public double ListPrice { get; set; }
        [Required]
        [Display(Name = "Price for 1-50")]
        [Range(1, 10000, ErrorMessage = "List Price must be between 1 and 10000")]
        public double Price { get; set; }
        [Required]
        [Display(Name = "Price for 50+")]
        [Range(1, 10000, ErrorMessage = "List Price must be between 1 and 10000")]
        public double Price50 { get; set; }
        [Required]
        [Display(Name = "Price for 100+")]
        [Range(1, 10000, ErrorMessage = "List Price must be between 1 and 10000")]
        public double Price100 { get; set; }

        // IMAGE URL 
        public string ImageUrl { get; set; } = string.Empty;

        // FOR FOREIGN CONNECTION BETWEEN THE PRODUCT AND THE CATEGORY
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; } = string.Empty;
    }
}
