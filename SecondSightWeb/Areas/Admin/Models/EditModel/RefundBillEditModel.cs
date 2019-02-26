using SecondSightSouthendEyeCentre.Models;
using SecondSightWeb.Areas.Admin.Models.ViewModels;
using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.Admin.Models.EditModel
{
    public class RefundBillEditModel 
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

        public List<ModeOfPayments> ModeOfPaymentList = new List<ModeOfPayments>()
        {
            new ModeOfPayments(){ModeOfPayment="Cash",IsSelected=true},
            new ModeOfPayments(){ModeOfPayment="Cheque",IsSelected=false},
            new ModeOfPayments(){ModeOfPayment="DD",IsSelected=false},
            new ModeOfPayments(){ModeOfPayment="Wallet",IsSelected=false},
            new ModeOfPayments(){ModeOfPayment="RSBY",IsSelected=false},
            new ModeOfPayments(){ModeOfPayment="EDC",IsSelected=false}
        };
        [Required(ErrorMessage = "Enter Refund Amount")]
        public decimal RefundAmount { get; set; }
        public string ModeOfPayment { get; set; }
        public string ModeOfPaymentNo { get; set; }
        public DateTime PaymentDate { get; set; } = System.DateTime.Now;
        [Required(ErrorMessage = "Enter Purpose")]
        public string Purpose { get; set; }
    }
}