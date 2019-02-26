using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class DoctorExaminationIntraOcularPressure
    {
        [Key]
        public int DoctorExaminationIntraOcularPressureId { get; set; }

        public string REApplanationValue { get; set; }

        public string LEApplanationValue { get; set; }

        public DateTime? ApplanationActualTime { get; set; }

    }
}