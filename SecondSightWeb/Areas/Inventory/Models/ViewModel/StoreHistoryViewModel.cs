using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.Inventory.Models.ViewModel
{
    public class StoreHistoryViewModel
    {
        [Key]
        //Category Table
        public int CategoryId { get; set; }
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }//CategoryMaster
        [DisplayName("Item Name")]
        public string ItemName { get; set; }
        [DisplayName("Item Description")]
        public string ItemDescription { get; set; }
        //StoreHistory Table
        [DisplayName("Supplier Name")]
        public string SupplierName { get; set; }
        [DisplayName("NewRate")]
        public decimal? NewRate { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayName("Manufacturing Date")]
        public DateTime ManufacturingDate { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayName("Expery Date")]
        public DateTime ExperyDate { get; set; }
        public string Location { get; set; }
        [DisplayName("Batch Number")]
        public string BatchNumber { get; set; }
    }
}