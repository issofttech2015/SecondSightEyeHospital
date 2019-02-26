using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre
{
    public class Appointments
    {
        public int AppointmentId { get; set; }
        public string AppointmentType { get; set; }
        public string PatientName { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public int DoctorsId { get; set; }
        public DateTime Time { get; set; }
        public string Comments { get; set; } = "";
        public string PatCode { get; set; }
        public bool IsAttented { get; set; } = false;
        public bool IsConfirmed { get; set; } = false;
        public bool IsNew { get; set; } = false;
        public bool IsCanceled { get; set; } = false;
    }
}