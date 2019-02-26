using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.Admin.Models.ViewModels
{
    public class AdjustmentViewModel
    {
        [Key]
        public int BillId { get; set; }
        public string PatCode { get; set; } = string.Empty;
        public string PatientName { get; set; }
        public decimal Contact { get; set; }
        public string BillCode { get; set; } = "";
        public decimal BillAmount { get; set; }
        public DateTime? Date { get; set; }
        public decimal Concession { get; set; } = 0;
        public decimal PaidAmount { get; set; }
        public decimal DueAmount { get; set; }
        public string ModeOfPayment { get; set; }
    }
}