using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class RefundBillDetails
    {
        [Key]
        public int RefundBillDetailsId { get; set; }

        public int RefundBillId { get; set; }

        public int? BillDetailsId { get; set; }

        public string Purpose { get; set; }

        public decimal? RefundAmount { get; set; }

    }
}