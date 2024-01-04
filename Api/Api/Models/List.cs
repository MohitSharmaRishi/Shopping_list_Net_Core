using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class List
    {
        [Key]
        public int LID { get; set; }

        [Required]
        public int PID { get; set; }

        [NotMapped]
        public string ProductName { get; set; } = "";

        [NotMapped]
        public float Price { get; set; }

        [NotMapped]
        public string Type { get; set; }

        [NotMapped]
        public string Category { get; set; } = "Default";


        [Required]
        public string Status { get; set; } = "Pending";

    }
}
