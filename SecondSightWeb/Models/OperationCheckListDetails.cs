using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class OperationCheckListDetails
    {
        [Key]
        public int DetailsId { get; set; }
        public int? OpeationSuggessitionId { get; set; } = 0;
        public int? OtCheckListId { get; set; }
        public int TreatmentId { get; set; } = 0;
    }
}