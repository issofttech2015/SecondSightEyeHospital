using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class DoctorExaminationLens
    {
        [Key]
        public int DoctorExaminationLensId { get; set; }

        public string RELensStatus { get; set; }

        public string REPigmentsOnAnteriorLenCapsule { get; set; }

        public string RESpecialConditions { get; set; }

        public string LELensStatus { get; set; }

        public string LEPigmentsOnAnteriorLenCapsule { get; set; }

        public string LESpecialConditions { get; set; }

    }
}