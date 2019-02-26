using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class BillSummery
    {
        [Key]
        public int BillSummeryId { get; set; }
        public int? BillId { get; set; }
        public int? OperationId { get; set; }
        public int? PatientId { get; set; }
        public int? BedDays { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

}
