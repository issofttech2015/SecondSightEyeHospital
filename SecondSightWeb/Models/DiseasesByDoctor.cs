using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class DiseasesByDoctor
    {
        [Key]
        public int DiseasesByDoctorId { get; set; }
        public int? TreatmentId { get; set; }
        public int? DiseasesId { get; set; }
        public string Eye { get; set; }
    }
}