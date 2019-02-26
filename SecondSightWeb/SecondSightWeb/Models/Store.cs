using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class Store
    {
        public int Storeid { get; set; }

        public string RequisitionId { get; set; }

        public int CategoryId { get; set; }

        public int Qty { get; set; }

        public int QtyTotal { get; set; }

        public DateTime? SIdate { get; set; }

        public DateTime? SOdate { get; set; }

        public string SStatus { get; set; }

        public int QtyBuffer { get; set; }

    }

}
