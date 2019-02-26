using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        public string AppointmentType { get; set; }

        public string Name { get; set; }

        public string Mobile { get; set; }

        public string Address { get; set; }

        public int? DoctorsId { get; set; }

        public DateTime Time { get; set; }

        public string Comments { get; set; }
        public string PatCode { get; set; }
        public bool IsAttented { get; set; }
        public bool? IsConfirmed { get; set; } = false;
        public bool? IsNew { get; set; } = false;
        public bool? IsCanceled { get; set; } = false;
        public int ProcedureRateId { get; set; }
        public bool IsExamineComplete { get; set; } = false;
    }

}
