using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{

    public class SurgicalMiscellaneousConsumptionList
    {
        [Key]
        public int SurgicalMiscellaneousId { get; set; }

        public int MiscellaneousId { get; set; }

        public int OperationId { get; set; }

        public string BatchNumber { get; set; }

        public int Qty { get; set; }

    }
}