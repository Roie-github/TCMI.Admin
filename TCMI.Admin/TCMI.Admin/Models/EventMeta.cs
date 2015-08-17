using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TCMI.Admin.Models
{
    public class EventMeta
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Venue { get; set; }
        [Required]
        [Display(Name="Date")]
        public System.DateTime DateOfEvent { get; set; }
        [Required]
        public string Time { get; set; }
        public Nullable<bool> Expired { get; set; }
    }
}