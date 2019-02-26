using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class DoctorExaminationVitreous
    {
        [Key]
        public int DoctorExaminationVitreousId { get; set; }
        public string REVitreous { get; set; }
        public string LEVitreous { get; set; }
    }
}