using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class PastOcularHistory
    {
        [Key]
        public int PastOcularHistoryId { get; set; }
        public int TreatmentId { get; set; }
        public string OcularHistory { get; set; }
        public string Eye { get; set; }
    }
}