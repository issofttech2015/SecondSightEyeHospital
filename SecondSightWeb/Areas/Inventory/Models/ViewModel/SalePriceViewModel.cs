using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.Inventory.Models.ViewModel
{
    public class SalePriceViewModel
    {
        [Key]
        public int CategoryId { get; set; }
        [DisplayName("Item Name")]
        public string ItemName { get; set; }
        [DisplayName("Item Description")]
        public string ItemDescription { get; set; }
        [DisplayName("Saleing Price")]
        public decimal? SaleingPrice { get; set; }
        [DisplayName("Added On")]
        public DateTime? AddedOn { get; set; } 
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
    }
}