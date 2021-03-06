﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class PastMedicalHistory
    {
        [Key]
        public int PastMedicalHistoryId { get; set; }
        public int TreatmentId { get; set; }
        public string MedicalHistory { get; set; }
        public string Eye { get; set; }
    }
}