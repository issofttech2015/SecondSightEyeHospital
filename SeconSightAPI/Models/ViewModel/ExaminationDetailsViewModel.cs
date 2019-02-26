using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeconSightAPI.Models.ViewModel
{
    public class ExaminationDetailsViewModel
    {
        public string PatCode { get; set; }
        public string ExaminationCode { get; set; }
        public string PatientName { get; set; }
        public string Contact { get; set; }
        public string ExaminationName { get; set; }
        public string ExaminationTime { get; set; }
        public string IsCompleted { get; set; }
    }
}