using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{

    public class OTChargeCategory
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter OtCharge Category Details")]
        [DisplayName("OtCharge Category Name")]
        public string OtChargeCategory { get; set; }
    }
}
