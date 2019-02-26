using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class Diseases
    {
        [Key]
        public int DiseasesId { get; set; }
        [Required(ErrorMessage = "Please Enter Diseases Details")]
        [DisplayName("Diseases Details")]
        public string DiseasesName { get; set; }

    }
}
