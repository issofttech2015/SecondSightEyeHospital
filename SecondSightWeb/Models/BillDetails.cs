using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class BillDetails
    {
        public int BillDetailsId { get; set; }

        public int BillId { get; set; }

        public int ProcedureRateId { get; set; }

        public decimal Rate { get; set; }

    }

}