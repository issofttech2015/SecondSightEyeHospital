using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.Admin.Models.DTO
{
    public class PatientDirectoryDetialsDTO
    {
        public int TotalAppointments { get; set; }
        public int TotalPrescriptions { get; set; }
        public int TotalExamination { get; set; }
        public int TotalDischargeCertificate { get; set; }
        public int TotalPreoperativeAdvice { get; set; }
        public int TotalSurgeryAdvice { get; set; }
        public int TotalSurgicalConsumptionList { get; set; }
        public decimal TotalCollection { get; set; }
        public int PatientId { get; set; }

    }
}