using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class CheifComplainByExamination
    {
        [Key]
        public int CheifComplainByExaminationId { get; set; }
        public int? ExaminationId { get; set; }
        public int? CheifComplainId { get; set; }
        public string Duration { get; set; }
        public string Eye { get; set; }
    }
}