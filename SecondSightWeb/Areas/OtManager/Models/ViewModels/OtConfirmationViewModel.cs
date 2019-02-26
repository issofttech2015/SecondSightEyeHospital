using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.OtManager.Models.ViewModels
{
    public class OtConfirmationViewModel
    {
        [DisplayName("Reffered Doctor")]
        public string ReffredbyDoctorsName { get; set; }
        [DisplayName("Patient Name")]
        public string PatientName { get; set; }
        [Key]
        public int OperationSuggessitionId { get; set; }
        public string Eye { get; set; }
        [DisplayName("Suggested Doctor")]
        public string SuggestedDoctor { get; set; }
        public string Operation { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Date")]
        public DateTime OperationTime { get; set; }
        public string SurgicalProcedure { get; set; }
    }
}