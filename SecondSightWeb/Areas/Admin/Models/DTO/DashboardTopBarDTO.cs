using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.Admin.Models.DTO
{
    public class DashboardTopBarDTO
    {
        public int TodaysAppointmnet { get; set; }
        public int TodaysOperation { get; set; }
        public int TotalRegisteredPatinet { get; set; }
        public int TotalEmployee { get; set; }
        public Decimal TodaysCollection { get; set; }
        public int PendingPurchaseOrder { get; set; }
        public int TotalAppointment { get; set; }
        public int TotalOperation { get; set; }
        public decimal TotalCollection { get; set; }
    }
}