using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.Admin.Models.DTO
{
    public class BillDashboardDTO
    {

        public decimal TotalCollection { get; set; }
        public DateTime Date { get; set; }
        public string DatePrint { get; set; }
    }
}