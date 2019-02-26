using SecondSightSouthendEyeCentre;
using SecondSightSouthendEyeCentre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.OtManager.Models.DTO
{
    public class OTSuggessitionDTO
    {
        public IEnumerable<AppointmentDTO> AppointmenList { get; set; }
        public EmployeeShortInfo Patient { get; set; }

    }
}