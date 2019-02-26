using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class DoctorExaminationOcularAlignment
    {
        [Key]
        public int DoctorExaminationOcularAlignmentId { get; set; }

        public string OcularAlignment { get; set; }

    }
}