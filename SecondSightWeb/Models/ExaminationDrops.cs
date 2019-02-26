using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightSouthendEyeCentre.Models
{
    public class ExaminationDrops
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Drops Details")]
        [DisplayName("Drops Name")]
        public string DropsName { get; set; }
    }
}