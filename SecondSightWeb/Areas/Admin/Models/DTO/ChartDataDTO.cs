using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.Admin.Models.DTO
{
    public class ChartDataDTO
    {
        public List<AppointmentDashBoardDTO> lstAppointments { get; set; }
        public List<BillDashboardDTO> lstBills { get; set; }
        public List<OperateSuccessRateDTO> lstOperationSuccessRate { get; set; }
    }
}