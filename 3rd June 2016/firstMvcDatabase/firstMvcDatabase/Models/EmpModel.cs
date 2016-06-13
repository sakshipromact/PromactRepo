using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace firstMvcDatabase.Models
{
    public class EmpModel
    {
        [Display(Name = "Id")]
        public int Empid { get; set; }
       
        [Required(ErrorMessage="First name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage="City is required")]
        public string city { get; set; }

        [Required(ErrorMessage="Address is required")]
        public string address { get; set; }


    }
}