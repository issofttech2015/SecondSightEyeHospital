using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class Treatement
    {
        public int TreatmentId { get; set; }

        public int? DoctorId { get; set; }

        public int? PatientId { get; set; }

        public int? CheifComplain { get; set; }

        public int? EyeDiseaseLeft { get; set; }

        public int? EyeDiseaseRight { get; set; }

        public string Advice { get; set; }

        public string Duration { get; set; }

    }

}
