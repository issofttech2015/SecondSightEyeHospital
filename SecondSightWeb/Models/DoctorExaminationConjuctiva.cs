using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class DoctorExaminationConjuctiva
    {
        [Key]
        public int DoctorExaminationConjuctivaId { get; set; }

        public string REUpperPalperbal { get; set; }

        public string RELowerPalperbal { get; set; }

        public string REBulbarNasal { get; set; }

        public string REBulberTemporal { get; set; }

        public string RELimbus { get; set; }

        public string REFornix { get; set; }

        public string RESpecialConditions { get; set; }

        public string LEUpperPalperbal { get; set; }

        public string LELowerPalperbal { get; set; }

        public string LEBulbarNasal { get; set; }

        public string LEBulberTemporal { get; set; }

        public string LELimbus { get; set; }

        public string LEFornix { get; set; }

        public string LESpecialConditions { get; set; }

    }
   
}