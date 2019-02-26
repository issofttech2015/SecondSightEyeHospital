using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeconSightAPI.Models.ViewModel
{
    public class OperationDetailsViewModel
    {
        public string PatCode { get; set; }
        public string Contact { get; set; }
        public string OperationCode { get; set; }
        public string PatientName { get; set; }
        public string RefferedBy { get; set; }
        public string RefferedTo { get; set; }
        public string SurgeryName { get; set; }
        public string SurgerySubName { get; set; }
        public string Eye { get; set; }

    }
}