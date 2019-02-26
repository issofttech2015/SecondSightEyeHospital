using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class ConsultantReport
    {
        public int ConsultantReportId { get; set; }

        public int? ConsutantExaminationId { get; set; }

        public int? ConsultantId { get; set; }

        public int? PatientId { get; set; }

        public string Report { get; set; }

    }

}
