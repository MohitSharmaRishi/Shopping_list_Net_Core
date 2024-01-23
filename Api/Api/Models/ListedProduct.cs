using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class ListedProduct
    {
        [Key]
        public int LID { get; set; }

        [Required]
        public int PID { get; set; }

        [Required]
        public int AddedBy { get; set; } = 1;

        [Required]
        public string Status { get; set; } = "Pending";

    }
}
