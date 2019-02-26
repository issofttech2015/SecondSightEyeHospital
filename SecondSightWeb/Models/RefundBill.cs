using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class RefundBill
    {
        [Key]
        public int RefundBillId { get; set; }

        public int BillId { get; set; }

        public DateTime? Date { get; set; }

        public string Purpose { get; set; }

        public string ModeOfPayment { get; set; }

        public string ChequeNo { get; set; }

        public decimal? RefundAmount { get; set; }

        public int? RefundBy { get; set; }

    }
}