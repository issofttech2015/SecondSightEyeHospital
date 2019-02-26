using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class BillSummery
    {
        public int BillSummeryId { get; set; }

        public int? BillId { get; set; }

        public int? OperationId { get; set; }

        public int? PatientId { get; set; }

        public int? BedDays { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal? DayCareCharge { get; set; }

        public decimal? BedCharge { get; set; }

        public decimal? OTCharges { get; set; }

        public decimal? OTEquimentCharges { get; set; }

        public decimal? MaterialCharges { get; set; }

        public decimal? Anasthasea { get; set; }

        public decimal? MachineAnathsea { get; set; }

        public decimal? DiametryMachine { get; set; }

        public decimal? EndolSer { get; set; }

        public decimal? CurdiacOperation { get; set; }

        public decimal? Medicines { get; set; }

        public decimal? Doctor { get; set; }

        public decimal? Diet { get; set; }

        public decimal? Aya { get; set; }

        public decimal? IOL { get; set; }

    }

}
