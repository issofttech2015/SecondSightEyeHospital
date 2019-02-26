using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeconSightAPI.Models.ViewModel
{
    public class AppointmentDetailsViewModel
    {
        public string PatCode { get; set; }
        public string AppointmentCode { get; set; }
        public string PatientName { get; set; }
        //public decimal Contact { get; set; }
        public string Contact { get; set; }
        public string DoctorName { get; set; }
        public string AppointmentTime { get; set; }
        public string IsConfirmed { get; set; }
        public string IsAttented { get; set; }
        public string IsCanceled { get; set; }
    }
}