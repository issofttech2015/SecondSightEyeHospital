using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.Admin.Models.DTO
{
    public class AppointmentDashBoardDTO
    {
        public int TotalAppointment { get; set; }
        public DateTime Date { get; set; }
        public string DatePrint { get; set; }
    }
}