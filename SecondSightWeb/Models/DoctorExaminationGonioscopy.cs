using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class DoctorExaminationGonioscopy
    {
        [Key]
        public int DoctorExaminationGonioscopyId { get; set; }

        public string REGonioscopy { get; set; }

        public string LEGonioscopy { get; set; }

    }
}