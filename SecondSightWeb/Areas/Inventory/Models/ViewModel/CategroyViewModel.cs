using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.Inventory.Models.ViewModel
{
    public class CategroyViewModel
    {
        [Key]
        public int CategoryId { get; set; }
        [DisplayName("Item Name")]
        public string ItemName { get; set; }
        [DisplayName("Item Description")]
        public string ItemDescription { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
        [DisplayName("Asset Tag")]
        public string AssetTag { get; set; }
        [DisplayName("ReOrder Level")]
        public int? ReOrderLevel { get; set; }
        [DisplayName("Quantity")]
        public int Qty { get; set; }
        [DisplayName("Saleing Price")]
        public decimal? SaleingPrice { get; set; }
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
    }
}