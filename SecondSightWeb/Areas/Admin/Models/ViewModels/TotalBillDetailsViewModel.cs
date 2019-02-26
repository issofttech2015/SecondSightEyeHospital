using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.Admin.Models.ViewModels
{
    public class TotalBillDetailsViewModel
    {
        public string BillId { get; set; }
        public string PatCode { get; set; }
        public string PatientName { get; set; }
        public string BillBy { get; set; }
        public DateTime BillDate { get; set; }
        public int Id { get; set; }
        public decimal BillAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal Concession { get; set; }
        public decimal Due { get; set; }
    }
}