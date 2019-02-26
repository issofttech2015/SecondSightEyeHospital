using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class CheifComplainList
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Compalain Details")]
        [DisplayName("Compalain Details")]
        public string CompalainName { get; set; }

    }

}
