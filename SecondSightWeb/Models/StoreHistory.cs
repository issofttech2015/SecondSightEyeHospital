using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class StoreHistory
    {
        [Key]
        public int StoreHistoryId { get; set; }

        public int StoreId { get; set; }

        public string RequisitionId { get; set; } = "N/A";

        public int SupplierId { get; set; }//
        [DisplayName("Store Entry Date")]
        [Required(ErrorMessage = "Enter Store Entry Date")]
        public DateTime SIdate { get; set; }
        [DisplayName("Quantity")]
        [Required(ErrorMessage = "Enter New Quantity")]
        public int? NewQty { get; set; }

        public int? OldQty { get; set; }
        [DisplayName("Rate")]
        [Required(ErrorMessage = "Enter Rate")]
        public decimal? NewRate { get; set; }//

        public decimal? OldRate { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayName("Manufacturing Date")]
        [Required(ErrorMessage = "Enter Manufacturing Date")]
        public DateTime ManufacturingDate { get; set; }//
        [DataType(DataType.DateTime)]
        [DisplayName("Expery Date")]
        [Required(ErrorMessage = "Enter Expery Date")]
        public DateTime ExperyDate { get; set; }//
        [Required(ErrorMessage = "Enter Location")]
        public string Location { get; set; }//
        [DisplayName("Batch Number")]
        [Required(ErrorMessage = "Enter Batch Number")]
        public string BatchNumber { get; set; }//

    }

}
