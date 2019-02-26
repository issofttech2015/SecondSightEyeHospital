using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class ForgotPasswordDetails
    {
        [Key]
        public int ForgotPasswordId { get; set; }

        public int EmployeeId { get; set; }

        public int ResolvedBy { get; set; } = 0;

        public DateTime? RequestTime { get; set; } = System.DateTime.Now;

        public bool IsResolved { get; set; } = false;

        public DateTime? ResolvedTime { get; set; } = System.DateTime.Now;

        public string RequestIP { get; set; } = "";

        public string ResolveIP { get; set; } = "";

    }
}