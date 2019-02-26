using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class Medication
    {
        [Key]
        public int MedicationId { get; set; }
        public int TreatmentId { get; set; } = 0;
        public int OperationId { get; set; } = 0;
        public string MedicineName { get; set; }
        public string Doss { get; set; }
        public string Duration { get; set; }
        public DateTime Date { get; set; } = System.DateTime.Now;
        public string Eye { get; set; }
    }

}
