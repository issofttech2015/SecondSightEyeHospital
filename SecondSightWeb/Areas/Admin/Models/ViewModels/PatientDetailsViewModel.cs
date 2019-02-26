using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.Admin.Models.ViewModels
{
    public class PatientDetailsViewModel
    {
        [Key]
        public int PatientId { get; set; }

        public string PatCode { get; set; }

        public string PatientName { get; set; }

        public decimal Contact { get; set; }

        public DateTime DateofBirth { get; set; }

        //public string Nationality { get; set; }

        public int? Age { get; set; }

        public string ResidanceAddress { get; set; }

        public string Email { get; set; }

        public string GuardianName { get; set; }

        public string GuardianContact { get; set; }

        public string GuardianRelateAs { get; set; }

        //public string Ocupation { get; set; }

        //public Decimal Adhar { get; set; }
    }
}