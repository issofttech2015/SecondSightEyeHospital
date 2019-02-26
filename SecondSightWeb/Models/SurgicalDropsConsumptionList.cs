using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{

    public class SurgicalDropsConsumptionList
    {
        [Key]
        public int SurgicalDropId { get; set; }

        public int DropId { get; set; }

        public int OperationId { get; set; }

        public string BatchNumber { get; set; }

        public int Qty { get; set; }

    }
}