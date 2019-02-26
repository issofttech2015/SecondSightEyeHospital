using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class Treatement {
        [Key]
        public int TreatmentId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int AppointmentId { get; set; }
        public string CheifComplain { get; set; }
        public string Disease { get; set; }
        public string Advice { get; set; }
        public string RefferedDoctorName { get; set; }
        public bool IsRefferedToTest { get; set; }
        public bool IsRefferedToOT { get; set; }
        public DateTime TreatmentDate { get; set; } = System.DateTime.Now;
        public string CheifComplainEye { get; set; }
        public string DiseaseEye { get; set; }


    }
}
