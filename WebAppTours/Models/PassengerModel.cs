using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebAppTours.Models
{
    public class VerifyNamePassenger
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "LastName")]
        public string LastName { get; set; }
    }

    public class VerifySelectedTour
    {
        [Required]
        [Display(Name = "Tour")]
        public string Id_Tour { get; set; }
    }
}