using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TCMI.Admin.Models
{
    public class User
    {
        [Required]
        public int id { get; set; }
        [Required(ErrorMessage="Username is required!")]
        [Display(Name="Username")]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}