using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeconSightAPI.Models
{
    public class CollectionDetailsViewModel
    {
        public string BillCode { get; set; }
        public string EmployeeName { get; set; }
        public string PatientName { get; set; }
        public DateTime BillDate { get; set; }
        public string TotalAmount { get; set; }
        public string AoountPaid { get; set; }
        public string AmountDue { get; set; }
        public string ConsessionAmount { get; set; }
        public string ModeofPayment { get; set; }
        public string PatCode { get; set; }
        public string Purpose { get; set; }
    }
}