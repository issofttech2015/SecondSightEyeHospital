using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class Store
    {
        [Key]
        public int Storeid { get; set; }
        [DisplayName("Requisition Id")]
        [Required(ErrorMessage = "Enter Requisition Id")]
        public string RequisitionId { get; set; }
        [DisplayName("Category Id")]
        [Required(ErrorMessage = "Enter Category Id")]
        public int CategoryId { get; set; }
        [DisplayName("Quantity")]
        [Required(ErrorMessage = "Enter Quantity")]
        public int Qty { get; set; }
        [DisplayName("Total Quantity")]
        [Required(ErrorMessage = "Enter Total Quantity")]
        public int QtyTotal { get; set; }
        [DisplayName("Store Entry Date")]
        [Required(ErrorMessage = "Enter Store Entry Date")]
        public DateTime? SIdate { get; set; }
        [DisplayName("Store Delivery Date")]
        [Required(ErrorMessage = "Enter Store Delivery Date")]
        public DateTime? SOdate { get; set; }
        [DisplayName("Store Status")]
        [Required(ErrorMessage = "Enter Store Status")]
        public string SStatus { get; set; }
        [DisplayName("Ready for Release Quantity")]
        [Required(ErrorMessage = "Enter Ready for Release Quantity")]
        public int QtyBuffer { get; set; }

    }

}
