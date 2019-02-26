using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class StoreHistory
    {
        public int StoreHistoryId { get; set; }

        public int StoreId { get; set; }

        public string RequisitionId { get; set; }

        public string Supplier { get; set; }

        public DateTime SIdate { get; set; }

        public int? NewQty { get; set; }

        public int? OldQty { get; set; }

        public decimal? NewRate { get; set; }

        public decimal? OldRate { get; set; }

        public DateTime ManufacturingDate { get; set; }

        public DateTime ExperyDate { get; set; }

        public string Location { get; set; }

        public string ItemDetails { get; set; }

    }

}
