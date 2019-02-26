using SecondSightSouthendEyeCentre.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class PaymentDetalis
    {
        [Key]
        public int PaymentId { get; set; }
        public int BillId { get; set; }
        [DisplayName("Payment Amount")]
        [Required(ErrorMessage = "Enter Payment Amount")]
        public decimal PaymentAmount { get; set; }
        [DisplayName("Payment Date")]
        public DateTime? PaymentDate { get; set; } = System.DateTime.Now;
        [DisplayName("Mode Of Payment")]
        public string ModeOfPayment { get; set; }
        [DisplayName("Mode Of Payment No")]
        public string ModeOfPaymentNo { get; set; }
        public int PaymentBy { get; set; }
        public virtual Bill Bill { get; set; }
    }
}