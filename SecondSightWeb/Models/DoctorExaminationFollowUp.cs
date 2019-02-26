using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class DoctorExaminationFollowUp
    {
        [Key]
        public int DoctorExaminationFollowUpId { get; set; }

        public string FollowUpInFormation { get; set; }

    }
}