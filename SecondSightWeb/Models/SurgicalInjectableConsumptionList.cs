using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class SurgicalInjectableConsumptionList
    {
        [Key]
        public int SurgicalInjectableId { get; set; }

        public int InjectableId { get; set; }

        public int OperationId { get; set; }

        public string BatchNumber { get; set; }

        public int Qty { get; set; }

    }
}