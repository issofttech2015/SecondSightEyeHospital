using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeconSightAPI.Models
{
    public class CollectionDetailsViewModel
    {
        public string BillId { get; set; }
        public string EmployeeName { get; set; }
        public string PatientName { get; set; }
        public DateTime BillDate { get; set; }
        public Decimal TotalAmount { get; set; }
        public Decimal AoountPaid { get; set; }
        public Decimal AmountDue { get; set; }
        public Decimal ConsessionAmount { get; set; }
        public string ModeofPayment { get; set; }
        public string PatCode { get; set; }
    }
}