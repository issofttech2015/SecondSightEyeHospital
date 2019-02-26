using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class Examination
    {
        public int ExaminationId { get; set; }

        public int? ExaminerId { get; set; }

        public int? PatientId { get; set; }

        public byte[] Report { get; set; }

        public string ReportPath { get; set; } = string.Empty;

        public string ExaminationCode { get; set; }
        public DateTime ExaminationDate { get; set; } = System.DateTime.Now;
    }
}
