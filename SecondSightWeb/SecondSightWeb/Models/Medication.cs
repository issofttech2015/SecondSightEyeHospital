using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class Medication
    {
        public int MedicationId { get; set; }

        public int? TreatmentId { get; set; }

        public int? PatientId { get; set; }

        public string MedicineName { get; set; }

    }
}
