using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class SystemicDisease
    {
        [Key]
        public int DiseaseId { get; set; }
        [Required(ErrorMessage = "Please Enter Disease Details")]
        [DisplayName("Disease Name")]
        public string DiseaseName { get; set; }

    }

}
