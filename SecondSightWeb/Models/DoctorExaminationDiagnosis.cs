using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class DoctorExaminationDiagnosis
    {
        [Key]
        public int DoctorExaminationDiagnosisId { get; set; }

        public string REDescription { get; set; }

        public string LEDescription { get; set; }

    }
}