using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lezlab.Models
{
    public class Customer
    {
        [Key]
        public int customerId { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public String name { get; set; }  = string.Empty;
        [Required(ErrorMessage ="Surname is required")]
        public String surname { get; set; }  = string.Empty;
        [Required(ErrorMessage ="Email is required")]
        public String email { get; set; }  = string.Empty;
        [Required(ErrorMessage ="password is required")]
        public String password { get; set; }   = string.Empty;
    }
}