﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class MainComplaints
    {
        [Key]
        public int MainComplaintsId { get; set; }
        public int TreatmentId { get; set; }
        public string Complaints { get; set; }
        public string Eye { get; set; }
    }


}