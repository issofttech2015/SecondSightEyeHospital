using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class Bill
    {
        public int BillId { get; set; }

        public int PatientId { get; set; }

        public decimal BillAmount { get; set; }

        public int OperationId { get; set; }

        public DateTime Date { get; set; }

        public string Purpose { get; set; }

        public string ModeOfPayment { get; set; }

        public string ChequeNo { get; set; }

        public DateTime? PaymentDateTime { get; set; }

        public string InAccountOf { get; set; }
        public bool IsPaid { get; set; } = false;
        public string BillCode { get; set; } = "";
        public decimal Concession { get; set; } = 0;

        public bool IsSettlementDone { get; set; } = false;
        public bool IsRefunded { get; set; } = false;
        public int? BillBy { get; set; }
        public virtual List<PaymentDetalis> PaymentDetails { get; set; }

    }
    

}
