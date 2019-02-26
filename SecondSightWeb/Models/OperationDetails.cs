using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class OperarionDetails
    {
        [Key]
        public int OperationId { get; set; }
        public int OperationSuggestionId { get; set; }
        public int PatientId { get; set; }
        public DateTime OperationDate { get; set; }
        public TimeSpan Time { get; set; }
        public int SurgicalProcedure { get; set; }
        public int Duration { get; set; }
        public string OperationEye { get; set; }
        public bool IsOperated { get; set; } = false;
        public int DoctorId { get; set; }
        public int DropId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime? OTStartTime { get; set; }
        public DateTime? OTEndTime { get; set; }
        public bool IsGeneratedSurgicalConsumptionList { get; set; } = false;
    }

}
