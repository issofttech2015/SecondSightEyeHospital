using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class Item
    {
        public int ItemId { get; set; }

        public decimal Qty { get; set; }

        public string Status { get; set; }

        public int PatientId { get; set; }

        public DateTime ItemDate { get; set; }

        public int CategoryId { get; set; }

        public decimal? ApprovedQty { get; set; }

    }

}
