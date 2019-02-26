using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class DischargeDetails
    {
        [Key]
        public int DischargeDetailsId { get; set; }
        public int OperationId { get; set; }
        public DateTime DischargeDate { get; set; }
        public string Diagonosis { get; set; }
        public DateTime NextVisitDate { get; set; }
        public TimeSpan NextVisitTime { get; set; }
        public int DischargeCertificateType { get; set; }
        public string AdditionalComments { get; set; }
    }
}