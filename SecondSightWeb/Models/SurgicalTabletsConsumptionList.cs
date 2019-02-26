using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{

    public class SurgicalTabletsConsumptionList
    {
        [Key]
        public int SurgicalTabletId { get; set; }

        public int TabletId { get; set; }

        public int OperationId { get; set; }

        public string BatchNumber { get; set; }

        public int Qty { get; set; }

    }
}