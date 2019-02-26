using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.Inventory.Models.ViewModel
{
    public class ItemEntryListViewModel
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
        [DisplayName("Quantity")]
        [Required]
        //[Range(0,Store]
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public bool IsDelivered { get; set; }

    }
}