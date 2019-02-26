using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeconSightAPI.Models.ViewModel
{
    public class TreatementDetailsViewModel
    {
        public string TreatmentCode { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public string PatCode { get; set; }
        public string Contact { get; set; }
        public string CheifComplain { get; set; }
        public string Disease { get; set; }
        public string Advice { get; set; }
        public string RefferedDoctorName { get; set; }
        public string IsRefferedToTest { get; set; }
        public string IsRefferedToOT { get; set; }
        public string TreatmentDate { get; set; }
    }
}