using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class ProcedureRate
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Procedure Details")]
        [DisplayName("Procedure")]
        public string ProcedureName { get; set; } = "";
        [Required(ErrorMessage = "Please Enter Rate Details")]
        [DisplayName("Rate")]
        public Decimal Rate { get; set; } = 0;

    }
}
