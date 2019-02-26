using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class OperationSuggestion
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Select Patient Id")]
        public int PatientId { get; set; }
        [Required(ErrorMessage = "Select Appointment Id")]
        public int AppointmentId { get; set; }
        [Required(ErrorMessage ="Please select Operation Eye")]
        public string Eye { get; set; }
        [Required(ErrorMessage = "Select Operation Categroy")]
        public int OperationCategory { get; set; }
        public DateTime OperationDate { get; set; }
        public string DoctorsName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Select Reffered by")]
        public int RefferedBy { get; set; }
        public DateTime? RefferTime { get; set; } = System.DateTime.Now;
        public bool? IsDeleted { get; set; } = false;
        public bool? IsConvertedToOT { get; set; } = false;
        public bool IsCancelled { get; set; } = false;
    }
}