using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class Alergy
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter Alergy Details")]
        [DisplayName("Alergy Details")]
        public string AlergyName { get; set; }

    }
}
