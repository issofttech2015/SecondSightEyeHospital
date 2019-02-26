using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class DoctorExaminationIris
    {
        [Key]
        public int DoctorExaminationIrisId { get; set; }

        public string REIrisDetail { get; set; }

        public string LEIrisDetail { get; set; }

    }
}