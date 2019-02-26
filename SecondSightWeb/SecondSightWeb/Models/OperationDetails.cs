using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class OperarionDetails
    {
        public int OperationId { get; set; }

        public string OperationCode { get; set; }

        public int PatientId { get; set; }

        public DateTime? OperationDate { get; set; }

        public string Time { get; set; }

        public string SurgicalProcedure { get; set; }

        public decimal? EstimatedCost { get; set; }

        public int? Duration { get; set; }

        public string OperationEye { get; set; }

        public decimal? AdvanceReceived { get; set; }
        public bool IsOperated { get; set; } = false;
        public int DoctorId { get; set; }
        public decimal ActualCost { get; set; } = 0;

    }

}
