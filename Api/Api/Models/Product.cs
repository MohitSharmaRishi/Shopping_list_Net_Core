using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Product
    {
        [Key]
        public int PID { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        [RegularExpression(@"\d", ErrorMessage = "")]
        public float Price { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Category { get; set; } = "Default";

        [Required]
        
        public string Status { get; set; } = "Pending";


    }
}
