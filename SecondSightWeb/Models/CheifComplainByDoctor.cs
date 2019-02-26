using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class CheifComplainByDoctor
    {
        [Key]
        public int CheifComplainByDoctorId { get; set; }
        public int? TreatmentId { get; set; }
        public int? CheifComplainListId { get; set; }
        public string Duration { get; set; }
        public string Eye { get; set; }
    }
}