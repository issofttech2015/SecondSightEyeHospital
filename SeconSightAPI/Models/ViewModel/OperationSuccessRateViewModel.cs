using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeconSightAPI.Models.ViewModel
{
    public class OperationSuccessRateViewModel
    {
        public string DoctorName { get; set; }
        public string RefferedOperation { get; set; }
        public string ConvertedOperation { get; set; }
        public string SuccessRate { get; set; }
    }
}