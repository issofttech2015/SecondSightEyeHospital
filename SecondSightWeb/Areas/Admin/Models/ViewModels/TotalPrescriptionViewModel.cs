using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.Admin.Models.ViewModels
{
    public class TotalPrescriptionViewModel
    {
        public int PatientId { get; set; }
        public string PatCode { get; set; }
        public string AppointmentId { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public int Id { get; set; }
        public DateTime AppointmentTime { get; set; }
    }
}