using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.Inventory.Models.EditModel
{
    public class ItemEntryListEditModel
    {
        [Key]
        public int PODId { get; set; }
        public int POID { get; set; }

        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
        [DisplayName("Item Name")]
        public string ItemName { get; set; }
        [DisplayName("Item Description")]
        public string ItemDescription { get; set; }
        //public int DeliveredQty { get; set; }
        [DisplayName("Quantity")]
        [Required(ErrorMessage = "Enter Quantity")]
        //[Range(0,Store]
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public bool IsDelivered { get; set; }
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