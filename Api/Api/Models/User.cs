using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class User
    {
        [Key]
        public int UID { get; set; }
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PWD { get; set; }
        public string Mobile { get; set; }
        public string UserType { get; set; }

        //public string Address { get; set; }

        //[NotMapped]
        //public string GUID { get; set; }
        //[NotMapped]
        //public DateTime? DOB { get; set; }

        //[NotMapped]
        //public bool IsVerified { get; set; } = false;
        //public string Status { get; set; } = "Pending";
       

    }
    public class creds {

        public string Email { get; set; }

        
        public string PWD { get; set; }
    }
}
