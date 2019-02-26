using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class DoctorExaminationGlassPrescription
    {
        [Key]
        public int DoctorExaminationGlassPrescriptionId { get; set; }

        public string DVRESph { get; set; }

        public string DVRECyl { get; set; }

        public string DVREAxis { get; set; }

        public string DVREVA { get; set; }

        public string DVLESph { get; set; }

        public string DVLECyl { get; set; }

        public string DVLEAxis { get; set; }

        public string DVLEVA { get; set; }

        public string ADDRESph { get; set; }

        public string ADDREVA { get; set; }

        public string ADDREDistance { get; set; }

        public string ADDLESph { get; set; }

        public string ADDLEVA { get; set; }

        public string ADDLEDistance { get; set; }

    }
}