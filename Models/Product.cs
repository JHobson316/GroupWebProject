using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using GroupWebProject.Media.Products;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace GroupWebProject.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        //public string Brand { get; set; }
        [Required, MinLength(4, ErrorMessage = "Minimum length is 2.")]
        public string Description { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a valid value")]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        public long CategoryID { get; set; }
        public Category Category { get; set; }
        public string Slug { get; set; }
        public string image { get; set; }
    }
}
