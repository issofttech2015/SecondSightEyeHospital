using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class SuggestedTests
    {
        [Key]
        public int SuggestedTestId { get; set; }
        public int? TreatmentId { get; set; }
        public int? TestId { get; set; }
    }
}