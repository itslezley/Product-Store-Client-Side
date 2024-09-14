using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lezlab.Models
{
    public class Product
    {
        [Key]
        public int productId { get; set; }
        [Required(ErrorMessage ="Product name is required")]
        public String productName { get; set; } = string.Empty;
        [Required(ErrorMessage ="Product name is required")]
        public String productType { get; set; } = string.Empty;
        [Required(ErrorMessage ="Product name is required")]
        [Range(0,double.MaxValue,ErrorMessage ="Product price must be greater than 0 and less than limit of double")]
        public float productPrice { get; set; }
        [Required(ErrorMessage ="Product name is required")]
        public String description { get; set; } = string.Empty;
        [DataType(DataType.Upload)]
        public byte[]? Image { get; set; }
    }
}