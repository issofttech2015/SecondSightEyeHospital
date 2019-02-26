using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.Admin.Models.DTO
{
    public class OperateSuccessRateDTO
    {
        public int RefferedOperation { get; set; }
        public int ConvertedOperation { get; set; }
        public string DoctorName { get; set; }
    }
}