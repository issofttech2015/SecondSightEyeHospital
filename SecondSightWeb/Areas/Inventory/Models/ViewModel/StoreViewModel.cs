using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.Inventory.Models.ViewModel
{
    public class StoreViewModel
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
        //Store
        [DisplayName("Store Present Quantity")]
        public int Qty { get; set; }
        [DisplayName("Total Quantity")]
        public int QtyTotal { get; set; }
        [DisplayName("Store Entry Date")]
        public DateTime? SIdate { get; set; }
        [DisplayName("Ready for Release Quantity")]
        public int QtyBuffer { get; set; }
    }
}